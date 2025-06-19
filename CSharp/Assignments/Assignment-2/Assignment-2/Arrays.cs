using System;
namespace Assignment_2
{
    class Arrays
    {
        public static void Main()
        {
            question4 q4 = new question4();
            q4.Avg_min_max();
            question5 q5 = new question5();
            q5.display();
            question6 q6 = new question6();
            q6.copy_array();
            Console.Read();
        }
    }
    /*1.Write a  Program to assign integer values to an array  and then print the following
       a.Average value of Array elements
       b.Minimum and Maximum value in an array*/
    class question4
    {
        public void Avg_min_max()
        {
            Console.WriteLine("Enter size of the array");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the numbers");
            int[] arr = new int[n];
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
                sum += arr[i];
            }
            float avg = (sum / n);
            Console.WriteLine("Average of the array elements is {0}", avg);

            //min and max 
            Array.Sort(arr);
            int min = arr[0];
            int max = arr[n - 1];
            Console.WriteLine($"Maximum element : {max}, Minimum element : {min}");
        }
    }
    /*2.	Write a program in C# to accept ten marks and display the following
	a.	Total
	b.	Average
	c.	Minimum marks
	d.	Maximum marks
	e.	Display marks in ascending order
	f.	Display marks in descending order*/
    class question5
    {
        public void display()
        {
            Console.WriteLine("Enter ten marks");
            int[] marks = new int[10];
            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                marks[i] = Convert.ToInt32(Console.ReadLine());
                sum += marks[i]; //a.sum
            }
            Console.WriteLine("Total marks: {0}", sum);
            float avg = (sum / 10);  //b. average
            Console.WriteLine("Average marks: {0}", avg);
            //c.min marks and max marks 
            Array.Sort(marks);
            int min = marks[0];
            int max = marks[9];
            Console.WriteLine($"Maximum marks : {max}, Minimum marks : {min}");
            //Ascending order
            Console.WriteLine("Ascending order of the marks");
            foreach (int mark in marks)
            {
                Console.Write(mark + " ");
            }
            //Descending order
            Array.Reverse(marks);
            Console.WriteLine();
            Console.WriteLine("Descending order of the marks");
            foreach(int mark in marks)
            {
                Console.Write(mark + " ");
            }
        }

    }

    /*3.  Write a C# Sharp program to copy the elements of one array into another array.(do not use any inbuilt functions)*/
    class question6
    {
        public void copy_array()
        {
            Console.WriteLine("Enter size of the array");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr1 = new int[n];
            Console.WriteLine("Enter elements of the array");
            for(int i=0;i<n;i++)
            {
                arr1[i] = Convert.ToInt32(Console.ReadLine());
            }
            int[] arr2 = new int[n];
            arr2 = arr1;
            for(int i=0;i<n;i++)
            {
                //printing copy array
                Console.Write(arr2[i]+" ");
            }
        }
    }
}
