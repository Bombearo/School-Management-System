CREATE VIEW [dbo].[FullTeacher]
	AS SELECT [t].[TeacherId],
	[t].[Salary],
	[t].[BonusAdded],
	[t].[Expertise], 
	[t].[DateJoined], 
	[t].[PersonId],
	[p].[Forename], 
	[p].[Surname], 
	[p].[DateOfBirth], 
	[p].[EmailAddress], 
	[p].[ContactNo] 
	FROM dbo.Teacher t
	left join dbo.Person p on t.PersonId = p.PersonId
