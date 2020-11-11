using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MTG.Data.Models
{
    public class CardFace
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        
        [JsonProperty(PropertyName = "type_line")]
        public string TypeLine { get; set; }
        
        [JsonProperty(PropertyName = "oracle_text")]
        public string OracleText { get; set; }
        
        [JsonProperty(PropertyName = "mana_cost")]
        public string ManaCost { get; set; }
        
        [JsonProperty(PropertyName = "colors")]
        public List<Colours?> Colors { get; set; }
        
        [JsonProperty(PropertyName = "color_indicator")]
        public List<Colours?> ColorIndicator { get; set; }
        
        [JsonProperty(PropertyName = "power")]
        public string Power { get; set; }
        
        [JsonProperty(PropertyName = "toughness")]
        public string Toughness { get; set; }
        
        [JsonProperty(PropertyName = "loyalty")]
        public string Loyalty { get; set; }
        
        [JsonProperty(PropertyName = "flavor_text")]
        public string FlavorText { get; set; }
        
        [JsonProperty(PropertyName = "illustration_id")]
        public string IllustrationId { get; set; }
        
        [JsonProperty(PropertyName = "image_uris")]
        public ImageUri ImageUris { get; set; }
    }
}