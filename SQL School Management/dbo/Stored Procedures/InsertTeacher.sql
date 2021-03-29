CREATE PROCEDURE [dbo].[InsertTeacher]
	@Forename nvarchar(30),
	@Surname nvarchar(30),
	@DateOfBirth date,
	@DateJoined date,
	@Salary int,
	@BonusAdded bit,
	@Expertise nvarchar(20),
	@EmailAddress nvarchar(50),
	@ContactNo nvarchar(11)

AS
BEGIN
	INSERT INTO Teacher(forename,surname,dateOfBirth,DateJoined,Salary,BonusAdded,Expertise,EmailAddress,ContactNo)
	VALUES (@Forename,@Surname,@DateOfBirth,@DateJoined,@Salary,@BonusAdded,@Expertise,@EmailAddress,@ContactNo)
END
RETURN 0
