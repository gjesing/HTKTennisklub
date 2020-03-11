USE master
IF EXISTS(SELECT * FROM sys.databases WHERE name='HTKTennisklub')
DROP DATABASE HTKTennisklub

CREATE DATABASE HTKTennisklub
GO

USE HTKTennisklub

CREATE TABLE Levels(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(20) NOT NULL,
	BasePoints TINYINT NOT NULL
)

CREATE TABLE AgeGroups(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(20) NOT NULL,
	MinAge TINYINT,
	MaxAge TINYINT
)

CREATE TABLE Classifications(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(20) NOT NULL
)

CREATE TABLE Courts(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(20) NOT NULL,
	IsClosed BIT NOT NULL DEFAULT 0
)

CREATE TABLE CourtClosings(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	CourtId INT NOT NULL FOREIGN KEY REFERENCES Courts(Id),
	StartDate DATETIME2(0) NOT NULL,
	EndDate DATETIME2(0),
	IsPermanent BIT NOT NULL DEFAULT 0
)

CREATE TABLE Members(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Address NVARCHAR(50) NOT NULL,
	PhoneNumber CHAR(8) NOT NULL,
	Email NVARCHAR(320) NOT NULL,
	BirthDate DATETIME2(0) NOT NULL,
	Gender CHAR(1) NOT NULL,
	AgeGroupId INT NOT NULL FOREIGN KEY REFERENCES AgeGroups(Id),
	LevelId INT NOT NULL FOREIGN KEY REFERENCES Levels(Id),
	IsMember BIT NOT NULL DEFAULT 1
)

CREATE TABLE MemberClassifications(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	MemberId INT NOT NULL FOREIGN KEY REFERENCES Members(Id),
	ClassificationId INT NOT NULL FOREIGN KEY REFERENCES Classifications(Id)
)

CREATE TABLE Ranks(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	MemberId INT NOT NULL FOREIGN KEY REFERENCES Members(Id),
	Points INT NOT NULL,
	RankNumber INT NOT NULL
)

CREATE TABLE Challenges(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Member1Id INT NOT NULL FOREIGN KEY REFERENCES Members(Id),
	Member2Id INT NOT NULL FOREIGN KEY REFERENCES Members(Id),
	WinnerId INT NOT NULL FOREIGN KEY REFERENCES Members(Id)
)

CREATE TABLE Bookings(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Time DATETIME2(0) NOT NULL,
	Member1Id INT NOT NULL FOREIGN KEY REFERENCES Members(Id),
	Member2Id INT FOREIGN KEY REFERENCES Members(Id)
)

INSERT INTO Levels VALUES ('Nybegynder', 50)
INSERT INTO Levels VALUES ('Let øvet', 60)
INSERT INTO Levels VALUES ('Øvet', 70)
INSERT INTO Levels VALUES ('Elite', 80)

INSERT INTO AgeGroups (Name, MaxAge) VALUES ('Junior', 17)
INSERT INTO AgeGroups VALUES ('Ungdom', 18, 23)
INSERT INTO AgeGroups VALUES ('Senior', 24, 39)
INSERT INTO AgeGroups VALUES ('Veteran', 40, 54)
INSERT INTO AgeGroups (Name, MinAge) VALUES ('55+', 55)

INSERT INTO Classifications VALUES ('Kvinder')
INSERT INTO Classifications VALUES ('Mænd')
INSERT INTO Classifications VALUES ('Junior kvinder')
INSERT INTO Classifications VALUES ('Junior mænd')
INSERT INTO Classifications VALUES ('Ungdom kvinder')
INSERT INTO Classifications VALUES ('Ungdom mænd')
INSERT INTO Classifications VALUES ('Senior kvinder')
INSERT INTO Classifications VALUES ('Senior mænd')
INSERT INTO Classifications VALUES ('Veteran kvinder')
INSERT INTO Classifications VALUES ('Veteran mænd')
INSERT INTO Classifications VALUES ('55+ kvinder')
INSERT INTO Classifications VALUES ('55+ mænd')
INSERT INTO Classifications VALUES ('Bredde')

INSERT INTO Courts (Name) VALUES ('Bane 1')
INSERT INTO Courts (Name) VALUES ('Bane 2')
INSERT INTO Courts (Name) VALUES ('Bane 3')
INSERT INTO Courts (Name) VALUES ('Bane 4')
UPDATE Courts SET IsClosed = 1 WHERE Id=2

INSERT INTO CourtClosings (CourtId, StartDate) VALUES (2, DATEADD(DAY, -1, GETDATE()))

INSERT INTO Members VALUES ('Martin', 'Svendsen', 'Mellemvej 81 9440 Aabybro', '42478478', 'martinsvendsen@gmail.com', '2005-04-15', 'm', 1, 2, 1)
INSERT INTO Members VALUES ('Astrid', 'Eriksen', 'Plouggårdsvej 627960 Karby', '24898632', 'astrideriksen@gmail.com', '2002-01-25', 'f', 2, 3, 1)
INSERT INTO Members VALUES ('Astrid', 'Jørgensen', 'Havnegade 18 9530 Støvring', '52605653', 'astridjørgensen@gmail.com', '1990-03-30', 'f', 3, 1, 0)
INSERT INTO Members VALUES ('Sille', 'Nygaard', 'Dosseringen 67 7850 Stoholm Jylland', '22756149', 'sillenygaard@gmail.com', '1971-03-22', 'f', 4, 4, 1)
INSERT INTO Members VALUES ('Laura', 'Koch', 'Mellemvej 88 9220 Aalborg Øst', '51616704', 'laurakoch@gmail.com', '2006-03-2', 'f', 1, 1, 1)
INSERT INTO Members VALUES ('Michael', 'Frederiksen', 'Rynkebyvej 66 7752 Snedsted', '23556294', 'michaelfrederiksen@gmail.com', '2000-05-13', 'm', 2, 4, 1)
INSERT INTO Members VALUES ('Bertram', 'Overgaard', 'Gasværksvej 70 9340 Asaa', '31237427', 'bertramovergaard@gmail.com', '1986-01-22', 'm', 3, 1, 1)

INSERT INTO MemberClassifications VALUES (1, 2)
INSERT INTO MemberClassifications VALUES (1, 4)
INSERT INTO MemberClassifications VALUES (2, 1)
INSERT INTO MemberClassifications VALUES (2, 3)
INSERT INTO MemberClassifications VALUES (3, 1)
INSERT INTO MemberClassifications VALUES (3, 5)
INSERT INTO MemberClassifications VALUES (3, 13)
INSERT INTO MemberClassifications VALUES (4, 1)
INSERT INTO MemberClassifications VALUES (4, 7)
INSERT INTO MemberClassifications VALUES (5, 1)
INSERT INTO MemberClassifications VALUES (5, 3)
INSERT INTO MemberClassifications VALUES (6, 2)
INSERT INTO MemberClassifications VALUES (6, 6)
INSERT INTO MemberClassifications VALUES (6, 13)
INSERT INTO MemberClassifications VALUES (7, 2)
INSERT INTO MemberClassifications VALUES (7, 8)

INSERT INTO Ranks VALUES (1, 60, 4)
INSERT INTO Ranks VALUES (2, 72, 3)
INSERT INTO Ranks VALUES (4, 81, 1)
INSERT INTO Ranks VALUES (5, 48, 6)
INSERT INTO Ranks VALUES (6, 79, 2)
INSERT INTO Ranks VALUES (7, 54, 5)