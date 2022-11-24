using GitHub.Pages.Writer.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GitHub.Pages.Writer.API {
    public class BlogDbContext : DbContext {
        public BlogDbContext(DbContextOptions options) : base(options) {
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Category>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
