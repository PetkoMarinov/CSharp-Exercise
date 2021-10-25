USE Minions

CREATE TABLE People
(
	PersonID INT IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(2000),
	Height FLOAT(2),
	[Weight] FLOAT(2),
	Gender BIT NOT NULL,
	Birthdate DATETIME NOT NULL,
	Biography NVARCHAR(MAX)
	CONSTRAINT PK_PersonID PRIMARY KEY(PersonID)
)

INSERT INTO People
([Name], Height, [Weight], Gender, Birthdate, Biography)
VALUES
('Gosho', 1.78, 79.31, 1, '5/15/2021','abc'),
('Iva', 1.81, 82.31, 0, '5/16/2021','рст'),
('Mitko', 1.60, 65.12, 1, '6/15/2021','abc1'),
('Pesho', 1.85, 84.31, 1, '7/15/2021','a_*'),
('Tosho',2.02, 111.31, 1, '8/15/2021','sdsdf')


