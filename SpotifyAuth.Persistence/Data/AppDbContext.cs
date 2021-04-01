using Microsoft.EntityFrameworkCore;
using SpotifyAuth.Domain.Entities;

namespace SpotifyAuth.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}