using System.ComponentModel;
using System.Text.Json.Serialization;
using MediatR;
using MessageService.Entities;
using MessageService.Shared;
using Microsoft.AspNetCore.Mvc;

namespace MessageService.Features.Messages.GetMessages;

public class GetMessagesQuery : IRequest<PagedList<MessageBase>>
{
    public int UserId { get; set; }
    [FromRoute]
    public int DialogId { get; set; }
    private int _count;

    public int Count
    {
        get  => _count;
        set => _count = value is < 50 and > 0 ? value : 50; 
    }
    private int _page;
    public int Page
    {
        get => _page;
        set => _page = value > 0 ? value : 1;
    }
}