using Dapper;
using MTG.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace MTG.DataManagement
{
    public static class DataManager
    {
        public static int CreateDeck(string deckName, string deckDesc, List<CardItem> cards)
        {
            DeckModel deck = new DeckModel()
            {
                DeckName = deckName,
                DeckDescription = deckDesc
            };

            string sqlDeck = @"insert into dbo.Deck (DeckName, DeckDescription) output INSERTED.Id values (@DeckName, @DeckDescription);";

            int deckId = SaveData(sqlDeck, deck);

            foreach (var card in cards)
            {
                DeckCardModel deckCard = new DeckCardModel()
                {
                    DeckId = deckId,
                    CardId = card.CardID,
                    CardQuantity = card.Quantity
                };

                string sqlCard = @"insert into dbo.DeckCard (DeckId, CardId, CardQuantity) output INSERTED.Id values (@DeckId, @CardId, @CardQuantity);";

                int deckCardId = SaveData(sqlCard, deckCard);
            }

            return deckId;
        }


        public static string GetConnectionString(string connection = "MTGDB")
        {
            return ConfigurationManager.ConnectionStrings[connection].ConnectionString;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return (int)cnn.ExecuteScalar(sql, data);
            }
        }

        class DeckModel
        {
            public int DeckId { get; set; }
            public string DeckName { get; set; }
            public string DeckDescription { get; set; }
        }

        class DeckCardModel
        {
            public int DeckCardId { get; set; }
            public int DeckId { get; set; }
            public string CardId { get; set; }
            public int CardQuantity { get; set; }
        }
    }

    
}