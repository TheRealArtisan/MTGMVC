using Newtonsoft.Json;

namespace MTGMVC.Data.Models
{
    public class Legality
    {
        [JsonProperty(PropertyName = "standard")]
        public LegalStatus? Standard { get; set; }

        [JsonProperty(PropertyName = "pioneer")]
        public LegalStatus? Pioneer { get; set; }

        [JsonProperty(PropertyName = "modern")]
        public LegalStatus? Modern { get; set; }

        [JsonProperty(PropertyName = "legacy")]
        public LegalStatus? Legacy { get; set; }

        [JsonProperty(PropertyName = "vintage")]
        public LegalStatus? Vintage { get; set; }
    }
}