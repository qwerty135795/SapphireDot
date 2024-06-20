using MediatR;
using UserProfile.Entities;

namespace UserProfile.Features.GetProfileById;

public class GetProfileByIdQuery : IRequest<Profile?>
{
    public Guid UserId { get; set; }
}