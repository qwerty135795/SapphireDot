using MediatR;
using MessageService.Data;
using MessageService.Entities;
using MessageService.Extensions;
using MessageService.Shared;

namespace MessageService.Features.Messages.GetMessages;

public class GetMessagesQueryHandler : IRequestHandler<GetMessagesQuery, PagedList<MessageBase>>
{
    private readonly MessageContext _context;

    public GetMessagesQueryHandler(MessageContext context)
    {
        _context = context;
    }
    public async Task<PagedList<MessageBase>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Messages.AsQueryable();
        // query = query.Where(u => (u.SenderId == request.UserId || u.SenderId == request.DialogId)
        //     && (u.ReceiverId == request.DialogId || u.ReceiverId == request.UserId));
        return await query.GetUserDialog(request.UserId, request.DialogId)
            .ToPagedList(request.Page, request.Count);
    }
}