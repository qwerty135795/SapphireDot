using MediatR;
using Microsoft.EntityFrameworkCore;
using RelationshipService.Data;

namespace RelationshipService.Features.FriendRequestsNS.RemoveFriendRequest;

public class RemoveFriendRequestCommandHandler : IRequestHandler<RemoveFriendRequestCommand>
{
    private readonly RelationshipContext _context;

    public RemoveFriendRequestCommandHandler(RelationshipContext context)
    {
        _context = context;
    }
    public async Task Handle(RemoveFriendRequestCommand request, CancellationToken cancellationToken)
    {
        var req = await _context.FriendRequests.FindAsync(request.RequestId,
            cancellationToken);
        if (req is null || req.RequesterId != request.UserId) return;

        _context.FriendRequests.Remove(req);
        await _context.SaveChangesAsync(cancellationToken);
    }
}