--Problem 1.	Find Names of All Employees by First Name
SELECT FirstName, LastName FROM Employees
	WHERE FirstName LIKE 'SA%'

--Problem 2.	  Find Names of All employees by Last Name 
SELECT FirstName, LastName FROM Employees
	WHERE LastName LIKE '%ei%'

--Problem 3.	Find First Names of All Employees
SELECT FirstName FROM Employees
	WHERE DepartmentID IN (3, 10) AND
		DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005

--Problem 4.	Find All Employees Except Engineers
SELECT FirstName, LastName FROM Employees
	WHERE JobTitle NOT LIKE '%engineer%'

--Problem 5.	Find Towns with Name Length
SELECT [Name] FROM Towns
	WHERE LEN([Name]) IN (5, 6)
	ORDER BY [Name] ASC

--Problem 6.	 Find Towns Starting With
SELECT TownID, [Name] FROM Towns
	WHERE [Name] LIKE '[MKBE]%'
	ORDER BY [Name] ASC

--Problem 7.	 Find Towns Not Starting With
SELECT TownID, [Name] FROM Towns
	WHERE [Name] NOT LIKE '[RBD]%'
	ORDER BY [Name] ASC

--Problem 8.	Create View Employees Hired After 2000 Year
CREATE VIEW V_EmployeesHiredAfter2000 AS
	SELECT FirstName, LastName FROM Employees
	WHERE DATEPART(YEAR,HireDate) > 2000

--Problem 9.	Length of Last Name
SELECT FirstName, LastName FROM Employees
	WHERE LEN(LastName) = 5

--Problem 10.	Rank Employees by Salary

SELECT EmployeeID, FirstName, LastName, Salary, 
	DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID ASC) AS [Rank]
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000
	ORDER BY SALARY DESC

SELECT * FROM Employees
--Problem 11.	Find All Employees with Rank 2 *

SELECT * FROM
	(SELECT EmployeeID, FirstName, LastName, Salary, 
		DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID ASC) AS [Rank]
		FROM Employees
		WHERE Salary BETWEEN 10000 AND 50000) AS RANKED
	WHERE [Rank] = 2
	ORDER BY SALARY DESC

--Problem 12.	Countries Holding ‘A’ 3 or More Times
SELECT CountryName AS [Country Name], IsoCode AS [ISO Code] FROM Countries
	WHERE LEN(REPLACE(CountryName,'A','')) <= LEN(CountryName) - 3
	ORDER BY IsoCode

--SELECT CountryName AS 'Country Name', IsoCode AS 'ISO Code'
--	FROM Countries
--	WHERE CountryName LIKE '%A%A%A%'
--ORDER BY IsoCode

--Problem 13.	 Mix of Peak and River Names
SELECT PeakName, RiverName, LOWER(PeakName + SUBSTRING(RiverName, 2, 100)) AS Mix
	FROM Peaks
	JOIN Rivers ON LEFT(RiverName,1) = RIGHT(PeakName,1)
	ORDER BY Mix

--Problem 14.	Games from 2011 and 2012 year
SELECT TOP(50) [Name], FORMAT([Start],'yyyy-MM-dd') AS [Start]
FROM Games
	WHERE DATEPART(YEAR,[Start]) IN (2011, 2012) 
	ORDER BY [Start], [Name]

--Problem 15.	 User Email Providers
SELECT UserName, SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider]
FROM Users
	ORDER BY [Email Provider], Username

--Problem 16.	 Get Users with IPAdress Like Pattern
SELECT UserName, IpAddress FROM Users
	WHERE IpAddress LIKE '[0-9][0-9][0-9].1%.%[0-9][0-9][0-9]' --'___.1%.%.___'
	ORDER BY UserName

--Problem 17.	 Show All Games with Duration and Part of the Day
SELECT [Name] AS Game,
	CASE 
		WHEN DATEPART(HOUR,[Start]) >=0 AND DATEPART(HOUR,[Start]) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR,[Start]) >=12 AND DATEPART(HOUR,[Start]) < 18 THEN 'Afternoon'
		WHEN DATEPART(HOUR,[Start]) >=18 AND DATEPART(HOUR,[Start]) < 24 THEN 'Evening'
	END AS [Part of the Day], 

	CASE 
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration > 3 AND Duration <= 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		WHEN Duration IS NULL THEN 'Extra Long'
	END AS Duration
FROM Games
	ORDER BY [Name], Duration, [Part of the Day] 
	
--Problem 18.	 Orders Table
CREATE TABLE Orders
(
	Id INT IDENTITY,
	ProductName VARCHAR(50) NOT NULL,
	OrderDate DATETIME NOT NULL
)

INSERT INTO Orders VALUES
	('Butter', '2016-09-19 00:00:00.000'),
	('Milk', '2016-09-30 00:00:00.000'),
	('Cheese', '2016-09-04 00:00:00.000'),
	('Bread', '2015-12-20 00:00:00.000'),
	('Tomatoes', '2015-12-30 00:00:00.000')

SELECT 
	ProductName, 
	OrderDate,
	DATEADD(DAY, 3, OrderDate) AS [Pay Due],
	DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM Orders

--Problem 19.	 People Table

CREATE TABLE People
(
	Id INT IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[BirthDate] DATETIME NOT NULL
)

INSERT INTO People VALUES
	('Victor', '2000-12-07 00:00:00.000'),
	('Steven', '1992-09-10 00:00:00.000'),
	('Stephen', '1910-09-19 00:00:00.000'),
	('John', '2010-01-06 00:00:00.000')

SELECT [Name], 
	DATEDIFF(YEAR, BirthDate, GETDATE()) AS 'Age in Years',
	DATEDIFF(MONTH, BirthDate, GETDATE()) AS 'Age in Months',
	DATEDIFF(DAY, BirthDate, GETDATE()) AS [Age in Days],
	DATEDIFF(MINUTE, BirthDate, GETDATE()) AS [Age in Minutes]
FROM People

