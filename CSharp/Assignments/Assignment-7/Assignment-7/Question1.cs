//1.) 
//Write a query that returns list of numbers and their squares only if square is greater than 20 

//Example input [7, 2, 30]
//Expected output
//→ 7 - 49, 30 - 900

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    class Question1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of elements: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] numbers = new int[n];
            Console.WriteLine("\nEnter the numbers: ");
            for (int i = 0; i < n; i++)
            {
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }

            var squares = from num in numbers
                          let square = num * num
                          where square > 20
                          select new { N = num, S = square };

            Console.WriteLine("\nSquares greater than 20: ");
            foreach (var number in squares)
            {
                Console.WriteLine($"{number.N} ->  {number.S}");
            }

            Console.Read();
        }
    }
}
