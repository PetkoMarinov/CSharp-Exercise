CREATE DATABASE [Service]

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	[Name] VARCHAR(50),
	Birthdate DATETIME,
	Age	INT CHECK(Age BETWEEN 14 and 110),
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATETIME,
	Age INT CHECK(Age BETWEEN 18 and 110),
	DepartmentId INT REFERENCES Departments(Id)
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE [Status]
(
	Id INT PRIMARY KEY IDENTITY,
	[Label] VARCHAR(30) NOT NULL,
)

CREATE TABLE Reports
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT REFERENCES Categories(Id) NOT NULL,
	StatusId INT REFERENCES [Status](Id) NOT NULL,
	OpenDate DATETIME NOT NULL,
	CloseDate DATETIME,
	[Description] VARCHAR(200) NOT NULL,
	UserId INT REFERENCES Users(Id) NOT NULL,
	EmployeeId INT REFERENCES Employees(Id)
)

--3.	Update
--Update the CloseDate with the current date of all reports, which don't have CloseDate. 
UPDATE Reports
	SET CloseDate = GETDATE()
	WHERE CloseDate IS NULL

--4.	Delete
--Delete all reports who have a Status 4.
DELETE FROM Reports
	WHERE StatusId = 4

DELETE FROM [Status]
	WHERE Id = 4

--5.	Unassigned Reports
--Find all reports that don't have an assigned employee. 
--Order the results by OpenDate in ascending order, then by description ascending.
--OpenDate must be in format - 'dd-MM-yyyy'
SELECT [Description], OpenDate FROM
	(SELECT [Description], r.OpenDate AS oldOpenDate, 
		CONVERT(VARCHAR, OpenDate,105) AS OpenDate
		FROM Reports r
		WHERE EmployeeId IS NULL) AS temp
	ORDER BY oldOpenDate, [Description]

--6.	Reports & Categories
--Select all descriptions from reports, which have category.
--Order them by description (ascending) then by category name (ascending).
SELECT r.[Description], c.[Name] AS CategoryName
	FROM Reports r
	JOIN Categories c ON c.Id = r.CategoryId
	WHERE CategoryId IS NOT NULL
	ORDER BY [Description], c.[Name]

--7.	Most Reported Category
--Select the top 5 most reported categories and order them by the number of 
--reports per category in descending order and then alphabetically by name.

SELECT TOP(5) c.Name AS CategoryName, COUNT(r.CategoryId) AS ReportsNumber
	FROM Reports r
	JOIN Categories c ON c.Id = r.CategoryId
	GROUP BY c.Name
	ORDER BY [ReportsNumber] DESC, c.[Name]

--8.	Birthday Report
--Select the user's username and category name in all reports in which users 
--have submitted a report on their birthday. Order them by username (ascending) 
--and then by category name (ascending).

SELECT u.Username, c.[Name] AS CategoryName
	FROM Reports r
	JOIN Users u ON u.Id = r.UserId
	JOIN Categories c ON c.Id = r.CategoryId
	WHERE DAY(r.OpenDate) = DAY(u.Birthdate) AND
		  MONTH(r.OpenDate) = MONTH(u.Birthdate)
	ORDER BY Username, CategoryName

--9.	Users per Employee 
--Select all employees and show how many unique users each of them has served to.
--Order by users count  (descending) and then by full name (ascending).

SELECT CONCAT_WS(' ',e.FirstName, e.LastName) AS FullName,
		COUNT(DISTINCT(r.UserId)) AS UsersCount
	FROM Employees e
	LEFT JOIN Reports r ON r.EmployeeId = e.Id 
	GROUP BY CONCAT_WS(' ',e.FirstName, e.LastName)
	ORDER BY UsersCount DESC, FullName

--10.	Full Info

--Select all info for reports along with employee first name and last name 
--(concataned with space), their department name, category name, report description,
--open date, status label and name of the user. Order them by first name (descending),
--last name (descending), department (ascending), category (ascending), 
--description (ascending), open date (ascending), status (ascending) and user (ascending).
--Date should be in format - dd.MM.yyyy
--If there are empty records, replace them with 'None'.

SELECT e.FirstName + ' ' + e.LastName AS Employee, d.Name AS Department,
	c.Name AS Category, r.Description, r.OpenDate, st.Label, u.Name
	FROM Employees e
	LEFT JOIN Reports r ON r.EmployeeId = e.Id
	LEFT JOIN Users u On u.Id = r.UserId
	LEFT JOIN Categories c ON c.Id = r.CategoryId
	LEFT JOIN Departments d ON d.Id = e.DepartmentId
	LEFT JOIN Status st ON st.Id = r.StatusId
	GROUP BY e.FirstName + ' ' + e.LastName
	ORDER BY e.FirstName DESC, e.LastName DESC, d.Name, c.Name, r.Description, r.OpenDate,
				st.Label, u.Name

	SELECT * FROM Categories
	SELECT * FROM Reports
	SELECT * FROM Users
	SELECT * FROM Employees