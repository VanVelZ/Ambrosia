Begin
	Insert into [dbo].tblUser (Id, FirstName, LastName, Username, Password)
	Values
	(NEWID(), 'Jon', 'Smith', 'Johnsmith', 'password'),
	(NEWID(), 'Leroy', 'Jenkins', 'LEROYJENKINS', 'password'),
	(NEWID(), 'Ferris', 'Wheel', 'ferriswheel', 'password')
End