using System.Net;
using TicTacToeAPI.Models;

namespace TicTacToeAPI.Endpoints
{
    public class GamesEndpoint : BaseEndpoint
    {
        private readonly GameController _gameController;

        public GamesEndpoint(GameController gameController)
        {
            _gameController = gameController;
        }

        public override string Path => "^/games$";

        public override (HttpStatusCode code, object? data) InnerExecute(HttpListenerContext ctx)
        {
            return (HttpStatusCode.OK, new GamesResponse
            {
                GameIds = _gameController.GameIds
            });
        }
    }
}