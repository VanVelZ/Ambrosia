Begin
	--Variables
	Declare @WorkoutTypeId uniqueidentifier
	Select @WorkoutTypeId = Id from tblWorkoutType where Name = 'Power Walking'

	Declare @UserId uniqueidentifier
	Select @UserId = Id from tblUser where LastName = 'Jenkins' AND FirstName = 'Leroy'

	Insert into [dbo].tblWorkout (Id, WorkoutTypeId, StartTime, EndTime, UserId)
	Values
	(NEWID(), @WorkoutTypeId, '2020-11-15 14:00:00', '2020-11-15 15:00:00', @UserId)
	
	--Entry 2

	Select @WorkoutTypeId = Id from tblWorkoutType where Name = 'Running'
	Select @UserId = Id from tblUser where LastName = 'Jenkins' AND FirstName = 'Leroy'

	Insert into [dbo].tblWorkout (Id, WorkoutTypeId, StartTime, EndTime, UserId)
	Values
	(NEWID(), @WorkoutTypeId, '2020-11-15 15:00:00', '2020-11-15 20:00:00', @UserId)

	--Entry 3

	Select @WorkoutTypeId = Id from tblWorkoutType where Name = 'Running'
	Select @UserId = Id from tblUser where LastName = 'Ferris' AND FirstName = 'Wheel'

	Insert into [dbo].tblWorkout (Id, WorkoutTypeId, StartTime, EndTime, UserId)
	Values
	(NEWID(), @WorkoutTypeId, '2020-11-14 15:00:00', '2020-11-14 16:00:00', @UserId)

	--Entry 4

	Select @WorkoutTypeId = Id from tblWorkoutType where Name = 'Walking'
	Select @UserId = Id from tblUser where LastName = 'Ferris' AND FirstName = 'Wheel'

	Insert into [dbo].tblWorkout (Id, WorkoutTypeId, StartTime, EndTime, UserId)
	Values
	(NEWID(), @WorkoutTypeId, '2020-11-15 13:00:00', '2020-11-15 18:00:00', @UserId)
End