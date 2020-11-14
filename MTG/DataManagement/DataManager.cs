using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace MTG.DataManagement
{
    public static class DataManager
    {
        public static List<DeckItemDataModel> GetDecks()
        {
            string sql = "SELECT * FROM dbo.Deck";

            List<DeckItemDataModel> decks = LoadData<DeckItemDataModel>(sql);

            return decks;
        }

        public static int CreateDeck(string deckName, string deckDesc, List<Models.CardItem> cards)
        {
            DeckDataModel deck = new DeckDataModel()
            {
                DeckName = deckName,
                DeckDescription = deckDesc
            };

            string sqlDeck = @"insert into dbo.Deck (DeckName, DeckDescription) output INSERTED.Id values (@DeckName, @DeckDescription);";

            int deckId = SaveData(sqlDeck, deck, true);

            foreach (var card in cards)
            {
                DeckCardDataModel deckCard = new DeckCardDataModel()
                {
                    DeckId = deckId,
                    CardId = card.CardID,
                    CardQuantity = card.Quantity,
                    CardName = card.Name
                };

                string sqlCard = @"insert into dbo.DeckCard (DeckId, CardId, CardQuantity, CardName) output INSERTED.Id values (@DeckId, @CardId, @CardQuantity, @CardName);";

                int deckCardId = SaveData(sqlCard, deckCard);
            }

            return deckId;
        }

        public static void SaveDeck(int deckId, string deckName, string deckDesc, List<Models.CardItem> cards)
        {
            DeckDataModel deck = new DeckDataModel()
            {
                Id = deckId,
                DeckName = deckName,
                DeckDescription = deckDesc
            };

            string sqlDeck = @"update dbo.Deck set DeckName = @DeckName, DeckDescription = @DeckDescription where Id = @DeckId;";
            
            int r = SaveData(sqlDeck, deck);

            foreach (var card in cards)
            {
                DeckCardDataModel deckCard = new DeckCardDataModel()
                {
                    DeckId = deckId,
                    CardId = card.CardID,
                    CardQuantity = card.Quantity,
                    CardName = card.Name
                };

                string sqlCard = @"insert into dbo.DeckCard (DeckId, CardId, CardQuantity, CardName) output INSERTED.Id values (@DeckId, @CardId, @CardQuantity, @CardName);";

                int deckCardId = SaveData(sqlCard, deckCard);
            }

            return;
        }

        public static Tuple<DeckDataModel, List<DeckCardDataModel>> LoadDeck(int deckId)
        {
            string sqlDeck = $"SELECT * FROM dbo.Deck WHERE Id = {deckId}";

            DeckDataModel deck = LoadData<DeckDataModel>(sqlDeck).FirstOrDefault();

            string sqlCards = $"SELECT * FROM dbo.DeckCard WHERE DeckId = {deckId}";

            List<DeckCardDataModel> cards = LoadData<DeckCardDataModel>(sqlCards);

            return new Tuple<DeckDataModel, List<DeckCardDataModel>>(deck, cards);
        }

        private static string GetConnectionString(string connection = "MTGDB")
        {
            return ConfigurationManager.ConnectionStrings[connection].ConnectionString;
        }

        private static List<T> LoadData<T>(string sql)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        private static int SaveData<T>(string sql, T data, bool scalar = false)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString()))
            {
                if (scalar)
                {
                    return (int)cnn.ExecuteScalar(sql, data);
                }
                else
                {
                    return (int)cnn.Execute(sql, data);
                }
                
            }
        }

        public class DeckItemDataModel
        {
            public int Id { get; set; }
            public string DeckName { get; set; }
        }

        public class DeckDataModel
        {
            public int Id { get; set; }
            public string DeckName { get; set; }
            public string DeckDescription { get; set; }
        }

        public class DeckCardDataModel
        {
            public int DeckCardId { get; set; }
            public int DeckId { get; set; }
            public string CardId { get; set; }
            public int CardQuantity { get; set; }
            public string CardName { get; set; }
        }
    }

    
}