using ProtoBuf;

namespace TicTacToeAPI.Models
{
    [ProtoContract]
    public class GamesResponse
    {
        [ProtoMember(1)] public required int[] GameIds { get; set; }
    }
}