using Microsoft.EntityFrameworkCore;

namespace YouTube_Clone.Models
{
    public class User
    {
        public Guid UserID { get; set; }
        public string ClerkID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
    }

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Users = Set<User>();
        }

        public DbSet<User> Users { get; set; }
    }
}
