
create database DapperCrudApp;



CREATE TABLE Course (
                        CourseId SERIAL PRIMARY KEY,
                        CourseName VARCHAR(255) NOT NULL,
                        CourseDescription TEXT
);

CREATE TABLE Group (
                         GroupId SERIAL PRIMARY KEY,
                         GroupName VARCHAR(255) NOT NULL,
                         CorseId INT NOT NULL REFERENCES Course(CourseId),
                         StartDate DATE NOT NULL,
                         EndDate DATE NOT NULL
);

CREATE TABLE Mentor (
                        MentorId SERIAL PRIMARY KEY,
                        FirstName VARCHAR(100) NOT NULL,
                        LastName VARCHAR(100) NOT NULL,
                        Email VARCHAR(255) UNIQUE NOT NULL,
                        Phone VARCHAR(20),
                        Address TEXT,
                        BirthDate DATE NOT NULL
);

CREATE TABLE MentorGroup (
                             MentorGroupId SERIAL PRIMARY KEY,
                             MentorId INT NOT NULL REFERENCES Mentor(MentorId),
                             GroupId INT NOT NULL REFERENCES Group(GroupId)
);

CREATE TABLE Student (
                         StudentId SERIAL PRIMARY KEY,
                         FirstName VARCHAR(100) NOT NULL,
                         LastName VARCHAR(100) NOT NULL,
                         Email VARCHAR(255) UNIQUE NOT NULL,
                         Phone VARCHAR(20),
                         Address TEXT,
                         BirthDate DATE NOT NULL
);

CREATE TABLE StudentGroup (
                              StudentGroupId SERIAL PRIMARY KEY,
                              StudentId INT NOT NULL REFERENCES Student(StudentId),
                              GroupId INT NOT NULL REFERENCES Group(GroupId)
);
