CREATE DATABASE AccentureAcademyBookDb;

CREATE DATABASE AccentureAcademyBookDb;

CREATE DATABASE AccentureAcademyBookDb;
GO 

USE AccentureAcademyBookDb;
GO

USE  AccentureAcademyBookDb;
GO


CREATE TABLE Genre
(
	Id int primary key identity(1,1),
	GenreName varchar(50) unique not null
);

CREATE TABLE Publisher
(
	Id int primary key identity(1,1),
	PublisherName varchar(50) unique not null
);

CREATE TABLE Author
(
	Id int primary key identity(1,1),
	AuthorName varchar(50) unique not null
);

CREATE TABLE Book
(
	Id int primary key identity(1,1),
	Title varchar(50) unique not null,
	ISBN varchar(22) unique not null,
	Edition DateTime not null,
	AuthorID int not null,
	GenreID int not null,
	PublisherID int not null,
	CONSTRAINT FK_AUTHOR 
			FOREIGN KEY (AuthorID)
			REFERENCES Author(Id)
			ON DELETE CASCADE,
	CONSTRAINT FK_GENRE 
			FOREIGN KEY (GenreID)
			REFERENCES Genre(Id)
			ON DELETE CASCADE,
   CONSTRAINT FK_PUBLISHED_BY 
		FOREIGN KEY (PublisherID)
		REFERENCES Publisher(Id)
		ON DELETE CASCADE
);

INSERT INTO Author
(AuthorName)
Values
('Gabriel García Márquez'),
('Miguel de Cervantes'),
('William Shakespeare'),
('Antoine de Saint Exupéry'),
('Patric Rothfuss')

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