using System.Text;
using TicTacToeAPI.DTOs;
using TicTacToeAPI.Models;

namespace TicTacToeAPI.Utils
{
    public static class ConverterUtil
    {
        public static GameResponse ToGameResponse(this Game game)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < game.Size; i++)
            {
                for (int j = 0; j < game.Size; j++)
                {
                    Player value = game.Cells[i][j];
                    if (value == Player.None)
                    {
                        sb.Append('_');
                    }
                    else
                    {
                        sb.Append(value.ToString());
                    }
                }
                sb.Append(',');
            }
            return new GameResponse
            {
                Field = sb.ToString(),
                NextPlayer = game.NextPlayer.ToString(),
                Winner = game.Winner == Player.None ? null : game.Winner.ToString()
            };
        }
    }
}
