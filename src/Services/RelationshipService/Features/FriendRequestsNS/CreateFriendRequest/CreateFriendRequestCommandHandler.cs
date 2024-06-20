using MediatR;
using Microsoft.EntityFrameworkCore;
using RelationshipService.Data;
using RelationshipService.Entities;

namespace RelationshipService.Features.FriendRequestsNS.CreateFriendRequest;

public class CreateFriendRequestCommandHandler : IRequestHandler<CreateFriendRequestCommand>
{
    private readonly RelationshipContext _context;

    public CreateFriendRequestCommandHandler(RelationshipContext context)
    {
        _context = context;
    }
    public async Task Handle(CreateFriendRequestCommand request, CancellationToken cancellationToken)
    {
        if (await _context.BlockedUsers.AnyAsync(u => u.Userid == request.TargetId
                                                      && u.BlockedId == request.UserId)) return;
        
        if (await _context.FriendRequests.AnyAsync(u =>
                (u.RequesterId == request.UserId && u.ReceiverId == request.TargetId)
                || (u.RequesterId == request.TargetId &&
                    u.ReceiverId == request.UserId), cancellationToken)) return;
        var req = new FriendRequest
        {
            RequesterId = request.UserId,
            ReceiverId = request.TargetId,
            RequestStatus = Status.Pending
        };
        _context.FriendRequests.Add(req);
        await _context.SaveChangesAsync(cancellationToken);
    }
}