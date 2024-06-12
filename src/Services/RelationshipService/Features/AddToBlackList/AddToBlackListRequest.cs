using MediatR;

namespace RelationshipService.Features.AddToBlackList;

public class AddToBlackListRequest : IRequest
{
    public Guid UserId { get; set; }
    public Guid TargetBlockId { get; set; }
}