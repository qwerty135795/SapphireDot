using MediatR;
using MessageService.Data;
using Microsoft.EntityFrameworkCore;

namespace MessageService.Features.TextMessages.DeleteMessage;

public class DeleteMessageCommandHandler : IRequestHandler<DeleteMessageCommand>
{
    private readonly MessageContext _context;

    public DeleteMessageCommandHandler(MessageContext context)
    {
        _context = context;
    }
    public async Task Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
    {
        await _context.Messages.Where(u => u.SenderId == request.UserId && u.Id == request.MessageId)
            .ExecuteDeleteAsync(cancellationToken);
    }
}