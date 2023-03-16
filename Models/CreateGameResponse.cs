using ProtoBuf;

namespace TicTacToeAPI.Models
{
    [ProtoContract]
    public class CreateGameResponse
    {
        [ProtoMember(1)] public required int Id { get; set; }
        [ProtoMember(2)] public required Game Game { get; set; }
    }
}