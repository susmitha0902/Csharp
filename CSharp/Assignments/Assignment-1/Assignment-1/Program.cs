using System;

namespace Assignment_1
{
    class Driver
    {
        static void Main(string[] args)
        {
            Question1 q1 = new Question1();
            q1.Are_Equal();
            Console.ReadLine();
            Question2 q2 = new Question2();
            q2.Is_Positive();
            Console.ReadLine();
            Question3 q3 = new Question3();
            q3.operations();
            Console.ReadLine();
            Question4 q4 = new Question4();
            q4.Table();
            Console.ReadLine();
            Question5 q5 = new Question5();
            q5.Addition();
        }

    }
    
}
