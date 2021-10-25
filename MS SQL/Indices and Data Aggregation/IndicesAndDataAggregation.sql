SELECT * FROM WIZzARDDEPOSITS

--1. Records’ Count
SELECT COUNT(*) AS COUNT FROM WizzardDeposits

--2. Longest Magic Wand
SELECT MAX(w.MagicWandSize) AS LongestMagicWand
	FROM WizzardDeposits w

--3. Longest Magic Wand Per Deposit Groups
SELECT DepositGroup, MAX(w.MagicWandSize) AS LongestMagicWand
	FROM WizzardDeposits w
	GROUP BY w.DepositGroup

--4. * Smallest Deposit Group Per Magic Wand Size
SELECT TOP (2) w.DepositGroup
	FROM WizzardDeposits w
	GROUP BY w.DepositGroup
	ORDER BY AVG(w.MagicWandSize)

--5. Deposits Sum
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
	GROUP BY DepositGroup

--6. Deposits Sum for Ollivander Family
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup
	
--7. Deposits Filter
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits w
	WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup
	HAVING SUM(DepositAmount) < 150000
	ORDER BY TotalSum DESC

--8.  Deposit Charge
SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge
	FROM WizzardDeposits
	GROUP BY DepositGroup, MagicWandCreator
	ORDER BY MagicWandCreator, DepositGroup

--9. Age Groups
SELECT sub.AgeGroup, COUNT(*) AS WizardCount FROM
	(SELECT  
			CASE WHEN Age > 0 AND Age <= 10 THEN '[0-10]' 
				  WHEN Age > 10 AND Age <= 20 THEN '[11-20]' 
				  WHEN Age > 20 AND Age <= 30 THEN '[21-30]'
				  WHEN Age > 30 AND Age <= 40 THEN '[31-40]'
				  WHEN Age > 40 AND Age <= 50 THEN '[41-50]'
				  WHEN Age > 50 AND Age <= 60 THEN '[51-60]'
				  WHEN Age > 60 THEN '[61+]'
			END AS AgeGroup
		FROM WizzardDeposits w) AS sub
	GROUP BY AgeGroup

--10. First Letter
SELECT LEFT(FirstName,1) AS FirstLetter
	FROM WizzardDeposits 
	WHERE DepositGroup = 'Troll Chest' 
	GROUP BY LEFT(FirstName,1)

--11. Average Interest 
SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) AS AverageInterest
	FROM WizzardDeposits
	WHERE YEAR(DepositStartDate) > 1984
	Group BY DepositGroup, IsDepositExpired
	ORDER BY DepositGroup DESC, IsDepositExpired

--12. * Rich Wizard, Poor Wizard
SELECT ABS(SUM([Difference])) AS 'SumDifference' 
	FROM (SELECT h.FirstName AS [Host Wizard], h.DepositAmount AS 'Host Wizard Deposit',
			g.FirstName AS [Guest Wizard], g.DepositAmount AS [Guest Wizard Deposit],
			g.DepositAmount - h.DepositAmount AS [Difference]
		FROM WizzardDeposits h
		LEFT JOIN WizzardDeposits g ON h.Id = g.Id - 1) AS sub

--13. Departments Total Salaries
SELECT DepartmentID, SUM(Salary) AS TotalSalary
	FROM Employees
	GROUP BY DepartmentID
	ORDER BY DepartmentID

--14. Employees Minimum Salaries
SELECT DepartmentID, MIN(Salary) AS MinimumSalary
	FROM Employees
	WHERE DepartmentID IN (2, 5 , 7) AND Year(HireDate) > 1999
	GROUP BY DepartmentID
	ORDER BY DepartmentID

--15. Employees Average Salaries
SELECT *
	INTO NewSalaries
	FROM Employees
	WHERE Salary > 30000

DELETE 
	FROM NewSalaries 
	WHERE ManagerID = 42

UPDATE NewSalaries
	SET Salary += 5000
	WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary
	FROM NewSalaries
	GROUP BY DepartmentID

--16. Employees Maximum Salaries
SELECT DepartmentID, MAX(Salary) AS MaxSalary
	FROM Employees
	GROUP BY DepartmentID
	HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--17. Employees Count Salaries
SELECT COUNT(*) AS 'Count'
	FROM Employees
	WHERE ManagerID IS NULL

--18. *3rd Highest Salary
SELECT DepartmentID, Salary AS ThirdHighestSalary
	FROM (SELECT DepartmentID, Salary, 
				DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Rank]
			FROM Employees) as sub
	WHERE [Rank] = 3
	GROUP BY DepartmentID, Salary

--19. **Salary Challenge
SELECT TOP(10) e.FirstName, e.LastName, e.DepartmentID
	FROM Employees e
		LEFT JOIN 
		(SELECT e.DepartmentID, AVG(e.Salary) AS AverageSalary
			FROM Employees e
			GROUP BY e.DepartmentID) AS [Avg]
	  ON e.DepartmentID = [Avg].DepartmentID
   WHERE e.Salary > [Avg].AverageSalary
   ORDER BY DepartmentID