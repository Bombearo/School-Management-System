USE [master]
GO
/****** Object:  Database [SchoolDB]    Script Date: 2021-03-30 4:02:53 PM ******/
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
/****** Object:  Table [dbo].[Course]    Script Date: 2021-03-30 4:02:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [varchar](30) NOT NULL,
	[Scqf] [int] NOT NULL,
	[Level] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course_Class]    Script Date: 2021-03-30 4:02:53 PM ******/
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
/****** Object:  Table [dbo].[Person]    Script Date: 2021-03-30 4:02:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[Forename] [varchar](30) NOT NULL,
	[Surname] [varchar](30) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[EmailAddress] [varchar](50) NULL,
	[ContactNo] [varchar](11) NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pupil]    Script Date: 2021-03-30 4:02:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pupil](
	[PupilId] [int] IDENTITY(1,1) NOT NULL,
	[DateJoined] [date] NOT NULL,
	[PersonId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PupilId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pupil Class]    Script Date: 2021-03-30 4:02:53 PM ******/
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
/****** Object:  Table [dbo].[Teacher]    Script Date: 2021-03-30 4:02:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[TeacherId] [int] IDENTITY(1,1) NOT NULL,
	[Salary] [int] NOT NULL,
	[BonusAdded] [bit] NOT NULL,
	[Expertise] [varchar](20) NULL,
	[DateJoined] [date] NOT NULL,
	[PersonId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([CourseId], [Subject], [Scqf], [Level]) VALUES (1, N'Cyber Security', 5, N'NPA')
INSERT [dbo].[Course] ([CourseId], [Subject], [Scqf], [Level]) VALUES (2, N'Maths', 6, N'Advanced HIgher')
INSERT [dbo].[Course] ([CourseId], [Subject], [Scqf], [Level]) VALUES (3, N'Computer Science', 5, N'Higher')
INSERT [dbo].[Course] ([CourseId], [Subject], [Scqf], [Level]) VALUES (4, N'Computer Science', 6, N'Advanced Higher')
SET IDENTITY_INSERT [dbo].[Course] OFF
GO
SET IDENTITY_INSERT [dbo].[Course_Class] ON 

INSERT [dbo].[Course_Class] ([ClassId], [ClassTime], [CourseId], [TeacherId]) VALUES (2, CAST(N'09:00:00' AS Time), 1, 1)
INSERT [dbo].[Course_Class] ([ClassId], [ClassTime], [CourseId], [TeacherId]) VALUES (3, CAST(N'09:00:00' AS Time), 2, 2)
INSERT [dbo].[Course_Class] ([ClassId], [ClassTime], [CourseId], [TeacherId]) VALUES (4, CAST(N'10:30:00' AS Time), 1, 3)
INSERT [dbo].[Course_Class] ([ClassId], [ClassTime], [CourseId], [TeacherId]) VALUES (5, CAST(N'13:00:00' AS Time), 2, 2)
INSERT [dbo].[Course_Class] ([ClassId], [ClassTime], [CourseId], [TeacherId]) VALUES (6, CAST(N'13:00:00' AS Time), 3, 3)
INSERT [dbo].[Course_Class] ([ClassId], [ClassTime], [CourseId], [TeacherId]) VALUES (7, CAST(N'13:00:00' AS Time), 4, 1)
SET IDENTITY_INSERT [dbo].[Course_Class] OFF
GO
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([PersonId], [Forename], [Surname], [DateOfBirth], [EmailAddress], [ContactNo]) VALUES (1, N'Mark', N'Moloney', CAST(N'1992-10-20' AS Date), N'markMoloney@edu.edin.sch.uk', N'07879823144')
INSERT [dbo].[Person] ([PersonId], [Forename], [Surname], [DateOfBirth], [EmailAddress], [ContactNo]) VALUES (2, N'Kathryn', N'Ewing', CAST(N'1983-03-04' AS Date), N'KatEwing@gmail.com', N'07234132433')
INSERT [dbo].[Person] ([PersonId], [Forename], [Surname], [DateOfBirth], [EmailAddress], [ContactNo]) VALUES (3, N'Chris', N'Taner', CAST(N'1996-05-13' AS Date), N'ChrisT@outlook.co.uk', N'07324777534')
INSERT [dbo].[Person] ([PersonId], [Forename], [Surname], [DateOfBirth], [EmailAddress], [ContactNo]) VALUES (4, N'Cameron', N'Davis', CAST(N'2005-10-10' AS Date), N'ScottDavis@outlook.co.uk', N'01314229382')
INSERT [dbo].[Person] ([PersonId], [Forename], [Surname], [DateOfBirth], [EmailAddress], [ContactNo]) VALUES (5, N'Keren', N'Von Karma', CAST(N'2004-04-20' AS Date), N'KVKarma@gmail.com', N'01314921168')
INSERT [dbo].[Person] ([PersonId], [Forename], [Surname], [DateOfBirth], [EmailAddress], [ContactNo]) VALUES (6, N'Priscilla', N'Chan', CAST(N'2007-02-03' AS Date), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
SET IDENTITY_INSERT [dbo].[Pupil] ON 

INSERT [dbo].[Pupil] ([PupilId], [DateJoined], [PersonId]) VALUES (1, CAST(N'2017-09-01' AS Date), 4)
INSERT [dbo].[Pupil] ([PupilId], [DateJoined], [PersonId]) VALUES (2, CAST(N'2016-09-01' AS Date), 5)
INSERT [dbo].[Pupil] ([PupilId], [DateJoined], [PersonId]) VALUES (3, CAST(N'2020-10-20' AS Date), 6)
SET IDENTITY_INSERT [dbo].[Pupil] OFF
GO
INSERT [dbo].[Pupil Class] ([PupilId], [ClassId]) VALUES (1, 2)
INSERT [dbo].[Pupil Class] ([PupilId], [ClassId]) VALUES (2, 2)
INSERT [dbo].[Pupil Class] ([PupilId], [ClassId]) VALUES (2, 4)
INSERT [dbo].[Pupil Class] ([PupilId], [ClassId]) VALUES (2, 5)
INSERT [dbo].[Pupil Class] ([PupilId], [ClassId]) VALUES (2, 6)
INSERT [dbo].[Pupil Class] ([PupilId], [ClassId]) VALUES (3, 2)
GO
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([TeacherId], [Salary], [BonusAdded], [Expertise], [DateJoined], [PersonId]) VALUES (1, 10000, 0, N'Computer Science', CAST(N'2019-01-09' AS Date), 1)
INSERT [dbo].[Teacher] ([TeacherId], [Salary], [BonusAdded], [Expertise], [DateJoined], [PersonId]) VALUES (2, 12000, 0, N'Maths', CAST(N'2018-01-09' AS Date), 2)
INSERT [dbo].[Teacher] ([TeacherId], [Salary], [BonusAdded], [Expertise], [DateJoined], [PersonId]) VALUES (3, 9000, 0, N'Computer Science', CAST(N'2020-06-11' AS Date), 3)
SET IDENTITY_INSERT [dbo].[Teacher] OFF
GO
ALTER TABLE [dbo].[Pupil] ADD  DEFAULT (getdate()) FOR [DateJoined]
GO
ALTER TABLE [dbo].[Teacher] ADD  DEFAULT ((0)) FOR [BonusAdded]
GO
ALTER TABLE [dbo].[Teacher] ADD  DEFAULT (getdate()) FOR [DateJoined]
GO
ALTER TABLE [dbo].[Course_Class]  WITH CHECK ADD FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[Course_Class]  WITH CHECK ADD FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([TeacherId])
GO
ALTER TABLE [dbo].[Pupil]  WITH CHECK ADD FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Pupil Class]  WITH CHECK ADD FOREIGN KEY([ClassId])
REFERENCES [dbo].[Course_Class] ([ClassId])
GO
ALTER TABLE [dbo].[Pupil Class]  WITH CHECK ADD FOREIGN KEY([PupilId])
REFERENCES [dbo].[Pupil] ([PupilId])
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD CHECK  (([Scqf]<(10)))
GO
/****** Object:  StoredProcedure [dbo].[InsertTeacher]    Script Date: 2021-03-30 4:02:53 PM ******/
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
SELECT * FROM Teacher
END
RETURN 0
GO
USE [master]
GO
ALTER DATABASE [SchoolDB] SET  READ_WRITE 
GO
