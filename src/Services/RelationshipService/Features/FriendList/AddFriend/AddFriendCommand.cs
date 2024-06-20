using MediatR;

namespace RelationshipService.Features.FriendList.AddFriend;

public class AddFriendCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid RequestId { get; set; }
    public bool Accepted { get; set; }
}