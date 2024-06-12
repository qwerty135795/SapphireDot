using MediatR;
using MessageService.Entities;
using MessageService.Shared;

namespace MessageService.Features.Messages.GetDialogs;

public class GetDialogsQuery : IRequest<PagedList<MessageBase>>
{
    public int UserId { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}