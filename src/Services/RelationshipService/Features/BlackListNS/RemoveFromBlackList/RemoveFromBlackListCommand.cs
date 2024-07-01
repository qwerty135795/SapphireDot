using MediatR;

namespace RelationshipService.Features.BlackListNS.RemoveFromBlackList;

public class RemoveFromBlackListCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid TargetId { get; set; }
}