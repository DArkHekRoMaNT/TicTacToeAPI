using System.Net;

namespace TicTacToeAPI.Endpoints
{
    public interface IEndpoint
    {
        Task Execute(HttpListenerContext ctx);
        bool IsSuitable(string? path);
    }
}