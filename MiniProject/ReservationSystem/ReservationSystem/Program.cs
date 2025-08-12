using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ReservationSystem.Services;

namespace ReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Services.AuthServices auth = new Services.AuthServices();
            int customerId = -1;

            while (true)
            {
                Console.WriteLine("\n--- Railway Reservation System ---");
                Console.WriteLine("1. Admin Login");
                Console.WriteLine("2. Customer Login");
                Console.WriteLine("3. Customer Registration");
                Console.WriteLine("4. Exit");
                Console.Write("Choose option: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        if (auth.AdminLogin())
                        {
                            Console.WriteLine("Admin logged in successfully.");
                            AdminService.ShowAdminMenu();
                        }
                        else
                        {
                            Console.WriteLine("Invalid credentials.");
                        }
                        break;

                    case "2":
                        customerId = auth.LoginCustomer();
                        if (customerId != -1)
                        {
                            CustomerMenu(customerId);
                        }
                        break;

                    case "3":
                        auth.RegisterCustomer();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
        static void CustomerMenu(int customerId)
        {
            var bookingService = new BookingServices();
            while(true)

            {
                Console.WriteLine("\n ----Customer Menu----");
                Console.WriteLine("1.Search/ View Trains");
                Console.WriteLine("2. Book Ticket");
                Console.WriteLine("3.Cancel Ticket");
                Console.WriteLine("4.View My Bookings");
                Console.WriteLine("5.LogOut");
                Console.WriteLine("Choose the option: ");
                string option = Console.ReadLine();

                switch(option)
                {
                    case "1": 
                        Console.WriteLine("Enter Source (leave blank to view destination specific trains): ");
                        string src = Console.ReadLine();
                        Console.WriteLine("Enter Destination (leave blank to view source specific trains): ");
                        string dst = Console.ReadLine();

                        var trains = bookingService.SearchTrains(src, dst);
                        bookingService.DisplayTrains(trains);

                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;  
                    case "2":
                        bookingService.BookTicket(customerId);
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                    case "3":
                        CancellationServices.CancelTicket(customerId);
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                    case "4":
                        BookingServices.ViewMyBookings(customerId);
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;

                }

            }            
        }
    }
}
