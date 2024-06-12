using AutoMapper;
using MediatR;
using MessageService.Data;
using MessageService.Entities;

namespace MessageService.Features.TextMessages.SendMessage;

public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, Guid>
{
    private readonly MessageContext _context;
    private readonly IMapper _mapper;

    public SendMessageCommandHandler(MessageContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(SendMessageCommand request, CancellationToken cancellationToken)
    {
        var message = _mapper.Map<TextMessage>(request);
        _context.TextMessages.Add(message);
        await _context.SaveChangesAsync(cancellationToken);
        return message.Id;
    }
}