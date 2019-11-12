CREATE TABLE [dbo].[AssetTracker] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [AssetID]       INT            NOT NULL,
    [EmpID]         INT            NULL,
    [AssetStatusID] INT            NOT NULL,
    [CreatedDate]   DATETIME       NOT NULL,
    [CreatedBy]     INT            NOT NULL,
    [Remarks]       NVARCHAR (500) NOT NULL,
    CONSTRAINT [PK__AssetTra__3214EC27BC1F6045] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_AssetTracker_Assets] FOREIGN KEY ([AssetID]) REFERENCES [dbo].[Assets] ([ID]),
    CONSTRAINT [FK_AssetTracker_AssetStatus] FOREIGN KEY ([AssetStatusID]) REFERENCES [dbo].[AssetStatus] ([ID]),
    CONSTRAINT [FK_AssetTracker_Employee] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Employee] ([ID])
);

