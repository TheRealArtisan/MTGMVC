using Newtonsoft.Json;
using System.Collections.Generic;

namespace MTGMVC.Data.Models
{
    public class Card
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "oracle_id")]
        public string OracleId { get; set; }

        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }

        [JsonProperty(PropertyName = "scryfall_uri")]
        public string ScryfallUri { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "cmc")]
        public double? Cmc { get; set; }

        [JsonProperty(PropertyName = "type_line")]
        public string TypeLine { get; set; }

        [JsonProperty(PropertyName = "oracle_text")]
        public string OracleText { get; set; }

        [JsonProperty(PropertyName = "mana_cost")]
        public string ManaCost { get; set; }

        [JsonProperty(PropertyName = "power")]
        public string Power { get; set; }

        [JsonProperty(PropertyName = "toughness")]
        public string Toughness { get; set; }

        [JsonProperty(PropertyName = "loyalty")]
        public string Loyalty { get; set; }

        [JsonProperty(PropertyName = "colors")]
        public List<Colours?> Colours { get; set; }

        [JsonProperty(PropertyName = "color_identity")]
        public List<Colours?> ColourIdentity { get; set; }

        //[JsonProperty(PropertyName = "card_faces")]
        //public List<CardFace> CardFaces { get; set; }

        [JsonProperty(PropertyName = "legalities")]
        public Legality Legalities { get; set; }

        [JsonProperty(PropertyName = "reserved")]
        public bool? Reserved { get; set; }

        [JsonProperty(PropertyName = "edhrec_rank")]
        public int? EdhrecRank { get; set; }

        [JsonProperty(PropertyName = "set")]
        public string Set { get; set; }

        [JsonProperty(PropertyName = "set_name")]
        public string SetName { get; set; }

        [JsonProperty(PropertyName = "image_uris")]
        public ImageUri ImageUris { get; set; }

        [JsonProperty(PropertyName = "highres_image")]
        public bool? HighresImage { get; set; }

        [JsonProperty(PropertyName = "rarity")]
        public Rarity? Rarity { get; set; }

        [JsonProperty(PropertyName = "flavor_text")]
        public string FlavorText { get; set; }

        [JsonProperty(PropertyName = "artist")]
        public string Artist { get; set; }

        [JsonProperty(PropertyName = "illustration_id")]
        public string IllustrationId { get; set; }

        [JsonProperty(PropertyName = "purchase_uris")]
        public Dictionary<string, string> PurchaseUris { get; set; }
    }
}