using MediatR;
using Microsoft.EntityFrameworkCore;
using UserProfile.Data;
using UserProfile.Entities;

namespace UserProfile.Features.GetProfileById;

public class GetProfileByIdQueryHandler : IRequestHandler<GetProfileByIdQuery, Profile?>
{
    private readonly ProfileContext _context;

    public GetProfileByIdQueryHandler(ProfileContext context)
    {
        _context = context;
    }
    public async Task<Profile?> Handle(GetProfileByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Profiles.FirstOrDefaultAsync(p => p.Id == request.UserId,
            cancellationToken);
    }
}