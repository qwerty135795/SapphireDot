using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions.MinimalApiExtensions;

namespace RelationshipService.Features.FriendList.RemoveFromFriends;

public class RemoveFromFriendsEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapDelete("friends", async ([FromBody] RemoveFromFriendsCommand command,
            [FromServices] IMediator mediator) =>
        {
            if (command.UserId == command.FriendId) return Results.BadRequest();

            await mediator.Send(command);
            return Results.NoContent();
        });
    }
}