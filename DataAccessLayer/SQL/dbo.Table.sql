CREATE TABLE [dbo].[Pokemon]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Name] VARCHAR (50) NULL,
	[Type] VARCHAR (50) NULL,
	[Weakness] VARCHAR (50) NULL,
	[Abilities] VARCHAR (50) NULL,
	[Weight] DECIMAL (20, 2),
	[Height] DECIMAL (20,2),
	[Description] VARCHAR (50) NULL,
	[Category] VARCHAR (50) NULL,
	[ImageFileName] VARCHAR (50) NULL,
);
