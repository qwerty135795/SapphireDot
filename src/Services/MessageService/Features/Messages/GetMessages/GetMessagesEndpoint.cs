using MediatR;
using MessageService.Entities;
using MessageService.Shared;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions.MinimalApiExtensions;

namespace MessageService.Features.Messages.GetMessages;

public class GetMessagesEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapGet("messages/{dialogId:int}", GetMessages);
    }

    private async Task<PagedList<MessageBase>> GetMessages([AsParameters]GetMessagesQuery query,[FromServices] IMediator mediator)
    {
        // query.DialogId = id;
        var messages = await mediator.Send(query);
        return messages;
    }
}