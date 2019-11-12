CREATE TABLE [dbo].[EmployeeAssetMapping] (
    [ID]          INT      IDENTITY (1, 1) NOT NULL,
    [EmployeeID]  INT      NOT NULL,
    [AssetID]     INT      NOT NULL,
    [CreatedDate] DATETIME NOT NULL,
    [CreatedBy]   INT      NOT NULL,
    CONSTRAINT [PK_EmployeeAssetMapping] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK__EmployeeA__Asset__1EA48E88] FOREIGN KEY ([AssetID]) REFERENCES [dbo].[Assets] ([ID]),
    CONSTRAINT [FK_EmployeeAssetMapping_Employee] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([ID])
);

