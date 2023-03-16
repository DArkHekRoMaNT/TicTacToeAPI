using System.Net;

namespace TicTacToeAPI.Endpoints
{
    public class ResetGameEndpoint : GameEndpoint
    {
        public ResetGameEndpoint(GameController gameController) : base(gameController) { }

        public override string SubPath => "/reset$";

        public override (HttpStatusCode code, object? data) InnerExecute(HttpListenerContext ctx)
        {
            int gameId = GetGameId(ctx.Request.RawUrl!);
            _gameController.Reset(gameId);
            return (HttpStatusCode.OK, _gameController.GetGameById(gameId));
        }
    }
}