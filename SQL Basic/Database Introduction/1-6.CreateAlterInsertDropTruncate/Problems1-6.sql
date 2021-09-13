CREATE DATABASE Minions

USE Minions

--Problem 1.	Create Database
CREATE TABLE Minions
(
	Id INT NOT NULL,
	[Name] VARCHAR(15) NOT NULL,
	Age INT
	CONSTRAINT PK_Id PRIMARY KEY(Id)
)

--Problem 2.	Create Tables
CREATE TABLE Towns
(
	Id INT NOT NULL,
	[Name] VARCHAR(30) NOT NULL,
	CONSTRAINT PK_TownId PRIMARY KEY(Id)
)

--Problem 3.	Alter Minions Table
ALTER TABLE Minions
	ADD TownId INT NOT NULL

ALTER TABLE Minions
	ADD FOREIGN KEY (TownId) REFERENCES Towns(Id)

--Problem 4.	Insert Records in Both Tables
INSERT INTO Towns (Id, [Name]) VALUES
	(1, 'Sofia'),
	(2, 'Plovdiv'),
	(3, 'Varna')

INSERT INTO Minions (Id, [Name], Age, TownId) VALUES
	(1, 'Kevin', 22, 1),
	(2, 'Bob', 15, 3),
	(3, 'Steward', NULL, 2)

--Problem 5.	Truncate Table Minions
TRUNCATE TABLE Minions

--Problem 6.	Drop All Tables

DROP TABLE Minions
DROP TABLE Towns


