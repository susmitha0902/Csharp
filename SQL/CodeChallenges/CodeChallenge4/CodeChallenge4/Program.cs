using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge4
{

    class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ{ get; set; }
        public string city { get; set; }
    }



    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> emplist = new List<Employee>();
            Console.WriteLine("Enter count of employees");
            int count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Enter details for Employee {i + 1}:");
                Console.WriteLine("Employee ID: ");
                int EmpID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter First Name: ");
                string fn = Console.ReadLine();
                Console.WriteLine("Enter Last Name: ");
                string ln = Console.ReadLine();
                Console.WriteLine("Enter title: ");
                string title = Console.ReadLine();
                Console.WriteLine("Enter DOB: ");
                DateTime dob = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter DOJ: ");
                DateTime doj = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter City: ");
                string city = Console.ReadLine();

                emplist.Add(new Employee
                {
                    EmployeeID = EmpID,
                    FirstName = fn,
                    LastName = ln,
                    title = title,
                    DOB = dob,
                    DOJ = dob,
                    city = city
                });
            }
            //a. Details of all employees
            DisplayEmployees(emplist);

            //b.Display details of all employees whose location is not mumbai
            Console.WriteLine("---List of people not in Mumbai");
            var emp2list = (from e in emplist
                            where e.city != "Mumbai"
                            select e).ToList();
            DisplayEmployees(emp2list);

            //c.Display details of all the employee whose title is AsstManager
            Console.WriteLine("List of people whose title is asstmanager");
            var emp3list = (from e in emplist
                            where e.title == "AsstManager"
                            select e).ToList();
            DisplayEmployees(emp3list);

            Console.Read();
        }


        static void DisplayEmployees(List<Employee> employees)
        {
            foreach (var e in employees)
            {
                Console.WriteLine($"{e.EmployeeID} | {e.FirstName} {e.LastName} | {e.title} | DOB: {e.DOB} | DOJ: {e.DOJ} | City: {e.city}");
            }
        }

    }
}
