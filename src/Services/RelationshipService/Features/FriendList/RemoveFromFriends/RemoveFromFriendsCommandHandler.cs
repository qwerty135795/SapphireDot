using MediatR;
using Microsoft.EntityFrameworkCore;
using RelationshipService.Data;
using RelationshipService.Entities;

namespace RelationshipService.Features.FriendList.RemoveFromFriends;
// Change FriendId to PrimaryKey Friendship Entity ???
public class RemoveFromFriendsCommandHandler : IRequestHandler<RemoveFromFriendsCommand>
{
    private readonly RelationshipContext _context;

    public RemoveFromFriendsCommandHandler(RelationshipContext context)
    {
        _context = context;
    }
    public async Task Handle(RemoveFromFriendsCommand request, CancellationToken cancellationToken)
    {
        var req = await _context.Friendships
            .FirstOrDefaultAsync(u => (u.UserId == request.UserId && u.FriendId == request.FriendId)
                                      || (u.UserId == request.FriendId && u.FriendId == request.UserId), cancellationToken: cancellationToken);
        if (req is null) return;

        _context.Friendships.Remove(req);
        var friendRequest = new FriendRequest
        {
            RequesterId = req.FriendId,
            ReceiverId = req.UserId,
            RequestStatus = Status.Rejected
        };

        _context.FriendRequests.Add(friendRequest);
        await _context.SaveChangesAsync(cancellationToken);
    }
}