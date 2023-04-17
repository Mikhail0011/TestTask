USE [master]
GO

CREATE DATABASE [OnlineOrdersDB]
 ON  PRIMARY ( NAME = N'OnlineOrdersDB' )
GO

USE OnlineOrdersDB
GO

CREATE TABLE dbo.Clients
(
	ID    int IDENTITY(1,1) NOT NULL,
	Surname   varchar(250)  NOT NULL,
	"Name"    varchar(250)  NOT NULL,
	Lastname  varchar(250)  NULL,
	Gender    char(1)       NOT NULL,
	BirthDate date          NOT NULL,
	Phone     varchar(50)   NOT NULL,
	Email     varchar(250)  NOT NULL,
	CONSTRAINT PK_Clients
	   PRIMARY KEY (ID)
 );
GO

CREATE TABLE dbo.Statuses
(
	ID int IDENTITY(1,1) NOT NULL,
	"Name" varchar(50)   NOT NULL,
	CONSTRAINT PK_Statuses 
	   PRIMARY KEY (ID)
);
GO

CREATE TABLE dbo.ProductsItem
(
	ID        int NOT NULL,
	ProductID int NOT NULL,
	Quantity  int NOT NULL,
	Price     decimal(18, 2) NOT NULL,
	CONSTRAINT PK_ProductsItem
	   PRIMARY KEY (ID)
);
GO

CREATE TABLE dbo.Orders
(
	ID            int          NOT NULL,
	OrderDate     datetime2(7) NOT NULL,
	"Sum" AS udf_GetOrderSum(ProductsItems),
	ClientID      int          NOT NULL,
	StatusID      int          NOT NULL,
	ProductsItems varchar(255) NOT NULL,
	ClientComment varchar(255) NULL,
	CONSTRAINT PK_Orders 
	   PRIMARY KEY (ID),	
	CONSTRAINT FK_Orders_Clients 
	   FOREIGN KEY(ClientID)
	   REFERENCES dbo.Clients (ID),
	CONSTRAINT FK_Orders_Statuses 
	   FOREIGN KEY(StatusID)
	   REFERENCES dbo.Statuses (ID)
);