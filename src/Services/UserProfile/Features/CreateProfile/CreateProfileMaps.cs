

using Shared.Consumers;
using UserProfile.Entities;

namespace UserProfile.Features.CreateProfile;

public class CreateProfileMaps : AutoMapper.Profile
{
    public CreateProfileMaps()
    {
        CreateMap<CreateProfileRequest, Profile>();
        CreateMap<Profile, UserCreated>();
    }
}