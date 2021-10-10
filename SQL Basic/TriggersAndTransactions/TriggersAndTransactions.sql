
--1. Create Table Logs
CREATE TABLE Logs
(
	LogId INT IDENTITY,
	AccountId INT,
	OldSum MONEY,
	NewSum MONEY,
)

CREATE TRIGGER tr_AddToLogsOnAmountUpdate
	ON Accounts FOR UPDATE AS
	INSERT INTO Logs(AccountId, OldSum, NewSum)
	SELECT i.Id, d.Balance, i.Balance
		FROM inserted i
		JOIN deleted d ON i.Id = d.Id
		WHERE i.Balance != d.Balance

--2.	Create Table Emails
CREATE TABLE NotificationEmails
(
	LogId INT IDENTITY,
	Recipient INT,
	[Subject] VARCHAR(MAX),
	Body VARCHAR(MAX)
)

CREATE TRIGGER tr_NotificationEmails
ON Logs FOR INSERT AS
BEGIN
	DECLARE @recipient INT = (SELECT i.AccountId FROM inserted i)
	DECLARE @subject VARCHAR(MAX) = 'Balance change for account: ' + 
		CAST(@recipient AS VARCHAR(10))
	DECLARE @oldSum DECIMAL(15,2) = (SELECT i.OldSum FROM inserted i)
	DECLARE @newSum DECIMAL(15,2) = (SELECT i.NewSum FROM inserted i)
	DECLARE @body VARCHAR(MAX) = 'On ' + CAST(GETDATE() AS VARCHAR(50)) 
		+ ' your balance was changed from ' 
		+ CAST(@oldSum AS VARCHAR(50)) + ' to ' + CAST(@newSum AS VARCHAR(50)) + '.'

	INSERT INTO NotificationEmails(Recipient, [Subject], Body) VALUES
	(@recipient, @subject, @body)
END

--3.	Deposit Money
CREATE PROC usp_DepositMoney (@accountsId INT, @moneyAmount DECIMAL(15,4))
AS
BEGIN TRANSACTION
	IF (@moneyAmount < 0 OR @moneyAmount IS NULL)
		BEGIN
			ROLLBACK
			RAISERROR('Invalid amount of money', 15, 1)
			RETURN
		END
	
	IF (NOT EXISTS(
		SELECT a.Id FROM Accounts a
		WHERE a.Id = @accountsId) OR @accountsId IS NULL)
		BEGIN
			ROLLBACK
			RAISERROR('Invalid Id', 15, 1)
			RETURN
		END

	UPDATE Accounts
		SET Balance = Balance + @moneyAmount
		WHERE Id = @accountsId
COMMIT

-- 4.	Withdraw Money
CREATE PROC usp_WithdrawMoney (@accountId INT, @moneyAmount DECIMAL(15,4)) 
AS
BEGIN TRANSACTION
	IF (@moneyAmount < 0 OR @moneyAmount IS NULL)
		BEGIN
			ROLLBACK
			RAISERROR('Invalid amount of money', 15, 1)
			RETURN
		END
	
	IF (NOT EXISTS(
		SELECT a.Id FROM Accounts a
		WHERE a.Id = @accountId) OR @accountId IS NULL)
		BEGIN
			ROLLBACK
			RAISERROR('Invalid Id', 15, 1)
			RETURN
		END

	IF (SELECT a.Balance FROM Accounts a
		WHERE a.Id = @accountId) >= @moneyAmount
		BEGIN
			UPDATE Accounts
				SET Balance = Balance - @moneyAmount
				WHERE Id = @accountId
		END
	ELSE 
		BEGIN
			ROLLBACK
			RAISERROR('Balance in not enough', 15, 1)
			RETURN
		END
COMMIT

--5.	Money Transfer
CREATE PROC usp_TransferMoney (@senderId INT, @receiverId INT, @amount DECIMAL(15,4)) 
AS
BEGIN TRANSACTION
	EXEC usp_WithdrawMoney @senderId, @amount

	IF (SELECT a.Balance FROM Accounts a
		WHERE a.Id = @senderId) >= @amount
		BEGIN
			EXEC usp_DepositMoney @receiverId, @amount
		END
COMMIT

--8.	Employees with Three Projects

CREATE PROC usp_AssignProject(@emloyeeId INT, @projectId INT)
AS
BEGIN TRANSACTION
	DECLARE @projects INT
	SET @projects = (SELECT COUNT(*) FROM EmployeesProjects ep
		WHERE ep.EmployeeID = @emloyeeId)

	DECLARE @employeeExists BIT
	SET @employeeExists = (CASE WHEN @projects > 0 THEN 1
								ELSE 0
						   END)
			
	IF (@projects => 3)
		BEGIN
			ROLLBACK
			RAISERROR('The employee has too many projects!', 16, 1)
			RETURN
		END
	ELSE
		BEGIN
			INSERT INTO EmployeesProjects(EmployeeID, ProjectID) VALUES
			(@emloyeeId, @projectId)
		END
COMMIT

SELECT * FROM EmployeesProjects 
WHERE EmployeeID = 6

EXEC usp_AssignProject 2, 1

DROP PROC usp_AssignProject

CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN TRANSACTION
	DECLARE @EmployeesProjects INT

	SET @EmployeesProjects = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID = 2)

	IF (@EmployeesProjects >= 3)
	BEGIN
		RAISERROR ('The employee has too many projects!', 16, 1)
		ROLLBACK
	END

	INSERT INTO EmployeesProjects
	VALUES (@emloyeeId, @projectID)
COMMIT

EXEC usp_AssignProject 2,1
EXEC usp_AssignProject 2,2
EXEC usp_AssignProject 2,3
BEGIN TRY  
 EXEC usp_AssignProject 2,4
END TRY  
BEGIN CATCH  
   SELECT error_message()
END CATCH;
