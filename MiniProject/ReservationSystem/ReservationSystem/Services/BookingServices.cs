using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ReservationSystem.Models;

namespace ReservationSystem.Services
{
    public class BookingServices
    {
        public List<Train> SearchTrains(string Source, string Destination)
        {
            var results = new List<Train>();

            string srcPattern = string.IsNullOrWhiteSpace(Source) ? "%" : $"%{Source}%";
            string dstPattern = string.IsNullOrWhiteSpace(Destination) ? "%" : $"%{Destination}%";

            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "select TrainID,TrainNo,TrainName,Source,Destination,class,TotalSeats,AvailableSeats,CostPerSeat from train where Source like @src and destination like @dst order by TrainNo,Class";
                using (var cmd = new SqlCommand(query,conn))
                {
                    cmd.Parameters.AddWithValue("@src", srcPattern);
                    cmd.Parameters.AddWithValue("@dst", dstPattern);

                    using(var reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            results.Add(new Train
                            {
                                TrainID = Convert.ToInt32(reader["TrainID"]),
                                TrainNo = reader["TrainNo"].ToString(),
                                TrainName = reader["TrainName"].ToString(),
                                Source = reader["Source"].ToString(),
                                Destination = reader["Destination"].ToString(),
                                Class = reader["class"].ToString(),
                                TotalSeats = Convert.ToInt32(reader["TotalSeats"]),
                                AvailableSeats = Convert.ToInt32(reader["AvailableSeats"]),
                                CostPerSeat = Convert.ToDecimal(reader["CostPerSeat"])
                            }) ;  

                        }
                    }
                }
            }
            return results;
        }

        public void DisplayTrains(List<Train> trains)
        {
            if(trains==null||trains.Count==0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No trains found for that route");
                Console.ResetColor();
                return;
            }

            var groups = trains.GroupBy(t => new { t.TrainNo, t.TrainName, t.Source, t.Destination });
            foreach (var g in groups)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("======================================");
                Console.WriteLine($"{g.Key.TrainNo} - {g.Key.TrainName}   ({g.Key.Source} -> {g.Key.Destination})");
                Console.WriteLine("======================================");
                Console.ResetColor();

                Console.WriteLine(String.Format("{0,-8} {1,-8} {2,-12} {3,-10}", "class", "Available", "TotalSeats", "Cost"));

                foreach( var row in g)
                {
                    Console.ForegroundColor = row.AvailableSeats > 0 ? ConsoleColor.Green : ConsoleColor.Red;
                    Console.WriteLine(String.Format("{0,-8} {1,-8} {2,-12} {3,-10}", row.Class, row.AvailableSeats, row.TotalSeats, row.CostPerSeat));
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        public void BookTicket(int customerId)
        {

            Console.WriteLine("---Book Ticket---");
            Console.Write("Enter Source Station: ");
            string source = Console.ReadLine();
            Console.WriteLine("Enter Destination: ");
            string destination = Console.ReadLine();

            //search trains and display
            var trains = SearchTrains(source, destination);
            DisplayTrains(trains);
            if (trains.Count == 0) return;
            Console.WriteLine("Enter Train Number: ");
            string trainNo = Console.ReadLine();
            DateTime dateTravel;
            while (true)
            {
                Console.WriteLine("Enter Date of Travel: ");
                string dateInput = Console.ReadLine();

                if (DateTime.TryParse(dateInput, out dateTravel))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Date format");
                }
            }

            Console.WriteLine("Enter Class :(Sleeper/2AC/3AC): ");
            string travelClass = Console.ReadLine();
            Console.WriteLine("Enter number of seats you want to book");
            int seatCount = int.Parse(Console.ReadLine());

            List<string> passengerNames = new List<string>();
            for(int i=0;i<seatCount;i++)
            {
                Console.WriteLine($"Enter Passenger Name {i + 1}: ");
                passengerNames.Add(Console.ReadLine());
            }
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();

                //Check availability and cost
                string query = "select TrainID,AvailableSeats,TotalSeats,CostPerSeat from train where TrainNo=@TrainNo and class = @Class";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TrainNo", trainNo);
                    cmd.Parameters.AddWithValue("@Class", travelClass);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            Console.WriteLine("Train/Class not found");
                            return;
                        }

                        int trainId = reader.GetInt32(0);
                        int availableSeats = reader.GetInt32(1);
                        int totalSeats = reader.GetInt32(2);
                        decimal CostPerSeat = reader.GetDecimal(3);

                        if (availableSeats < seatCount)
                        {
                            Console.WriteLine("No seats available");
                            Console.WriteLine("Do you want to be waitlisted??(Enter y/n): ");
                            if (Console.ReadLine().ToLower() != "y")

                                return;

                            AddToWaitList(customerId, trainId, passengerNames, dateTravel, travelClass, CostPerSeat);
                            Console.WriteLine("You have been added to the Waiting List");
                            return;
                        }
                        //Seats Available - Confirm booking
                        SaveConfirmedReservation(customerId, trainId, passengerNames, dateTravel,travelClass, seatCount, CostPerSeat);
                        ReduceSeatCount(trainId, seatCount);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Ticket booked successfully for {seatCount} seat(s). Total Fare: {seatCount * CostPerSeat}");
                        Console.ResetColor();
                    }
                }
            }
        }

        private void SaveConfirmedReservation(int customerId,int trainId, List<string> passengerNames, DateTime dateTravel,string travelClass,int seatCount, decimal costPerSeat)
        {
            using(var conn = DBConnection.GetConnection())
            {
                conn.Open();
                foreach (var passengerName in passengerNames)
                {
                    string Berth = AssignBerth(travelClass);
                    string query = "insert into reservation (CustomerID,TrainID,PassengerName,DateOfTravel,Class,TotalCost,BerthAllotment,WaitListStatus,IsActive,DateOfBooking) values (@cid,@tid,@passengername,@DateofTravel,@Class,@TotalCost,@BerthAllotment,0,1,@DateOfBooking)";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@cid", customerId);
                        cmd.Parameters.AddWithValue("@tid", trainId);
                        cmd.Parameters.AddWithValue("@passengername", passengerName);
                        cmd.Parameters.AddWithValue("@DateofTravel", dateTravel);
                        cmd.Parameters.AddWithValue("@Class", travelClass);
                        cmd.Parameters.AddWithValue("@TotalCost",costPerSeat);
                        cmd.Parameters.AddWithValue("@BerthAllotment", Berth);
                        cmd.Parameters.AddWithValue("@DateOfBooking", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void AddToWaitList(int customerId, int trainId, List<string> passengerNames, DateTime dateTravel, string travelClass, decimal CostPerSeat)
        {
            using(var conn = DBConnection.GetConnection())
            {
                conn.Open();
                foreach (var passengerName in passengerNames)
                {
                    string sql = "insert into reservation (CustomerID, TrainID,PassengerName,DateOfTravel,Class,TotalCost,BerthAllotment,WaitListStatus,IsActive,DateOfBooking) values(@CustomerID,@TrainID,@PassengerName,@DateOfTravel,@Class,@TotalCost,NULL,1,1,@DateOfBooking)";

                    using (var cmd = new SqlCommand(sql,conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", customerId);
                        cmd.Parameters.AddWithValue("@TrainID", trainId);
                        cmd.Parameters.AddWithValue("@PassengerName", passengerName);
                        cmd.Parameters.AddWithValue("@DateOfTravel", dateTravel);
                        cmd.Parameters.AddWithValue("@Class", travelClass);
                        cmd.Parameters.AddWithValue("@TotalCost", CostPerSeat);
                        cmd.Parameters.AddWithValue("@DateOfBooking", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void ReduceSeatCount(int trainId, int seatsToReduce)
        {
            using(var conn = DBConnection.GetConnection())
            {
                conn.Open();
                string sql = "update train set AvailableSeats = AvailableSeats - @Count where TrainID = @TrainID ";
                using(var cmd= new SqlCommand(sql,conn))
                {
                    cmd.Parameters.AddWithValue("@Count", seatsToReduce);
                    cmd.Parameters.AddWithValue("@TrainID", trainId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public string AssignBerth(string travelClass)
        {
            string[] berths = { "Lower", "Middle", "Upper", "Side Lower", "Side Upper" };
            Random rnd = new Random();
            return berths[rnd.Next(berths.Length)];
        }

        public static void ViewMyBookings(int customerId)
        {
            var bookings = new List<Reservation>();
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();

                string sql = @"SELECT r.BookingID, t.TrainNo, r.PassengerName, r.DateOfTravel, r.Class, r.WaitListStatus
                       FROM reservation r
                       JOIN train t ON r.TrainID = t.TrainID
                       WHERE r.CustomerID = @custId AND r.IsActive = 1
                       ORDER BY r.DateOfTravel";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@custId", customerId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bookings.Add(new Reservation
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

            if (bookings.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No active bookings found.");
                Console.ResetColor();
                return;
            }

            Console.WriteLine(String.Format("{0,-5} {1,-15} {2,-20} {3,-12} {4,-10} {5,-10}", "ID", "Train No", "Passenger", "Travel Date", "Class", "Booking Status"));
            foreach (var b in bookings)
            {
                string status = b.WaitListStatus ? "Waitlisted" : "Confirmed";
                Console.WriteLine(String.Format("{0,-5} {1,-15} {2,-20} {3,-12:d} {4,-10} {5,-10}", b.BookingId, b.TrainNo, b.PassengerName, b.DateOfTravel, b.Class, status));
            }
        }

    }
}
