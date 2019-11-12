CREATE TABLE [dbo].[AssetTypes] (
    [ID]              INT          IDENTITY (1, 1) NOT NULL,
    [Description]     VARCHAR (50) NOT NULL,
    [AssetCategoryID] INT          NOT NULL,
    CONSTRAINT [PK__AssetTyp__3214EC277868B57A] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_AssetTypes_AssetCategory] FOREIGN KEY ([AssetCategoryID]) REFERENCES [dbo].[AssetCategory] ([ID])
);

