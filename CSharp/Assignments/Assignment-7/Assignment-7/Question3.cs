//3.Create a list of employees with following property EmpId, EmpName, EmpCity, EmpSalary. Populate some data
//Write a program for following requirement
//a.	To display all employees data
//b.	To display all employees data whose salary is greater than 45000
//c.	To display all employees data who belong to Bangalore Region
//d.	To display all employees data by their names is Ascending order

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public double EmpSalary { get; set; }
    }
    class Question3
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>();
            Console.WriteLine("Enter number of employees: ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter employee {i + 1} details:");
                Console.Write("Employee ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Employee Name: ");
                string name = Console.ReadLine();

                Console.Write("Employee City: ");
                string city = Console.ReadLine();

                Console.Write("Employee Salary: ");
                double salary = double.Parse(Console.ReadLine());

                employees.Add(new Employee
                {
                    EmpId = id,
                    EmpName = name,
                    EmpCity = city,
                    EmpSalary = salary
                });
            }

            Console.WriteLine("\nDetails of all employees:");
            DisplayEmployees(employees);

            Console.WriteLine("\nEmployees with Salary greater than 45000:");
            var highSalaryEmp = employees.Where(e => e.EmpSalary > 45000);
            DisplayEmployees(highSalaryEmp);
           
            Console.WriteLine("\nEmployees who belong to Bangalore region:");
            var bangaloreEmp = employees.Where(e => e.EmpCity.Equals("Bangalore", StringComparison.OrdinalIgnoreCase));
            DisplayEmployees(bangaloreEmp);

            Console.WriteLine("\nEmployees sorted by name in ascending order:");
            var sortedEmployees = employees.OrderBy(e => e.EmpName);
            DisplayEmployees(sortedEmployees);

            Console.Read();
        }
        static void DisplayEmployees(IEnumerable<Employee> empList)
        {
            foreach (var emp in empList)
            {
                Console.WriteLine($"ID: {emp.EmpId}, Name: {emp.EmpName}, City: {emp.EmpCity}, Salary: {emp.EmpSalary}");
            }
        }

    }
}

