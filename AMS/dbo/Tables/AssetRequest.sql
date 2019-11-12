CREATE TABLE [dbo].[AssetRequest] (
    [ID]                   INT             IDENTITY (1, 1) NOT NULL,
    [RequestedBy]          INT             NOT NULL,
    [RequestedTo]          INT             NOT NULL,
    [CreatedDate]          DATETIME        NOT NULL,
    [AssetRequestStatusID] INT             NOT NULL,
    [Priority]             INT             NOT NULL,
    [RequestedAsset]       NVARCHAR (1000) NOT NULL,
    CONSTRAINT [PK_AssetRequest] PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([AssetRequestStatusID]) REFERENCES [dbo].[AssetRequestStatus] ([ID])
);

