using MediatR;
using Microsoft.EntityFrameworkCore;
using RelationshipService.Data;

namespace RelationshipService.Features.AddToBlackList;

public class AddToBlackListRequestHandler : IRequestHandler<AddToBlackListRequest>
{
    private readonly RelationshipContext _context;

    public AddToBlackListRequestHandler(RelationshipContext context)
    {
        _context = context;
    }
    public async Task Handle(AddToBlackListRequest request, CancellationToken cancellationToken)
    {
        var user = await _context.Relationships.Include(opt => opt.BlackList)
            .FirstOrDefaultAsync(u => u.UserId == request.UserId, cancellationToken);
        if (user is null) return;
        if (user.BlackList.All(u => u.Id != request.TargetBlockId))
        {
            var userForBlock = await _context.Users.FindAsync(request.TargetBlockId, cancellationToken);
            if (userForBlock is null) return;
            user.BlackList.Add(userForBlock);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}