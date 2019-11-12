CREATE TABLE [dbo].[Log] (
    [LogId]     INT            IDENTITY (1, 1) NOT NULL,
    [Date]      DATETIME       NULL,
    [Thread]    VARCHAR (255)  NULL,
    [Level]     VARCHAR (50)   NULL,
    [Logger]    VARCHAR (255)  NULL,
    [Message]   VARCHAR (4000) NULL,
    [Exception] VARCHAR (2000) NULL,
    CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED ([LogId] ASC)
);

