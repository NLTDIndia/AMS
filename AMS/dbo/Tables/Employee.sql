CREATE TABLE [dbo].[Employee] (
    [ID]             INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeID]     INT            NOT NULL,
    [EmployeeRoleID] INT            NOT NULL,
    [EmployeeName]   NVARCHAR (500) NOT NULL,
    [SeatID]         INT            NOT NULL,
    [MailID]         NVARCHAR (100) NOT NULL,
    [CreatedDate]    DATETIME       NOT NULL,
    [CreatedBy]      INT            NOT NULL,
    [ISActive]       BIT            NOT NULL,
    [ManagerID]      INT            NULL,
    [CorpId]         VARCHAR (50)   NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([EmployeeRoleID]) REFERENCES [dbo].[EmployeeRole] ([ID]),
    FOREIGN KEY ([SeatID]) REFERENCES [dbo].[Seats] ([ID])
);

