namespace TicTacToeAPI.Models
{
    public class DataFile
    {
        public const string DefaultPath = "data.json";
        public required int LastGameId { get; set; }
        public required Dictionary<int, Game> Games { get; set; }
    }
}