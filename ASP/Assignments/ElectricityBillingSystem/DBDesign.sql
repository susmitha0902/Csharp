create database ElectricityBillDB
use ElectricityBillDB

--creating the table
create table ElectricityBill(
consumer_number varchar(20) not null primary key,
consumer_name varchar(50) not null,
units_consumed int not null,
bill_amount float not null,
created_at datetime2(0)  not null constraint DF_created_at default sysdatetime(),

--validations
constraint CK_Consumer_Format check(consumer_number like 'EB[0-9][0-9][0-9][0-9][0-9]'),
constraint CK_Units_Positive check(units_consumed>=0),
constraint CK_Bill_Positive check(bill_amount>=0))


create table AdminUser(
admin_id int identity(1,1) primary key, 
username varchar(50) not null unique,
password varchar(50) not null,
created_at datetime2(0) not null default sysdatetime()
)

insert into AdminUser(username,password) values('admin','admin90')
insert into AdminUser(username,password) values('bhanu','bhanu12')
insert into AdminUser(username,password) values('susmitha','musk12')

select * from AdminUser

select * from ElectricityBill
update  ElectricityBill set consumer_number='EB20208' where BillID=7

select name from sys.key_constraints where parent_object_id = OBJECT_ID('ElectricityBill')

alter table ElectricityBill
drop constraint PK__Electric__6DFBEE3A0D27D701

alter table electricitybill
add BillID int identity(1,1)

alter table ElectricityBill
add constraint PK_Bill primary key(BillID)






