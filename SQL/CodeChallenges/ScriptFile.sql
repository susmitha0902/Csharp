create database CodeChallenge
use CodeChallenge
--Create a book table with id as primary key and provide the appropriate data type to other attributes 
--.isbn no should be unique for each book
create table books
(id int not null ,title varchar(30),
author varchar (30),isbn numeric,
published_date datetime,
constraint pkid primary key(id),
constraint uisbn unique(isbn))

insert into books values(1,'My First SQL book','Mary Parker',981483029127,'2012-02-22 12:08:17')
,(2,'My Second SQL book','John Mayer',857300923713,'1972-07-03 09:22:45'),
(3,'My third SQL book','Cary Flint',523120967812,'2015-10-18 14:05:44')
select * from books;

create table reviews 
(id int,
book_id int,
reviewer_name varchar(15),
content varchar(30),
rating int,published_date datetime,
FOREIGN KEY (book_id) REFERENCES books(id))

insert into reviews values(1,1,'John Smith','My first review',4,'2017-12-10 05:50:11.1'),
(2,2,'John Smith','My second review',5,'2017-10-13 15:05:12.6'),
(3,2,'Alice Walker','Another Review',1,'2017-10-22 23:47:10')

select * from reviews;

--1. Write a query to fetch the details of the books written by author whose name ends with er.

select * from books
where author like '%er'

--2.Display the Title ,Author and ReviewerName for all the books from the above table

select title,author,reviewer_name from reviews,books
where books.id = reviews.book_id

--3.Display the reviewer name who reviewed more than one book.

select reviewer_name from reviews
group by reviewer_name
having count(rating)>1

create table customers
(id int not null,name varchar(30),
age int,address varchar(30),salary decimal)

insert into customers values(1,'Ramesh',32,'Ahmedabad',2000),(2,'Khilan',25,'Delhi',1500),(3,'Kaushik',23,'Kota',2000),
(4,'Chaitali',25,'Mumbai',6500),(5,'Hardik',27,'Bhopal',8500),(6,'Komal',22,'MP',4500),(7,'Muffy',24,'Indore',10000)
select * from customers


--4.Display the Name for the customer from above customer table who live in same address which has character o anywhere in address
select name,address from customers
where address like '%o%'
order by name

alter table customers
add constraint pid primary key (id)

create table orders
(oid int,date_ordered datetime,customer_id int,amount decimal,
foreign key (customer_id) references customers(id))

insert into orders values (102,'2009-10-08 00:00:00',3,3000),(100,'2009-10-08 00:00:00',3,1500),
(101,'2009-11-20 00:00:00',2,1560),(103,'2008-05-20 00:00:00',4,2060)
select * from orders


update customers set  salary=null where id in(6,7)

select * from customers

--6.Display the Names of the Employee in lower case, whose salary is null
select lower(name) as Name
from customers 
where salary is null 

create table StudentDetails
(registerno int ,name varchar(30),age int,qualification varchar(10),Mobileno numeric,
maild_id varchar(30),location varchar(15),gender char)

insert into StudentDetails values(2,'Sai',22,'B.E',9952836777,'Sai@gmail.com','Chennai','M'),
(3,'Kumar',20,'BSC',7890125648,'Kumar@gmail.com','Madurai','M'),(4,'Selvi',22,'B.Tech',8904567342,'selvi@gmail.com','Selam','F'),
(5,'Nisha',25,'M.E',7834672310,'Nisha@gmail.com','Theni','F'),
(6,'SaiSaran',21,'B.A',7890345678,'saran@gmail.com','Madurai','F'),(7,'Tom',23,'BCA',8901234675,'Tom@gmail.com','Pune','M')

select * from StudentDetails

--7.Write a sql server query to display the Gender,Total no of male and female from the above relation

select gender, count(gender) as total_count from StudentDetails
group by gender




--5.Write a query to display the Date,Total no of customer placed order on same Date
select date_ordered,count(customer_id) as total_customers
from orders
group by date_ordered
