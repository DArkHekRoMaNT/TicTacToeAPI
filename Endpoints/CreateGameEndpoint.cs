using System.Net;
using TicTacToeAPI.Models;

namespace TicTacToeAPI.Endpoints
{
    public class CreateGameEndpoint : BaseEndpoint
    {
        private readonly GameController _gameController;

        public CreateGameEndpoint(GameController gameController)
        {
            _gameController = gameController;
        }

        public override string Path => "^/game/create$";

        public override (HttpStatusCode code, object? data) InnerExecute(HttpListenerContext ctx)
        {
            int gameId = _gameController.Create();
            return (HttpStatusCode.OK, new CreateGameResponse
            {
                Id = gameId,
                Game = _gameController.GetGameById(gameId)
            });
        }
    }
}