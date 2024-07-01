using MediatR;
using Microsoft.EntityFrameworkCore;
using RelationshipService.Data;

namespace RelationshipService.Features.BlackListNS.RemoveFromBlackList;

public class RemoveFromBlackListCommandHandler : IRequestHandler<RemoveFromBlackListCommand>
{
    private readonly RelationshipContext _context;

    public RemoveFromBlackListCommandHandler(RelationshipContext context)
    {
        _context = context;
    }
    public async Task Handle(RemoveFromBlackListCommand request, CancellationToken cancellationToken)
    {
        await _context.BlockedUsers.Where(u => u.Userid == request.UserId &&
                                               u.BlockedId == request.TargetId)
            .ExecuteDeleteAsync(cancellationToken);
    }
}