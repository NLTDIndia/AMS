CREATE TABLE [dbo].[Vendor] (
    [ID]            INT             IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (200)  NOT NULL,
    [Address]       NVARCHAR (2000) NOT NULL,
    [Email]         NVARCHAR (200)  NOT NULL,
    [ContactNumber] NVARCHAR (50)   NOT NULL,
    [ContactPerson] NVARCHAR (200)  NOT NULL,
    [CreatedDate]   DATETIME        DEFAULT (getdate()) NULL,
    [CreatedBy]     INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Vendor_Employee] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Employee] ([ID])
);

