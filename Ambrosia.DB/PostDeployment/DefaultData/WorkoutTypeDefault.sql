Begin
	Insert into [dbo].tblWorkoutType(Id, Name, CaloriesPerMinute )
	Values
	(NEWID(), 'Walking', 5),
	(NEWID(), 'Power Walking', 8),
	(NEWID(), 'Running', 11)
End