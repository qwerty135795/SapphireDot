using AutoMapper;
using MediatR;
using MessageService.Data;
using MessageService.Entities;
using Microsoft.EntityFrameworkCore;

namespace MessageService.Features.TextMessages.UpdateMessage;

public class UpdateMessageCommandHandler : IRequestHandler<UpdateMessageCommand, bool>
{
    private readonly MessageContext _context;
    private readonly IMapper _mapper;

    public UpdateMessageCommandHandler(MessageContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<bool> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
    {
        var message = await  _context.Messages
            .FirstOrDefaultAsync(u => u.Id == request.MessageId, cancellationToken);
        if (message is null || message.SenderId != request.UserId) return false;

        _mapper.Map(request, message, typeof(UpdateMessageCommand), typeof(TextMessage));

        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}