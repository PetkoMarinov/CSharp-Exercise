CREATE TABLE Planes
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	[Range] INT NOT NULL
)

CREATE TABLE Flights
(
	Id INT PRIMARY KEY IDENTITY,
	DepartureTime DATETIME,
	ArrivalTime DATETIME,
	Origin VARCHAR(50) NOT NULL,
	Destination VARCHAR(50) NOT NULL,
	PlaneId INT FOREIGN KEY REFERENCES Planes(Id) NOT NULL
)

CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	[Address] VARCHAR(30) NOT NULL,
	PassportId CHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes
(
	Id INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(30) 
)

CREATE TABLE Luggages
(
	Id INT PRIMARY KEY IDENTITY,
	LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
)

CREATE TABLE Tickets
(
	Id INT PRIMARY KEY IDENTITY,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	FlightId INT FOREIGN KEY REFERENCES Flights(Id) NOT NULL,
	LuggageId INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL,
	Price DECIMAL(15,2) NOT NULL
)

--Section 2. DML (10 pts)
--2.	Insert
INSERT INTO Planes([Name], Seats, [Range]) VALUES
	('Airbus 336', 112, 5132),
	('Airbus 330', 432,	5325),
	('Boeing 369', 231,	2355),
	('Stelt 297', 254, 2143),
	('Boeing 338', 165, 5111),
	('Airbus 558', 387, 1342),
	('Boeing 128', 345, 5541)

INSERT INTO LuggageTypes([Type]) VALUES
	('Crossbody Bag'),
	('School Backpack'),
	('Shoulder Bag')

--3.	Update
UPDATE Tickets
	SET Price += Price * 0.13
	WHERE FlightId IN 
	(SELECT TOP(1) Id FROM Flights 
		WHERE Destination = 'Carlsbad')

--4.	Delete
DELETE FROM Tickets
	WHERE FlightId = (SELECT TOP(1) Id FROM Flights WHERE Destination = 'Ayn Halagim')

DELETE FROM Flights
	WHERE Destination = 'Ayn Halagim'

--5.	The "Tr" Planes
SELECT *
	FROM Planes
	WHERE [Name] LIKE '%tr%'
	ORDER BY Id, [Name], Seats, [Range]

--6.	Flight Profits
SELECT FlightId, SUM(Price) AS 'Price'
	FROM Tickets
	GROUP BY FlightId
	ORDER BY Price DESC, FlightId ASC

--7.	Passenger Trips
SELECT p.FirstName + ' ' + p.LastName AS [Full Name], f.Origin, f.Destination 
	FROM Passengers p
	JOIN Tickets t ON p.Id = t.PassengerId
	JOIN Flights f ON t.FlightId = f.Id
	ORDER BY [Full Name], Origin, Destination

--8.	Non Adventures People
SELECT p.FirstName, p.LastName, p.Age 
	FROM Passengers p
	LEFT JOIN Tickets t ON p.Id = t.PassengerId
	WHERE t.Id IS NULL 
	ORDER BY p.Age DESC, p.FirstName, p.LastName

--9.	Full Info
SELECT p.FirstName + ' ' + p.LastName AS [Full Name],pl.[Name] AS 'Plane Name',
		f.Origin + ' - ' + f.Destination AS 'Trip', lt.[Type] AS 'Luggage Type'
	FROM Passengers p
		JOIN Tickets t ON t.PassengerId = p.Id
		JOIN Flights f ON f.Id = t.FlightId
		JOIN Planes pl ON pl.Id = f.PlaneId
		JOIN Luggages l ON l.Id = t.LuggageId
		JOIN LuggageTypes lt ON l.LuggageTypeId = lt.Id
	WHERE p.FirstName + ' ' + p.LastName IS NOT NULL
	ORDER BY [Full Name],[Plane name], f.Origin, f.Destination, lt.[Type]

--10.	PSP
SELECT pl.[Name], pl.Seats, COUNT(t.Id) AS 'Passengers count'
	FROM Planes pl
	LEFT JOIN Flights f ON f.PlaneId = pl.Id
	LEFT JOIN Tickets t ON t.FlightId = f.Id
	GROUP BY pl.Name, pl.Seats
	ORDER BY 'Passengers count' DESC, pl.[Name], pl.Seats

--11.	Vacation
CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(50)
AS 
BEGIN
	DECLARE @result VARCHAR(50)
	
	IF @peopleCount <= 0
		BEGIN
			SET @result = 'Invalid people count!'
		END
	ELSE IF @origin NOT IN (SELECT Origin FROM Flights WHERE Origin = @origin) 
		OR @destination NOT IN (SELECT Destination FROM Flights WHERE Destination = @destination) 
		BEGIN
			SET @result = 'Invalid flight!'
		END
	ELSE
		BEGIN
			SET @result = 'Total price ' + CAST(
			(SELECT Sum(t.Price * @peopleCount)
				FROM Tickets t
				LEFT JOIN Flights f ON f.Id = t.FlightId
			WHERE f.Origin = @origin AND f.Destination = @destination) AS VARCHAR(50))
		END
	RETURN @result
END

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)
SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)
SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)
DROP FUNCTION udf_CalculateTickets

--12.	Wrong Data
CREATE PROC usp_CancelFlights
AS
	BEGIN 
		UPDATE Flights
			SET DepartureTime = NULL, ArrivalTime = NULL
			WHERE DepartureTime < ArrivalTime
	END

				