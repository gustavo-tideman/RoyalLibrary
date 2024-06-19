# Royal Library

As part of a software engineering challenge, I developed a project featuring two main endpoints: one that returns a list of table data and another that filters this data based on a specified parameter.

 - .NET 8
 - SQL Server
 - Docker
 - Entity Framework Core
 - xUnit
 - Moq

# Run the API using Docker

Run the command below in the same directory as the docker-compose.yml file.
    
This will automatically deploy a SQL Server image, create the database, tables and insert some rows for testing.

    docker-compose up --build

Wait about 3 minutes and then open the link in the browser:

    http://localhost:8669/index.html

# Database

The SQL file is inside the project. Here is the source code you need to run to create the database, table and insert three rows:

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
