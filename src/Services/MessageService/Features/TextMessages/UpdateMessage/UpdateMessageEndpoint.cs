using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions.MinimalApiExtensions;

namespace MessageService.Features.TextMessages.UpdateMessage;

public class UpdateMessageEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPut("messages/{id:guid}", async (UpdateMessageCommand command,
            [FromServices] IMediator mediator) =>
        {
            await mediator.Send(command);
        });
    }
}