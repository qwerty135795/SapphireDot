namespace Shared.Consumers;

public class UserCreated
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? AvatarPath { get; set; }
    public DateOnly DateOfBirth { get; set; }
}