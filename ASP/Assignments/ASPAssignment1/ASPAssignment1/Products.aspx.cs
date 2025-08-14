using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPAssignment1
{
    public partial class Products : System.Web.UI.Page
    {
        Dictionary<string, (string ImageUrl, decimal Price)> products = new Dictionary<string, (string, decimal)>
        {
            {"HairBands",("~/Images/bands.webp", 90m) },
            {"Comic books",("~/Images/Cats.webp", 300m) },
            {"Writing Pads",("~/Images/pad.webp", 100m) },
            {"Pens",("~/Images/pens.webp", 40m) },
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (var product in products.Keys)
                {
                    ddlProducts.Items.Add(product);
                }
            }
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProduct = ddlProducts.SelectedItem.Text;
            if (products.ContainsKey(selectedProduct))
            {
                imgProduct.ImageUrl = products[selectedProduct].ImageUrl;
            }
        }

        protected void btnGetPrice_Click(object sender, EventArgs e)
        {
            string selectedProduct = ddlProducts.SelectedItem.Text;
            if (products.ContainsKey(selectedProduct))
            {
                lblPrice.Text = "Price:" + products[selectedProduct].Price.ToString();
            }
        }
    }
}