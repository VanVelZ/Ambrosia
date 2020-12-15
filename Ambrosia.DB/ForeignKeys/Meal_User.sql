ALTER TABLE [dbo].[tblMeal]
	ADD CONSTRAINT [Meal_User]
	FOREIGN KEY (UserId)
	REFERENCES [tblUser] (Id)
