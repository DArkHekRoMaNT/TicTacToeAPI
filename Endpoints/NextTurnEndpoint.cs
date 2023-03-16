using System.Collections.Specialized;
using System.Net;

namespace TicTacToeAPI.Endpoints
{
    public class NextTurnEndpoint : GameEndpoint
    {
        public NextTurnEndpoint(GameController gameController) : base(gameController) { }

        public override string SubPath => "/turn$";

        public override (HttpStatusCode code, object? data) InnerExecute(HttpListenerContext ctx)
        {
            int gameId = GetGameId(ctx.Request.RawUrl!);

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
    }
}