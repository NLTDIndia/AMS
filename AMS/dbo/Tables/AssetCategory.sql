CREATE TABLE [dbo].[AssetCategory] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [Description] VARCHAR (50)  NOT NULL,
    [Comment]     VARCHAR (100) NOT NULL,
    CONSTRAINT [PK__AssetCat__3214EC270A85ACC9] PRIMARY KEY CLUSTERED ([ID] ASC)
);

