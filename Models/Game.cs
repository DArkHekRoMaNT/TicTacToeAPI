namespace TicTacToeAPI.Models
{
    public class Game
    {
        public int Size { get; }
        public Player[][] Cells { get; }
        public Player NextPlayer { get; set; }
        public Player Winner { get; set; }

        public Game()
        {
            Size = 3;
            Cells = new Player[Size][];
            for (int i = 0; i < Size; i++)
            {
                Cells[i] = new Player[Size];
            }
            NextPlayer = Player.X;
            Winner = Player.None;
        }
    }
}