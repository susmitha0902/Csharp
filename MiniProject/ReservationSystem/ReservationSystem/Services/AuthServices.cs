using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ReservationSystem.Services
{
    public class AuthServices
    {
        public void RegisterCustomer()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your mobile number: ");
            string phone = Console.ReadLine();

            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            string password = "", confirmPassword = "";

            while (true)
            {
                Console.WriteLine("Create Password: ");
                password = Console.ReadLine();

                Console.WriteLine("Confirm Password: ");
                confirmPassword = Console.ReadLine();

                if (password == confirmPassword) break;
                else Console.WriteLine("Password Mismatch, please try again!");
            }

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();

                // Check for duplicate customer
                string checkQuery = @"SELECT COUNT(*) FROM Customer 
                              WHERE Phone = @phone OR MailID = @email";

                using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@phone", phone);
                    checkCmd.Parameters.AddWithValue("@email", email);

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        Console.WriteLine("\nA customer with this phone number or email already exists. Please try logging in or use different credentials.");
                        return;
                    }
                }

                // Insert new customer
                string query = "INSERT INTO Customer(Customer_Name, Phone, MailID, Password) VALUES(@name, @phone, @email, @password)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("\nRegistration Successful :)");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Registration Failed: {ex.Message}");
                    }
                }
            }
        }

        public int LoginCustomer()
        {
            Console.WriteLine("Enter Registered Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                string query = "select Customer_ID,Customer_Name from customer where MailID=@email and Password=@password";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);

                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    Console.WriteLine($"Welcome, {reader["Customer_Name"]}");
                    return Convert.ToInt32(reader["Customer_ID"]);
                }
                else
                {
                    Console.WriteLine("Invalid email or password");
                    return -1;
                }
            }
        }
        public bool AdminLogin()
        {
            Console.WriteLine("Enter Admin Username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();

            return username == "admin" && password == "admin123";

        }
    }
}
