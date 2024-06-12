namespace UserProfile.Entities;

public class Profile
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? AvatarPath { get; set; }
    public DateOnly DateOfBirth { get; set; }

    public int GetAge()
    {
        var now = DateTime.UtcNow;
        var year = DateOfBirth.ToDateTime(TimeOnly.MinValue).Year - now.Year;
        return DateOfBirth.ToDateTime(TimeOnly.MinValue).Date > now.AddYears(-year) ? --year : year;
    }
}