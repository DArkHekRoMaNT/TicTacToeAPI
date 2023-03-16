using ProtoBuf;

namespace TicTacToeAPI.DTOs
{
    [ProtoContract]
    public class GamesResponse
    {
        [ProtoMember(1)] public required int[] GameIds { get; set; }
    }
}