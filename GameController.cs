using System.Text.Json;
using TicTacToeAPI.Models;

namespace TicTacToeAPI
{
    public class GameController
    {
        private int _lastGameId = 0;
        private Dictionary<int, Game> Games { get; } = new();

        public int[] GameIds => Games.Keys.ToArray();

        public Game GetGameById(int gameId)
        {
            return Games[gameId];
        }

        public void Save()
        {
            lock (Games)
            {
                string json = JsonSerializer.Serialize(
                    new DataFile
                    {
                        LastGameId = _lastGameId,
                        Games = Games
                    },
                    new JsonSerializerOptions
                    {
                        WriteIndented = true,
                    });
                File.WriteAllText(DataFile.DefaultPath, json);
            }
        }

        public void Load()
        {
            lock (Games)
            {
                if (!File.Exists(DataFile.DefaultPath))
                {
                    Save();
                    return;
                }

                string json = File.ReadAllText(DataFile.DefaultPath);
                DataFile? data = JsonSerializer.Deserialize<DataFile>(json);
                if (data != null)
                {
                    _lastGameId = data.LastGameId;
                    Games.Clear();
                    foreach (KeyValuePair<int, Game> pair in data.Games)
                    {
                        Games.Add(pair.Key, pair.Value);
                    }
                }
            }
        }

        public int Create()
        {
            int gameId = _lastGameId++;
            Games.Add(gameId, new Game());
            Save();
            return gameId;
        }

        public void Remove(int gameId)
        {
            Games.Remove(gameId);
            Save();
        }

        public void Reset(int gameId)
        {
            Game game = GetGameById(gameId);
            for (int i = 0; i < game.Size; i++)
            {
                for (int j = 0; j < game.Size; j++)
                {
                    game.Cells[i][j] = Player.None;
                }
            }
            game.NextPlayer = Player.X;
            game.Winner = Player.None;
            Save();
        }

        public void Turn(int gameId, int x, int y)
        {
            Game game = GetGameById(gameId);

            if (game.Cells[x][y] != Player.None)
            {
                throw new InvalidOperationException("Cell not empty");
            }

            if (game.Winner != Player.None)
            {
                throw new InvalidOperationException("Has winner");
            }

            Player player = game.NextPlayer;
            game.Cells[x][y] = player;
            if (CheckWin(game, x, y, player))
            {
                game.Winner = player;
            }
            game.NextPlayer = player == Player.X ? Player.O : Player.X;
            Save();
        }

        private static bool CheckWin(Game game, int x, int y, Player player)
        {
            // check col
            for (int i = 0; i < game.Size; i++)
            {
                if (game.Cells[x][i] != player)
                {
                    break;
                }

                if (i == game.Size - 1)
                {
                    return true;
                }
            }

            // check row
            for (int i = 0; i < game.Size; i++)
            {
                if (game.Cells[i][y] != player)
                {
                    break;
                }

                if (i == game.Size - 1)
                {
                    return true;
                }
            }

            // check diag
            if (x == y)
            {
                for (int i = 0; i < game.Size; i++)
                {
                    if (game.Cells[i][i] != player)
                    {
                        break;
                    }

                    if (i == game.Size - 1)
                    {
                        return true;
                    }
                }
            }

            // check opposite diag
            if (x + y == game.Size - 1)
            {
                for (int i = 0; i < game.Size; i++)
                {
                    if (game.Cells[i][game.Size - 1 - i] != player)
                    {
                        break;
                    }

                    if (i == game.Size - 1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}