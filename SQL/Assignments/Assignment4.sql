use AssignmentsDB
 
 --1.	Write a T-SQL Program to find the factorial of a given number.
 
create or alter proc sp_factorial @integer int
as
begin
    declare @result int = 1, @counter int = @integer
 
    while @counter >= 1
    begin
        set @result = @result * @counter
        set @counter = @counter - 1
    end
 
    print 'Factorial of ' + cast(@integer as varchar) + ' is ' + cast(@result as varchar)
end
 
exec sp_factorial @integer = 6
 
 
--2.	Create a stored procedure to generate multiplication table that accepts a number and generates up to a given number.
 
create or alter proc sp_multiplication_table @number int, @limit int
as
begin
	declare @count int = 1
	while @count <= @limit
	begin 
		print cast(@number as varchar) + ' x ' + cast(@count as varchar) + ' = ' + cast(@number * @count as varchar)
		set @count = @count + 1
	end
end
 
exec sp_multiplication_table @number = 9, @limit = 12
 
 
--3. Create a function to calculate the status of the student. If student score >=50 then pass, else fail. Display the data neatly
 
create table Student (
    Sid int primary key,
    Sname varchar(50)
)
 
insert into Student (Sid, Sname) values
(1, 'Jack'),
(2, 'Rithvik'),
(3, 'Jaspreeth'),
(4, 'Praveen'),
(5, 'Bisa'),
(6, 'Suraj')
 
create table Marks (
    Mid int primary key,
    Sid int,
    Score int,
    foreign key (Sid) references Student(Sid)
)
 
insert into Marks (Mid, Sid, Score) values
(1, 1, 23),
(2, 6, 95),
(3, 4, 98),
(4, 2, 17),
(5, 3, 53),
(6, 5, 13)
 
select * from Student 
select * from Marks
 
create function StatusOfTheStudent (@marks int)
returns varchar(10)
as
begin
	declare @status varchar(10)
	if @marks >= 50
		set @status = 'Pass'
	else
		set @status = 'Fail'
	return @status
end
 
select s.sid, s.sname, m.score, dbo.StatusOfTheStudent(m.score) as 'Status of the student'
from Student s
join Marks m on s.sid = m.sid