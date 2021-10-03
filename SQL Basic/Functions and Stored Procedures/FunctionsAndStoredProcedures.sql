--1.	Queries for SoftUni Database
--1.	Employees with Salary Above 35000
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
SELECT FirstName, LastName
	FROM Employees
	WHERE Salary > 35000

--2.	Employees with Salary Above Number
CREATE PROC usp_GetEmployeesSalaryAboveNumber(@number DECIMAL(18,4))
AS
SELECT FirstName, LastName
	FROM Employees
	WHERE Salary >= @number

--3.	Town Names Starting With
CREATE PROC usp_GetTownsStartingWith (@startLetter VARCHAR(10))
AS
SELECT [Name]
	FROM Towns
	WHERE [Name] LIKE @startLetter + '%'

--4.	Employees from Town
CREATE PROC usp_GetEmployeesFromTown(@townName VARCHAR(50))
AS
SELECT FirstName, LastName
	FROM Employees e
	LEFT JOIN Addresses a ON e.AddressID = a.AddressID
	LEFT JOIN Towns t ON a.TownID = t.TownID
	WHERE t.Name = @townName

	EXEC usp_GetEmployeesFromTown 'Sofia'

DROP PROC usp_GetEmployeesFromTown
SELECT * FROM Addresses

--5.	Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @result VARCHAR(30)
	IF @salary < 30000 SET @result = 'Low'
	ELSE IF @salary BETWEEN 30000 AND 50000 SET @result = 'Average'
	ELSE IF @salary > 50000 SET @result = 'High'
	RETURN @result;
END
--Ñ CASE WHEN
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @result VARCHAR(30)
	SET @result =
	CASE WHEN @salary < 30000 THEN 'Low'
		WHEN @salary BETWEEN 30000 AND 50000 THEN 'Average'
		WHEN @salary > 50000 THEN 'High'
	END
	RETURN @result;
END

--6.	Employees by Salary Level
CREATE PROC usp_EmployeesBySalaryLevel(@salaryLevel VARCHAR(10))
AS
SELECT FirstName, LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel

--7.	Define Function
--CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50))
--RETURNS BIT
--AS
--BEGIN
--	DECLARE @isTrue BIT
--	DECLARE @i TINYINT, @j TINYINT

--	WHILE (@i <= LEN(@setOfLetters))
--	BEGIN
--		SET @j = 0
--		WHILE (@j <= LEN(@word))
--		BEGIN
--			IF SUBSTRING(@word,@j,1) = SUBSTRING(@setOfLetters,@i,1)
--				BEGIN
--					SET @isTrue = 1;
--					BREAK;
--				END
--			ELSE SET @isTrue = 0;
--			SET @j = @j + 1
--		END
--		SET @i = @i + 1 
--	END
--	RETURN @isTrue
--END

--------
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX)) 
RETURNS BIT
AS
BEGIN
	DECLARE @Count INT = 1
	DECLARE @Letter VARCHAR(1)

	WHILE (LEN(@word) >= @Count)
	BEGIN
		SET @Letter = SUBSTRING(@word, @Count, 1)

		IF @setOfLetters NOT LIKE '%' + @Letter + '%'
			RETURN 0

		SET @Count += 1
	END
	RETURN 1 
END

