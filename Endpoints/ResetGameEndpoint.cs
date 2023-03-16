using System.Net;

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
                return (HttpStatusCode.OK, _gameController.GetGameById(gameId));
            }
            return (HttpStatusCode.NotFound, null);
        }
    }
}