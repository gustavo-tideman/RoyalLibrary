CREATE DATABASE RoyalLibrary
GO

USE RoyalLibrary
GO

CREATE TABLE books
(
	book_id INT PRIMARY KEY IDENTITY (1, 1),
	title Varchar(100) NOT NULL,
	first_name VARCHAR (50) NOT NULL,
	last_name VARCHAR (50) NOT NULL,
	total_copies INT NOT NULL DEFAULT 0,
	copies_in_use INT NOT NULL DEFAULT 0,
	type VARCHAR(50),
	isbn VARCHAR (80),
	category VARCHAR(50)
);

INSERT INTO [dbo].[books] ([title],[first_name],[last_name],[total_copies],[copies_in_use],[type],[isbn],[category]) VALUES ('Designing Data-Intensive Applications','Martin','Kleppmann','10','2','Printed','123456','Book')
GO

INSERT INTO [dbo].[books] ([title],[first_name],[last_name],[total_copies],[copies_in_use],[type],[isbn],[category]) VALUES ('Patterns of Enterprise Application Architecture','Martin','Fowler','20','5','Printed','432454','Book')
GO

INSERT INTO [dbo].[books] ([title],[first_name],[last_name],[total_copies],[copies_in_use],[type],[isbn],[category]) VALUES ('Clean Code','Robert','Martin','50','30','Printed','676899','Book')
GO