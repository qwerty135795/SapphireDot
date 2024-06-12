using MessageService.Entities;
using Microsoft.EntityFrameworkCore;

namespace MessageService.Data;

public class MessageContext : DbContext
{
    public MessageContext(DbContextOptions<MessageContext> options) : base(options)
    {
        
    }
    public DbSet<MessageBase> Messages { get;set; }
    public DbSet<TextMessage> TextMessages { get; set; }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var entities = ChangeTracker.Entries()
            .Where(e => e.Entity is MessageBase 
                        && (e.State is EntityState.Modified or EntityState.Added));
        foreach (var entity in entities)
        {
            switch (entity.State)
            {
                case EntityState.Modified:
                    ((MessageBase)entity.Entity).UpdatedDate = DateTime.UtcNow;
                    break;
                case EntityState.Added:
                    ((MessageBase)entity.Entity).CreatedDate = DateTime.UtcNow;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TextMessage>().OwnsMany(m => m.Attachments);
        base.OnModelCreating(modelBuilder);
    }
}