/*2.Write a C# Sharp program to check whether a given number is positive or negative. 

Test Data : 14
Expected Output :
14 is a positive number */

using System;

namespace Assignment_1
{
    class Question2
    {
        public void Is_Positive()
        {
            Console.WriteLine("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            string s;
            s = (number >= 0) ? ($"{number} is positive") : ($"{number} is negative");
            Console.WriteLine(s);
            Console.Read();
        }
    }
}
