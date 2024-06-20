using MediatR;
using Microsoft.EntityFrameworkCore;
using RelationshipService.Data;
using RelationshipService.Entities;

namespace RelationshipService.Features.FriendList.AddFriend;

public class AddFriendCommandHandler : IRequestHandler<AddFriendCommand>
{
    // Separate Creation Request and response to reqyest
    // user add friend send FRiendRequest Id and true or false
    // change model friend request
    private readonly RelationshipContext _context;

    public AddFriendCommandHandler(RelationshipContext context)
    {
        _context = context;
    }
    public async Task Handle(AddFriendCommand request, CancellationToken cancellationToken)
    {
        var req = await _context.FriendRequests
            .FirstOrDefaultAsync(r => r.Id == request.RequestId, cancellationToken);
        if (req is null) return;

        req.RequestStatus = request.Accepted ? Status.Accepted : Status.Rejected; 
        if (!request.Accepted) return;
        if (!await _context.BlockedUsers.AnyAsync(o => o.Userid == req.ReceiverId &&
                                                      o.BlockedId == request.UserId, cancellationToken))
        {
            var friendship = new Friendship
            {
                UserId = req.RequesterId,
                FriendId = req.ReceiverId
            };
            _context.Friendships.Add(friendship);

            _context.FriendRequests.Remove(req);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}