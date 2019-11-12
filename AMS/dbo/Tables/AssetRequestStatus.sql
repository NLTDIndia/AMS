CREATE TABLE [dbo].[AssetRequestStatus] (
    [ID]          INT          IDENTITY (1, 1) NOT NULL,
    [Description] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_AssetRequestStatus] PRIMARY KEY CLUSTERED ([ID] ASC)
);

