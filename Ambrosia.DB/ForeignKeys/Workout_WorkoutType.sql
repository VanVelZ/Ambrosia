ALTER TABLE [dbo].[tblWorkout]
	ADD CONSTRAINT [Workout_WorkoutType]
	FOREIGN KEY (WorkoutTypeId)
	REFERENCES [tblWorkoutType] (Id)
