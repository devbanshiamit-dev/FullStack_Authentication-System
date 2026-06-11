using Microsoft.EntityFrameworkCore;
using Registration_System.Models;

namespace Registration_System.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }

        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
    }
}
