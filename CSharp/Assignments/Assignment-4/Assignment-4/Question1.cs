using System;
using System.Collections.Generic;

namespace Assignment_4
{
    // Employee class with properties
    class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }
}

class Question1
{
    static List<Employee> employeeList = new List<Employee>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nEmployee Management Menu");
            Console.WriteLine("1. Add New Employee");
            Console.WriteLine("2. View All Employees");
            Console.WriteLine("3. Search Employee by ID");
            Console.WriteLine("4. Update Employee Details");
            Console.WriteLine("5. Delete Employee");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            try
            {
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        ViewAllEmployees();
                        break;
                    case 3:
                        SearchEmployee();
                        break;
                    case 4:
                        UpdateEmployee();
                        break;
                    case 5:
                        DeleteEmployee();
                        break;
                    case 6:
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select from 1 to 6.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
            }
        }
    }

    static void AddEmployee()
    {
        try
        {
            Employee emp = new Employee();
            Console.Write("Enter Employee ID: ");
            emp.Id = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            emp.Name = Console.ReadLine();

            Console.Write("Enter Department: ");
            emp.Department = Console.ReadLine();

            Console.Write("Enter Salary: ");
            emp.Salary = double.Parse(Console.ReadLine());

            employeeList.Add(emp);
            Console.WriteLine("Employee added successfully!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid data format! Please enter correct types.");
        }
    }

    static void ViewAllEmployees()
    {
        if (employeeList.Count == 0)
        {
            Console.WriteLine("No employees to display.");
            return;
        }

        Console.WriteLine("\nEmployee List:");
        foreach (Employee emp in employeeList)
        {
            Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Department: {emp.Department}, Salary: {emp.Salary}");
        }
    }

    static void SearchEmployee()
    {
        try
        {
            Console.Write("Enter Employee ID to search: ");
            int id = int.Parse(Console.ReadLine());

            Employee emp = employeeList.Find(e => e.Id == id);

            if (emp != null)
            {
                Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Department: {emp.Department}, Salary: {emp.Salary}");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid ID format!");
        }
    }
    static void UpdateEmployee()
    {
        try
        {
            Console.Write("Enter Employee ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Employee emp = employeeList.Find(e => e.Id == id);

            if (emp != null)
            {
                Console.Write("Enter new Name (leave blank to keep current): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name)) emp.Name = name;

                Console.Write("Enter new Department (leave blank to keep current): ");
                string dept = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(dept)) emp.Department = dept;

                Console.Write("Enter new Salary (leave blank to keep current): ");
                string salaryInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(salaryInput))
                {
                    emp.Salary = double.Parse(salaryInput);
                }

                Console.WriteLine("Employee updated successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input format.");
        }
    }
    static void DeleteEmployee()
    {
        try
        {
            Console.Write("Enter Employee ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            Employee emp = employeeList.Find(e => e.Id == id);

            if (emp != null)
            {
                employeeList.Remove(emp); // Remove employee from the list
                Console.WriteLine("Employee deleted successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid ID format!");
        }
    }
}
}
