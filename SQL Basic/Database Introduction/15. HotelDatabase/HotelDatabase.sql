CREATE DATABASE HotelDatabase 
GO
USE HotelDatabase 

CREATE TABLE Employees 
(
	Id INT IDENTITY NOT NULL,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Title VARCHAR(30) NOT NULL,
	Notes VARCHAR(MAX),
	CONSTRAINT PK_EmployeeId PRIMARY KEY(Id)
)

INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES
	('Bai', 'Xiks', 'Title1', NULL),
	('Pesho', 'Peshov', 'Title2', 'dfgddsf'),
	('Ivan', 'Ivanov', 'Title3', 'dgddfgvdg')

CREATE TABLE Customers  
(
	AccountNumber INT NOT NULL,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	PhoneNumber VARCHAR(10),
	EmergencyName VARCHAR(20),
	EmergencyNumber SMALLINT,
	Notes VARCHAR(MAX),
	CONSTRAINT PK_AccountNumber PRIMARY KEY(AccountNumber)
)

INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES
	(12535, 'Tosho', 'Toshev', '0884693309', 'BAI X', NULL, NULL),
	(45646456, 'Pesho', 'Poshev', '0878746678', 'BAI Y', 1234, NULL),
	(45646, 'Gosho', 'Toshev', NULL,'BAI Z', 4567, NULL)

CREATE TABLE RoomStatus
(
	Id TINYINT NOT NULL,
	RoomStatus BIT NOT NULL,
	Notes VARCHAR(MAX)
	CONSTRAINT PK_RoomStatusId PRIMARY KEY(Id)
)

INSERT INTO RoomStatus(Id, RoomStatus, Notes) VALUES
	(1, 1, NULL),
	(2, 0, 'dfgddsf'),
	(3, 1, 'dgddfgvdg')

CREATE TABLE RoomTypes
(
	Id TINYINT NOT NULL,
	RoomType VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
	CONSTRAINT PK_RoomTypeId PRIMARY KEY(Id)
)

INSERT INTO RoomTypes(Id, RoomType, Notes) VALUES
	(1, 'double room', NULL),
	(2, 'apartament', NULL),
	(3, 'single room', 'malka staya')

CREATE TABLE BedTypes 
(
	Id TINYINT NOT NULL,
	BedType VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
	CONSTRAINT PK_BedTypeId PRIMARY KEY(Id)
)

INSERT INTO BedTypes(Id, BedType, Notes) VALUES
	(1, 'single bed', NULL),
	(2, 'double bed', NULL),
	(3, 'big bed', 'biig')

CREATE TABLE Rooms 
(
	RoomNumber TINYINT NOT NULL,
	RoomType TINYINT FOREIGN KEY REFERENCES RoomTypes(Id),
	BedType TINYINT FOREIGN KEY REFERENCES BedTypes(Id),
	Rate FLOAT(2),
	RoomStatus TINYINT FOREIGN KEY REFERENCES RoomStatus(Id),
	Notes VARCHAR(MAX)
	CONSTRAINT PK_RoomNumber PRIMARY KEY(RoomNumber)
)

INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes) VALUES
	(1, 3, 2, 1.8, 1, NULL),
	(2, 2, 2, 4.1, 3, NULL),
	(3, 1, 1, 1.1, 2, NULL)

CREATE TABLE Payments
(
	Id INT IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	PaymentDate DATETIME NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
	FirstDateOccupied DATETIME NOT NULL,
	LastDateOccupied DATETIME NOT NULL,
	TotalDays TINYINT NOT NULL,
	AmountCharged FLOAT(2) NOT NULL,
	TaxRate FLOAT(2),
	TaxAmount FLOAT(2),
	PaymentTotal FLOAT(2) NOT NULL,
	Notes VARCHAR(200),
	CONSTRAINT PK_PaymentId PRIMARY KEY(Id)
)

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays,
	AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes) VALUES
	(1, '05/12/2021', 12535, '12/06/2021', '12/18/2021', 12, 1980.12, 0.09, 200.12, 1780, NULL),
	(2, '06/12/2021', 45646456, '12/07/2021', '12/19/2021', 12, 2021.40, 0.09, 230.12, 1800, NULL),
	(3, '01/15/2021', 45646, '02/02/2021', '02/19/2021', 17, 1640.11, 0.09, 184.22, 1456, NULL)

	--•	Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)

CREATE TABLE Occupancies
(
	Id INT IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	DateOccupied DATETIME NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
	RoomNumber TINYINT NOT NULL,
	RateApplied FLOAT(2),
	PhoneCharge FLOAT(2),
	Notes VARCHAR(200),
	CONSTRAINT PK_OccupancyId PRIMARY KEY(Id)
)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
	VALUES
	(1, '05/12/2021', 45646456, 8, 1.85, 200.12, NULL),
	(2, '06/12/2021', 12535, 12, 2.1, 230.12, NULL),
	(3, '01/15/2021', 45646, 15, 3.19, 184.22, NULL)

--Problem 23.	Decrease Tax Rate
UPDATE Payments
	SET TaxRate = TaxRate - TaxRate * 0.03

SELECT TaxRate from Payments

--Problem 24.	Delete All Records

TRUNCATE TABLE Occupancies