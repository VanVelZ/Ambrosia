ALTER TABLE [dbo].[tblWorkout]
	ADD CONSTRAINT [Workout_User]
	FOREIGN KEY (UserId)
	REFERENCES [tblUser] (Id)
