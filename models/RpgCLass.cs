using System.Text.Json.Serialization;
namespace dot.models
{
 [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgCLass
    {
        knight=1,
        mage=2,
        cleric=3
    }

  
}