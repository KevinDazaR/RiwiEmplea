using System.Text.Json.Serialization;

namespace RiwiEmplea.Models.Enums
{
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum StateEnum
  {
    Active,
    Inactive
  }
}