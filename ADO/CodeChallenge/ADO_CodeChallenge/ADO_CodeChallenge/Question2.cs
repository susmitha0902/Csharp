using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ADO_CodeChallenge
{
    class Question2
    {
        public static void Main()
        {
            string conString = "Data Source = ICS-LT-1G83D64\\SQLEXPRESS01;initial catalog = CodeChallenge;user = sa;password = Susmitha@9870;";
            Console.Write("Enter EmpId to update salary: ");
            int empid = Convert.ToInt32(Console.ReadLine());


            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("UpdateSalary", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpId", empid);

                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    Console.WriteLine("Updated Employee Details:");
                    Console.WriteLine($"EmpId: {r["EmpId"]}");
                    Console.WriteLine($"Name: {r["Name"]}");
                    Console.WriteLine($"Salary: {r["Salary"]}");
                    Console.WriteLine($"Gender: {r["Gender"]}");
                }
                else
                {
                    Console.WriteLine("No match found");
                }

                Console.Read();
            }
        }
    }
}


