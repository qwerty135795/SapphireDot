using MediatR;
using RelationshipService.Data;
using RelationshipService.Entities;
using RelationshipService.Extensions;
using Shared.Pagination;

namespace RelationshipService.Features.FriendRequestsNS.GetFriendRequests;

public class GetFriendRequestsQueryHandler :
    IRequestHandler<GetFriendRequestsQuery, PagedList<FriendRequest>>
{
    private readonly RelationshipContext _context;

    public GetFriendRequestsQueryHandler(RelationshipContext context)
    {
        _context = context;
    }
    public async Task<PagedList<FriendRequest>> Handle(GetFriendRequestsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.FriendRequests
            .Where(o => request.InBox ? o.ReceiverId == request.UserId 
                : o.RequesterId == request.UserId)
            .AsQueryable();
        query = query.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize);
        return await query.ToPagedList(request.Page, request.PageSize);
    }
}