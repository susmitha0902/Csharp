using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ReservationSystem.Services
{
    public class AdminService
    {
        public static List<Reservation> GetAllReservations()
        {
            var reservations = new List<Reservation>();
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Reservation";
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reservations.Add(new Reservation
                        {
                            BookingId = Convert.ToInt32(reader["BookingID"]),
                            CustomerId = Convert.ToInt32(reader["CustomerID"]),
                            TrainID = Convert.ToInt32(reader["TrainID"]),
                            PassengerName = reader["PassengerName"].ToString(),
                            Class = reader["Class"].ToString(),
                            DateOfTravel = Convert.ToDateTime(reader["DateOfTravel"]),
                            BerthAllotment = reader["BerthAllotment"].ToString(),
                            WaitListStatus = Convert.ToBoolean(reader["WaitListStatus"]),
                            TotalCost = Convert.ToDecimal(reader["TotalCost"]),
                            DateOfBooking = Convert.ToDateTime(reader["DateOfBooking"]),
                            IsActive = Convert.ToBoolean(reader["IsActive"])
                        });
                    }
                }
            }
            return reservations;
        }
        public static void AddTrain(Train train)
        {
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO Train (TrainNo, TrainName, Source, Destination, Class, TotalSeats, AvailableSeats, CostPerSeat)
                         VALUES (@TrainNo, @TrainName, @Source, @Destination, @Class, @TotalSeats, @AvailableSeats, @CostPerSeat)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TrainNo", train.TrainNo);
                    cmd.Parameters.AddWithValue("@TrainName", train.TrainName);
                    cmd.Parameters.AddWithValue("@Source", train.Source);
                    cmd.Parameters.AddWithValue("@Destination", train.Destination);
                    cmd.Parameters.AddWithValue("@Class", train.Class);
                    cmd.Parameters.AddWithValue("@TotalSeats", train.TotalSeats);
                    cmd.Parameters.AddWithValue("@AvailableSeats", train.AvailableSeats);
                    cmd.Parameters.AddWithValue("@CostPerSeat", train.CostPerSeat);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static List<Cancellation> GetAllCancellations()
        {
            var cancellations = new List<Cancellation>();
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Cancellation";
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cancellations.Add(new Cancellation
                        {
                            CancelID = Convert.ToInt32(reader["cancelid"]),
                            BookingID = Convert.ToInt32(reader["BookingID"]),
                            TicketCancelled = Convert.ToBoolean(reader["TicketCancelled"]),
                            RefundAmount = Convert.ToDecimal(reader["RefundAmount"]),
                            DateOfCancellation = Convert.ToDateTime(reader["DateOfCancellation"])
                        });
                    }
                }
            }
            return cancellations;
        }


        public static List<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>();
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Customer";
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customer
                        {
                            Customer_ID = Convert.ToInt32(reader["Customer_ID"]),
                            Customer_Name = reader["Customer_Name"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            MailID = reader["MailID"].ToString(),
                            Password = reader["Password"].ToString()
                        });
                    }
                }
            }
            return customers;
        }


        public static void UpdateTrain(Train train)
        {
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE Train SET TrainNo=@TrainNo, TrainName=@TrainName, Source=@Source, Destination=@Destination,
                         Class=@Class, TotalSeats=@TotalSeats, AvailableSeats=@AvailableSeats, CostPerSeat=@CostPerSeat
                         WHERE TrainID=@TrainID";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TrainID", train.TrainID);
                    cmd.Parameters.AddWithValue("@TrainNo", train.TrainNo);
                    cmd.Parameters.AddWithValue("@TrainName", train.TrainName);
                    cmd.Parameters.AddWithValue("@Source", train.Source);
                    cmd.Parameters.AddWithValue("@Destination", train.Destination);
                    cmd.Parameters.AddWithValue("@Class", train.Class);
                    cmd.Parameters.AddWithValue("@TotalSeats", train.TotalSeats);
                    cmd.Parameters.AddWithValue("@AvailableSeats", train.AvailableSeats);
                    cmd.Parameters.AddWithValue("@CostPerSeat", train.CostPerSeat);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void SoftDeleteTrain(int trainId)
        {
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Train SET IsDeleted = 1 WHERE TrainID = @TrainID";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TrainID", trainId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void ShowAdminMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- Admin Menu ---");
                Console.WriteLine("1. View All Customers");
                Console.WriteLine("2. View All Reservations");
                Console.WriteLine("3. View All Cancellations");
                Console.WriteLine("4. Add New Train");
                Console.WriteLine("5. Update Train");
                Console.WriteLine("6. Soft Delete Train");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var customers = GetAllCustomers();
                        foreach (var customer in customers)
                        {
                            Console.WriteLine($"{customer.Customer_ID} - {customer.Customer_Name} - {customer.MailID}");
                        }
                        break;

                    case "2":
                        var reservations = GetAllReservations();
                        foreach (var res in reservations)
                        {
                            Console.WriteLine($"{res.BookingId} - {res.PassengerName} - {res.DateOfTravel.ToShortDateString()}");
                        }
                        break;

                    case "3":
                        var cancellations = GetAllCancellations();
                        foreach (var cancel in cancellations)
                        {
                            Console.WriteLine($"{cancel.CancelID} - BookingID: {cancel.BookingID} - Refund: {cancel.RefundAmount}");
                        }
                        break;

                    case "4":
                        Train newTrain = new Train();
                        Console.Write("Train No: ");
                        newTrain.TrainNo = Console.ReadLine();
                        Console.Write("Train Name: ");
                        newTrain.TrainName = Console.ReadLine();
                        Console.Write("Source: ");
                        newTrain.Source = Console.ReadLine();
                        Console.Write("Destination: ");
                        newTrain.Destination = Console.ReadLine();
                        Console.Write("Class: ");
                        newTrain.Class = Console.ReadLine();
                        Console.Write("Total Seats: ");
                        newTrain.TotalSeats = int.Parse(Console.ReadLine());
                        Console.Write("Available Seats: ");
                        newTrain.AvailableSeats = int.Parse(Console.ReadLine());
                        Console.Write("Cost Per Seat: ");
                        newTrain.CostPerSeat = decimal.Parse(Console.ReadLine());

                        AddTrain(newTrain);
                        Console.WriteLine("Train added successfully.");
                        break;

                    case "5":
                        Train updateTrain = new Train();
                        Console.Write("Train ID to update: ");
                        updateTrain.TrainID = int.Parse(Console.ReadLine());
                        Console.Write("New Train No: ");
                        updateTrain.TrainNo = Console.ReadLine();
                        Console.Write("New Train Name: ");
                        updateTrain.TrainName = Console.ReadLine();
                        Console.Write("New Source: ");
                        updateTrain.Source = Console.ReadLine();
                        Console.Write("New Destination: ");
                        updateTrain.Destination = Console.ReadLine();
                        Console.Write("New Class: ");
                        updateTrain.Class = Console.ReadLine();
                        Console.Write("New Total Seats: ");
                        updateTrain.TotalSeats = int.Parse(Console.ReadLine());
                        Console.Write("New Available Seats: ");
                        updateTrain.AvailableSeats = int.Parse(Console.ReadLine());
                        Console.Write("New Cost Per Seat: ");
                        updateTrain.CostPerSeat = decimal.Parse(Console.ReadLine());

                        UpdateTrain(updateTrain);
                        Console.WriteLine("Train updated successfully.");
                        break;

                    case "6":
                        Console.Write("Enter Train ID to soft delete: ");
                        int trainId = int.Parse(Console.ReadLine());
                        SoftDeleteTrain(trainId);
                        Console.WriteLine("Train marked as deleted.");
                        break;

                    case "7":
                        exit = true;
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

    }
}
