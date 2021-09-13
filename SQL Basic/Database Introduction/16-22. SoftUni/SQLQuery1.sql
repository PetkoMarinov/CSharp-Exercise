CREATE DATABASE SoftUni

Go

USE SoftUni

CREATE TABLE Towns
(
	Id INT IDENTITY NOT NULL,
	[Name] VARCHAR(30) NOT NULL,
	CONSTRAINT PK_TownId PRIMARY KEY(Id)
)

INSERT INTO Towns([Name]) VALUES
	('Sofia'),
	('Plovdiv'),
	('Varna'),
	('Burgas')

CREATE TABLE Addresses
(
	Id INT IDENTITY NOT NULL,
	AddressText VARCHAR(100) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id),
	CONSTRAINT PK_AddressId PRIMARY KEY(Id)
)

CREATE TABLE Departments
(
	Id INT IDENTITY NOT NULL,
	[Name] VARCHAR(30) NOT NULL,
	CONSTRAINT PK_DepartmentId PRIMARY KEY(Id)
)

INSERT INTO Departments([Name]) VALUES
	('Engineering'),
	('Sales'),
	('Marketing'),
	('Software Development'),
	('Quality Assurance')

CREATE TABLE Employees
(
	Id INT IDENTITY NOT NULL,
	FirstName VARCHAR(20) NOT NULL,
	MiddleName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	JobTitle VARCHAR(20) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
	HireDate VARCHAR(10) NOT NULL,
	Salary FLOAT(2) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id),
	CONSTRAINT PK_EmployeeId PRIMARY KEY(Id)
)

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate,
	Salary) VALUES
	('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '01/02/2013', 3500.00),
	('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '02/03/2004', 4000.00),
	('Maria ', 'Petrova', 'Ivanova', 'Intern', 5, '28/08/2016', 525.25),
	('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '09/12/2007', 3000.00),
	('Peter', 'Pan', 'Pan', 'Intern', 3, '28/08/2016', 599.88)

	--Problem 19.	Basic Select All Fields
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

--Problem 20.	Basic Select All Fields and Order Them
SELECT * FROM Towns
ORDER BY [Name]

SELECT * FROM Departments
ORDER BY [Name]

SELECT * FROM Employees
ORDER BY Salary DESC

--Problem 21.	Basic Select Some Fields
SELECT [Name] FROM Towns
ORDER BY [Name]

SELECT [Name] FROM Departments
ORDER BY [Name]

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC

--Problem 22.	Increase Employees Salary

UPDATE Employees
	SET Salary = Salary + Salary * 0.10

SELECT Salary FROM Employees
ORDER BY Salary DESC

--DROP DATABASE SoftUni