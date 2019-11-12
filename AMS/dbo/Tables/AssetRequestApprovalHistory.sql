CREATE TABLE [dbo].[AssetRequestApprovalHistory] (
    [ID]             INT             IDENTITY (1, 1) NOT NULL,
    [AssetRequestID] INT             NOT NULL,
    [RequestID]      INT             NOT NULL,
    [ApproverID]     INT             NOT NULL,
    [Comments]       NVARCHAR (1000) NOT NULL,
    [ApprovalStatus] INT             NOT NULL,
    [CreatedDate]    DATETIME        NOT NULL,
    [RequestedAsset] NVARCHAR (1000) NOT NULL,
    CONSTRAINT [PK_AssetRequestApprovalHistory] PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([ApprovalStatus]) REFERENCES [dbo].[AssetRequestStatus] ([ID]),
    FOREIGN KEY ([AssetRequestID]) REFERENCES [dbo].[AssetRequest] ([ID])
);

