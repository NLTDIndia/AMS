CREATE TABLE [dbo].[Components] (
    [ID]              INT             IDENTITY (1, 1) NOT NULL,
    [ComponentTypeID] INT             NOT NULL,
    [ComponentName]   VARCHAR (100)   NOT NULL,
    [CreatedDate]     DATETIME        NOT NULL,
    [CreatedBy]       INT             NOT NULL,
    [Description]     NVARCHAR (1000) NOT NULL,
    CONSTRAINT [PK__Components] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Components_ComponentType] FOREIGN KEY ([ComponentTypeID]) REFERENCES [dbo].[ComponentType] ([ID])
);

