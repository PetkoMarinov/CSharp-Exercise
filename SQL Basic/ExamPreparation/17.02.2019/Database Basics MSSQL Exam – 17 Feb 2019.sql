CREATE DATABASE School
DROP DATABASE School

CREATE TABLE Students
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(25),
	LastName NVARCHAR(30) NOT NULL,
	Age INT CHECK(Age BETWEEN 5 AND 100) NOT NULL,
	[Address] NVARCHAR(50),
	Phone CHAR(10)
)

CREATE TABLE Subjects
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	Lessons INT CHECK(Lessons > 0) NOT NULL
)

CREATE TABLE StudentsSubjects
(
	Id INT PRIMARY KEY IDENTITY,
	StudentId INT REFERENCES Students(Id) NOT NULL,
	SubjectId INT REFERENCES Subjects(Id) NOT NULL,
	Grade DECIMAL(3,2) CHECK(GRADE BETWEEN 2 AND 6)
)

CREATE TABLE Exams
(
	Id INT PRIMARY KEY IDENTITY,
	[Date] DATETIME,
	SubjectId INT REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsExams
(
	StudentId INT REFERENCES Students(Id) NOT NULL,
	ExamId INT REFERENCES Exams(Id) NOT NULL,
	Grade DECIMAL(3,2) CHECK(GRADE BETWEEN 2 AND 6),
	PRIMARY KEY(StudentId, ExamId)
)

CREATE TABLE Teachers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	[Address] NVARCHAR(20) NOT NULL,
	Phone CHAR(10),
	SubjectId INT REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsTeachers
(
	StudentId INT REFERENCES Students(Id) NOT NULL,
	TeacherId INT REFERENCES Teachers(Id) NOT NULL,
	PRIMARY KEY(StudentId,TeacherId)
)

--2. Insert
INSERT INTO Teachers(FirstName, LastName, [Address], Phone, SubjectId) VALUES
	('Ruthanne', 'Bamb', '84948 Mesta Junction', 3105500146, 6),
	('Gerrard',	'Lowin', '370 Talisman Plaza', 3324874824, 2),
	('Merrile',	'Lambdin', '81 Dahle Plaza', 4373065154, 5),
	('Bert', 'Ivie', '2 Gateway Circle', 4409584510, 4)

INSERT INTO Subjects([Name], Lessons) VALUES 
('Geometry', 12),
('Health',	10),
('Drama', 7),
('Sports', 9)

--3. Update
--Make all grades 6.00, where the subject id is 1 or 2, if the grade is above or equal to 5.50
UPDATE StudentsSubjects
	SET Grade = 6
	WHERE SubjectId IN (1,2) AND Grade >= 5.50

--4. Delete
--Delete all teachers, whose phone number contains ‘72’.
DELETE FROM StudentsTeachers
	WHERE TeacherId IN 
	(SELECT Id FROM Teachers WHERE Phone LIKE '%72%')

DELETE FROM Teachers
	WHERE Phone LIKE '%72%'

--5. Teen Students
--Select all students who are teenagers (their age is above or equal to 12). 
--Order them by first name (alphabetically), then by last name (alphabetically). 
--Select their first name, last name and their age.

SELECT FirstName, LastName, Age
	FROM Students
	WHERE Age >= 12
	ORDER BY FirstName, LastName 

--6. Students Teachers
--Select all students and the count of teachers each one has. 

SELECT s.FirstName, s.LastName, COUNT(st.TeacherId) AS TeachersCount 
	FROM Students s
	JOIN StudentsTeachers st ON st.StudentId = s.Id
	GROUP BY s.FirstName, s.LastName

--7. Students to Go
--Find all students, who have not attended an exam. 
--Select their full name (first name + last name).
--Order the results by full name (ascending).

SELECT s.FirstName + ' ' + s.LastName AS 'Full Name'
	FROM Students s
	LEFT JOIN StudentsExams se ON se.StudentId = s.Id
	WHERE ExamId IS NULL
	GROUP BY s.FirstName + ' ' + s.LastName
	ORDER BY [Full Name]

--8. Top Students
--Find top 10 students, who have highest average grades from the exams.
--Format the grade, two symbols after the decimal point.
--Order them by grade (descending), then by first name (ascending), 
--then by last name (ascending)

SELECT TOP(10) s.FirstName + ' ' + s.LastName AS 'Full Name'
	FROM Students s
	JOIN StudentsExams se ON se.StudentId = s.Id
	WHERE ExamId IS NULL
	GROUP BY s.FirstName + ' ' + s.LastName
	ORDER BY [Full Name]

--9. Not So In The Studying
--Find all students who don’t have any subjects. Select their full name. 
--The full name is combination of first name, middle name and last name. 
--Order the result by full name
--NOTE: If the middle name is null you have to concatenate the first name and 
--last name separated with single space.

SELECT s.FirstName + ' ' + ISNULL(s.MiddleName + ' ','') + LastName AS 'Full Name' FROM 
	STUDENTS s
	LEFT JOIN StudentsSubjects ss ON ss.StudentId = s.Id
	WHERE SubjectId IS NULL
	ORDER BY [Full Name]

--10. Average Grade per Subject
--Find the average grade for each subject. 
--Select the subject name and the average grade. 
--Sort them by subject id (ascending).

SELECT s.[Name], AVG(ss.Grade) AS 'AverageGrade'
	FROM Subjects s
	JOIN StudentsSubjects ss ON ss.SubjectId = s.Id
	GROUP BY s.[Name], ss.SubjectId
	ORDER BY ss.SubjectId

--11. Exam Grades
CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(3,2))
RETURNS VARCHAR(70)
AS
BEGIN
	DECLARE @result VARCHAR(70)

	IF @studentId NOT IN (SELECT Id FROM Students)
		BEGIN
			SET @result = 'The student with provided id does not exist in the school!'
		END
	ELSE IF @grade > 6	
		BEGIN
			SET @result = 'Grade cannot be above 6.00!'
		END
	ELSE
		BEGIN
			DECLARE @count INT
			SET @count = (SELECT COUNT(*) FROM 
				(SELECT * FROM StudentsExams
				WHERE Grade IN (@grade, @grade + 0.50) AND StudentId = @studentId) AS [temp])
			
			DECLARE @firstName VARCHAR(30) 
			SET @firstName = 
				(SELECT FirstName
					FROM Students
					WHERE Id = @studentId)

			SET @result = 'You have to update ' + CAST(@count AS VARCHAR) + 
			' grades for the student ' + @firstName
		END
	RETURN @result
END

--12. Exclude from school

--Create a user defined stored procedure, named usp_ExcludeFromSchool(@StudentId), 
--that receives a student id and attempts to delete the current student.
--A student will only be deleted if all of these conditions pass:
--•	If the student doesn’t exist, then it cannot be deleted. 
--Raise an error with the message “This school has no student with the provided id!”
--If all the above conditions pass, delete the student and ALL OF HIS REFERENCES!

CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
	DECLARE @studentExist BIT = (SELECT Id FROM Students s WHERE Id = @StudentId)

	IF @studentExist IS NULL
		BEGIN
			RAISERROR('This school has no student with the provided id!', 15, 1)
		END
	ELSE 
		BEGIN
			DELETE FROM StudentsTeachers
				WHERE StudentId = @StudentId

			DELETE FROM StudentsExams
				WHERE StudentId = @StudentId
			
			DELETE FROM StudentsSubjects
				WHERE StudentId = @StudentId

			DELETE FROM Students
				WHERE Id = @StudentId
		END

EXEC usp_ExcludeFromSchool 1
SELECT COUNT(*) FROM Students

EXEC usp_ExcludeFromSchool 301
