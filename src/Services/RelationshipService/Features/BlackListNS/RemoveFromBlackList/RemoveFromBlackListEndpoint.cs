using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions.MinimalApiExtensions;

namespace RelationshipService.Features.BlackListNS.RemoveFromBlackList;

public class RemoveFromBlackListEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapDelete("black-list", async ([FromBody] RemoveFromBlackListCommand command,
            [FromServices] IMediator mediator) =>
        {
            if (command.UserId == command.TargetId) return Results.BadRequest();

            await mediator.Send(command);
            return Results.NoContent();

        });
    }
}