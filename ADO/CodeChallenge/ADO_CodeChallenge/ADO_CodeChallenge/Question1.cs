using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ADO_CodeChallenge
{
    class Question1
    {
        static void Main(string[] args)
        {

            string conString = "Data Source = ICS-LT-1G83D64\\SQLEXPRESS01;initial catalog = CodeChallenge;user = sa;password = Susmitha@9870;";
            Console.WriteLine("Enter employee details you want to insert");
            Console.WriteLine("Enter employee name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter employee salary: ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter employee gender: ");
            string gender = Console.ReadLine();

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("EmployeeDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Salary", salary); 
                cmd.Parameters.AddWithValue("@Gender", gender);

                SqlParameter id = new SqlParameter("@EmpId", SqlDbType.Int);
                id.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(id);

                SqlParameter netSal = new SqlParameter("@NetSalary", SqlDbType.Decimal);
                netSal.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(netSal);

                con.Open();
                cmd.ExecuteNonQuery();

                int gen_id = (int)cmd.Parameters["@EmpId"].Value;
                decimal gen_sal = (decimal)cmd.Parameters["@NetSalary"].Value;


                Console.WriteLine("**The generated values are below**");
                Console.WriteLine($"Generated EmpId: {gen_id}");
                Console.WriteLine($"Net Salary: {gen_sal}");
                Console.Read();
            }
        }
    }
}


