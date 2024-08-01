-- Active: 1722468910909@@127.0.0.1@3306@bjfg41pkiuncnecnedjz
-- Insert data into Roles
INSERT INTO Roles (Name) VALUES 
('Staff'),
('Student');

-- Insert data into Users
INSERT INTO Users (FullName, Email, Password, GoogleId, State, RoleId) VALUES 
('John Doe', 'john.doe@example.com', 'password123', NULL, 'Active', 1),
('Jane Smith', 'jane.smith@example.com', 'password123', NULL, 'Active', 1),
('Alice Johnson', 'alice.johnson@example.com', 'password123', NULL, 'Inactive', 2),
('Bob Brown', 'bob.brown@example.com', 'password123', NULL, 'Active', 2),
('Charlie Davis', 'charlie.davis@example.com', 'password123', NULL, 'Inactive', 2);

-- Insert data into Resumes
INSERT INTO Resumes (Birthdate, PublicLink, AboutMe, CreatedAt, State, UserId) VALUES 
('1990-01-01', 'http://example.com/johndoe', 'Experienced software developer', NOW(), 'Active', 1),
('1992-02-02', 'http://example.com/janesmith', 'Project manager with 5 years experience', NOW(), 'Active', 2),
('1985-03-03', 'http://example.com/alicejohnson', 'HR specialist and recruiter', NOW(), 'Inactive', 3),
('1991-04-04', 'http://example.com/bobbrown', 'Senior developer with a focus on backend systems', NOW(), 'Active', 4),
('1988-05-05', 'http://example.com/charliedavis', 'Project coordinator with a background in marketing', NOW(), 'Inactive', 5);

-- Insert data into Skills
INSERT INTO Skills (Name, Level, State, ResumeId) VALUES 
('JavaScript', 'Advanced', 'Active', 1),
('Project Management', 'Advanced', 'Active', 2),
('Recruitment', 'Medium', 'Inactive', 3),
('Java', 'Advanced', 'Active', 4),
('Marketing', 'Medium', 'Inactive', 5);

-- Insert data into WorkExperiences
INSERT INTO WorkExperiences (Company, Position, Description, StartDate, EndDate, State, ResumeId) VALUES 
('Tech Corp', 'Software Engineer', 'Developed web applications', '2015-01-01', '2020-01-01', 'Active', 1),
('Business Solutions', 'Project Manager', 'Managed multiple projects', '2016-02-01', '2021-02-01', 'Active', 2),
('HR Pros', 'HR Specialist', 'Handled recruitment and training', '2013-03-01', '2018-03-01', 'Inactive', 3),
('Innovative Tech', 'Senior Developer', 'Led backend development team', '2014-04-01', '2019-04-01', 'Active', 4),
('Market Masters', 'Project Coordinator', 'Coordinated marketing campaigns', '2012-05-01', '2017-05-01', 'Inactive', 5);

-- Insert data into AcademicTrainings
INSERT INTO AcademicTrainings (Institution, Title, Description, StartDate, EndDate, State, ResumeId) VALUES 
('Tech University', 'BSc in Computer Science', 'Studied software development', '2008-09-01', '2012-06-01', 'Active', 1),
('Business School', 'MBA', 'Focused on project management', '2009-09-01', '2011-06-01', 'Active', 2),
('State University', 'BA in Human Resources', 'Learned about recruitment and training', '2005-09-01', '2009-06-01', 'Inactive', 3),
('Tech Institute', 'MSc in Software Engineering', 'Specialized in backend systems', '2010-09-01', '2012-06-01', 'Active', 4),
('Marketing Academy', 'BBA in Marketing', 'Focused on marketing strategies', '2007-09-01', '2011-06-01', 'Inactive', 5);