﻿CREATE TABLE [dbo].[DeckCard]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[DeckId] INT NOT NULL,
    [CardId] NVARCHAR(50) NOT NULL, 
    [CardQuantity] INT NOT NULL, 
    [CardName] NVARCHAR(50) NOT NULL
)
