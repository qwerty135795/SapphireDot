using System.ComponentModel;
using MediatR;
using RelationshipService.Entities;
using Shared.Pagination;

namespace RelationshipService.Features.FriendRequestsNS.GetFriendRequests;

public class GetFriendRequestsQuery : IRequest<PagedList<FriendRequest>>
{
    public Guid UserId { get; set; }
    public bool InBox { get; set; }
    [DefaultValue(1)]
    public int Page { get; set; } = 1;
    [DefaultValue(10)]
    public int PageSize { get; set; } = 10;
}