CREATE TABLE [dbo].[PurchaseOrder] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [QuotationID]      INT            NOT NULL,
    [InvoiceNumber]    NVARCHAR (200) NULL,
    [InvoiceFilePath]  NVARCHAR (200) NULL,
    [PurchaseStatusID] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_PurchaseOrder_PurchaseStatus] FOREIGN KEY ([PurchaseStatusID]) REFERENCES [dbo].[PurchaseStatus] ([ID]),
    CONSTRAINT [FK_PurchaseOrder_Quotation] FOREIGN KEY ([QuotationID]) REFERENCES [dbo].[Quotation] ([ID])
);

