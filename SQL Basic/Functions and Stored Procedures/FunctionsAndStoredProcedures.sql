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

