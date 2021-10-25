USE Minions

--Problem 8.	Create Table Users

CREATE TABLE Users
(	UserID BIGINT IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(900),
	LastLoginTime DATETIME,
	IsDeleted BIT
	CONSTRAINT PK_UserID PRIMARY KEY(UserID)
)

INSERT INTO Users
(Username, [Password], LastLoginTime, IsDeleted) VALUES
('Gosho', 'abcef', '5/15/2021',0),
('Iva', 'abvf1', '5/16/2021',1),
('Mitko', 'sdf1ddsf', '6/15/2021',0),
('Pesho', '32423', '7/15/2021',0),
('Tosho','ASerr', '8/15/2021',0)

--Problem 9.	Change Primary Key

ALTER TABLE Users
DROP CONSTRAINT PK_UserID

ALTER TABLE Users
ADD CONSTRAINT PK_IdUsername PRIMARY KEY (UserId,Username);

--Problem 10.	Add Check Constraint

ALTER TABLE Users
ADD CHECK (LEN(Password) >= 5)

--Problem 11.	Set Default Value of a Field
ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime

--Problem 12.	Set Unique Field

ALTER TABLE Users
DROP CONSTRAINT PK_IdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_UserId PRIMARY KEY (UserId)

ALTER TABLE Users
ADD CONSTRAINT Unique_Username UNIQUE (Username),
	CHECK (LEN(Username) >= 3)  -- пак си е констреинт, но не се наименова автоматично
