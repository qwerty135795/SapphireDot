using MediatR;

namespace RelationshipService.Features.FriendList.RemoveFromFriends;

public class RemoveFromFriendsCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid FriendId { get; set; }
}