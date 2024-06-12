using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions.MinimalApiExtensions;

namespace RelationshipService.Features.AddToBlackList;

public class AddToBlackListEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        // Change Route Params to Params from JwtTOken
        builder.MapPost("blacklist/{user_id:guid}", async (Guid userId, Guid targetId,
                [FromServices] IMediator mediator) =>
        {
            var request = new AddToBlackListRequest
            {
                UserId = userId,
                TargetBlockId = targetId
            };
            await mediator.Send(request);
        });
    }
}