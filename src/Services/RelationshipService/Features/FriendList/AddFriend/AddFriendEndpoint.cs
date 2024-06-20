using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions.MinimalApiExtensions;

namespace RelationshipService.Features.FriendList.AddFriend;

public class AddFriendEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost("friend", async ([FromBody]AddFriendCommand command,
                [FromServices]IMediator mediator) =>
            await mediator.Send(command));
    }
}