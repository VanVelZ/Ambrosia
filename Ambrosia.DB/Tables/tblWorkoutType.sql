CREATE TABLE [dbo].[tblWorkoutType]
(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY,
	[Name] nvarchar(50) NOT NULL,
	[CaloriesPerMinute] INT NOT NULL
)
