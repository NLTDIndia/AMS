CREATE TABLE [dbo].[ComponentType] (
    [ID]              INT           IDENTITY (1, 1) NOT NULL,
    [Name]            VARCHAR (100) NOT NULL,
    [AssetTypeID]     INT           NOT NULL,
    [IsActive]        BIT           NOT NULL,
    [CreatedDate]     DATETIME      NOT NULL,
    [CreatedBy]       INT           NOT NULL,
    [AssetCategoryId] INT           NOT NULL,
    CONSTRAINT [PK__ComponentType] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_ComponentType_AssetCategory] FOREIGN KEY ([AssetCategoryId]) REFERENCES [dbo].[AssetCategory] ([ID]),
    CONSTRAINT [FK_ComponentType_AssetTypes] FOREIGN KEY ([AssetTypeID]) REFERENCES [dbo].[AssetTypes] ([ID])
);

