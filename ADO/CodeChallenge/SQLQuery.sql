--1 Write a stored Procedure that inserts records in the Employee_Details table
--The procedure should generate the EmpId automatically to insert and should return the generated value to the user
 --Also the Salary Column is a calculated column (Salary is givenSalary - 10%)
create table Employee_Details (
    EmpId int primary key identity(1,1),
    Name varchar(25),
    Salary decimal,               
    NetSalary decimal,            
    Gender varchar(15)
)

create or alter procedure EmployeeDetails
    @Name varchar(25),
    @Salary decimal,         
    @Gender varchar(25),
    @EmpId int output,
    @NetSalary decimal output
as
begin
    set @NetSalary = @Salary - (@Salary * 0.10)
    insert into Employee_Details (Name, Salary, NetSalary, Gender) values(@Name, @Salary, @NetSalary, @Gender)
    set @EmpId = SCOPE_IDENTITY()
end
select * from Employee_Details


--2.Write a procedure that takes empid as input and outputs the updated salary as current salary + 100 for the give employee.
create or alter procedure UpdateSalary (@EmpId int) as
begin
    update Employee_Details
    set Salary = Salary + 100 where EmpId = @EmpId
    select EmpId, Name, Salary, NetSalary, Gender from Employee_Details
    where EmpId = @EmpId;
end


