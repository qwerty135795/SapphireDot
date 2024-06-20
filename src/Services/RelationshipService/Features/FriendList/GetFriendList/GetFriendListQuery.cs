using System.ComponentModel;
using MediatR;
using RelationshipService.Entities;
using Shared.Pagination;

namespace RelationshipService.Features.FriendList.GetFriendList;

public class GetFriendListQuery : IRequest<PagedList<User>>
{
    public Guid UserId { get; set; }
    [DefaultValue(1)]
    public int Page { get; set; } = 1;
    [DefaultValue(10)]
    public int PageSize { get; set; } = 10;
}