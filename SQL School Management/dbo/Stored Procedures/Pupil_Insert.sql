CREATE PROCEDURE [dbo].[Pupil_Insert]
	@DateJoined date,
	@PersonId int


AS
BEGIN
	INSERT INTO Pupil(DateJoined,PersonId)
	VALUES (@DateJoined,@PersonId);
	SELECT CAST(SCOPE_IDENTITY() AS INT);

END