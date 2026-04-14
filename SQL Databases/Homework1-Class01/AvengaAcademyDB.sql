CREATE DATABASE AvengaAcademyDB;

USE AvengaAcademyDB;

CREATE TABLE Students (
	Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(50),
	LastName NVARCHAR(50),
	DateOfBirth DATE,
	EnrolledDate DATE,
	Gender NCHAR(1),
	NationalIDNumber INT,
	StudentCardNumber INT
);

EXEC sp_rename 'Students', 'Student';

CREATE TABLE Teacher (
	Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(50),
	LastName NVARCHAR(50),
	DateOfBirth DATE,
	AcademicRank NVARCHAR(100),
	HireDate DATE
);

SELECT * FROM Teacher;

CREATE TABLE Grade (
	Id INT PRIMARY KEY IDENTITY(1,1),
	StudentID INT,
	CourseID INT,
	TeacherID INT,
	Grade INT,
	Comment NVARCHAR(300),
	CreatedDate DATE
);

CREATE TABLE Course (
	Id INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(50),
	Credit NVARCHAR(50),
	AcademicYear INT,
	Semester TINYINT
);

CREATE TABLE AchievementType (
	Id INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(50),
	[Description] NVARCHAR(300),
	ParticipationRate DECIMAL(3, 2)
);

CREATE TABLE GradeDetails (
	Id INT PRIMARY KEY IDENTITY(1,1),
	GradeID INT,
	AchievementTypeID INT,
	AchievementPointsID INT,
	AchievementMaxPoints INT,
	AchievementDate INT
);





