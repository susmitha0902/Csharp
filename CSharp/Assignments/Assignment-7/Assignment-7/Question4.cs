//4.Create a class library with a function CalculateConcession()  that takes age as an input and calculates concession for travel as below:
//If age <= 5 then “Little Champs - Free Ticket” should be displayed
//If age > 60 then calculate 30% concession on the totalfare(Which is a constant Eg:500 / -) and Display “ Senior Citizen” + Calculated Fare
//Else “Print Ticket Booked” + Fare. 
//Create a Console application with a Class called Program which has TotalFare as Constant, Name, Age.  Accept Name, Age from the user and call the CalculateConcession() function to test the Classlibrary functionality

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelConcessionLib;

namespace Assignment7
{
    class Program
    {
        const double TotalFare = 500.0;

        static void Main(string[] args)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Age: ");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.Write("Please enter a valid number for age: ");
            }

            // Creating an object for TravelConcession class from class library
            TravelConcession concession = new TravelConcession();
            concession.CalculateConcession(name, age, TotalFare);

            Console.ReadLine();
        }
    }
}