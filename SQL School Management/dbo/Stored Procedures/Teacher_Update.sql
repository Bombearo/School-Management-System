CREATE PROCEDURE [dbo].[Teacher_Update]
	@DateJoined date,
	@Salary int,
	@BonusAdded bit,
	@Expertise nvarchar(20),
	@PersonId int


AS
BEGIN
	UPDATE Teacher
	SET dateJoined = @DateJoined,Salary = @Salary,BonusAdded = @BonusAdded,Expertise = @Expertise
	WHERE personId = @PersonId;
END

