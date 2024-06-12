using MediatR;
using MessageService.Data;
using MessageService.Entities;
using MessageService.Extensions;
using MessageService.Shared;

namespace MessageService.Features.Messages.GetDialogs;

public class GetDialogsQueryHandler : IRequestHandler<GetDialogsQuery, PagedList<MessageBase>>
{
    private readonly MessageContext _context;

    public GetDialogsQueryHandler(MessageContext context)
    {
        _context = context;
    }
    public async Task<PagedList<MessageBase>> Handle(GetDialogsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Messages
            .Where(u => u.SenderId == request.UserId || u.ReceiverId == request.UserId)
            .OrderByDescending(m => m.CreatedDate)
            .AsQueryable();

        return await query
             .GroupBy(u => new 
            {
                User1 = u.SenderId < u.ReceiverId ? u.SenderId : u.ReceiverId,
                User2 = u.SenderId < u.ReceiverId ? u.ReceiverId : u.SenderId
            })
            .Select(m => m.First())
            .ToPagedList(request.Page, request.PageSize);
    }
}