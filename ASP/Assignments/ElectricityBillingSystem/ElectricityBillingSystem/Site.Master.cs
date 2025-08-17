using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectricityBillingSystem
{
    public partial class Site : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["Theme"] != null)
            {
                ddlThemes.SelectedValue = Session["Theme"].ToString();
            }
        }
        protected void Page_PreRender(object sender,EventArgs e)
        {
            var theme = string.IsNullOrEmpty(Page.Theme) ? "Light" : Page.Theme;
            themeCss.Href = ResolveUrl($"~/App_Themes/{theme}/Style.css");
        }
        protected void ddlThemes_SelectedIndexChanged(object sender,EventArgs e)
        {
            Session["Theme"] = ddlThemes.SelectedValue;
            Response.Redirect(Request.RawUrl);
        }
    }
}