using System.Net;

namespace TicTacToeAPI.Endpoints
{
    public class RemoveGameEndpoint : BaseGameEndpoint
    {
        public RemoveGameEndpoint(GameController gameController) : base(gameController) { }

        public override string SubPath => "/remove$";

        public override (HttpStatusCode code, object? data) InnerExecute(HttpListenerContext ctx)
        {
            int gameId = GetGameId(ctx.Request.RawUrl!);
            if (_gameController.GameIds.Contains(gameId))
            {
                _gameController.Remove(gameId);
                return (HttpStatusCode.OK, null);
            }
            return (HttpStatusCode.NotFound, null);
        }
    }
}