using AutoMapper;
using MessageService.Entities;

namespace MessageService.Features.TextMessages.SendMessage;

public class SendMessageMapperProfile : Profile
{
    public SendMessageMapperProfile()
    {
        CreateMap<SendMessageCommand, TextMessage>();
    }
}