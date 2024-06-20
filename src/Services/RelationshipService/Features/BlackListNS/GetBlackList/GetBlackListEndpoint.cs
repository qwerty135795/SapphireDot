using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions.MinimalApiExtensions;

namespace RelationshipService.Features.BlackListNS.GetBlackList;

public class GetBlackListEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapGet("blacklist", async ([AsParameters]GetBlackListQuery query,
            [FromServices]IMediator mediator) =>
             await mediator.Send(query) 
        );
    }
}