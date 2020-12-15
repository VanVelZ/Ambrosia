ALTER TABLE [dbo].[tblFoodItem]
	ADD CONSTRAINT [FoodItem_Meal]
	FOREIGN KEY (MealId)
	REFERENCES [tblMeal] (Id)
