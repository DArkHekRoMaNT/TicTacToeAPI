using System.Net;

namespace TicTacToeAPI.Endpoints
{
    public interface IEndpoint
    {
        string Path { get; }
        Task Execute(HttpListenerContext ctx);
        bool IsSuitable(string? path);
    }
}