using System.Net;
using TicTacToeAPI.Models;
using TicTacToeAPI.Utils;

namespace TicTacToeAPI.Endpoints
{
    public class ResetGameEndpoint : BaseGameEndpoint
    {
        public ResetGameEndpoint(GameController gameController) : base(gameController) { }

        public override string SubPath => "/reset$";

        public override (HttpStatusCode code, object? data) InnerExecute(HttpListenerContext ctx)
        {
            int gameId = GetGameId(ctx.Request.RawUrl!);
            if (_gameController.GameIds.Contains(gameId))
            {
                _gameController.Reset(gameId);
                Game game = _gameController.GetGameById(gameId);
                return (HttpStatusCode.OK, game.ToGameResponse());
            }
            return (HttpStatusCode.NotFound, null);
        }
    }
}