using System.Net.Mail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MessageService.Features.TextMessages.UpdateMessage;

public class UpdateMessageCommand : IRequest<bool>
{
    public int UserId { get; set; }
    public string TextContent { get; set; }
    public List<Attachment> Attachments { get; set; }
    [FromRoute]
    public Guid MessageId { get; set; }
}