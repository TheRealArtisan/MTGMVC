using Newtonsoft.Json;

namespace MTGMVC.Data.Models
{
    public class ImageUri
    {
        [JsonProperty(PropertyName = "small")]
        public string Small { get; set; }

        [JsonProperty(PropertyName = "normal")]
        public string Normal { get; set; }

        [JsonProperty(PropertyName = "large")]
        public string Large { get; set; }

        [JsonProperty(PropertyName = "png")]
        public string Png { get; set; }

        [JsonProperty(PropertyName = "art_crop")]
        public string ArtCrop { get; set; }

        [JsonProperty(PropertyName = "border_crop")]
        public string BorderCrop { get; set; }
    }
}