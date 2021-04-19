CREATE TABLE [dbo].[TaskTable]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TaskName] NVARCHAR(50) NULL, 
    [TaskCompleted] BIT NULL
)
