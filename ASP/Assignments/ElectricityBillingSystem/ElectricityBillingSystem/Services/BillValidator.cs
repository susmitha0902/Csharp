using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricityBillingSystem.Services
{
    public class BillValidator
    {
        public string ValidateUnitsConsumed(int unitsConsumed)
        {
            if (unitsConsumed < 0)
                return "Given units is not valid";
            return string.Empty;  //No error
        }
    }

}