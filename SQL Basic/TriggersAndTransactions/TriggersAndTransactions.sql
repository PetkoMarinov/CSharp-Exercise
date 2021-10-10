
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
	DECLARE @oldSum = (SELECT i.OldSum FROM inserted i)
	DECLARE @newSum = (SELECT i.NewSum FROM inserted i)

	DECLARE @body = 'On {date} your balance was changed from 'CAST(i.OldSum AS VARCHAR(50)) + ' to ' + CAST(i.NewSum AS VARCHAR(50)) + '.'

	INSERT INTO NotificationEmails(Recipient, [Subject], Body) VALUES
	(@recipient, @subject, @body)
END

DROP TABLE Logs
DROP TRIGGER tr_NotificationEmails

INSERT INTO Logs(AccountId, NewSum) VALUES
	(9, 9988)

SELECT * FROM NotificationEmails

SELECT * FROM Logs