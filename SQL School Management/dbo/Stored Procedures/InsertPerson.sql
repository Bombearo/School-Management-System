CREATE PROCEDURE [dbo].[InsertPerson]
	@Forename nvarchar(30),
	@Surname nvarchar(30),
	@DateOfBirth date,
	@EmailAddress nvarchar(50),
	@ContactNo nvarchar(11)
AS
BEGIN
	INSERT INTO Person(Forename,Surname,DateOfBirth,EmailAddress,ContactNo)
	VALUES (@Forename,@Surname,@DateOfBirth,@EmailAddress,@ContactNo);


END
RETURN 0
