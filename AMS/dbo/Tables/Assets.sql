CREATE TABLE [dbo].[Assets] (
    [ID]            INT           IDENTITY (1, 1) NOT NULL,
    [AssetTypeID]   INT           NOT NULL,
    [AssetName]     VARCHAR (100) NOT NULL,
    [SerialNumber]  VARCHAR (100) NOT NULL,
    [AssetStatusID] INT           NOT NULL,
    [CreatedDate]   DATETIME      NOT NULL,
    [CreatedBy]     INT           NOT NULL,
    CONSTRAINT [PK__Assets__3214EC27FDDAE35C] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Assets_AssetStatus] FOREIGN KEY ([AssetStatusID]) REFERENCES [dbo].[AssetStatus] ([ID]),
    CONSTRAINT [FK_Assets_AssetTypes] FOREIGN KEY ([AssetTypeID]) REFERENCES [dbo].[AssetTypes] ([ID]),
    CONSTRAINT [FK_Assets_Employee] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Employee] ([ID])
);

