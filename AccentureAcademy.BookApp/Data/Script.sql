CREATE DATABASE AccentureAcademyBookDb;
GO 

USE AccentureAcademyBookDb;
GO

CREATE TABLE Book
(
	Id int primary key identity(1,1),
	Title varchar(200) unique not null,
	ISBN varchar(22) unique not null,
	Edition DateTime not null,

);

CREATE TABLE Author
(
	Id int primary key identity(1,1),
	AuthorName varchar(50) not null,
	Country varchar(50) not null,
);

CREATE TABLE Genre
(
	Id int primary key identity(1,1),
	GenreName varchar(20) not null,
    CONSTRAINT UQ_Ritle UNIQUE (GenreName)
);

CREATE TABLE Publisher
(
	Id int primary key identity(1,1),
	PublisherName varchar(50) not null,
    CONSTRAINT UQ_Publisher UNIQUE (PublisherName)
);


CREATE TABLE WrittenBy
(	
	Id int primary key identity(1,1),
	BookId int not null,
	AuthorID int not null,
	CONSTRAINT UQ_Author_Book UNIQUE (BookID, AuthorID), 
	CONSTRAINT FK_Author	FOREIGN KEY (AuthorID)
						 REFERENCES Author(ID),
	CONSTRAINT FK_Book FOREIGN KEY (BookID)
						REFERENCES Book(ID),
);


GO

INSERT INTO Book
(Title, ISBN, Edition)
Values
('El nombre del viento','123458','2019-10-31')

INSERT INTO Author
(AuthorName, Country)
Values
('Gabriel García Márquez','CL'),
('Miguel de Cervantes','ES'),
('William Shakespeare','GB'),
('Antoine de Saint Exupéry','FR'),
('Patric Rothfuss','US')

INSERT INTO Genre
(GenreName)
Values
('Antropología'),
('Arqueología'),
('Fotografía'),
('Diseño'),
('Arquitectura')

INSERT INTO Publisher
(PublisherName)
Values
('Ariel'),
('Alianza'),
('Tecnos'),
('Síntesis')
