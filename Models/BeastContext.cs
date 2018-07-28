using Microsoft.EntityFrameworkCore;

namespace BEAST_API.Models {
    public class BeastContext : DbContext {

        public BeastContext(DbContextOptions<BeastContext> options) : base(options) {

        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Beast> Beasts { get; set; }
        public DbSet<Application> Applications { get; set; }

    }
}