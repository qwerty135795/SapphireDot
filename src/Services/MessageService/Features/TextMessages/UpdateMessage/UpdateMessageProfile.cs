using AutoMapper;
using MessageService.Entities;

namespace MessageService.Features.TextMessages.UpdateMessage;

public class UpdateMessageProfile : Profile
{
    public UpdateMessageProfile()
    {
        CreateMap<UpdateMessageCommand, TextMessage>();
    }
}