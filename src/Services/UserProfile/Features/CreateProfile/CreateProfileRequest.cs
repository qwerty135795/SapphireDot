using System.ComponentModel;
using MediatR;

namespace UserProfile.Features.CreateProfile;

public class CreateProfileRequest : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? AvatarPath { get; set; }
    public DateOnly DateOfBirth { get; set; }

    public CreateProfileRequest(Guid userId, string firstName, string lastName, string? avatarPath, DateOnly dateOfBirth)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        AvatarPath = avatarPath;
        DateOfBirth = dateOfBirth;
    }

    public CreateProfileRequest()
    {
        
    }
}