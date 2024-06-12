using MediatR;
using MessageService.Entities;
using MessageService.Shared;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions.MinimalApiExtensions;

namespace MessageService.Features.Messages.GetDialogs;

public class GetDialogsEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapGet("messages", GetDialogs);
    }

    // Delete parameters and take userId from JWT
    private async Task<PagedList<MessageBase>> GetDialogs([AsParameters]GetDialogsQuery query,
        [FromServices] IMediator mediator)
    {
        return await mediator.Send(query);
    }
}