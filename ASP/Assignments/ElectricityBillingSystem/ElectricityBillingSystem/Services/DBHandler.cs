using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace ElectricityBillingSystem.Services
{
    public class DBHandler
    {
        public SqlConnection GetConnection()
        {
            string connString = ConfigurationManager.ConnectionStrings["EBConnectionString"].ConnectionString;

            return new SqlConnection(connString);
        }
    }
}