using System.Text.Json.Serialization;
using MediatR;

namespace MessageService.Features.TextMessages.SendMessage;

public class SendMessageCommand : IRequest<Guid>
{
    public int SenderId { get; set; }
    [JsonIgnore]
    public int ReceiverId { get; set; }
    public string TextContent { get; set; }
    public List<IFormFile>? Attachments { get; set; }
}