CREATE TABLE [dbo].[ComponentAssetMapping] (
    [ID]              INT      IDENTITY (1, 1) NOT NULL,
    [ComponentID]     INT      NOT NULL,
    [AssignedAssetID] INT      NULL,
    [ActualAssetID]   INT      NULL,
    [AssignedDate]    DATETIME NOT NULL,
    [AssignedBy]      INT      NOT NULL,
    [CreatedDate]     DATETIME NOT NULL,
    [CreatedBy]       INT      NOT NULL,
    CONSTRAINT [PK_ComponentAssetMapping] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK__Component__Actua__44CA3770] FOREIGN KEY ([ActualAssetID]) REFERENCES [dbo].[Assets] ([ID]),
    CONSTRAINT [FK__Component__Assig__43D61337] FOREIGN KEY ([AssignedAssetID]) REFERENCES [dbo].[Assets] ([ID]),
    CONSTRAINT [FK_ComponentAssetMapping_Components] FOREIGN KEY ([ComponentID]) REFERENCES [dbo].[Components] ([ID])
);

