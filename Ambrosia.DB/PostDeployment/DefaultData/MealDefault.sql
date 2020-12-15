Begin
	--Variables

	Declare @UserId2 uniqueidentifier
	Select @UserId2 = Id from tblUser where LastName = 'Jenkins' AND FirstName = 'Leroy'

	Insert into [dbo].tblMeal (Id, UserId, Description, Time)
	Values
	(NEWID(), @UserId2, 'Breakfast', '2020-11-15 08:00:00')
	
	--Entry 2

	Select @UserId2 = Id from tblUser where LastName = 'Jenkins' AND FirstName = 'Leroy'

	Insert into [dbo].tblMeal (Id, UserId, Description, Time)
	Values
	(NEWID(), @UserId2, 'Dinner', '2020-11-15 18:00:00')

	--Entry 3

	Select @UserId2 = Id from tblUser where LastName = 'Ferris' AND FirstName = 'Wheel'

	Insert into [dbo].tblMeal (Id, UserId, Description, Time)
	Values
	(NEWID(), @UserId2, 'Breakfast', '2020-11-14 08:30:00')

	--Entry 4

	Select @UserId2 = Id from tblUser where LastName = 'Ferris' AND FirstName = 'Wheel'

	Insert into [dbo].tblMeal (Id, UserId, Description, Time)
	Values
	(NEWID(), @UserId2, 'Lunch', '2020-11-15 12:00:00')

	--Entry 5

	Select @UserId2 = Id from tblUser where LastName = 'John' AND FirstName = 'Smith'

	Insert into [dbo].tblMeal (Id, UserId, Description, Time)
	Values
	(NEWID(), @UserId2, 'Lunch', '2020-11-15 12:00:00')
End