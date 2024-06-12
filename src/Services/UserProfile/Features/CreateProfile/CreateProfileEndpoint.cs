using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions.MinimalApiExtensions;

namespace UserProfile.Features.CreateProfile;

public class CreateProfileEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost("profile", async ([FromBody]CreateProfileRequest request,
            [FromServices]IMediator mediator) =>
        {
            await mediator.Send(request);
        });
    }
    
}