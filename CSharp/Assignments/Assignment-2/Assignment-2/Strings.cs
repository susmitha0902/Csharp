using System;
namespace Assignment_2
{
    class Strings
    {
        public static void Main()
        {
            question7 q7 = new question7();
            q7.string_len();
            question8 q8 = new question8();
            q8.string_rev();
            question9 q9 = new question9();
            q9.string_similarity();
            Console.Read();
        }

    }
//1.	Write a program in C# to accept a word from the user and display the length of it.
    class question7
    {
        public void string_len()
        {
            Console.WriteLine("Enter a string");
            string s = Console.ReadLine();
            Console.WriteLine(s.Length);
        }
    }
//2.	Write a program in C# to accept a word from the user and display the reverse of it. 
class question8
    {
        public void string_rev()
        {
            Console.WriteLine("Enter a string");
            string original = Console.ReadLine();
            char[] stringArray = original.ToCharArray();
            Array.Reverse(stringArray);
            string reverseString = new string(stringArray);
            Console.Write($"Reverse String is : {reverseString} ");
        }
    }
//3.	Write a program in C# to accept two words from user and find out if they are same. 
class question9
    {
        public void string_similarity()
        {
            Console.WriteLine("Enter first string:");
            string first_str = Console.ReadLine();
            Console.WriteLine("Enter second string:");
            string second_str = Console.ReadLine(); 
            if(first_str.Length==second_str.Length)
            {
                string fs = first_str.ToLower();
                string ss = second_str.ToLower();
                if (fs == ss)
                    Console.WriteLine("Same");
                else
                    Console.WriteLine("Not same");
            }
            else
            {
                Console.WriteLine("Not same");
            }
        }
    }
}
