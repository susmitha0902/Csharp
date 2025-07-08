//2.)Write a query that returns words starting with letter 'a' and ending with letter 'm'.
//Expected input and output
//"mum", "amsterdam", "bloom" → "amsterdam"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    class Question2
    {
        static void Main()
        {
            Console.WriteLine("Enter number of words: ");
            int n = Convert.ToInt32(Console.ReadLine());
            string[] words = new string[n];
            Console.WriteLine("\nEnter the words: ");
            for (int i = 0; i < n; i++)
            {
                words[i] = Console.ReadLine();
            }
            IEnumerable<string> word = from s in words
                                       where s.StartsWith("a", StringComparison.OrdinalIgnoreCase) && s.EndsWith("m", StringComparison.OrdinalIgnoreCase)
                                       select s;

            Console.WriteLine("\nWords that starts with A and ends with M are:");
            foreach (var item in word)
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }
    }
}


        