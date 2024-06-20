using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions.MinimalApiExtensions;

namespace RelationshipService.Features.FriendRequestsNS.GetFriendRequests;

public class GetFriendRequestsEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapGet("friend-requests", async ([AsParameters] GetFriendRequestsQuery query,
            [FromServices] IMediator mediator) =>
        
            await mediator.Send(query)
        );

    }
}