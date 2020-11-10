using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MTG.Data.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Colours
    {
        [EnumMember(Value = "W")]
        White,
        [EnumMember(Value = "U")]
        Blue,
        [EnumMember(Value = "B")]
        Black,
        [EnumMember(Value = "R")]
        Red,
        [EnumMember(Value = "G")]
        Green
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Rarity
    {
        [EnumMember(Value = "common")]
        Common,
        [EnumMember(Value = "uncommon")]
        Uncommon,
        [EnumMember(Value = "rare")]
        Rare,
        [EnumMember(Value = "mythic")]
        Mythic
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum LegalStatus
    {
        [EnumMember(Value = "legal")]
        Legal,
        [EnumMember(Value = "not_legal")]
        NotLegal,
        [EnumMember(Value = "restricted")]
        Restricted,
        [EnumMember(Value = "banned")]
        Banned
    }
}
