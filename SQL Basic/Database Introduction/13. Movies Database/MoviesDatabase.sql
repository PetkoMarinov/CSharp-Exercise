CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors
(
	Id INT IDENTITY NOT NULL,
	DirectorName VARCHAR(30) NOT NULL,
	Notes VARCHAR(MAX)
	CONSTRAINT PK_DirectorId PRIMARY KEY(Id)
)

INSERT INTO Directors(DirectorName, Notes) VALUES
	('Bai Xiks', NULL),
	('Abra Kadabra', 'Sin Salabin'),
	('Aman Veche', 'nyama'),
	('Aman', 'ima'),
	('DAman', 'imali')

CREATE TABLE Genres
(
	Id INT IDENTITY NOT NULL,
	GenreName VARCHAR(30) NOT NULL,
	Notes VARCHAR(MAX)
	CONSTRAINT PK_GenreId PRIMARY KEY(Id)
)

INSERT INTO Genres(GenreName, Notes) VALUES
	('Comedy', NULL),
	('Action', 'Sin Salabin'),
	('Adventure', 'nyama'),
	('Historic', 'ima'),
	('Exotic', 'imali')

CREATE TABLE Categories
(
	Id INT IDENTITY NOT NULL,
	CategoryName VARCHAR(30) NOT NULL,
	Notes VARCHAR(MAX)
	CONSTRAINT PK_CategoryId PRIMARY KEY(Id)
)

INSERT INTO Categories(CategoryName, Notes) VALUES
	('Category1', NULL),
	('Category2', 'Sin Salabin'),
	('Category3', 'nyama'),
	('Category4', 'ima'),
	('Category5', 'imali')

CREATE TABLE Movies
(
	Id INT IDENTITY NOT NULL,
	Title VARCHAR(50) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
	CopyrightYear SMALLINT,
	[Length] FLOAT(2),
	GenreId INT FOREIGN KEY REFERENCES Genres(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Rating FLOAT(1),
	Notes VARCHAR(MAX)
	CONSTRAINT PK_MoviesId PRIMARY KEY(Id)
)

INSERT INTO Movies(Title, DirectorId, CopyrightYear, [Length], GenreId,
	CategoryId, Rating, Notes) VALUES
	('Die hard', 2, NULL, 1.87, 1, 1, 5.4, 'gagaa'),
	('Rocky 2', 1, 1987, 1.6, 3, 3, 5.3, 'gagaa'),
	('Han Asparuh', 4, 1983, 2.67, 2, 2, 5.2, NULL),
	('Toplo', 3, 1976, 1.56, 5, 4, 5.5, 'gagaa'),
	('Nai - dobriyat chovek, kogoto poznavam', 5, 1971, 1.47, 4, 5, 6, 'gagaa')


