using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace ElectricityBillingSystem
{
    public partial class Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            //connection string
            string connString = ConfigurationManager.ConnectionStrings["EBConnectionString"].ConnectionString;
            using(SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "select count(*) from AdminUser where username=@user and password=@pass";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);

                int count = (int)cmd.ExecuteScalar();

                if (count>0)
                {
                    Session["Admin"] = username;
                    Response.Redirect("Admin.aspx"); //Next page after login
                }
                else
                {
                    lblMessage.Text = "Invalid Username or password!!";
                }

            }
        }
    }
}