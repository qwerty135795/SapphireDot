using AutoMapper;
using MassTransit;
using RelationshipService.Data;
using RelationshipService.Entities;
using Shared.Consumers;

namespace RelationshipService.Consumers;

public class UserCreatedConsumer : IConsumer<UserCreated>
{
    private readonly RelationshipContext _context;
    private readonly IMapper _mapper;

    public UserCreatedConsumer(RelationshipContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task Consume(ConsumeContext<UserCreated> context)
    {
        var user = _mapper.Map<User>(context.Message);

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
}