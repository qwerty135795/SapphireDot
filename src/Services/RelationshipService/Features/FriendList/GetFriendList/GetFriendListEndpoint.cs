
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions.MinimalApiExtensions;

namespace RelationshipService.Features.FriendList.GetFriendList;

public class GetFriendListEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapGet("friendlist", async ([AsParameters]GetFriendListQuery query,
            [FromServices]IMediator mediator) =>
             await mediator.Send(query)
        );
    }
}