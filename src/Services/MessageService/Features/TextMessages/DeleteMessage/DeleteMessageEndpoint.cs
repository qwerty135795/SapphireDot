using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions.MinimalApiExtensions;

namespace MessageService.Features.TextMessages.DeleteMessage;

public class DeleteMessageEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapDelete("messages/{messageId:guid}", async ([AsParameters]DeleteMessageCommand command,
            [FromServices]IMediator mediator) =>
        {
            await mediator.Send(command);
        } );
    }
}