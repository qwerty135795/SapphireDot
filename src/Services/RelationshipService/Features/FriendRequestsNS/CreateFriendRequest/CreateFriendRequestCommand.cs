using MediatR;

namespace RelationshipService.Features.FriendRequestsNS.CreateFriendRequest;

public class CreateFriendRequestCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid TargetId { get; set; }
}