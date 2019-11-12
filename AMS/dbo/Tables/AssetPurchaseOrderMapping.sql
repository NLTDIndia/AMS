CREATE TABLE [dbo].[AssetPurchaseOrderMapping] (
    [ID]              INT IDENTITY (1, 1) NOT NULL,
    [AssetID]         INT NOT NULL,
    [PurchaseOrderID] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_AssetPurchaseOrderMapping_Assets] FOREIGN KEY ([AssetID]) REFERENCES [dbo].[Assets] ([ID]),
    CONSTRAINT [FK_AssetPurchaseOrderMapping_PurchaseOrder] FOREIGN KEY ([PurchaseOrderID]) REFERENCES [dbo].[PurchaseOrder] ([ID])
);

