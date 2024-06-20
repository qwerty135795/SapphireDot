using MediatR;
using Microsoft.EntityFrameworkCore;
using RelationshipService.Data;
using RelationshipService.Entities;

namespace RelationshipService.Features.BlackListNS.AddToBlackList;

public class AddToBlackListRequestHandler : IRequestHandler<AddToBlackListRequest>
{
    private readonly RelationshipContext _context;

    public AddToBlackListRequestHandler(RelationshipContext context, ILogger<AddToBlackListRequestHandler> logger)
    {
        _context = context;
    }
    public async Task Handle(AddToBlackListRequest request, CancellationToken cancellationToken)
    {
        var blockEntry = await _context.BlockedUsers.FirstOrDefaultAsync(u =>
            u.Userid == request.UserId && u.BlockedId == request.TargetBlockId
            ,cancellationToken);
        if (blockEntry != null) return;

        var block = new BlackList
        {
            Userid = request.UserId,
            BlockedId = request.TargetBlockId
        };
        _context.BlockedUsers.Add(block);
        
        await _context.SaveChangesAsync(cancellationToken);
        
        await _context.Friendships.Where(u => u.UserId == request.UserId && u.FriendId == request.TargetBlockId
                                        || u.UserId == request.TargetBlockId && u.FriendId == request.UserId)
            .ExecuteDeleteAsync(cancellationToken);
        await _context.FriendRequests
            .Where(u => u.RequesterId == request.UserId && u.ReceiverId == request.TargetBlockId)
            .ExecuteDeleteAsync(cancellationToken);
    }
    
}