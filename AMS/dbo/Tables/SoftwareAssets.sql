CREATE TABLE [dbo].[SoftwareAssets] (
    [ID]                  INT            IDENTITY (1, 1) NOT NULL,
    [AssetID]             INT            NOT NULL,
    [ProductName]         NVARCHAR (500) NOT NULL,
    [LicenceNumber]       NVARCHAR (500) NOT NULL,
    [LicencePurchaseDate] DATETIME       NOT NULL,
    [LicenceExpiryDate]   DATETIME       NOT NULL,
    [Comment]             NVARCHAR (500) NULL,
    CONSTRAINT [PK__Software__3214EC2725D3A9CA] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_SoftwareAssets_Assets] FOREIGN KEY ([AssetID]) REFERENCES [dbo].[Assets] ([ID])
);

