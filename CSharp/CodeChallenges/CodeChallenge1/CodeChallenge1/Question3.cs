/*
3. Write a C# Sharp program to check the largest number among three given integers.
 
Sample Input:
1,2,3
1,3,2
1,1,1
1,2,2
Expected Output:
3
3
1
2
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge1
{
    class Question3
    {
        public static void Main()
        {
            int num1, num2, num3;
            Console.WriteLine("Enter first integer");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second integer");
            num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter third integer");
            num3 = Convert.ToInt32(Console.ReadLine());
            if(num3>=num2 && num3>=num1)
            {
                Console.WriteLine(num3);
            }
            else if (num2>=num1 && num2>=num3)
            {
                Console.WriteLine(num2);
            }
            else
            {
                Console.WriteLine(num1);
            }
            Console.Read();
        }

    }
}
