namespace RelationshipService.Entities;

public class BlackList
{
    public Guid Id { get; set; }
    public Guid Userid { get; set; }
    public User User { get; set; }
    public Guid BlockedId { get; set; }
    public User Blocked { get; set; }
}