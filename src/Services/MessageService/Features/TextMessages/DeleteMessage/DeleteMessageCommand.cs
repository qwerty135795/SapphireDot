using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MessageService.Features.TextMessages.DeleteMessage;

public class DeleteMessageCommand : IRequest
{
    public int UserId { get; set; }
    [FromRoute]
    public Guid MessageId { get; set; }
}