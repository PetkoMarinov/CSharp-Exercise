GO

Drop database Minions

CREATE DATABASE Minions
USE Minions

CREATE TABLE Minions (
	Id INT NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	Age INT
	)

CREATE TABLE Towns (
	Id INT NOT NULL,
	[Name] NVARCHAR(50) 
)

ALTER TABLE Minions
	ADD CONSTRAINT PK_ID
		PRIMARY KEY(ID)

ALTER TABLE Towns
	ADD CONSTRAINT PK_TownID
		PRIMARY KEY(ID)

ALTER TABLE Minions ADD TownId INT;

ALTER TABLE Minions
ADD CONSTRAINT FK_TownID FOREIGN KEY(TownId)
REFERENCES Towns(ID);

INSERT INTO Towns(ID,[Name]) VALUES
	(1, 'Sofia'),
	(2,'Plovdiv'),
	(3,'Varna')

INSERT INTO Minions(Id,[Name],Age,TownId) VALUES
(1,'Kevin', 22,1),
(2,'Bob', 15,3),
(3,'Steward',NULL, 2)

GO

TRUNCATE TABLE Minions

DROP TABLE Minions
DROP TABLE Towns

CREATE TABLE People (
	Id BIGINT IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX)
		CHECK (DATALENGTH(Picture) <= 2097152),
	Height REAL
)

--SELECT * FROM Minions
SELECT * FROM People


