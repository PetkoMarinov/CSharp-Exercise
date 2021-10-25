CREATE DATABASE CarRental 
GO
USE CarRental 

CREATE TABLE Categories
(
	Id INT IDENTITY NOT NULL,
	CategoryName VARCHAR(30) NOT NULL,
	DailyRate FLOAT(2),
	WeeklyRate FLOAT(2),
	MonthlyRate FLOAT(2),
	WeekendRate FLOAT(2)
	CONSTRAINT PK_CategoryId PRIMARY KEY(Id)
)

INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
	('Category1', NULL, NULL, NULL, NULL),
	('Category2', 1.5, 2.88, 4.1, 5),
	('Category3', 2.0, 4.2, 1.1, NULL)

CREATE TABLE Cars
(
	Id INT IDENTITY NOT NULL,
	PlateNumber VARCHAR(8) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	CarYear SMALLINT NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Doors TINYINT,
	Picture NVARCHAR(300),
	Condition Varchar(30),
	Available BIT NOT NULL
	CONSTRAINT PK_CarId PRIMARY KEY(Id)
)

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId,
	Doors, Picture, Condition, Available) VALUES
	('PA4344AB', 'Ford', 'Fiesta', 1996, 2, 5, 'C:\Users\сем. Маринови\Desktop\ІІ-А-група.jpeg', 'Good', 0),
	('CA7622CK', 'Ford', 'Mondeo', 1998, 1, 5, 'C:\Users\сем. Маринови\Desktop\ІІ-А-група.jpeg', 'Bad', 0),
	('CA6315CC', 'Ford', 'Focus', 2005, 3, 5, 'C:\Users\сем. Маринови\Desktop\ІІ-А-група.jpeg', 'Super', 1)

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
	Id INT IDENTITY NOT NULL,
	DriverLicenceNumber VARCHAR(30) NOT NULL,
	FullName VARCHAR(50) NOT NULL,
	[Address] VARCHAR(150) NOT NULL,
	City VARCHAR(150),
	ZIPCode SMALLINT,
	Notes VARCHAR(MAX),
	CONSTRAINT PK_CustomerId PRIMARY KEY(Id)
)

INSERT INTO Customers(DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes) VALUES
	('peci345', 'Tosho Toshev', 'ul. Zavodska 8', NULL, 4400, NULL),
	('ABC345', 'Pesho Toshev', 'ul. Zavodska 9', 'Pazardzhik', 4400, 'sdfssf'),
	('peci345', 'Gosho Toshev', 'ul. Zavodska 10', NULL, 4400, NULL)

CREATE TABLE RentalOrders  
(
	Id INT IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
	CarId INT FOREIGN KEY REFERENCES Cars(Id),
	TankLevel FLOAT(2),
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT NOT NULL,
	StartDate DATETIME NOT NULL,
	EndDate DATETIME NOT NULL,
	TotalDays TINYINT NOT NULL,
	RateApplied FLOAT(2),
	TaxRate FLOAT(2),
	OrderStatus BIT NOT NULL,
	Notes VARCHAR(MAX),
	CONSTRAINT PK_RentalOrdersId PRIMARY KEY(Id)
)

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd,
	TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes) VALUES
	(1, 3, 2, NULL, 266487, 267100, 267100 - 266487, '06/15/2021', '06/19/2021', 4, 1.47, 9.00, 1, NULL),
	(2, 2, 3, 18.40, 26800, 27200, 27200 - 26800, '06/15/2021', '06/17/2021', 3, 2.11, 9.00, 1, NULL), 
	(3, 1, 1, 45, 4400, 5640, 5640 - 4400, '06/15/2021', '06/20/2021', 5, 4.1, 9.00, 1, NULL)

--DROP DATABASE CarRental
