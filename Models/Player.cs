using System.Text.Json.Serialization;

namespace TicTacToeAPI.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Player : int
    {
        None = 0,
        X = 1,
        O = 2
    }
}