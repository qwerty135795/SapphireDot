using Microsoft.EntityFrameworkCore;
using RelationshipService.Entities;

namespace RelationshipService.Data;

public class RelationshipContext : DbContext
{
    public RelationshipContext(DbContextOptions<RelationshipContext> options) : base(options)
    {
        
    }
    public DbSet<User> Users { get; set; }
    public DbSet<FriendRequest> FriendRequests { get; set; }
    public DbSet<BlackList> BlockedUsers { get; set; }
    public DbSet<Friendship> Friendships { get; set; }
}