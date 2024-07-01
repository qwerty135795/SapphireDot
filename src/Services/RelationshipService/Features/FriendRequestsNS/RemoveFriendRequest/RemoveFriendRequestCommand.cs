using MediatR;

namespace RelationshipService.Features.FriendRequestsNS.RemoveFriendRequest;

public class RemoveFriendRequestCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid RequestId { get; set; }
}