CREATE TABLE [dbo].[tblUser]
(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY,
	[FirstName] nvarchar(50) NOT NULL,
	[LastName] nvarchar(50) NOT NULL, 
	[Username] nvarchar(150) NOT NULL,
	[Password] nvarchar(255) NOT NULL 
)
