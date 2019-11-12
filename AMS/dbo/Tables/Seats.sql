CREATE TABLE [dbo].[Seats] (
    [ID]         INT            IDENTITY (1, 1) NOT NULL,
    [LocationID] INT            NOT NULL,
    [SeatName]   NVARCHAR (500) NOT NULL,
    [IsFilled]   BIT            NULL,
    CONSTRAINT [PK_Seats] PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([LocationID]) REFERENCES [dbo].[Location] ([ID])
);

