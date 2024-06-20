
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions.MinimalApiExtensions;

namespace RelationshipService.Features.BlackListNS.AddToBlackList;

public class AddToBlackListEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        // Change Route Params to Params from JwtTOken
        builder.MapPost("blacklist", async (AddToBlackListRequest request,
                [FromServices] IMediator mediator) =>
        {
            await mediator.Send(request);
        });
    }
}