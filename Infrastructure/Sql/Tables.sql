CREATE TABLE Users (
    Id INTEGER AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(45),
    Email VARCHAR(45) UNIQUE,
    Password VARCHAR(45),
    GoogleId INT(11),
    RoleId INT(11),
    Foreign Key (RoleId) REFERENCES Roles(Id)
);


CREATE TABLE Resume (
    Id INTEGER AUTO_INCREMENT PRIMARY KEY,
    UserId INT(11),
    BirthYear DATE,
    PublicLink VARCHAR(50),
    AboutMy TEXT,
    CreatedAt DATETIME,
    Foreign Key (UserId) REFERENCES Users(Id)
);


CREATE TABLE Skills(
    Id INTEGER AUTO_INCREMENT PRIMARY KEY,
    ResumeId INTEGER,
    Ability VARCHAR(45),
    Level ENUM('Basic', 'Medium', 'Advanced'),
    Foreign Key (ResumeId) REFERENCES Resume(Id)
);


CREATE TABLE WorkExperiences (
    Id INTEGER PRIMARY KEY AUTO_INCREMENT,
    ResumeId INT,
    Company VARCHAR(45),
    Position VARCHAR(50),
    StartDate DATE,
    EndDate DATE,
    Description VARCHAR(60),
    Foreign Key (ResumeId) REFERENCES Resume(Id)
);

CREATE TABLE AcademicTrainings (
    Id INTEGER AUTO_INCREMENT PRIMARY KEY,
    ResumeId INT(11),
    Institution VARCHAR(60),
    Title VARCHAR(45),
    StartDate DATE,
    EndDate DATE,
    Description VARCHAR(60),
    Foreign Key (ResumeId) REFERENCES Resume(Id)
);


CREATE TABLE Roles (
    Id INTEGER AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(45)
);

/* Datos quemados */

-- Tabla Roles
INSERT INTO Roles (Name) VALUES ('Staff');
INSERT INTO Roles (Name) VALUES ('User');

-- Tabla Users
INSERT INTO Users (Name, Email, Password, GoogleId, RoleId) VALUES ('Alice Smith', 'alice@example.com', 'password123', 1001, 1);
INSERT INTO Users (Name, Email, Password, GoogleId, RoleId) VALUES ('Bob Johnson', 'bob@example.com', 'password456', 1002, 2);
INSERT INTO Users (Name, Email, Password, GoogleId, RoleId) VALUES ('Charlie Brown', 'charlie@example.com', 'password789', 1003, 2);
INSERT INTO Users (Name, Email, Password, GoogleId, RoleId) VALUES ('Daisy Clark', 'daisy@example.com', 'passwordabc', 1004, 2);
INSERT INTO Users (Name, Email, Password, GoogleId, RoleId) VALUES ('Evan Davis', 'evan@example.com', 'passworddef', 1005, 1);

-- Tabla Resume
INSERT INTO Resume (UserId, BirthYear, PublicLink, AboutMy, CreatedAt) VALUES (1, '1980-01-01', 'http://example.com/alice', 'About Alice', '2024-07-09 12:00:00');
INSERT INTO Resume (UserId, BirthYear, PublicLink, AboutMy, CreatedAt) VALUES (2, '1985-05-15', 'http://example.com/bob', 'About Bob', '2024-07-09 12:00:00');
INSERT INTO Resume (UserId, BirthYear, PublicLink, AboutMy, CreatedAt) VALUES (3, '1990-03-25', 'http://example.com/charlie', 'About Charlie', '2024-07-09 12:00:00');
INSERT INTO Resume (UserId, BirthYear, PublicLink, AboutMy, CreatedAt) VALUES (4, '1995-07-30', 'http://example.com/daisy', 'About Daisy', '2024-07-09 12:00:00');
INSERT INTO Resume (UserId, BirthYear, PublicLink, AboutMy, CreatedAt) VALUES (5, '2000-12-10', 'http://example.com/evan', 'About Evan', '2024-07-09 12:00:00');

-- Tabla Skills
INSERT INTO Skills (ResumeId, Skill, Level) VALUES (1, 'JavaScript', 'Advanced');
INSERT INTO Skills (ResumeId, Skill, Level) VALUES (2, 'Python', 'Medium');
INSERT INTO Skills (ResumeId, Skill, Level) VALUES (3, 'HTML', 'Basic');
INSERT INTO Skills (ResumeId, Skill, Level) VALUES (4, 'CSS', 'Medium');
INSERT INTO Skills (ResumeId, Skill, Level) VALUES (5, 'SQL', 'Advanced');

-- Tabla WorkExperiences
INSERT INTO WorkExperiences (ResumeId, Company, Position, StartDate, EndDate, Description) VALUES (1, 'Company A', 'Developer', '2020-01-01', '2022-01-01', 'Developed web applications');
INSERT INTO WorkExperiences (ResumeId, Company, Position, StartDate, EndDate, Description) VALUES (2, 'Company B', 'Analyst', '2019-02-15', '2021-02-15', 'Analyzed data');
INSERT INTO WorkExperiences (ResumeId, Company, Position, StartDate, EndDate, Description) VALUES (3, 'Company C', 'Designer', '2018-03-25', '2020-03-25', 'Designed websites');
INSERT INTO WorkExperiences (ResumeId, Company, Position, StartDate, EndDate, Description) VALUES (4, 'Company D', 'Manager', '2017-07-30', '2019-07-30', 'Managed projects');
INSERT INTO WorkExperiences (ResumeId, Company, Position, StartDate, EndDate, Description) VALUES (5, 'Company E', 'Intern', '2016-12-10', '2018-12-10', 'Assisted with various tasks');

-- Tabla AcademicTraining
INSERT INTO AcademicTraining (ResumeId, Institution, Title, StartDate, EndDate, Description) VALUES (1, 'University X', 'BSc Computer Science', '2000-09-01', '2004-06-01', 'Studied computer science');
INSERT INTO AcademicTraining (ResumeId, Institution, Title, StartDate, EndDate, Description) VALUES (2, 'College Y', 'BA Economics', '2005-09-01', '2009-06-01', 'Studied economics');
INSERT INTO AcademicTraining (ResumeId, Institution, Title, StartDate, EndDate, Description) VALUES (3, 'Institute Z', 'Diploma in Design', '2010-01-15', '2012-12-15', 'Studied design');
INSERT INTO AcademicTraining (ResumeId, Institution, Title, StartDate, EndDate, Description) VALUES (4, 'University W', 'MBA', '2013-09-01', '2015-06-01', 'Studied business administration');
INSERT INTO AcademicTraining (ResumeId, Institution, Title, StartDate, EndDate, Description) VALUES (5, 'School V', 'Certificate in SQL', '2016-09-01', '2018-06-01', 'Studied SQL');
