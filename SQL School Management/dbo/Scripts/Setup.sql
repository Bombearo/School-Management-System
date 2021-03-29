USE [master]
GO
/****** Object:  Database [SchoolDB]    Script Date: 2021-03-29 10:38:16 PM ******/
CREATE DATABASE [SchoolDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SchoolDB', FILENAME = N'C:\Users\Jaden\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\SchoolDB_Primary.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SchoolDB_log', FILENAME = N'C:\Users\Jaden\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\SchoolDB_Primary.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SchoolDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SchoolDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SchoolDB] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [SchoolDB] SET ANSI_NULLS ON 
GO
ALTER DATABASE [SchoolDB] SET ANSI_PADDING ON 
GO
ALTER DATABASE [SchoolDB] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [SchoolDB] SET ARITHABORT ON 
GO
ALTER DATABASE [SchoolDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SchoolDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SchoolDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SchoolDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SchoolDB] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [SchoolDB] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [SchoolDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SchoolDB] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [SchoolDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SchoolDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SchoolDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SchoolDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SchoolDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SchoolDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SchoolDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SchoolDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SchoolDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SchoolDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SchoolDB] SET  MULTI_USER 
GO
ALTER DATABASE [SchoolDB] SET PAGE_VERIFY NONE  
GO
ALTER DATABASE [SchoolDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SchoolDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SchoolDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SchoolDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SchoolDB] SET QUERY_STORE = OFF
GO
USE [SchoolDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [SchoolDB]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 2021-03-29 10:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[subject] [varchar](30) NOT NULL,
	[scqf] [int] NOT NULL,
	[level] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course_Class]    Script Date: 2021-03-29 10:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course_Class](
	[ClassId] [int] IDENTITY(1,1) NOT NULL,
	[ClassTime] [time](7) NOT NULL,
	[CourseId] [int] NOT NULL,
	[TeacherId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pupil]    Script Date: 2021-03-29 10:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pupil](
	[PupilId] [int] IDENTITY(1,1) NOT NULL,
	[forename] [varchar](30) NOT NULL,
	[surname] [varchar](30) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[dateJoined] [date] NOT NULL,
	[contactNo] [varchar](11) NULL,
	[emailAddress] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[PupilId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pupil Class]    Script Date: 2021-03-29 10:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pupil Class](
	[PupilId] [int] NOT NULL,
	[ClassId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PupilId] ASC,
	[ClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 2021-03-29 10:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[TeacherId] [int] IDENTITY(1,1) NOT NULL,
	[forename] [varchar](30) NOT NULL,
	[surname] [varchar](30) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[dateJoined] [date] NOT NULL,
	[salary] [int] NOT NULL,
	[bonusAdded] [bit] NOT NULL,
	[expertise] [varchar](20) NULL,
	[emailAddress] [varchar](50) NULL,
	[contactNo] [varchar](11) NULL,
PRIMARY KEY CLUSTERED 
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([CourseId], [subject], [scqf], [level]) VALUES (7, N'Computer Science', 6, N'Advanced Higher')
INSERT [dbo].[Course] ([CourseId], [subject], [scqf], [level]) VALUES (8, N'Maths', 5, N'Higher')
INSERT [dbo].[Course] ([CourseId], [subject], [scqf], [level]) VALUES (9, N'Cyber Security', 6, N'NPA')
SET IDENTITY_INSERT [dbo].[Course] OFF
GO
SET IDENTITY_INSERT [dbo].[Course_Class] ON 

INSERT [dbo].[Course_Class] ([ClassId], [ClassTime], [CourseId], [TeacherId]) VALUES (1, CAST(N'09:00:00' AS Time), 7, 2)
INSERT [dbo].[Course_Class] ([ClassId], [ClassTime], [CourseId], [TeacherId]) VALUES (2, CAST(N'09:00:00' AS Time), 8, 1)
INSERT [dbo].[Course_Class] ([ClassId], [ClassTime], [CourseId], [TeacherId]) VALUES (3, CAST(N'13:00:00' AS Time), 9, 3)
INSERT [dbo].[Course_Class] ([ClassId], [ClassTime], [CourseId], [TeacherId]) VALUES (4, CAST(N'13:30:00' AS Time), 9, 2)
SET IDENTITY_INSERT [dbo].[Course_Class] OFF
GO
SET IDENTITY_INSERT [dbo].[Pupil] ON 

INSERT [dbo].[Pupil] ([PupilId], [forename], [surname], [DateOfBirth], [dateJoined], [contactNo], [emailAddress]) VALUES (2, N'Cameron', N'Davis', CAST(N'2005-10-10' AS Date), CAST(N'2017-09-01' AS Date), N'01314229382', N'ScottDavis@outlook.co.uk')
INSERT [dbo].[Pupil] ([PupilId], [forename], [surname], [DateOfBirth], [dateJoined], [contactNo], [emailAddress]) VALUES (3, N'Keren', N'Von Karma', CAST(N'2004-04-20' AS Date), CAST(N'2016-09-01' AS Date), N'01314921168', N'KVKarma@gmail.com')
INSERT [dbo].[Pupil] ([PupilId], [forename], [surname], [DateOfBirth], [dateJoined], [contactNo], [emailAddress]) VALUES (4, N'Priscilla', N'Chan', CAST(N'2007-02-03' AS Date), CAST(N'2020-10-20' AS Date), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Pupil] OFF
GO
INSERT [dbo].[Pupil Class] ([PupilId], [ClassId]) VALUES (2, 1)
INSERT [dbo].[Pupil Class] ([PupilId], [ClassId]) VALUES (2, 2)
INSERT [dbo].[Pupil Class] ([PupilId], [ClassId]) VALUES (2, 3)
INSERT [dbo].[Pupil Class] ([PupilId], [ClassId]) VALUES (3, 1)
INSERT [dbo].[Pupil Class] ([PupilId], [ClassId]) VALUES (4, 3)
GO
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([TeacherId], [forename], [surname], [DateOfBirth], [dateJoined], [salary], [bonusAdded], [expertise], [emailAddress], [contactNo]) VALUES (1, N'Mark', N'Moloney', CAST(N'1983-03-04' AS Date), CAST(N'2019-01-09' AS Date), 10000, 0, N'Maths', N'MarkMoloney@edin.sch.uk', N'07879823144')
INSERT [dbo].[Teacher] ([TeacherId], [forename], [surname], [DateOfBirth], [dateJoined], [salary], [bonusAdded], [expertise], [emailAddress], [contactNo]) VALUES (2, N'Kathryn', N'Ewing', CAST(N'1992-10-20' AS Date), CAST(N'2018-01-09' AS Date), 12000, 0, N'Computing Science', N'KatEwing@gmail.com', N'07234132433')
INSERT [dbo].[Teacher] ([TeacherId], [forename], [surname], [DateOfBirth], [dateJoined], [salary], [bonusAdded], [expertise], [emailAddress], [contactNo]) VALUES (3, N'Chris', N'Tanning', CAST(N'1996-05-13' AS Date), CAST(N'2020-06-11' AS Date), 9000, 0, N'Computing Science', N'ChrisT@outlook.co.uk', N'07324777534')
SET IDENTITY_INSERT [dbo].[Teacher] OFF
GO
ALTER TABLE [dbo].[Teacher] ADD  DEFAULT (getdate()) FOR [dateJoined]
GO
ALTER TABLE [dbo].[Teacher] ADD  DEFAULT ((0)) FOR [bonusAdded]
GO
ALTER TABLE [dbo].[Course_Class]  WITH CHECK ADD FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[Course_Class]  WITH CHECK ADD FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([TeacherId])
GO
ALTER TABLE [dbo].[Pupil Class]  WITH CHECK ADD FOREIGN KEY([ClassId])
REFERENCES [dbo].[Course_Class] ([ClassId])
GO
ALTER TABLE [dbo].[Pupil Class]  WITH CHECK ADD FOREIGN KEY([PupilId])
REFERENCES [dbo].[Pupil] ([PupilId])
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD CHECK  (([scqf]<(10)))
GO
/****** Object:  StoredProcedure [dbo].[InsertTeacher]    Script Date: 2021-03-29 10:38:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
USE [master]
GO
ALTER DATABASE [SchoolDB] SET  READ_WRITE 
GO
