using System.Net;
using TicTacToeAPI.Models;
using TicTacToeAPI.Utils;

namespace TicTacToeAPI.Endpoints
{
    public class ShowGameEndpoint : BaseGameEndpoint
    {
        public ShowGameEndpoint(GameController gameController) : base(gameController) { }

        public override string SubPath => "$";

        public override (HttpStatusCode code, object? data) InnerExecute(HttpListenerContext ctx)
        {
            int gameId = GetGameId(ctx.Request.RawUrl!);
            if (_gameController.GameIds.Contains(gameId))
            {
                Game game = _gameController.GetGameById(gameId);
                return (HttpStatusCode.OK, game.ToGameResponse());
            }
            return (HttpStatusCode.NotFound, null);
        }
    }
}