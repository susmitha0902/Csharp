using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ReservationSystem
{
    public static class DBConnection
    {
        private static string con = "Data Source = ICS-LT-1G83D64\\SQLEXPRESS01;initial catalog = ReservationSystems; user = sa;password = Susmitha@9870;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(con);
        }
    }
}
