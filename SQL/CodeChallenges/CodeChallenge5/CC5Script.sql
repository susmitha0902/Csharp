--CodeChallenge 2

--1.Write a query to display your birthday( day of week)
SELECT datename(WEEKDAY, '2003-10-07') AS Day_of_week


--2.Write a query to display your age in days	
SELECT DATEDIFF(DAY, CONVERT(DATE, '2003-10-07'), GETDATE()) AS Age_in_days

create table Employees (
    Empid int PRIMARY KEY,
    EmpName varchar(25),
    Salary decimal,
    Hire_Date date,
    Deptid int
)

insert into Employees values (101, 'Susmitha', 5500, '2017-07-10', 2),(102, 'Sneha', 6200, '2019-03-15', 1),(103, 'Rahul', 4800, '2020-07-23', 4),
(104, 'Priya', 7500, '2015-07-05', 1),(105, 'Syam', 5100, '2018-07-20', 6),(106, 'Hari', 6700, '2021-11-30', 2)
select * from Employees


--3.Write a query to display all employees information those who joined before 5 years in the current month
--(Hint : If required update some HireDates in your EMP table of the assignment)
select * from Employees where year(Hire_Date) <= year(GETDATE()) - 5 AND month(Hire_Date) = month(GETDATE())

alter table employees
drop column deptid 

--4.	Create table Employee with empno, ename, sal, doj columns or use your emp table and perform the following operations in a single transaction
--a. First insert 3 rows 
--b. Update the second row sal with 15% increment  
--c. Delete first row.
--After completing above all actions, recall the deleted row without losing increment of second row.

begin transaction
-- a. Insert 3 rows
insert into Employees values (201, 'Varnika', 5000, '2020-01-10')
insert into Employees values (202, 'Vijay', 6000, '2019-03-15')
insert into Employees values (203, 'Varun', 5500, '2021-07-23')
save transaction t1
select * from employees

-- b. Update second row's salary with 15% increment
update Employees set salary = salary+salary * (15/100) where Empid = 202
save transaction t2
select * from employees

-- c. Delete first row
delete from Employees where Empid = 201
save transaction t3
-- Recall deleted row 
rollback transaction t3
commit
select * from employees;
alter table employees
add  deptno int;
 

 update employees set deptno =20 where empname ='Susmitha'
 update employees set deptno =10 where empname ='Syam'
 update employees set deptno =30 



--5.     Create a user defined function calculate Bonus for all employees of a  given dept using 	following conditions
	--a.     For Deptno 10 employees 15% of sal as bonus.
	--b.     For Deptno 20 employees  20% of sal as bonus
	--c.      For Others employees 5%of sal as bonus
create or alter function calcbonus(@deptno int, @salary int)
returns int
as begin
	declare @bonus int
    if @deptno = 10
	begin
        set @bonus = @salary * 0.15
    end
	else if @deptno = 20
	begin
        set @bonus = @salary * 0.20
    end
	else
	begin
        set @bonus = @salary * 0.05
	end
    return @bonus
end
 
select empid , empname , deptno,Salary, dbo.calcbonus(deptno, salary) 'Bonus' from Employees

--6. Create a procedure to update the salary of employee by 500 whose dept name is Sales and current salary is below 1500 (use emp table)


