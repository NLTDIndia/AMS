CREATE TABLE [dbo].[Location] (
    [ID]       INT            IDENTITY (1, 1) NOT NULL,
    [Location] NVARCHAR (500) NOT NULL,
    [Building] NVARCHAR (500) NOT NULL,
    [Floor]    NVARCHAR (500) NOT NULL,
    [IsActive] BIT            NOT NULL,
    CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED ([ID] ASC)
);

