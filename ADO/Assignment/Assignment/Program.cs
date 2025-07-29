using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Assignment
{
    public class Employee
    {

        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {

            List<Employee> empList = GetEmployees();
            Console.WriteLine("****Joined before 1/1/2015****");
            DisplayEmployees(empList.Where(e => e.DOJ < new DateTime(2015, 1, 1)));
            Console.WriteLine();
            Console.WriteLine("****Date of birth is after 1/1/1990****");
            DisplayEmployees(empList.Where(e => e.DOB > new DateTime(1990, 1, 1)));
            Console.WriteLine();
            Console.WriteLine("****Designation is Consultant and Associate****");
            DisplayEmployees(empList.Where(e => e.Title == "Consultant" || e.Title == "Associate"));
            Console.WriteLine();
            Console.WriteLine("****Total number of employees*****");
            Console.WriteLine(empList.Count);
            Console.WriteLine();
            Console.WriteLine("****Employees in Chennai****");
            Console.WriteLine(empList.Count(e => e.City == "Chennai"));
            Console.WriteLine();
            Console.WriteLine("****Highest Employee ID ****");
            Console.WriteLine(empList.Max(e => e.EmployeeID));
            Console.WriteLine();
            Console.WriteLine("****Joined after 1/1/2015****");
            Console.WriteLine(empList.Count(e => e.DOJ > new DateTime(2015, 1, 1)));
            Console.WriteLine();
            Console.WriteLine("****Designation not Associate****");
            Console.WriteLine(empList.Count(e => e.Title != "Associate"));
            Console.WriteLine();
            Console.WriteLine("****Employees by City****");
            var EmployeesByCity = empList.GroupBy(e => e.City);

            foreach (var c in EmployeesByCity)
            {
                Console.WriteLine($"{c.Key}: {c.Count()}");
            }
            Console.WriteLine();
            Console.WriteLine("*****Employees by City and Title****");
            var EmployeesByCityAndTitle = empList.GroupBy(e => new { e.City, e.Title });

            foreach (var group in EmployeesByCityAndTitle)
            {
                Console.WriteLine($"{group.Key.City}  {group.Key.Title}: {group.Count()}");
            }
            Console.WriteLine();
            Console.WriteLine("**************** Youngest employee ****************");

            var youngest = empList.OrderByDescending(e => e.DOB).FirstOrDefault();
            Console.WriteLine($"{youngest.EmployeeID}   {youngest.FirstName}   {youngest.LastName}   {youngest.Title}   {youngest.DOB.ToShortDateString()}   {youngest.DOJ.ToShortDateString()}   {youngest.City}");
            Console.ReadLine();
        }
        static List<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = DateTime.Parse("16/11/1984"), DOJ = DateTime.Parse("8/6/2011"), City = "Mumbai" },
                new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = DateTime.Parse("20/08/1984"), DOJ = DateTime.Parse("7/7/2012"), City = "Mumbai" },
                new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = DateTime.Parse("14/11/1987"), DOJ = DateTime.Parse("12/4/2015"), City = "Pune" },
                new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("3/6/1990"), DOJ = DateTime.Parse("2/2/2016"), City = "Pune" },
                new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("8/3/1991"), DOJ = DateTime.Parse("2/2/2016"), City = "Mumbai" },
                new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = DateTime.Parse("7/11/1989"), DOJ = DateTime.Parse("8/8/2014"), City = "Chennai" },
                new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = DateTime.Parse("2/12/1989"), DOJ = DateTime.Parse("1/6/2015"), City = "Mumbai" },
                new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = DateTime.Parse("11/11/1993"), DOJ = DateTime.Parse("6/11/2014"), City = "Chennai" },
                new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = DateTime.Parse("12/8/1992"), DOJ = DateTime.Parse("3/12/2014"), City = "Chennai" },
                new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = DateTime.Parse("12/4/1991"), DOJ = DateTime.Parse("2/1/2016"), City = "Pune" }
            };

        }
        static void DisplayEmployees(IEnumerable<Employee> employees)
        {
            Console.WriteLine("EmpId   FirstName \t LastName \t Title \t    DOB \t  DOJ \t       City");

            foreach (var e in employees)
            {
                Console.WriteLine($"{e.EmployeeID}\t  {e.FirstName}\t {e.LastName}\t {e.Title}  {e.DOB.ToShortDateString()}\t {e.DOJ.ToShortDateString()}\t {e.City}");

            }
        }
    }
}


