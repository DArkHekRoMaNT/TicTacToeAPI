namespace TicTacToeAPI
{
    public class Program
    {
        private static async Task Main()
        {
            var gameController = new GameController();
            gameController.Load();

            var api = new ApiListener("http://127.0.0.1:41234/", gameController);
            await api.Loop();
        }
    }
}