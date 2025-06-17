/*4.Write a C# Sharp program that prints the multiplication table of a number as input.

Test Data:
Enter the number: 5
Expected Output:
5 * 0 = 0
5 * 1 = 5
5 * 2 = 10
5 * 3 = 15....5 * 10 = 50
*/
using System;

namespace Assignment_1
{
    class Question4
    {
        public void Table()
        {
            Console.WriteLine("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            int result;
            for (int i = 0; i <= 10; i++)
            {
                result = number * i;
                Console.WriteLine($"{number} * {i} = {result}");
            }
            Console.Read();
        }
    }
}
