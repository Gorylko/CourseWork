CREATE DATABASE [ConsoleShop]
Set DateFormat MDY
GO
USE [ConsoleShop];
CREATE TABLE [dbo].[Category]
(
	[Id] INT IDENTITY (1,1) NOT NULL,
   	[Name] NVARCHAR(20) NOT NULL,

 	PRIMARY KEY CLUSTERED([Id] ASC)
);
GO
CREATE TABLE [dbo].[Location]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	PRIMARY KEY CLUSTERED([Id]ASC)
);
GO
CREATE TABLE [dbo].[State]
(
	[Id]INT IDENTITY(1,1) NOT NULL,
	[Name]NVARCHAR(40) NOT NULL,
	PRIMARY KEY CLUSTERED([Id]ASC)
);
GO
CREATE TABLE [dbo].[Role]
(
	[Id] INT IDENTITY (1,1) NOT NULL,
	[Name] NVARCHAR(20) NOT NULL,
	PRIMARY KEY CLUSTERED([Id] ASC)
);
GO
CREATE TABLE [dbo].[User]
(
	[Id] INT IDENTITY (1,1) NOT NULL,
	[RoleId] INT NOT NULL,
   	[Login] NVARCHAR(20) NOT NULL,
	[Password] NVARCHAR(20) NOT NULL,
	[Email] NVARCHAR(20) NOT NULL,
	[PhoneNumber] NVARCHAR(15) NULL,
 	PRIMARY KEY CLUSTERED([Id] ASC),
	FOREIGN KEY(RoleId) REFERENCES [dbo].[Role]([Id])
);
GO
CREATE TABLE [dbo].[Product]
(
	[Id]INT IDENTITY(1,1) NOT NULL,
	[UserId] INT NOT NULL,
	[CategoryId]INT NOT NULL,
	[LocationId]INT NOT NULL,
	[StateId]INT NOT NULL,
	[Name]NVARCHAR(MAX) NOT NULL,
	[Description]NVARCHAR(MAX) NOT NULL,
	[Price]DECIMAL NOT NULL,
	[CreationDate]DATETIME NOT NULL,
	[LastModifiedDate]DATETIME NOT NULL,
	PRIMARY KEY CLUSTERED([Id]ASC),
	FOREIGN KEY([CategoryId]) REFERENCES [dbo].[Category]([Id]),
	FOREIGN KEY([LocationId]) REFERENCES [dbo].[Location]([Id]),
	FOREIGN KEY([StateId]) REFERENCES [dbo].[State]([Id]),
	FOREIGN KEY([UserId]) REFERENCES [dbo].[User]([Id])
);
GO
CREATE TABLE [dbo].[Purchase]
(
	[Id]INT IDENTITY(1,1) NOT NULL,
	[ProductId]INT NOT NULL,
	[SellerId]INT NOT NULL,
	[CustomerId]INT NOT NULL,
	[Address]NVARCHAR(100)NOT NULL,
	[Date]DATETIME NOT NULL,
	PRIMARY KEY CLUSTERED ([Id]ASC),
	FOREIGN KEY([ProductId])REFERENCES [dbo].[Product](Id),
	FOREIGN KEY([SellerId])REFERENCES [dbo].[User](Id),
	FOREIGN KEY([CustomerId])REFERENCES [dbo].[User](Id),

);
GO
