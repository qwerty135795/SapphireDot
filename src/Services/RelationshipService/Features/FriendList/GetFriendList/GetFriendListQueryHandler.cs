using MediatR;
using RelationshipService.Data;
using RelationshipService.Entities;
using RelationshipService.Extensions;
using Shared.Pagination;

namespace RelationshipService.Features.FriendList.GetFriendList;

public class GetFriendListQueryHandler : IRequestHandler<GetFriendListQuery, PagedList<User>>
{
    private readonly RelationshipContext _context;

    public GetFriendListQueryHandler(RelationshipContext context)
    {
        _context = context;
    }
    public async Task<PagedList<User>> Handle(GetFriendListQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Friendships
            .Where(o => o.UserId == request.UserId || o.FriendId == request.UserId).AsQueryable();

        return await query.Select(o => o.Friend).ToPagedList(request.Page, request.PageSize);
    }
}