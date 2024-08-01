-- Active: 1722462983270@@127.0.0.1@3306@bjfg41pkiuncnecnedjz
CREATE TABLE Roles (
    Id INT NOT NULL AUTO_INCREMENT,
    Name VARCHAR(90) NOT NULL,
    PRIMARY KEY (Id)
);

CREATE TABLE Users (
    Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    FullName VARCHAR(125) NOT NULL,
    Email VARCHAR(125) NOT NULL,
    Password VARCHAR(255) NOT NULL,
    GoogleId INT,
    State ENUM('Active', 'Inactive') DEFAULT 'Active',
    RoleId INT,
    FOREIGN KEY (RoleId) REFERENCES Roles(Id)
);
-- Drop tables in order of dependencies to avoid foreign key constraint issues
CREATE TABLE Resumes (
    Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Birthdate DATE NOT NULL,
    PublicLink VARCHAR(50),
    AboutMe TEXT,
    CreatedAt DATETIME NOT NULL,
    State ENUM('Active', 'Inactive') DEFAULT 'Active',
    UserId INT,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

CREATE TABLE Skills (
    Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(125) NOT NULL,
    Level ENUM('Basic', 'Medium', 'Advanced') NOT NULL,
    State ENUM('Active', 'Inactive') DEFAULT 'Active',
    ResumeId INT,
    FOREIGN KEY (ResumeId) REFERENCES Resumes(Id)
);

CREATE TABLE WorkExperiences (
    Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Company VARCHAR(50) NOT NULL,
    Position VARCHAR(50) NOT NULL,
    Description VARCHAR(255),
    StartDate DATE NOT NULL,
    EndDate DATE,
    State ENUM('Active', 'Inactive') DEFAULT 'Active',
    ResumeId INT,
    FOREIGN KEY (ResumeId) REFERENCES Resumes(Id)
);

CREATE TABLE AcademicTrainings (
    Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Institution VARCHAR(60) NOT NULL,
    Title VARCHAR(90) NOT NULL,
    Description VARCHAR(255),
    StartDate DATE NOT NULL,
    EndDate DATE,
    State ENUM('Active', 'Inactive') DEFAULT 'Active',
    ResumeId INT,
    FOREIGN KEY (ResumeId) REFERENCES Resumes(Id)
);