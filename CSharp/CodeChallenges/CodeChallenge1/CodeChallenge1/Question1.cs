/*1.Write a C# Sharp program to remove the character at a given position in the string. The given position will be in the range 0..(string length -1) inclusive.
 
Sample Input:
"Python", 1
"Python", 0
"Python", 4
Expected Output:
Pthon
ython
Pythn
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge1
{
    class Question1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the word");
            string word = Console.ReadLine();
            Console.WriteLine("Enter the index of the character you want to remove");
            int index = Convert.ToInt32(Console.ReadLine());
            char[] arr = word.ToCharArray();
            string res="";
            for(int i=0;i<arr.Length;i++)
            {
                if (i == index) continue;
                else
                    res += arr[i];
            }
            Console.WriteLine($"After removing the character at {index} is {res}");
            Console.Read();
        }
    }
}
