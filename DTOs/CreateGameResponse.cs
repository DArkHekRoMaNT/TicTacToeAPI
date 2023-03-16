using ProtoBuf;

namespace TicTacToeAPI.DTOs
{
    [ProtoContract]
    public class CreateGameResponse
    {
        [ProtoMember(1)] public required int Id { get; set; }
        [ProtoMember(2)] public required GameResponse Game { get; set; }
    }
}