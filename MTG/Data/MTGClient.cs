﻿using MTG.Data.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace MTG.Data
{
    public class MTGClient
    {
        private string baseURL = "https://api.scryfall.com";

        private T Execute<T>(MethodType type, string parameters)
        {
            try
            {
                T data;
                HttpWebRequest request = WebRequest.CreateHttp($"{baseURL}/{parameters}");
                request.Method = type.ToString();

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            string json = reader.ReadToEnd();

                            data = JsonConvert.DeserializeObject<T>(json);
                        }
                    }
                }
                return data;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {

            }
        }

        public Search SearchCards(string query)
        {
            string parameters = $"cards/search?unique=cards&pretty=true&q={System.Uri.EscapeDataString(query)}";

            return Execute<Search>(MethodType.GET, parameters);
        }
        
        public string GetImageFromCard(Card card)
        {
            if (card.ImageUris?.Small != null)
            {
                return card.ImageUris?.Small;
            }

            if (card.CardFaces[0].ImageUris?.Small != null)
            {
                return card.CardFaces[0].ImageUris?.Small;
            }

            return null;
        }
    }

    public enum MethodType
    {
        GET,
        PUT,
        POST
    }
}
