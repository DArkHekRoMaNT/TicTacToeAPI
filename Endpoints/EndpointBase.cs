using System.Net;
using System.Text.RegularExpressions;
using TicTacToeAPI.Utils;

namespace TicTacToeAPI.Endpoints
{
    public abstract class BaseEndpoint : IEndpoint
    {
        public abstract string Path { get; }

        public bool IsSuitable(string? url)
        {
            if (url == null)
            {
                return false;
            }
            url = url.Split('?')[0]; // remove query
            return Regex.IsMatch(url, Path);
        }

        public async Task Execute(HttpListenerContext ctx)
        {
            try
            {
                (HttpStatusCode status, object? data) = InnerExecute(ctx);
                ctx.Response.StatusCode = (int)status;
                if (data != null)
                {
                    ctx.Response.ContentType = "application/json";
                    await ctx.Response.SendJson(data);
                }
                ctx.Response.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ctx.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                ctx.Response.Close();
            }
        }

        public abstract (HttpStatusCode code, object? data) InnerExecute(HttpListenerContext ctx);
    }
}