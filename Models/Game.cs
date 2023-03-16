using ProtoBuf;

namespace TicTacToeAPI.Models
{
    [ProtoContract]
    public class Game
    {
        [ProtoMember(1)] public int Size { get; }
        [ProtoMember(2)] public Player[][] Cells { get; }
        [ProtoMember(3)] public Player NextPlayer { get; set; }
        [ProtoMember(4)] public Player Winner { get; set; }

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