using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricityBillingSystem
{
    public class BasePage: System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            var theme = Session["Theme"] as string;
            if (!string.IsNullOrEmpty(theme))
                this.Theme = theme;
            base.OnPreInit(e);
        }
    }
}