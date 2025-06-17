/* 3.Write a C# Sharp program that takes two numbers as input and performs all operations (+,-,*,/) on them and displays the result of that operation. 

Test Data
Input first number: 20
Input operation: -
Input second number: 12
Expected Output :
20 - 12 = 8 */

using System;

namespace Assignment_1
{
    class Question3
    {
       public void operations()
        {
            int num1, num2, res = 0 ;
            Console.WriteLine("Enter first number: ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number: ");
            num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the operator: ");
            string opr = Console.ReadLine();
            switch(opr)
            {
                case "+": res = num1 + num2;
                    Console.WriteLine($"{num1}{opr}{num2} ={res}");
                    break;
                case "-": res = Math.Abs(num1 - num2);
                    Console.WriteLine($"{num1}{opr}{num2} ={res}");
                    break;
                case "*":
                    res = num1 * num2;
                    Console.WriteLine($"{num1}{opr}{num2} ={res}");
                    break;
                case "/":
                    res = num1 / num2;
                    Console.WriteLine($"{num1}{opr}{num2} ={res}");
                    break;
                default:
                    Console.WriteLine("Invalid operator");
                    break;
            }
            Console.Read();
        }
    }
}
