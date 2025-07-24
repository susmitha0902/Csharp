use AssignmentsDB
 
--1. Write a T-Sql based procedure to generate complete payslip of a given employee with respect to the following condition
--   a) HRA as 10% of Salary
--   b) DA as 20% of Salary
--   c) PF as 8% of Salary
--   d) IT as 5% of Salary
--   e) Deductions as sum of PF and IT
--   f) Gross Salary as sum of Salary, HRA, DA
--   g) Net Salary as Gross Salary - Deductions
--Print the payslip neatly with all details

create or alter procedure payslip @empid int
as begin
declare @Employee_Name varchar(15)
declare @Salary float(2)
declare @HRA float(2)
declare @DA float
declare @PF float
declare @IT float
declare @deductions float
declare @Gross_Salary float
declare @Net_Salary float
select  @salary = salary from emp where empno = @empid
select  @Employee_Name=ename from emp where empno=@empid
set @HRA = @salary * 0.1
set @DA = @salary * 0.2
set @Pf = @salary * 0.08
set @IT = @salary * 0.05
set @deductions = (@PF + @IT)
set @Gross_Salary = (@salary + @hra + @da)
set @net_salary = @Gross_salary - @deductions
print 'Payslip of Employee ' + @Employee_Name
print 'HRA is: ' + ' ' + cast(@HRA as varchar(max))
print 'DA is: ' + ' ' + cast(@DA as varchar(max))
print 'PF is: ' + ' ' + cast(@PF as varchar(max))
print 'IT is: ' + ' ' + cast(@IT as varchar(max))
print 'Deduction is: ' + ' ' + cast(@deductions as varchar(max))
print 'Gross salary is: ' + ' ' + cast(@Gross_salary as varchar(max))
print 'Net salary is: ' + ' ' + cast(@Net_Salary as varchar(max))
end
execute payslip @empid = 7876


--2.  Create a trigger to restrict data manipulation on EMP table during General holidays. 
--Display the error message like “Due to Independence day you cannot manipulate data” or "Due To Diwali", you cannot manipulate" etc
--Note: Create holiday table with (holiday_date,Holiday_name). 
--Store at least 4 holiday details. try to match and stop manipulation
 
create table Holiday (
    holiday_date date primary key,
    holiday_name varchar(50)
)
 
insert into Holiday values 
('2025-10-02', 'Gandhi Jayanthi'),
('2025-01-01', 'New Year'),
('2025-12-25', 'Christmas'),
('2025-08-15', 'Independence day'),
('2025-07-23','Diwali')
 
create or alter trigger tr_data_manipulation
on emp for insert,delete,update
as begin
declare @today_date date
declare @holiday_name varchar(15)
set @today_date = '01-01-2025'
select @holiday_name = holiday_name from Holiday where holiday_date = @today_date
if @holiday_name is not null
begin
raiserror('due to %s you cannot manipulate data.', 16, 1, @holiday_name)
rollback 
end
end
 
select * from emp
 
insert into emp values(7348,'TIM','CLERK', 7788, '10-JAN-87', 1298, null, 20)
delete from emp where empno=7654
update emp set salary = salary + 1000 where empno = 7654
 