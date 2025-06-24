/*3. Create a class called Saledetails which has data members like Salesno,  Productno,  Price, dateofsale, Qty, TotalAmount
- Create a method called Sales() that takes qty, Price details of the object and updates the TotalAmount as  Qty *Price
- Pass the other information like SalesNo, Productno, Price,Qty and Dateof sale through constructor
- call the show data method to display the values without an object. 
 */
using System;

namespace Assignment_3
{
    class SaleDetails
    {
        public int Salesno, Productno, Qty;
        public float Price, TotalAmount;
        public DateTime dateofsale;
        public SaleDetails(){ }
        public SaleDetails(int Salesno, int Productno, float Price, int Qty, DateTime dateofsale)
        {
            this.Salesno = Salesno;
            this.Productno = Productno;
            this.Price = Price;
            this.Qty = Qty;
            this.dateofsale = dateofsale;
        }

        public void Sales(int Qty, float Price)
        {
            this.Qty = Qty;
            this.Price = Price; 
            TotalAmount = Qty * Price;
            Console.WriteLine("Total Amount is " + TotalAmount);
        }
        public static void ShowData(SaleDetails s1)
        {
            Console.WriteLine($"SalesNo: {s1.Salesno}, ProductNo : {s1.Productno}, Price: {s1.Price}, " +
            $"Quantity:{s1.Qty}, Date of Sale: {s1.dateofsale}, Total Amount: {s1.TotalAmount}");
        }
    }
    class Question3 : SaleDetails
    {
        public static void Main()
        {
            Question3 sale1 = new Question3();
            Console.WriteLine("Enter Sales Number");
            sale1.Salesno = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Product Number");
            sale1.Productno = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Price");
            sale1.Price = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Enter Quantity");
            sale1.Qty = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter DateOfSale");
            sale1.dateofsale = Convert.ToDateTime(Console.ReadLine());
            SaleDetails s1 = new SaleDetails(sale1.Salesno, sale1.Productno, sale1.Price, sale1.Qty, sale1.dateofsale);
            s1.Sales(s1.Qty, s1.Price); //sale1.Sales(sale1.Qty,sale1.Price);
            SaleDetails.ShowData(s1);
            Console.Read();
        }
    }
}

