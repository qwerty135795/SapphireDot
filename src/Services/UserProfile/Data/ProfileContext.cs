using Microsoft.EntityFrameworkCore;
using UserProfile.Entities;

namespace UserProfile.Data;

public class ProfileContext : DbContext
{
    public ProfileContext(DbContextOptions<ProfileContext> options) : base(options)
    {
        
    }

    public DbSet<Profile> Profiles { get; set; }
}