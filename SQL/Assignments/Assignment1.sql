use AssignmentsDB
--client table creation
create table clients(Client_ID NUMERIC(4) Primary Key, 
Cname VARCHAR(40) Not Null,Address VARCHAR(30),
Email VARCHAR(30) Unique,Phone NUMERIC(10), Business VARCHAR(20) Not Null)
 
--Departments table creation
create table Departments(Deptno NUMERIC(2) Primary Key,Dname VARCHAR(15) Not Null,
Loc VARCHAR(20))
 
--Employee table creation
create table Employees(Empno NUMERIC(4) Primary Key,Ename VARCHAR(20) Not Null,
Job VARCHAR(15), Salary NUMERIC(7) CHECK (Salary>0),
Deptno NUMERIC(2) Foreign Key(Deptno) references Departments(Deptno))
 
--Project table creation
create table Projects(Project_ID NUMERIC(3) Primary Key,Descr VARCHAR(30) Not Null,
Start_Date DATE,Planned_End_Date DATE,Actual_End_date DATE ,check (Actual_End_date >Planned_End_Date),
Budget NUMERIC(10) CHECK(budget>0),Client_ID NUMERIC(4) Foreign Key(client_id) references clients(client_id))
 
--EmpProjectTasks table  creation
create table EmpProjectTasks(Project_ID NUMERIC(3),Empno NUMERIC(4),
Start_Date DATE,End_Date DATE,Task VARCHAR(25) Not Null,
Status VARCHAR(15) Not Null
primary key (Project_ID,Empno)
foreign key(project_id) references projects(project_id),
foreign key (empno) references employees(empno))
 
--insert to clients
insert into clients values(1001,' ACME Utilities',' Noida',' contact@acmeutil.com', 9567880032,' Manufacturing'),
(1002 ,'Trackon Consultants',' Mumbai',' consult@trackon.com', 8734210090,' Consultant'),
(1003 ,'MoneySaver Distributors',' Kolkata ','save@moneysaver.com ',7799886655,' Reseller'),
(1004 ,'Lawful Corp',' Chennai',' justice@lawful.com', 9210342219,' Professional')
 
--insert into Departments
insert into Departments values(10 ,'Design', 'Pune'),
(20,' Development',' Pune'),(30 ,'Testing',' Mumbai'),
(40 ,'Document' ,'Mumbai')
 
--insert into Employees
insert into Employees values(7001,' Sandeep ','Analyst' ,25000, 10),
(7002 ,'Rajesh ','Designer', 30000, 10),(7003,' Madhav', 'Developer', 40000 ,20),
(7004,' Manoj',' Developer', 40000, 20),(7005 ,'Abhay',' Designer', 35000, 10),
(7006,' Uma', 'Tester', 30000, 30),(7007,' Gita',' Tech. Writer', 30000, 40),
(7008 ,'Priya',' Tester', 35000 ,30),(7009,' Nutan',' Developer', 45000, 20),
(7010 ,'Smita',' Analyst', 20000, 10),(7011,' Anand', 'Project Mgr', 65000, 10)
 
--insert to projects
insert into projects values (401 ,'Inventory', '01-Apr-11',' 01-Oct-11', '31-Oct-11', 150000, 1001)
insert into projects(Project_ID ,Descr, Start_Date ,Planned_End_Date ,Budget ,Client_ID)
values(402 ,'Accounting',' 01-Aug-11',' 01-Jan-12', 500000, 1002),
(403 ,'Payroll',' 01-Oct-11',' 31-Dec-11', 75000, 1003),
(404, 'Contact Mgmt',' 01-Nov-11',' 31-Dec-11', 50000, 1004)

--insert to EmpProjectTasks
insert into EmpProjectTasks values(401, 7001, '01-Apr-11', '20-Apr-11', 'System Analysis', 'Completed'),
(401, 7002, '21-Apr-11', '30-May-11', 'System Design', 'Completed'),
(401, 7003, '01-Jun-11', '15-Jul-11', 'Coding', 'Completed'),
(401, 7004, '18-Jul-11', '01-Sep-11', 'Coding', 'Completed'),
(401, 7006, '03-Sep-11', '15-Sep-11', 'Testing', 'Completed'),
(401, 7009, '18-Sep-11', '05-Oct-11', 'Code Change', 'Completed'),
(401, 7008, '06-Oct-11', '16-Oct-11', 'Testing', 'Completed'),
(401, 7007, '06-Oct-11', '22-Oct-11', 'Documentation', 'Completed'),
(401, 7011, '22-Oct-11', '31-Oct-11', 'Sign off', 'Completed'),
(402, 7010, '01-Aug-11', '20-Aug-11', 'System Analysis', 'Completed'),
(402, 7002, '22-Aug-11', '30-Sep-11', 'System Design', 'Completed');
insert into EmpProjectTasks(Project_ID, Empno, Start_Date, Task, Status) values(402 ,'7004',' 01-Oct-11',' Coding ','In Progress')
 
--Display clients table
select * from clients
 
--Display Employees table
select * from Employees
 
--Display Departments table
select * from Departments
 
--Display Projects table
select * from Projects
 
--Display EmpProjectTasks
select * from EmpProjectTasks