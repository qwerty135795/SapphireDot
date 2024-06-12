using System.Text.Json.Serialization;

namespace MessageService.Entities;

[JsonDerivedType(typeof(TextMessage))]
public abstract class MessageBase
{
    public Guid Id { get; init; }
    public DateTime CreatedDate { get; set; }
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsRead { get; set; }
}