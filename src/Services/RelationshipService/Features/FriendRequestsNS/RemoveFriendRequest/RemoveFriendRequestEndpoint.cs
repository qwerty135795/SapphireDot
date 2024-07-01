using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions.MinimalApiExtensions;

namespace RelationshipService.Features.FriendRequestsNS.RemoveFriendRequest;

public class RemoveFriendRequestEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapDelete("friend-request", async ([FromBody] RemoveFriendRequestCommand command,
            [FromServices] IMediator mediator) =>
        {
            await mediator.Send(command);
            return Results.NoContent();
        });
    }
}