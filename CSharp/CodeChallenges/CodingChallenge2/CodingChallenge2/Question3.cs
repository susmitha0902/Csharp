/* 3. Write a C# program to implement a method that takes an integer as input and throws an exception if the number is negative. 
 * Handle the exception in the calling code.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge2
{
    class NegativeNumberException : ApplicationException
    {
            public NegativeNumberException(string message) : base(message) { }
    }
    class Question3
    {
            public static void IsPositive(int number)
            {
                if (number > 0)
                {
                    Console.WriteLine("Entered a positive value");
                }
                else
                {
                    throw new NegativeNumberException("Invalid entry, please enter a positive number");
                }
            }
            public static void Main()
            {
                try
                {
                    int number;
                    Console.WriteLine("Enter a number");
                    number = Convert.ToInt32(Console.ReadLine());
                    IsPositive(number);
                }
                catch (NegativeNumberException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.Read();
            }
    }
}

