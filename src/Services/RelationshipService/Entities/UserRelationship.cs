namespace RelationshipService.Entities;

public class UserRelationship
{
    public Guid UserId { get; set; }
    public ICollection<User> FriendsList { get; set; } = [];
    public ICollection<User> BlackList { get; set; } = [];
    public ICollection<User> FriendRequests { get; set; }
}