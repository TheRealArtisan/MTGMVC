﻿CREATE TABLE [dbo].[Deck]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [DeckName] NVARCHAR(50) NOT NULL, 
    [DeckDescription] NVARCHAR(50) NULL
)