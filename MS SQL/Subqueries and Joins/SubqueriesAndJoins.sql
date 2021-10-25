--1.	Employee Address
SELECT TOP(5) e.EmployeeId, e.JobTitle, e.AddressId, a.AddressText
	FROM Employees AS e
	LEFT JOIN Addresses AS a ON e.AddressID = a.AddressID  	
	ORDER BY e.AddressId

--2.	Addresses with Towns
SELECT TOP(50) e.FirstName, e.LastName, t.[Name] AS Town, a.AddressText
	FROM Employees AS e
	LEFT JOIN Addresses AS a ON e.AddressID = a.AddressID
	LEFT JOIN Towns AS t ON a.TownID = t.TownID
	ORDER BY e.FirstName, e.LastName  

--3.	Sales Employee
SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name] AS DepartmentName
	FROM Employees e
	LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'
	ORDER BY e.EmployeeID

--4.	Employee Departments
SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary,	d.[Name] AS DepartmentName
	FROM Employees e
	LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE e.Salary > 15000
	ORDER BY e.DepartmentID

--5.	Employees Without Project
SELECT TOP(3) e.EmployeeID, e.FirstName
	FROM Employees e
		LEFT JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
	WHERE ep.ProjectID IS NULL
	ORDER BY e.EmployeeID

--6.	Employees Hired After
SELECT e.FirstName, e.LastName, e.HireDate,	d.[Name] AS DeptName
	FROM Employees e
		LEFT JOIN Departments d ON e.DepartmentID  = d.DepartmentID
	WHERE e.HireDate > '01/01/1999' AND	
		d.Name IN ('Sales', 'Finance')
	ORDER BY e.HireDate

--7.	Employees with Project

SELECT TOP(5) e.EmployeeID, e.FirstName, p.Name AS ProjectName
	FROM Employees e
		LEFT JOIN EmployeesProjects ep ON e.EmployeeID  = ep.EmployeeID
		LEFT JOIN Projects p ON ep.ProjectID = p.ProjectID
	WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
	ORDER BY e.EmployeeID

--8.	Employee 24

SELECT e.EmployeeID, e.FirstName, 
	CASE 
		WHEN YEAR(p.StartDate) >= 2005 THEN NULL
		ELSE p.Name 	
	END AS ProjectName
FROM Employees e
		LEFT JOIN EmployeesProjects ep ON e.EmployeeID  = ep.EmployeeID
		LEFT JOIN Projects p ON ep.ProjectID = p.ProjectID
	WHERE e.EmployeeID = 24

--9.	Employee Manager
-- e.ManagerID става em.EmployeeID съответно на емплоито му връащаме името 
SELECT e.EmployeeID, e.FirstName, e.ManagerID,em.FirstName AS ManagerName
	FROM Employees e
		LEFT JOIN Employees em ON e.ManagerID = em.EmployeeID
	WHERE e.ManagerID IN (3, 7)
	ORDER BY e.EmployeeID

--10. Employee Summary
SELECT TOP(50) e.EmployeeID, e.FirstName + ' ' + e.Lastname AS EmployeeName,
	em.FirstName + ' ' + em.Lastname AS ManagerName,	d.[Name] AS DepartmentName
	FROM Employees e
		LEFT JOIN Employees em ON e.ManagerID = em.EmployeeID
		LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
	ORDER BY e.EmployeeID

--11. Min Average Salary
SELECT MIN([Average Salary]) AS MinAverageSalary FROM 
	(SELECT AVG(e.Salary) AS [Average Salary]
		FROM Employees e
		GROUP BY e.DepartmentID) AS s

--12. Highest Peaks in Bulgaria
SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
	FROM MountainsCountries mc
		LEFT JOIN Mountains m ON mc.MountainId = m.Id
		LEFT JOIN Peaks p ON m.Id = p.MountainId
	WHERE CountryCode = 'BG' AND p.Elevation > 2835
	ORDER BY p.Elevation DESC

--13. Count Mountain Ranges

SELECT CountryCode, COUNT(MountainId) AS MountainRanges
	FROM MountainsCountries
	WHERE CountryCode IN ('US', 'RU', 'BG')
	GROUP BY CountryCode
	
--14. Countries with Rivers
SELECT TOP (5) c.CountryName, r.RiverName
	FROM Countries c
		LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
		LEFT JOIN Rivers r ON cr.RiverId = r.Id
	WHERE c.ContinentCode = 'AF'
	ORDER BY CountryName ASC

--15. *Continents and Currencies
SELECT ContinentCode, CurrencyCode, CurrencyUsage
	FROM (SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) AS CurrencyUsage,
		DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY Count(CurrencyCode) DESC)
		AS [Rank]
		FROM Countries
		GROUP BY ContinentCode, CurrencyCode) AS Ranked 
		WHERE [Rank] = 1 AND CurrencyUsage > 1
		ORDER BY ContinentCode

--16. Countries Without Any Mountains
SELECT COUNT(c.CountryName) - COUNT(mc.MountainId) AS [COUNT]
	FROM Countries c
	LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode

--17. Highest Peak and Longest River by Country
SELECT TOP(5) 
		c.CountryName, MAX(p.Elevation) AS HighestPeakElevation,
		MAX(r.[Length]) AS LongestRiverLength
	FROM Countries c
		LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
		LEFT JOIN Peaks p ON mc.MountainId = p.MountainId
		LEFT JOIN CountriesRivers cr ON cr.CountryCode = c.CountryCode
		LEFT JOIN Rivers r ON cr.RiverId = r.Id
	GROUP BY c.CountryName
	ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, CountryName

--18. Highest Peak Name and Elevation by Country

SELECT TOP (5) CountryName,
		ISNULL(PeakName, '(no highest peak)') AS [Highest Peak Name], 
		ISNULL(HighestPeakElevation, 0) AS [Highest Peak Elevation],
		ISNULL(MountainRange, '(no mountain)') AS [Mountain]
	FROM
		(SELECT c.CountryName,
			MAX(p.Elevation) AS HighestPeakElevation, 
			m.MountainRange, p.PeakName,
			DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY MAX(p.Elevation) DESC) AS [Rank]
		FROM Countries c
			LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
			LEFT JOIN Mountains m ON mc.MountainId = m.Id
			LEFT JOIN Peaks p ON m.Id = p.MountainId
		GROUP BY c.CountryName, m.MountainRange, p.PeakName) AS sub
		WHERE [Rank] = 1
	ORDER BY sub.CountryName, [Highest Peak Name]

	

	--EXEC sp_fkeys 'Rivers'


