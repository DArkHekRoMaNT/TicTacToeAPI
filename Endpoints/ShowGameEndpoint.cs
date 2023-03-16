﻿using System.Net;

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
                return (HttpStatusCode.OK, _gameController.GetGameById(gameId));
            }
            return (HttpStatusCode.NotFound, null);
        }
    }
}