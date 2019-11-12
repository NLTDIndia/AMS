CREATE TABLE [dbo].[EmployeeRole] (
    [ID]          INT          IDENTITY (1, 1) NOT NULL,
    [Designation] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_EmployeeRole] PRIMARY KEY CLUSTERED ([ID] ASC)
);

