using ProtoBuf;

namespace TicTacToeAPI.DTOs
{
    [ProtoContract]
    public class GameResponse
    {
        [ProtoMember(1)] public required string Field { get; set; }
        [ProtoMember(2)] public required string NextPlayer { get; set; }
        [ProtoMember(3)] public string? Winner { get; set; }
    }
}