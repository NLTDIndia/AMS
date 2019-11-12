CREATE TABLE [dbo].[Quotation] (
    [ID]                    INT            IDENTITY (1, 1) NOT NULL,
    [VendorID]              INT            NOT NULL,
    [AssetRequestID]        INT            NOT NULL,
    [QuotationFilePath]     NVARCHAR (200) NOT NULL,
    [QuotationStatusID]     INT            NOT NULL,
    [QuotationReceivedDate] DATETIME       DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Quotation_AssetRequest] FOREIGN KEY ([AssetRequestID]) REFERENCES [dbo].[AssetRequest] ([ID]),
    CONSTRAINT [FK_Quotation_QuotationStatus] FOREIGN KEY ([QuotationStatusID]) REFERENCES [dbo].[QuotationStatus] ([ID]),
    CONSTRAINT [FK_Quotation_Vendor] FOREIGN KEY ([VendorID]) REFERENCES [dbo].[Vendor] ([ID])
);

