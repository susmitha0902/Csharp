/*5.Write a C# program to compute the sum of two given integers. 
 If two values are the same, return the triple of their sum.*/
using System;
namespace Assignment_1
{
    class Question5
    {
        public void Addition()
        {
            int num1, num2;
            Console.WriteLine("Enter first number: ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number: ");
            num2 = Convert.ToInt32(Console.ReadLine());
            if(num1==num2)
                Console.WriteLine(6*num1);
            else
                Console.WriteLine(num1 + num2);
            Console.Read();
        }
    }
}
