using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions.MinimalApiExtensions;

namespace MessageService.Features.TextMessages.SendMessage;

public class SendMessageEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost("messages/{id:int}", SendMessage);
    }
    // Add implementation for id param or remove this
    public async Task<Results<Ok, BadRequest>> SendMessage(int id ,
        [FromServices] IMediator mediator, [FromBody]SendMessageCommand command)
    {
        command.ReceiverId = id;
        await mediator.Send(command);
        return TypedResults.Ok();
    }
}