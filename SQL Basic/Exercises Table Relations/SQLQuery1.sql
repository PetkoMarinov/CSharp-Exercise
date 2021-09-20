--Problem 1.	One-To-One Relationship

CREATE TABLE Passports
(
	PassportID INT NOT NULL,
	PassportNumber VARCHAR(50),
	CONSTRAINT PK_PassportID PRIMARY KEY(PassportID)
)

CREATE TABLE Persons
(
	PersonId INT IDENTITY NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	Salary DECIMAL(10,2) NOT NULL,
	PassportID INT FOREIGN KEY REFERENCES Passports(PassportID) UNIQUE NOT NULL,
	CONSTRAINT PK_PersonId PRIMARY KEY(PersonId)
)

INSERT INTO Passports VALUES
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')

INSERT INTO Persons(FirstName, Salary, PassportID) VALUES
('Roberto', 43300.00, 102),
('Tom',	56100.00, 103),
('Yana', 60200.00, 101)

--Problem 2.	One-To-Many Relationship

CREATE TABLE Manufacturers
(
	ManufacturerID INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(30) NOT NULL,
	EstablishedOn DATETIME NOT NULL
)

CREATE TABLE Models
(
	ModelID INT IDENTITY(101,1) NOT NULL,
	[Name] VARCHAR(30),
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID) NOT NULL
	CONSTRAINT PK_ModelID PRIMARY KEY(ModelID)
)

INSERT INTO Manufacturers([Name], EstablishedOn) VALUES
	('BMW',	'07/03/1916'),
	('Tesla', '01/01/2003'),
	('Lada', '01/05/1966')

INSERT INTO Models([Name], ManufacturerID) VALUES
	('X1', 1),
	('i6', 1),
	('Model S',	2),
	('Model X',	2),
	('Model 3',	2),
	('Nova', 3)

	--Problem 3.	Many-To-Many Relationship

CREATE TABLE Students
(
	StudentID INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(20)
)

INSERT INTO Students([Name]) VALUES
	('Mila'),('Toni'),('Ron')

CREATE TABLE Exams
(
	ExamID INT IDENTITY(101,1) PRIMARY KEY,
	[Name] VARCHAR(20)
)

INSERT INTO Exams([Name]) VALUES
	('SpringMVC'),('Neo4j'),('Oracle 11g')

CREATE TABLE StudentsExams
(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	ExamID INT FOREIGN KEY REFERENCES Exams(ExamID)
	CONSTRAINT PK_StudentsExams PRIMARY KEY(StudentID, ExamID),
)

INSERT INTO StudentsExams(StudentID, ExamID) VALUES
	(1,	101),
	(1,	102),
	(2,	101),
	(3,	103),
	(2,	102),
	(2,	103)

--Problem 4.	Self-Referencing 

CREATE TABLE Teachers
(
	TeacherID INT IDENTITY(101,1) PRIMARY KEY,
	[Name] VARCHAR(30),
	ManagerID INT REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers VALUES      
	('John', NULL),
    ('Maya', 106),
    ('Silvia', 106),
    ('Ted', 105),
    ('Mark', 101),
    ('Greta', 101)

--Problem 5.	Online Store Database

CREATE DATABASE OnlineStore
GO
USE OnlineStore

CREATE TABLE Cities
(
	CityID INT NOT NULL,
	[Name] VARCHAR(50),
	CONSTRAINT PK_CityID PRIMARY KEY(CityID)
)

CREATE TABLE Customers
(
	CustomerID INT,
	[Name] VARCHAR(50) NOT NULL,
	Birthday DATE,
	CityID INT FOREIGN KEY REFERENCES Cities(CityID) NOT NULL,
	CONSTRAINT PK_CustomerID PRIMARY KEY(CustomerID)
)

CREATE TABLE Orders
(
	OrderID INT,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
	CONSTRAINT PK_OrderID PRIMARY KEY(OrderID)
)

CREATE TABLE ItemTypes
(
	ItemTypeID INT,
	[Name] VARCHAR(50) NOT NULL,
	CONSTRAINT PK_ItemTypeID PRIMARY KEY(ItemTypeID)
)

CREATE TABLE Items
(
	ItemID INT,
	[Name] VARCHAR(50) NOT NULL,
	ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID),
	CONSTRAINT PK_ItemID PRIMARY KEY(ItemID)
)

CREATE TABLE OrderItems
(
	OrderID INT REFERENCES Orders(OrderID) NOT NULL,
	ItemID INT REFERENCES Items(ItemID) NOT NULL,
	PRIMARY KEY(OrderID, ItemID)
)

--Problem 6.	University Database

CREATE TABLE Majors
(
	MajorID INT,
	[Name] VARCHAR(50) NOT NULL,
	CONSTRAINT PK_MajorID PRIMARY KEY(MajorID)
)

CREATE TABLE Students
(
	StudentID INT,
	StudentNumber VARCHAR(50) NOT NULL,
	StudentName VARCHAR(50) NOT NULL,
	MajorID INT,
	CONSTRAINT FK_MajorID FOREIGN KEY(MajorID) REFERENCES Majors(MajorID),
	CONSTRAINT PK_StudentID PRIMARY KEY(StudentID)
)

CREATE TABLE Payments
(
	PaymentID INT,
	PaymentDate DATETIME NOT NULL,
	PaymentAmount DECIMAL NOT NULL,
	StudentID INT,
	CONSTRAINT FK_StudentID FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
	CONSTRAINT PK_PaymentID PRIMARY KEY(PaymentID)
)

CREATE TABLE Subjects
(
	SubjectID INT,
	[SubjectName] VARCHAR(50) NOT NULL,
	CONSTRAINT PK_SubjectID PRIMARY KEY(SubjectID)
)

CREATE TABLE Agenda
(
	StudentID INT,
	SubjectID INT,
	CONSTRAINT PK_StudentID_SubjectID PRIMARY KEY(StudentID,SubjectID),
	CONSTRAINT FK_Agenda_StudentID FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
	CONSTRAINT FK_Agenda_SubjectID FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID)
)

--Problem 9.	*Peaks in Rila

SELECT MountainRange, PeakName, Elevation FROM Peaks
  JOIN Mountains ON 
    Mountains.Id = Peaks.MountainId
	WHERE MountainRange = 'Rila'
	ORDER BY Elevation DESC


