using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions.MinimalApiExtensions;

namespace UserProfile.Features.GetProfileById;

public class GetProfileByIdEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapGet("profile", async ([AsParameters]GetProfileByIdQuery query, 
            [FromServices]IMediator mediator) =>
        {
            var profile = await mediator.Send(query);
            return profile;
        });
    }
}