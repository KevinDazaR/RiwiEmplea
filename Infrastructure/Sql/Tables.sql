CREATE TABLE Users (
    Id INTEGER AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(45),
    Email VARCHAR(45) UNIQUE,
    Password VARCHAR(45),
    GoogleId INT(11),
    RoleId INT(11),
    Foreign Key (RoleId) REFERENCES Roles(Id)
);
ALTER TABLE Users ADD LastName VARCHAR(45);
ALTER TABLE Users ADD State ENUM('Active', 'Inactive') DEFAULT 'Active';

CREATE TABLE Resumes (
    Id INTEGER AUTO_INCREMENT PRIMARY KEY,
    UserId INT(11),
    BirthYear DATE,
    PublicLink VARCHAR(50),
    AboutMy TEXT,
    CreatedAt DATETIME,
    State ENUM('Active', 'Inactive') DEFAULT('Active'),
    Foreign Key (UserId) REFERENCES Users(Id)
);

CREATE TABLE Skills(
    Id INTEGER AUTO_INCREMENT PRIMARY KEY,
    ResumeId INT,
    Ability VARCHAR(45),
    Level ENUM('Basic', 'Medium', 'Advanced'),
    State ENUM('Active', 'Inactive') DEFAULT('Active'),
    Foreign Key (ResumeId) REFERENCES Resumes(Id)
);

CREATE TABLE WorkExperiences (
    Id INTEGER PRIMARY KEY AUTO_INCREMENT,
    ResumeId INT,
    Company VARCHAR(45),
    Position VARCHAR(50),
    StartDate DATE,
    EndDate DATE,
    Description VARCHAR(60),
    State ENUM('Active', 'Inactive') DEFAULT('Active'),
    Foreign Key (ResumeId) REFERENCES Resumes(Id)
);

CREATE TABLE AcademicTrainings (
    Id INTEGER AUTO_INCREMENT PRIMARY KEY,
    ResumeId INT,
    Institution VARCHAR(60),
    Title VARCHAR(45),
    StartDate DATE,
    EndDate DATE,
    Description VARCHAR(60),
    State ENUM('Active', 'Inactive') DEFAULT('Active'),
    Foreign Key (ResumeId) REFERENCES Resumes(Id)
);

CREATE TABLE Roles (
    Id INTEGER AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(45)
);
