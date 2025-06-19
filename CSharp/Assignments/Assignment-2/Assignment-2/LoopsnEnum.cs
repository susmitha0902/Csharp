using System;
namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //swapping
            Console.WriteLine("Enter the first number:");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second number:");
            int num2 = Convert.ToInt32(Console.ReadLine());
            question1 q1 = new question1();
            Console.WriteLine("Numbers after swapping are");
            q1.swap_number(num1, num2);
            Console.WriteLine("*****");

            //loops
            question2 q2 = new question2();
            q2.show();
            Console.WriteLine("*****");

            //enum-usage
            question3 q3 = new question3();
            q3.Days();
            Console.Read();

        }
    }
//1. Write a C# Sharp program to swap two numbers.
    class question1
    {
        public void swap_number(int n1, int n2)
        {
            //using temp
            int temp;
            temp = n1;
            n1 = n2;
            n2 = temp;
            Console.WriteLine($"First number: {n1}, Second number : {n2}");
            //using xor(bitwise operator)
            /*
            n1 = n1^n2;
            n2 = n1^n2;
            n1 = n1^n2;
             */
        }
    }
/* 2. Write a C# program that takes a number as input and displays it four times in a row (separated 
 * by blank spaces),and then four times in the next row, with no separation. You should do it twice:
 * Use the console. Write and use {0}.
Test Data:
Enter a digit: 25
Expected Output:
25 25 25 25
25252525
25 25 25 25
25252525*/
    class question2
    {
        public void show()
        {
            Console.WriteLine("Enter a number");
            int number = Convert.ToInt32(Console.ReadLine());
            for(int i=0;i<2;i++)
            {
                Console.WriteLine("{0}{0}{0}{0}", number);
                Console.WriteLine("{0} {0} {0} {0}", number);
            }
        }
    }
 /*3. Write a C# Sharp program to read any day number as an integer and display the name of the day
 as a word.
Test Data / input: 2
Expected Output :
Tuesday*/
 public enum days{ Monday=1, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday}
    class question3
    {
        public void Days()
        {
            Console.WriteLine("Enter a number from 1 to 7");
            int x = Convert.ToInt32(Console.ReadLine());
            foreach(int y in Enum.GetValues(typeof(days)))
            {
                if(y==x)
                {
                    Console.WriteLine(Enum.GetName(typeof(days), y));
                }
            }
        }
    }
}
