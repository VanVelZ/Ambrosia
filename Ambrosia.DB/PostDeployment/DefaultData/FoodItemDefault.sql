Begin
	--Variables

	Declare @MealId uniqueidentifier
	Declare @UserId3 uniqueidentifier
	Select @UserId3 = Id from tblUser where LastName = 'Jenkins' AND FirstName = 'Leroy'
	Select @MealId = Id from tblMeal where UserId = @UserId3 And Description = 'Breakfast'

	Insert into [dbo].tblFoodItem (Id, FDCId, MealId, Quantity)
	Values
	(NEWID(), 1102193, @MealId, 1)

	--Entry 2

	Select @UserId3 = Id from tblUser where LastName = 'Jenkins' AND FirstName = 'Leroy'
	Select @MealId = Id from tblMeal where UserId = @UserId3 AND Description = 'Dinner'

	Insert into [dbo].tblFoodItem (Id, FDCId, MealId, Quantity)
	Values
	(NEWID(), 1104086, @MealId, 1)

	--Entry 3

	Select @UserId3 = Id from tblUser where LastName = 'Ferris' AND FirstName = 'Wheel'
	Select @MealId = Id from tblMeal where UserId = @UserId3 AND Description = 'Breakfast'

	Insert into [dbo].tblFoodItem (Id, FDCId, MealId, Quantity)
	Values
	(NEWID(), 1099098, @MealId, 1)
End