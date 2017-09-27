using Microsoft.EntityFrameworkCore;


namespace WorldWebServer.Models
{
    public class WorldDbContext : DbContext {
        public WorldDbContext(DbContextOptions<WorldDbContext> options)
        : base(options) { }

        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
    }

    public class WorldDbContextFactory {
        public WorldDbContext Create(string connectionStirng) {
            var optionsBuilder = new DbContextOptionsBuilder<WorldDbContext>();
            optionsBuilder.UseMySql(connectionStirng);
            var dbContext = new WorldDbContext(optionsBuilder.Options);
            return dbContext;
        }
    }

}