using MediatR;
using Shared.Extensions.MinimalApiExtensions;

namespace RelationshipService.Features.FriendRequestsNS.CreateFriendRequest;

public class CreateFriendRequestEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost("friend-request", async (HttpContext context,
                CreateFriendRequestCommand command, IMediator mediator) =>
            {
                if (command.UserId == command.TargetId) return Results.BadRequest();

                await mediator.Send(command);
                return Results.Ok();
            }
        );
    }
}