CREATE TABLE [dbo].[Order] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Number]     INT           NOT NULL,
    [Text]       NVARCHAR (20) NULL,
    [CustomerId] INT           NULL,
    CONSTRAINT [PK__Order__3214EC079F190522] PRIMARY KEY CLUSTERED ([Id] ASC)
);

