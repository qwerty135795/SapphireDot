using MediatR;
using RelationshipService.Data;
using RelationshipService.Entities;
using RelationshipService.Extensions;
using Shared.Pagination;

namespace RelationshipService.Features.BlackListNS.GetBlackList;

public class GetBlackListQueryHandler : IRequestHandler<GetBlackListQuery, PagedList<User>>
{
    private readonly RelationshipContext _context;

    public GetBlackListQueryHandler(RelationshipContext context)
    {
        _context = context;
    }
    public async Task<PagedList<User>> Handle(GetBlackListQuery request, CancellationToken cancellationToken)
    {
        var query = _context.BlockedUsers.Where(o => o.Userid == request.UserId)
            .AsQueryable();

        return await query.Select(o => o.Blocked).ToPagedList(request.Page, request.PageSize);

    }
}