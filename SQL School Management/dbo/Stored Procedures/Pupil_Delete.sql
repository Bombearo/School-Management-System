CREATE PROCEDURE [dbo].[Pupil_Delete]
	@PersonId int,
    @PupilId int
AS
BEGIN
DELETE FROM [Pupil Class]
WHERE PupilId = @PupilId;
DELETE FROM Pupil
WHERE PersonId = @PersonId;
DELETE FROM Person
WHERE PersonId = @PersonId;

END