namespace TicTacToeAPI.Endpoints
{
    public abstract class GameEndpoint : BaseEndpoint
    {
        protected GameController _gameController;

        public GameEndpoint(GameController gameController)
        {
            _gameController = gameController;
        }

        public override string Path => "^/game/[0-9]*" + SubPath;
        public abstract string SubPath { get; }

        public static int GetGameId(string url)
        {
            string[] parts = url.Split('/');
            return int.Parse(parts[2]);
        }
    }
}