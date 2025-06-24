/*

2. Create a class called student which has data members like rollno, name, class, Semester, branch, int [] marks=new int marks [5](marks of 5 subjects )

-Pass the details of student like rollno, name, class, SEM, branch in constructor

-For marks write a method called GetMarks() and give marks for all 5 subjects

-Write a method called displayresult, which should calculate the average marks

-If marks of any one subject is less than 35 print result as failed
-If marks of all subject is >35,but average is < 50 then also print result as failed
-If avg > 50 then print result as passed.

-Write a DisplayData() method to display all object members values. 
 */

using System;
namespace Assignment_3
{
    class Student
    {
        string rollno,name,branch, result;
        int Class,Semester;
        public int[] marks = new int[5];

        public Student(string rollno, string name, int Class, int Semester, string branch)
        {
            this.name = name;
            this.rollno = rollno;
            this.Class = Class;
            this.Semester = Semester;
            this.branch = branch;
        }

        public void GetMarks()
        {
            for(int i=0;i<5;i++)
            {
            Console.WriteLine("Enter the marks of {0} subject:", i+1);
            marks[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        public float DisplayResult()
        {
            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                sum += marks[i];
            }
            float avg = sum / 5;
            Console.WriteLine("Average marks: " + avg);
            return avg;
        }

        public void evaluate(float avg)
        {
            for (int i = 0; i < 5; i++)
            {
                if (marks[i] < 35)
                {
                    result = "Failed";
                    Console.WriteLine(result);
                    return;
                }
            }
            if (avg < 50)
            {
                result = "Failed";
                Console.WriteLine(result);
                
            }
            else
            {
                result = "Passed";
                Console.WriteLine(result);
            }
        }
        public void DisplayData()
        {
            Console.WriteLine($"Roll number: {rollno} , Name : {name} , Class: {Class} , Semester : {Semester} , Branch : {branch}");
            for(int i=0;i<5;i++)
            {
                Console.WriteLine($"Marks of subject {i+1} : {marks[i]}");
            }
            Console.WriteLine("Your result:{0}", result);
        }
    }
    class Question2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter roll number :");
            string rollNo = (Console.ReadLine());
            Console.WriteLine("Enter student name :");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter class :");
            int Class = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Semester :");
            int semester = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Branch :");
            string branch = (Console.ReadLine());
            Student student = new Student(rollNo, Name, Class, semester, branch);
            student.GetMarks();
            float average = student.DisplayResult();
            student.evaluate(average);
            student.DisplayData();
            Console.Read();
        }
    }
}
