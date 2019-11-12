CREATE TABLE [dbo].[HardwareAssets] (
    [ID]                INT            IDENTITY (1, 1) NOT NULL,
    [AssetID]           INT            NOT NULL,
    [Model]             NVARCHAR (500) NOT NULL,
    [ServiceTag]        NVARCHAR (500) NOT NULL,
    [Manufacturer]      NVARCHAR (500) NOT NULL,
    [WarrantyStartDate] DATETIME       NOT NULL,
    [WarrantyEndDate]   DATETIME       NOT NULL,
    [Comment]           NVARCHAR (500) NULL,
    CONSTRAINT [PK__Hardware__3214EC27F0501CA2] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_HardwareAssets_Assets] FOREIGN KEY ([AssetID]) REFERENCES [dbo].[Assets] ([ID])
);

