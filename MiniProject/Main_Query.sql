create database ReservationSystems
use ReservationSystems

--CUSTOMER TABLE
create table Customer
(Customer_ID int primary key identity(1,1),
Customer_Name varchar(50) not null,
Phone varchar(10) not null,
MailID varchar(30) not null unique,
Password varchar(30) not null);

--TRAIN TABLE
create table train
(TrainID int primary key identity(1,1),
TrainNo varchar(50),
TrainName varchar(50),
Source varchar(50),
Destination varchar(50),
class varchar(20),
TotalSeats int,
AvailableSeats int,
CostPerSeat decimal);


--RESERVATION TABLE
create table reservation(
BookingID int primary key identity(1,1),
CustomerID int,
TrainID int,
PassengerName varchar(50),
Class varchar(30),
DateOfTravel date,
BerthAllotment varchar(20),
WaitListStatus bit default 0,
TotalCost decimal,
DateOfBooking date,
IsActive bit default 1,
foreign key (CustomerID) references Customer(Customer_ID),
foreign key (TrainID) references Train(TrainID));

--CANCELLATION TABLE
create table cancellation(
cancelid int primary key identity(1,1),
BookingID int,
TicketCancelled bit,
RefundAmount decimal,
DateOfCancellation date,
foreign key(BookingID) references reservation(BookingID));



--ADMIN TABLE
create table admin(
AdminID int primary key identity(1,1),
Username varchar(50),
Password varchar(50));



-- Chennai Express - 12345
INSERT INTO Train (TrainNo, TrainName, Source, Destination, Class, TotalSeats, AvailableSeats, CostPerSeat)
VALUES
('12345', 'Chennai Express', 'Chennai', 'Delhi', 'Sleeper', 100, 100, 450),
('12345', 'Chennai Express', 'Chennai', 'Delhi', '2AC', 50, 50, 1200),
('12345', 'Chennai Express', 'Chennai', 'Delhi', '3AC', 75, 75, 900);


delete from train where TrainID in (7,9)
-- Howrah Express - 23456
INSERT INTO Train (TrainNo, TrainName, Source, Destination, Class, TotalSeats, AvailableSeats, CostPerSeat)
VALUES
('23456', 'Howrah Express', 'Kolkata', 'Bangalore', 'Sleeper', 120, 120, 500),
('23456', 'Howrah Express', 'Kolkata', 'Bangalore', '2AC', 60, 60, 1400),
('23456', 'Howrah Express', 'Kolkata', 'Bangalore', '3AC', 80, 80, 1000);

-- Kerala Express - 34567
INSERT INTO Train (TrainNo, TrainName, Source, Destination, Class, TotalSeats, AvailableSeats, CostPerSeat)
VALUES
('34567', 'Kerala Express', 'Trivandrum', 'New Delhi', 'Sleeper', 130, 130, 550),
('34567', 'Kerala Express', 'Trivandrum', 'New Delhi', '2AC', 70, 70, 1500),
('34567', 'Kerala Express', 'Trivandrum', 'New Delhi', '3AC', 90, 90, 1100);

-- Shri Shakti Express
INSERT INTO Train (TrainNo, TrainName, Source, Destination, Class, TotalSeats, AvailableSeats, CostPerSeat)
VALUES
('22461', 'Shri Shakti Express', 'New Delhi', 'Katra', 'Sleeper', 60, 60, 500),
('22461', 'Shri Shakti Express', 'New Delhi', 'Katra', '2AC', 30, 30, 1450),
('22461', 'Shri Shakti Express', 'New Delhi', 'Katra', '3AC', 40, 40, 1000);

-- Jammu Tawi–Udaipur Express
INSERT INTO Train (TrainNo, TrainName, Source, Destination, Class, TotalSeats, AvailableSeats, CostPerSeat)
VALUES
('19612', 'Jammu Tawi–Udaipur Express', 'Jammu Tawi', 'Udaipur City', 'Sleeper', 70, 70, 600),
('19612', 'Jammu Tawi–Udaipur Express', 'Jammu Tawi', 'Udaipur City', '2AC', 25, 25, 1600),
('19612', 'Jammu Tawi–Udaipur Express', 'Jammu Tawi', 'Udaipur City', '3AC', 35, 35, 1150);

-- Kamakhya–SVDK Express
INSERT INTO Train (TrainNo, TrainName, Source, Destination, Class, TotalSeats, AvailableSeats, CostPerSeat)
VALUES
('15655', 'Kamakhya–SVDK Express', 'Kamakhya', 'Katra', 'Sleeper', 65, 65, 800),
('15655', 'Kamakhya–SVDK Express', 'Kamakhya', 'Katra', '2AC', 20, 20, 2000),
('15655', 'Kamakhya–SVDK Express', 'Kamakhya', 'Katra', '3AC', 30, 30, 1400);




