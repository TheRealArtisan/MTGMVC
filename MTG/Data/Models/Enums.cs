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

    public enum Layouts
    {
        [EnumMember(Value = "normal")]
        Normal,
        [EnumMember(Value = "split")]
        Split,
        [EnumMember(Value = "flip")]
        Flip,
        [EnumMember(Value = "transform")]
        Transform,
        [EnumMember(Value = "meld")]
        Meld,
        [EnumMember(Value = "leveler")]
        Leveler,
        [EnumMember(Value = "saga")]
        Saga,
        [EnumMember(Value = "adventure")]
        Adventure,
        [EnumMember(Value = "modal_dfc")]
        Modal,
        [EnumMember(Value = "planar")]
        Planar,
        [EnumMember(Value = "scheme")]
        Scheme,
        [EnumMember(Value = "vanguard")]
        Vanguard,
        [EnumMember(Value = "token")]
        Token,
        [EnumMember(Value = "double_faced_token")]
        DoubleFacedToken,
        [EnumMember(Value = "emblem")]
        Emblem,
        [EnumMember(Value = "augment")]
        Augment,
        [EnumMember(Value = "host")]
        Host
    }

    public enum Format
    {
        Standard,
        Pioneer,
        Modern,
        Legacy,
        Vintage
    }
}
