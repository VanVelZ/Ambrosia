CREATE TABLE [dbo].[tblWorkout]
(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY,
	[WorkoutTypeId] uniqueidentifier NOT NULL,
	[StartTime] datetime NOT NULL,
	[EndTime] datetime NOT NULL,
	[UserId] uniqueidentifier NOT NULL
)
