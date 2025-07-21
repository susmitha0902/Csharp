use AssignmentsDB
 
select * from emp
 
--(Using the same tables as Assignment 2)
--1. Retrieve a list of MANAGERS.
select * from emp
where job = 'Manager'
 
--2. Find out the names and salaries of all employees earning more than 1000 per month.
select ename as 'Employee Name', salary as 'Salary'
from emp
where salary > 1000
 
--3. Display the names and salaries of all employees except JAMES. 
select ename as 'Employee Name', salary as 'Salary'
from emp
except 
select ename, salary
from emp
where ename = 'James'

 
--4. Find out the details of employees whose names begin with ‘S’. 
select empno 'employee Id', ename 'Employee name begins with "S"', job 'Job', mgr_id, salary 'Salary', deptno 'Department No'
from emp
where ename like 'S%'
 
--5. Find out the names of all employees that have ‘A’ anywhere in their name. 
select empno 'Employee Id', ename 'Employee name that have "A" in their name' from emp
where ename like '%A%'
 
--6. Find out the names of all employees that have ‘L’ as their third character in their name.
select empno 'Employee ID', ename 'Employee Name that have "L" as their third character' 
from emp
where ename like '__L%'
 
--7. Compute daily salary of JONES. 
select empno 'Employee Id', ename 'Employee Name', 
salary 'Monthly Salary', 
salary / day(eomonth(hire_date)) 'Daily Salary' --eomonth(hire_date) gives the last day of the hire month and day extracts the day number (i.e 28 or 30 or 31)
from emp
where ename = 'Jones'
 
--8. Calculate the total monthly salary of all employees. 
select sum(salary) as 'Total monthly salary of all Employees' from emp
 
--9. Print the average annual salary
select avg(salary * 12) as 'Average Annual Salary' from emp
 
--10. Select the name, job, salary, department number of all employees except SALESMAN from department number 30. 
select ename 'Employee Name', job, salary, deptno 'Department No' from emp
except
select ename, job, salary, deptno from emp 
where (job = 'Salesman' and deptno = 30)
 
--11. List unique departments of the EMP table. 
select distinct(e.deptno), d.dname 'Department Name' from emp e 
join dept d on e.deptno = d.deptno
 
--12. List the name and salary of employees who earn more than 1500 and are in department 10 or 30. Label the columns Employee and Monthly Salary respectively
select ename 'Employee Name', salary from emp
where salary > 1500 and deptno in (10, 30)
 
--13. Display the name, job, and salary of all the employees whose job is MANAGER or ANALYST and their salary is not equal to 1000, 3000, or 5000
select ename 'Employee Name', job, salary from emp
where job in ('Manager', 'Analyst') and salary not in (1000, 3000, 5000)
 
--14. Display the name, salary and commission for all employees whose commission amount is greater than their salary increased by 10%
select ename 'Employee Name', salary, comm 'Commission Amount' from emp
where comm > (salary + salary * 0.1)
 
--15. Display the name of all employees who have two L's in their name and are in department 30 or their manager is 7782
select ename 'Employee Name' from emp
where ename like '%L%L%' and (deptno = 30 or mgr_id = 7782)
 
--16. Display the names of employees with experience of over 30 years and under 40 yrs. Count the total number of employees
 
with experienced_employees_cte as (
    select ename 'Employee Name' from emp
    where (datediff(day, hire_date, '2025-01-01')/ 365.25)> 30 and (datediff(day, hire_date, '2025-01-01')/ 365.25)< 40
)
select [Employee Name], 
       (select count(*) from experienced_employees_cte) 'Total Employees'
from experienced_employees_cte

--17. Retrieve the names of departments in ascending order and their employees in  descending order. 
select d.dname as Department_Name,e.ename as Employee_Name
from dept d
join emp e on d.deptno = e.deptno
order by d.dname,e.ename desc;

--18. Find out experience of MILLER. 
select ename 'Employee Name', (datediff(year, hire_date, '01-01-2025')) 'Experience in Years' from emp
where ename = 'Miller'