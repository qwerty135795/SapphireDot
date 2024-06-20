namespace RelationshipService.Entities;

public class FriendRequest
{
    public Guid Id { get; set; }
    public Guid RequesterId { get; set; }

    public User Requester { get; set; }

    public Guid ReceiverId { get; set; }
    public User Receiver { get; set; }
    public Status RequestStatus { get; set; }

}