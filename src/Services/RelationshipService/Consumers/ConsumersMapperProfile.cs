using AutoMapper;
using RelationshipService.Entities;
using Shared.Consumers;

namespace RelationshipService.Consumers;

public class ConsumersMapperProfile : Profile
{
    public ConsumersMapperProfile()
    {
        CreateMap<UserCreated, User>();
    }
}