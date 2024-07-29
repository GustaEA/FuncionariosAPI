using System.Text.Json.Serialization;

namespace WebApplication1.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TurnEnums
    {
        Manha,
        Tarde,
        Noite
    }
}
