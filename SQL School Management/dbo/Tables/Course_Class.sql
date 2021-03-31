CREATE TABLE [dbo].[Course_Class] (
    [ClassId]   INT         IDENTITY (1, 1) NOT NULL,
    [ClassTime] TIME (7)    NOT NULL,
    [DayOfWeek] VARCHAR (9) NOT NULL,
    [CourseId]  INT         NOT NULL,
    [TeacherId] INT         NOT NULL,
    PRIMARY KEY CLUSTERED ([ClassId] ASC),
    FOREIGN KEY ([CourseId]) REFERENCES [dbo].[Course] ([CourseId]),
    FOREIGN KEY ([TeacherId]) REFERENCES [dbo].[Teacher] ([TeacherId]),
    CONSTRAINT [CHKDay] CHECK ([DayOfWeek]='Friday' OR [DayOfWeek]='Thursday' OR [DayOfWeek]='Wednesday' OR [DayOfWeek]='Tuesday' OR [DayOfWeek]='Monday')
);


