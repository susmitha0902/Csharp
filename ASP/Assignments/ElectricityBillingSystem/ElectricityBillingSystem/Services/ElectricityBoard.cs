using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace ElectricityBillingSystem.Services
{
    public class ElectricityBoard
    {
        private DBHandler dbHandler;

        public ElectricityBoard()
        {
            dbHandler = new DBHandler();
        }
        //we are calculating and setting the bill amount for a given electricity bill object here 
        public void CalculateBill(ElectricityBill ebill)
        {
            int units = ebill.UnitsConsumed;

            if (units <= 100)
                ebill.GetType().GetProperty("BillAmount").SetValue(ebill, 0.0);
            else if (units <= 300)
                ebill.GetType().GetProperty("BillAmount").SetValue(ebill, (units - 100) * 1.5);
            else if (units <= 600)
                ebill.GetType().GetProperty("BillAmount").SetValue(ebill, (200 * 1.5) + (units - 300) * 3.5);
            else if (units <= 1000)
                ebill.GetType().GetProperty("BillAmount").SetValue(ebill, (200 * 1.5) + (300 * 3.5) + (units - 600) * 5.5);
            else
                ebill.GetType().GetProperty("BillAmount").SetValue(ebill, (200 * 1.5) + (300 * 3.5) + (400 * 5.5) + (units - 1000) * 7.5);
        }

        //insert the bill details into the database
        public string AddBill(ElectricityBill ebill)
        {
            using (SqlConnection con = dbHandler.GetConnection())
            {
                con.Open();

                DateTime today = DateTime.Now;
                string checkQuery = "select created_at from ElectricityBill where consumer_number = @num and consumer_name = @name and units_consumed=@units and month(created_at) = @month and year(created_at)=@year";
                using(SqlCommand checkcmd = new SqlCommand(checkQuery, con))
                {
                    checkcmd.Parameters.AddWithValue("@num", ebill.ConsumerNumber);
                    checkcmd.Parameters.AddWithValue("@name", ebill.ConsumerName);
                    checkcmd.Parameters.AddWithValue("@units", ebill.UnitsConsumed);
                    checkcmd.Parameters.AddWithValue("@month", today.Month);
                    checkcmd.Parameters.AddWithValue("@year", today.Year);

                    object result = checkcmd.ExecuteScalar();
                    if(result!=null)
                    {
                        DateTime existingDate = Convert.ToDateTime(result);
                        return $"This bill already exists for this month, entered on {existingDate}";  
                    }
                }
                ebill.ConsumerNumber = ebill.ConsumerNumber.ToUpper();
                string query = "insert into ElectricityBill(consumer_number,consumer_name,units_consumed,bill_amount,created_at) values (@num,@name,@units,@amount,GETDATE())";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@num", ebill.ConsumerNumber);
                    cmd.Parameters.AddWithValue("@name", ebill.ConsumerName);
                    cmd.Parameters.AddWithValue("@units", ebill.UnitsConsumed);
                    cmd.Parameters.AddWithValue("@amount", ebill.BillAmount);

                    cmd.ExecuteNonQuery();
                }
                return "Success";
            }
        }

        public List<ElectricityBill> Generate_N_BillDetails(int num)
        {
            List<ElectricityBill> bills = new List<ElectricityBill>();
            using(SqlConnection conn = dbHandler.GetConnection())
            {
                string query = @"select top (@N) consumer_number,consumer_name,units_consumed,bill_amount from ElectricityBill order by created_at DESC";
                using (SqlCommand cmd = new SqlCommand(query,conn))
                {
                    cmd.Parameters.AddWithValue("@N", num);
                    conn.Open();
                    using(SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while(rd.Read())
                        {
                            ElectricityBill ebill = new ElectricityBill
                            {
                                ConsumerName = rd["consumer_name"].ToString(),
                                ConsumerNumber = rd["consumer_number"].ToString(),
                                UnitsConsumed = Convert.ToInt32(rd["units_consumed"]),
                            };

                            //set bill amount
                            ebill.GetType().GetProperty("BillAmount").SetValue(ebill, Convert.ToDouble(rd["bill_amount"]));
                            bills.Add(ebill);
                        }
                    }
                }
            }
            return bills;
        }
    }
}