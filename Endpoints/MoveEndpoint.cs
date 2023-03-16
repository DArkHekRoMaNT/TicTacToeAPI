using System.Collections.Specialized;
using System.Net;

namespace TicTacToeAPI.Endpoints
{
    public class MoveEndpoint : BaseGameEndpoint
    {
        public MoveEndpoint(GameController gameController) : base(gameController) { }

        public override string SubPath => "/move$";

        public override (HttpStatusCode code, object? data) InnerExecute(HttpListenerContext ctx)
        {
            int gameId = GetGameId(ctx.Request.RawUrl!);
            if (_gameController.GameIds.Contains(gameId))
            {
                NameValueCollection query = ctx.Request.QueryString;

                string? xStr = query["x"];
                string? yStr = query["y"];

                if (xStr == null || yStr == null)
                {
                    return (HttpStatusCode.BadRequest, null);
                }

                int x = int.Parse(xStr);
                int y = int.Parse(yStr);

                _gameController.Turn(gameId, x, y);

                return (HttpStatusCode.OK, _gameController.GetGameById(gameId));
            }
            return (HttpStatusCode.NotFound, null);
        }
    }
}