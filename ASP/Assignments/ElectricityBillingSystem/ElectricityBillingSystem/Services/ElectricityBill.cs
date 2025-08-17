using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricityBillingSystem.Services
{
    public class ElectricityBill
    {
        //private fields
        private string consumerNumber;
        private string consumerName;
        private int unitsConsumed;
        private double billAmount;

        //public properties
        public string ConsumerNumber
        {
            get { return consumerNumber; }
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new FormatException("Invalid Consumer Number");
                }
                consumerNumber = value;
            }
        }

        public string ConsumerName
        {
            get { return consumerName; }
            set { consumerName = value; }
        }

        public int UnitsConsumed
        {
            get { return unitsConsumed; }
            set
            {
                unitsConsumed = value;
            }
        }

        public double BillAmount
        {
            get { return billAmount; }
            internal set
            {
                billAmount = value; //lets only electricityboard set this value
            }
        }

        public ElectricityBill() { }
        public ElectricityBill(string consumerNumber,string consumerName,int unitsConsumed)
        {
            ConsumerNumber = consumerNumber;
            ConsumerName   = consumerName;
            UnitsConsumed = unitsConsumed;
        }
    }
}