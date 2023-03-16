using System.Net;
using System.Reflection;

namespace TicTacToeAPI.Endpoints
{
    public class ReadMeEndpoint : IEndpoint
    {
        public bool IsSuitable(string? path)
        {
            return path == "/";
        }

        public async Task Execute(HttpListenerContext ctx)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string? assemblyName = assembly.GetName().Name;
            using Stream? stream = assembly.GetManifestResourceStream($"{assemblyName}.README.md");
            if (stream == null)
            {
                ctx.Response.StatusCode = (int)HttpStatusCode.NotFound;
                ctx.Response.Close();
                return;
            }
            await stream.CopyToAsync(ctx.Response.OutputStream);
            ctx.Response.ContentType = "text/markdown";
            ctx.Response.StatusCode = (int)HttpStatusCode.OK;
            ctx.Response.Close();
        }
    }
}