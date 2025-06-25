/* 2. Write a C# Sharp program to exchange the first and last characters in a given string and return the new string.
 
Sample Input:
"abcd"
"a"
"xy"
Expected Output:
dbca
a
yx */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge1
{
    class Question2
    {
        public static void Main()
        { 
            Console.WriteLine("Enter the word: ");
            string str = Console.ReadLine();
            if (str.Length < 2)
            {
                Console.WriteLine(str);
            }
            else
            {
                char firstChar = str[0];
                char lastChar = str[str.Length - 1];
                string result = lastChar + str.Substring(1, str.Length - 2) + firstChar;
                Console.WriteLine("After changing first and last characters: " + result);
                Console.Read();
            }
        }

    }

}
