CREATE TABLE [dbo].[Student]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[forename] VARCHAR(30) NOT NULL,
	[surname] VARCHAR(30) NOT NULL,
	[dob] date NOT NULL,
	[dateJoined] date NOT NULL,
	[contactNo] VARCHAR(11),
	[emailAddress] VARCHAR(50)
)
