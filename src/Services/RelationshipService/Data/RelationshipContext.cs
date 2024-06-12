using Microsoft.EntityFrameworkCore;
using RelationshipService.Entities;

namespace RelationshipService.Data;

public class RelationshipContext : DbContext
{
    public RelationshipContext(DbContextOptions<RelationshipContext> options) : base(options)
    {
        
    }

    public DbSet<UserRelationship> Relationships { get; set; }
    public DbSet<User> Users { get; set; }
}