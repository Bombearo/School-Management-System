CREATE VIEW [dbo].[FullStudent]
	AS SELECT [pup].[PupilId], 
	[pup].[DateJoined], 
	[pup].[PersonId], 
	[p].[Forename], 
	[p].[Surname], 
	[p].[DateOfBirth], 
	[p].[EmailAddress], 
	[p].[ContactNo]
	FROM dbo.Pupil pup
	left join dbo.Person p on pup.PersonId = p.PersonId

