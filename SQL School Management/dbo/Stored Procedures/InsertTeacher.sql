CREATE PROCEDURE [dbo].[InsertTeacher]
	@DateJoined date,
	@Salary int,
	@BonusAdded bit,
	@Expertise nvarchar(20),
	@PersonID int


AS
BEGIN
	INSERT INTO Teacher(DateJoined,PersonId,Salary,BonusAdded,Expertise)
	VALUES (@DateJoined,@PersonId,@Salary,@BonusAdded,@Expertise);


END
RETURN 0

