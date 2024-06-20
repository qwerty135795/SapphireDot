using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions.MinimalApiExtensions;

namespace UserProfile.Features.CreateProfile;

public class CreateProfileEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost("profile", async (HttpContext context,[FromBody]CreateProfileRequest request,
            
            [FromServices]IMediator mediator) =>
        {
            var id = await mediator.Send(request);
            return Results.Created(context.Request.Path, new {id = id});
        });
    }
    
}