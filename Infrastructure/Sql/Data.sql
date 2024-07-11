/* Datos quemados */

-- Tabla Roles
INSERT INTO Roles (Name) VALUES 
('Staff'),
('User');

-- Tabla Users
INSERT INTO Users (Name, Email, Password, GoogleId, RoleId) VALUES
('Alice Smith', 'alice@example.com', 'password123', 1001, 1),
('Bob Johnson', 'bob@example.com', 'password456', 1002, 2),
('Charlie Brown', 'charlie@example.com', 'password789', 1003, 2),
('Daisy Clark', 'daisy@example.com', 'passwordabc', 1004, 2),
('Evan Davis', 'evan@example.com', 'passworddef', 1005, 1);

-- Tabla Resume
INSERT INTO Resumes (UserId, BirthYear, PublicLink, AboutMy, CreatedAt) VALUES 
(1, '1980-01-01', 'http://example.com/alice', 'About Alice', '2024-07-09 12:00:00'),
(2, '1985-05-15', 'http://example.com/bob', 'About Bob', '2024-07-09 12:00:00'),
(3, '1990-03-25', 'http://example.com/charlie', 'About Charlie', '2024-07-09 12:00:00'),
(4, '1995-07-30', 'http://example.com/daisy', 'About Daisy', '2024-07-09 12:00:00'),
(5, '2000-12-10', 'http://example.com/evan', 'About Evan', '2024-07-09 12:00:00');

-- Tabla Skills
INSERT INTO Skills (ResumeId, Skill, Level) VALUES 
(1, 'JavaScript', 'Advanced'),
(2, 'Python', 'Medium'),
(3, 'HTML', 'Basic'),
(4, 'CSS', 'Medium'),
(5, 'SQL', 'Advanced');

-- Tabla WorkExperiences
INSERT INTO WorkExperiences (ResumeId, Company, Position, StartDate, EndDate, Description) VALUES 
(1, 'Company A', 'Developer', '2020-01-01', '2022-01-01', 'Developed web applications'),
(2, 'Company B', 'Analyst', '2019-02-15', '2021-02-15', 'Analyzed data'),
(3, 'Company C', 'Designer', '2018-03-25', '2020-03-25', 'Designed websites'),
(4, 'Company D', 'Manager', '2017-07-30', '2019-07-30', 'Managed projects'),
(5, 'Company E', 'Intern', '2016-12-10', '2018-12-10', 'Assisted with various tasks');

-- Tabla AcademicTraining
INSERT INTO AcademicTrainings (ResumeId, Institution, Title, StartDate, EndDate, Description) VALUES 
(1, 'University X', 'BSc Computer Science', '2000-09-01', '2004-06-01', 'Studied computer science'),
(2, 'College Y', 'BA Economics', '2005-09-01', '2009-06-01', 'Studied economics'),
(3, 'Institute Z', 'Diploma in Design', '2010-01-15', '2012-12-15', 'Studied design'),
(4, 'University W', 'MBA', '2013-09-01', '2015-06-01', 'Studied business administration'),
(5, 'School V', 'Certificate in SQL', '2016-09-01', '2018-06-01', 'Studied SQL');