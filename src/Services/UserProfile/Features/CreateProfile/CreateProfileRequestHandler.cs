using AutoMapper;
using MassTransit;
using MediatR;
using Shared.Consumers;
using UserProfile.Data;
using Profile = UserProfile.Entities.Profile;

namespace UserProfile.Features.CreateProfile;

public class CreateProfileRequestHandler : IRequestHandler<CreateProfileRequest, Guid>
{
    private readonly ProfileContext _context;
    private readonly IMapper _mapper;
    private readonly IPublishEndpoint _endpoint;

    public CreateProfileRequestHandler(ProfileContext context, IMapper mapper
    , IPublishEndpoint endpoint)
    {
        _context = context;
        _mapper = mapper;
        _endpoint = endpoint;
    }
    public async Task<Guid> Handle(CreateProfileRequest request, CancellationToken cancellationToken)
    {
        var profile = _mapper.Map<Profile>(request);
        _context.Profiles.Add(profile);
        if (await _context.SaveChangesAsync(cancellationToken) > 0)
        {
            var user = _mapper.Map<UserCreated>(profile);
            
            await _endpoint.Publish(user, cancellationToken);
        }

        return profile.Id;
    }
}