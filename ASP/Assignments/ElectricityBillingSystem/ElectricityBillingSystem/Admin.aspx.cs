using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ElectricityBillingSystem.Services;

namespace ElectricityBillingSystem
{
    public partial class Admin : BasePage
    {

        private BillValidator validator = new BillValidator();
        private ElectricityBoard board = new ElectricityBoard();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnShow_Click(object sender,EventArgs e)
        {
            int n;
            if(!int.TryParse(txtN.Text,out n)||n<=0)
            {
                //validation
                Label.Text = "Please enter a valid number";
                return;
            }

            //get total bills
            int totalBillsInDb = 0;
            using(SqlConnection con = new DBHandler().GetConnection())
            {
                con.Open();
                string countQuery = "select count(*) from ElectricityBill";
                using (SqlCommand cmd = new SqlCommand(countQuery, con))
                {
                    totalBillsInDb = (int)cmd.ExecuteScalar();
                }
            }

            if(totalBillsInDb==0)
            {
                Label.Text = "No bills found in the database";
                gvBills.DataSource = null;
                gvBills.DataBind();
                return;
            }

            if(n>totalBillsInDb)
            {
                Label.Text = $"Only {totalBillsInDb} bills are present. Showing all available bills...";
                n = totalBillsInDb;
            }
            else
            {
                Label.Text = $"Showing {n} bills...";
            }
            List<ElectricityBill> bills = board.Generate_N_BillDetails(n);
            gvBills.DataSource = bills;
            gvBills.DataBind();

        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                string consumerNumber = txtConsumerNo.Text.Trim();
                string consumerName = txtConsumerName.Text.Trim();
                int units;
                if (!int.TryParse(txtUnits.Text, out units))
                {
                    lblResult.Text = "Please enter a valid number for units";
                    return;
                }

                //validate units
                string validationMessage = validator.ValidateUnitsConsumed(units);
                if (!string.IsNullOrEmpty(validationMessage))
                {
                    lblResult.Text = validationMessage;
                    return;
                }

                ElectricityBill ebill = new ElectricityBill(consumerNumber, consumerName, units);
                board.CalculateBill(ebill);
                string result = board.AddBill(ebill);
                if(result!="Success")
                {
                    Response.Write($"<script>alert('{result}')</script>;");
                }

                //clear textboxes for next entry
                txtConsumerNo.Text = txtConsumerName.Text = txtUnits.Text = string.Empty;
                //update counter
                int current = 0;

                 if(ViewState["CurrentBill"] !=null)
                {
                    current = (int)ViewState["CurrentBill"];
                }
                current++;
                ViewState["CurrentBill"] = current;

                int total = 0;
                if(ViewState["TotalBills"]!=null)
                    total=(int)ViewState["TotalBills"];
                else
                { lblResult.Text = "Please click on set total bills first!!";
                    return;
                }
                lblResult.Text = $"Bill {current} of {total} bills generated : {ebill.ConsumerNumber} {ebill.ConsumerName} {ebill.UnitsConsumed} Bill Amount: {ebill.BillAmount}";

                if(current>=total)
                {
                    lblResult.Text += "  --All bills generated!";
                    txtConsumerNo.Enabled = txtConsumerName.Enabled = txtUnits.Enabled = false;
                    btnGenerate.Enabled = false;
                }
            }
            catch (FormatException fex)
            {
                lblResult.Text = fex.Message;
            }
            catch (Exception ex)
            {
                lblResult.Text = "Error: " + ex.Message;
            }
        }

        protected void btnSetN_Click(object sender, EventArgs e)
        {
            int n;
            if(!int.TryParse(txt.Text,out n)||n<=0)
            {
                lbl.Text = "Please enter a valid number";
                return;
            }

            ViewState["TotalBills"] = n;
            ViewState["CurrentBill"] = 0;
            lbl.Text = $"Enter details for {n} bills";

            txtConsumerNo.Enabled = txtConsumerName.Enabled = txtUnits.Enabled = true;
            btnGenerate.Enabled = true;
        }
    }
}