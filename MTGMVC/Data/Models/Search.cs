using Newtonsoft.Json;
using System.Collections.Generic;

namespace MTGMVC.Data.Models
{
    public class Search
    {
        [JsonProperty(PropertyName = "total_cards")]
        public int? TotalCards { get; set; }

        [JsonProperty(PropertyName = "has_more")]
        public bool? HasMore { get; set; }

        [JsonProperty(PropertyName = "next_page")]
        public string NextPage { get; set; }

        [JsonProperty(PropertyName = "data")]
        public List<Card> Data { get; set; }
    }
}