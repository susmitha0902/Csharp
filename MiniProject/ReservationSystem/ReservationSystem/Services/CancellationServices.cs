using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ReservationSystem.Models;
using ReservationSystem.Services;

namespace ReservationSystem.Services
{
    public class CancellationServices
    {
        public static void CancelTicket(int customerId)
        {
            Console.WriteLine("---Cancel Ticket---");
            List<Reservation> activeReservations = GetActiveReservations(customerId);
            if(activeReservations.Count==0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No active reservations found.");
                Console.ResetColor();
                return;
            }
            Console.WriteLine(String.Format("{0,5} {1,-15} {2,-15} {3,-12} {4,-10} {5,-8}", "ID", "Train No", "Passenger", "Travel Date", "Class", "WaitListStatus"));

            foreach(var res in activeReservations)
            {
                string StatusText = res.WaitListStatus ? "WaitListed" : "Confirmed";
                Console.WriteLine(String.Format("{0,-5} {1,-15} {2,-15} {3,-12:d} {4,-10} {5,-8}", res.BookingId, res.TrainNo, res.PassengerName, res.DateOfTravel, res.Class, StatusText));
            }
            //reservation to cancel
            Console.WriteLine("Enter reservation ID to cancel: ");
            if(!int.TryParse(Console.ReadLine(),out int reservationID))
            {
                Console.WriteLine("Invalid Input.");
                return;
            }
            //cancelling
            CancelReservations(reservationID);
            InsertCancellationRecord(reservationID);
            //Free seat and promote waitlist if needed
            PromoteWaitlistedPassenger(reservationID);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Reservation Cancelled Successfully");
            Console.ResetColor();
        }

        private static void InsertCancellationRecord(int reservationID)
        {
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();

                // Step 1: Get booking date and total cost for this reservation
                string getBookingDetails = "SELECT DateOfBooking, TotalCost FROM reservation WHERE BookingID = @BookingID";

                DateTime bookingDate = DateTime.MinValue;
                decimal totalCost = 0m;

                using (var cmd = new SqlCommand(getBookingDetails, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingID", reservationID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bookingDate = reader.GetDateTime(0);
                            totalCost = reader.GetDecimal(1);
                        }
                        else
                        {
                       
                            return;
                        }
                    }
                }

                // Step 2: Calculate refund
                DateTime cancellationDate = DateTime.Now.Date;
                int daysDifference = (cancellationDate - bookingDate.Date).Days;

                decimal refundAmount = 0m;
                if (daysDifference <= 30 && daysDifference >= 0)
                {
                    refundAmount = totalCost * 0.5m;  
                }

                // Step 3: Insert cancellation record with refund info
                string sql = @"INSERT INTO cancellation (BookingID, TicketCancelled, RefundAmount, DateOfCancellation)
                       VALUES (@BookingID, 1, @RefundAmount, @DateOfCancellation)";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingID", reservationID);
                    cmd.Parameters.AddWithValue("@RefundAmount", refundAmount);
                    cmd.Parameters.AddWithValue("@DateOfCancellation", cancellationDate);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private static List<Reservation> GetActiveReservations(int customerId)
        {
            var reservations = new List<Reservation>();
            using(var conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT r.BookingID, t.TrainNo, r.PassengerName, r.DateOfTravel, r.Class, r.WaitListStatus FROM reservation r JOIN train t ON r.TrainID = t.TrainID WHERE r.CustomerID = @custID AND r.IsActive = 1 ";
                using(var cmd = new SqlCommand(query,conn))
                {
                    cmd.Parameters.AddWithValue("@custID", customerId);
                    using(var reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            reservations.Add(new Reservation
                            {
                                BookingId = Convert.ToInt32(reader["BookingID"]),
                                TrainNo = reader["TrainNo"].ToString(),
                                PassengerName = reader["PassengerName"].ToString(),
                                DateOfTravel = Convert.ToDateTime(reader["DateOfTravel"]),
                                Class = reader["Class"].ToString(),
                                WaitListStatus = Convert.ToBoolean(reader["WaitListStatus"])
                            });

                        }
                    }

                }
            }
            return reservations;
        }

        private static void CancelReservations(int reservationID)
        {
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();

                // Step 1: Check if reservation is active and get TrainID
                int trainId = 0;
                bool isActive = false;

                string checkSql = "SELECT TrainID, IsActive FROM reservation WHERE BookingID = @reservationId";
                using (var cmd = new SqlCommand(checkSql, conn))
                {
                    cmd.Parameters.AddWithValue("@reservationId", reservationID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            trainId = reader.GetInt32(0);
                            isActive = reader.GetBoolean(1);
                        }
                        else
                        {
                            Console.WriteLine("Reservation not found.");
                            return;
                        }
                    }
                }

                // Step 2: Only cancel and increment seats if reservation is active
                if (isActive)
                {
                    // Mark reservation as inactive (soft delete)
                    string updateReservationSql = "UPDATE reservation SET IsActive = 0 WHERE BookingID = @reservationId";
                    using (var cmd = new SqlCommand(updateReservationSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@reservationId", reservationID);
                        cmd.ExecuteNonQuery();
                    }

                    // Increment available seats for the train IMMEDIATELY here
                    string updateTrainSql = "UPDATE train SET AvailableSeats = AvailableSeats + 1 WHERE TrainID = @trainId";
                    using (var cmd = new SqlCommand(updateTrainSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@trainId", trainId);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    Console.WriteLine("Reservation already cancelled.");
                }
            }
        }

        private static void PromoteWaitlistedPassenger(int cancelledReservationId)
        {
            BookingServices obj = new BookingServices();
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                int trainId = 0;
                string travelClass = "";
                DateTime travelDate = DateTime.MinValue;

                string getDetails = "select TrainID, Class, DateOfTravel FROM reservation WHERE BookingID = @ResID";
                using (var cmd = new SqlCommand(getDetails, conn))
                {
                    cmd.Parameters.AddWithValue("@ResID", cancelledReservationId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            trainId = reader.GetInt32(0);
                            travelClass = reader.GetString(1);
                            travelDate = reader.GetDateTime(2);
                        }
                    }
                }

                int waitlistId = 0;
                string findWaitlist = @"SELECT TOP 1 BookingID
                                        FROM reservation
                                        WHERE TrainID = @TrainID AND Class = @Class AND DateOfTravel = @Date
                                              AND WaitListStatus = 1 AND IsActive = 1
                                        ORDER BY BookingID ASC";

                using (var cmd = new SqlCommand(findWaitlist, conn))
                {
                    cmd.Parameters.AddWithValue("@TrainID", trainId);
                    cmd.Parameters.AddWithValue("@Class", travelClass);
                    cmd.Parameters.AddWithValue("@Date", travelDate);

                    var result = cmd.ExecuteScalar();
                    if (result != null)
                        waitlistId = Convert.ToInt32(result);
                }

                // Step 3: Promote if found, else free the seat
                if (waitlistId > 0)
                {
                    Console.WriteLine($"Promoting waitlisted reservation {waitlistId}");
                    string promote = @"UPDATE reservation
                                        SET WaitListStatus = 0, BerthAllotment = @Berth
                                        WHERE BookingID = @ResID";
                    using (var cmd = new SqlCommand(promote, conn))
                    {
                        cmd.Parameters.AddWithValue("@Berth", obj.AssignBerth(travelClass));
                        cmd.Parameters.AddWithValue("@ResID", waitlistId);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    Console.WriteLine($"No waiting list found");
                }
            }
        }
    }
}
