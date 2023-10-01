using System.Runtime.Serialization;

namespace ModernFrequency.Data.Models.Models.Enums
{
    public enum Genre
    {
        [EnumMember(Value = "Pop")]
        Pop,

        [EnumMember(Value = "HipHop")]
        HipHop1,

        [EnumMember(Value = "Rock")]
        Rock,

        [EnumMember(Value = "Metal")]
        Metal,

        [EnumMember(Value = "Electronic")]
        Electronic,

        [EnumMember(Value = "Jazz")]
        Jazz,

        [EnumMember(Value = "Techno")]
        Techno,

        [EnumMember(Value = "RnB")]
        RnB,

        [EnumMember(Value = "Country")]
        Country,

        [EnumMember(Value = "Classical")]
        Classical,

        [EnumMember(Value = "Rap")]
        Rap,

        [EnumMember(Value = "Dubstep")]
        Dubstep
    }
}
