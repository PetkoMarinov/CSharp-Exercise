CREATE DATABASE CigarShop
USE CigarShop

DROP DATABASE CigarShop

CREATE TABLE Sizes
(
	Id INT PRIMARY KEY IDENTITY,
	[Length] INT CHECK([Length] BETWEEN 10 AND 25) NOT NULL,
	RingRange DECIMAL(3, 2) CHECK(RingRange BETWEEN 1.5 AND 7.5) NOT NULL
)

CREATE TABLE Tastes
(
	Id INT PRIMARY KEY IDENTITY,
	TasteType VARCHAR(20) NOT NULL,
	TasteStrength VARCHAR(15) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Brands
(
	Id INT PRIMARY KEY IDENTITY,
	BrandName VARCHAR(30) UNIQUE NOT NULL,
	BrandDescription VARCHAR(MAX)
)

CREATE TABLE Cigars
(
	Id INT PRIMARY KEY IDENTITY,
	CigarName VARCHAR(80) NOT NULL,
	BrandId INT REFERENCES Brands(Id) NOT NULL,
	TastId INT REFERENCES Tastes(Id) NOT NULL,
	SizeId INT REFERENCES Sizes(Id) NOT NULL,
	PriceForSingleCigar DECIMAL(15,2) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	Town VARCHAR(30) NOT NULL,
	Country NVARCHAR(30) NOT NULL,
	Streat NVARCHAR(100) NOT NULL,
	ZIP VARCHAR(20) NOT NULL
)

CREATE TABLE Clients
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	AddressId INT REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE ClientsCigars
(
	ClientId INT REFERENCES Clients(Id) NOT NULL,
	CigarId INT REFERENCES Cigars(Id) NOT NULL,
	PRIMARY KEY(ClientId,CigarId)
)

--2.	Insert

INSERT INTO Cigars(CigarName, BrandId, TastId, SizeId, PriceForSingleCigar, ImageURL)
VALUES
('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00,	'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES',	2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses(Town, Country, Streat, ZIP) VALUES
('Sofia', 'Bulgaria', '18 Bul. Vasil levski', 1000),
('Athens', 'Greece', '4342 McDonald Avenue', 10435),
('Zagreb', 'Croatia', '4333 Lauren Drive', 10000)

SELECT * FROM Cigars
SELECT * FROM Addresses
--3.	Update

UPDATE Cigars
	SET PriceForSingleCigar = PriceForSingleCigar + PriceForSingleCigar * 0.20
	WHERE TastId IN (SELECT Id FROM Tastes WHERE TasteType = 'Spicy')

UPDATE Brands
	SET BrandDescription = 'New description'
	WHERE BrandDescription IS NULL

--4.	Delete
DELETE FROM Clients
	WHERE AddressId IN (SELECT Id FROM Addresses WHERE Country LIKE 'C%')

DELETE FROM Addresses
	WHERE Country LIKE 'C%'

--5.	Cigars by Price
SELECT CigarName, PriceForSingleCigar, ImageURL
	FROM Cigars
	ORDER BY PriceForSingleCigar, CigarName DESC 

--6.	Cigars by Taste
SELECT c.Id, c.CigarName, c.PriceForSingleCigar, t.TasteType, t.TasteStrength
	FROM Cigars c
	JOIN Tastes t ON t.Id = c.TastId
	WHERE t.TasteType IN ('Earthy', 'Woody') 
	ORDER BY PriceForSingleCigar DESC

--7.	Clients without Cigars
SELECT c.Id, CONCAT_WS(' ', c.FirstName, c.LastName) AS ClientName, c.Email
	FROM Clients c
	LEFT JOIN ClientsCigars cc ON cc.ClientId = c.Id
	LEFT JOIN Cigars ci ON ci.Id = cc.CigarId
	WHERE ci.CigarName IS NULL
	ORDER BY ClientName
	
--8.	First 5 Cigars
SELECT TOP(5) c.CigarName, c.PriceForSingleCigar, c.ImageURL
	FROM Cigars c
	JOIN Sizes s ON s.Id = c.SizeId
	WHERE s.[Length] >= 12 AND (c.CigarName LIKE '%ci%' OR
		c.PriceForSingleCigar > 50 AND s.RingRange > 2.55)
	ORDER BY c.CigarName, c.PriceForSingleCigar DESC

--9.	Clients with ZIP Codes
SELECT FullName, Country, ZIP, '$' + CAST(Price AS VARCHAR) AS CigarPrice FROM
	(SELECT c.FirstName + ' ' + c.LastName AS FullName, a.Country, a.ZIP,
			MAX(ci.PriceForSingleCigar) AS Price
		FROM Clients c
		JOIN Addresses a ON a.Id = c.AddressId
		JOIN ClientsCigars cc ON cc.ClientId = c.Id
		JOIN Cigars ci ON ci.Id = cc.CigarId
		WHERE a.ZIP NOT LIKE '%[^0-9]%'
		GROUP BY c.FirstName + ' ' + c.LastName, a.Country, a.ZIP) AS temp
		ORDER BY FullName

--10.	Cigars by Size
SELECT c.LastName, AVG(s.[Length]) AS CiagrLength, CEILING(AVG(s.RingRange)) AS CiagrRingRange
	FROM Clients c
	LEFT JOIN ClientsCigars cc ON cc.ClientId = c.Id
	LEFT JOIN Cigars ci ON ci.Id = cc.CigarId
	LEFT JOIN Sizes s ON s.Id = ci.SizeId
	WHERE cc.CigarId IS NOT NULL
	GROUP BY c.LastName
	ORDER BY CiagrLength DESC

--Section 4. Programmability (20 pts)
--11.	Client with Cigars
CREATE FUNCTION udf_ClientWithCigars(@name VARCHAR(30)) RETURNS INT
AS 
BEGIN
	DECLARE @count INT 
	SET @count = (SELECT COUNT(*) FROM 
					(SELECT FirstName 
						FROM Clients c
						JOIN ClientsCigars cc ON cc.ClientId = c.Id
						JOIN Cigars ci ON ci.Id = cc.CigarId
						WHERE c.FirstName = @name) AS [temp])
	RETURN @count
END

--12.	Search for Cigar with Specific Taste

CREATE PROC usp_SearchByTaste(@taste VARCHAR(20))
AS
BEGIN
	SELECT CigarName, Price, TasteType, BrandName,
			CAST(Clength AS VARCHAR) + ' cm' AS 'CigarLength',
			CAST(RRange AS VARCHAR) + ' cm' AS 'CigarRingRange'
			FROM
		(SELECT c.CigarName, '$' + CAST(c.PriceForSingleCigar AS VARCHAR) AS 'Price',
				t.TasteType, b.BrandName, s.[Length] AS 'Clength', s.RingRange AS 'RRange'
			FROM Cigars c
			LEFT JOIN Brands b ON b.Id = c.BrandId
			LEFT JOIN Tastes t ON t.Id = c.TastId
			LEFT JOIN Sizes s ON s.Id = c.SizeId 
			WHERE t.TasteType = @taste) AS Temp
			ORDER BY Clength, RRange DESC
END

DROP PROC usp_SearchByTaste

EXEC usp_SearchByTaste 'Woody'

