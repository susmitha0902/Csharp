//3. Write a program in C# Sharp to count the number of lines in a file.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment6
{
    class Question3
    {
        static void Main()
        {
            string filepath = "Assign6_q3.txt";

            try
            {
                string[] lines = File.ReadAllLines(filepath);
                int count = lines.Length;

                Console.WriteLine($"Number of lines in the file {filepath} are: {count}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: File not present at the given path");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in reading the file", e.Message);
            }

            Console.Read();
        }
    }
}
