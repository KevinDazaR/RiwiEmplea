using System.Text.Json.Serialization;

namespace RiwiEmplea.Models.Enums
{
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum LevelEnum
  {
    Basic,
    Medium,
    Advanced    
  }
}