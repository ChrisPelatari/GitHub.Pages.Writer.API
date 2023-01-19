using GitHub.Pages.Writer.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GitHub.Pages.Writer.API {
    public class BlogDbContext : DbContext {
        public BlogDbContext(DbContextOptions options) : base(options) {
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Category>()
                .HasData(
                    new Category { Id = 1, Name = "Programming", Description = "Programming", Slug = "programming" },
                    new Category { Id = 2, Name = "Life", Description = "Life", Slug = "life" },
                    new Category { Id = 3, Name = "as-if-you-cared", Description = "As if you cared", Slug = "as-if-you-cared" },
                    new Category { Id = 4, Name = "professional_geek", Description = "Professional Geek", Slug = "professional-geek" },
                    new Category { Id = 5, Name = "rssbandit", Description = "RSSBandit", Slug = "rssbandit" },
                    new Category { Id = 6, Name = "postxing", Description = "PostXing", Slug = "postxing" },
                    new Category { Id = 7, Name = "dotnet", Description = ".NET", Slug = "dotnet" },
                    new Category { Id = 8, Name = "csharp", Description = "C#", Slug = "csharp" },
                    new Category { Id = 9, Name = "winforms",   Description = "WinForms", Slug = "winforms" },
                    new Category { Id = 10, Name = "visual_studio", Description = "Visual Studio", Slug = "visual-studio" },
                    new Category { Id = 11, Name = "aspnet", Description = "ASP.NET", Slug = "aspnet" },
                    new Category { Id = 12, Name = "BlogML", Description = "BlogML", Slug = "blogml" },
                    new Category { Id = 13, Name = "SubSonic", Description = "SubSonic", Slug = "subsonic" },
                    new Category { Id = 14, Name = "javascript", Description = "JavaScript", Slug = "javascript" },
                    new Category { Id = 15, Name = "DataGridView", Description = "DataGridView", Slug = "datagridview" },
                    new Category { Id = 16, Name = "subversion", Description = "Subversion", Slug = "subversion" },
                    new Category { Id = 17, Name = "svn", Description = "SVN", Slug = "svn" },
                    new Category { Id = 18, Name = "apache", Description = "Apache", Slug = "apache" },
                    new Category { Id = 19, Name = "xunit", Description = "xUnit", Slug = "xunit" },
                    new Category { Id = 20, Name = "StructureMap", Description = "StructureMap", Slug = "structuremap" },
                    new Category { Id = 21, Name = "SQLite", Description = "SQLite", Slug = "sqlite" },
                    new Category { Id = 22, Name = "mvc", Description = "MVC", Slug = "mvc" },
                    new Category { Id = 23, Name = "Standard", Description = "Standard", Slug = "standard" },
                    new Category { Id = 24, Name = "stencil", Description = "Stencil", Slug = "stencil" },
                    new Category { Id = 25, Name = "streetart", Description = "Street Art", Slug = "streetart" },
                    new Category { Id = 26, Name = "same", Description = "Same", Slug = "same" },
                    new Category { Id = 27, Name = "Image", Description = "Image", Slug = "image" },
                    new Category { Id = 28, Name = "rake", Description = "Rake", Slug = "rake" },
                    new Category { Id = 29, Name = "geek", Description = "Geek", Slug = "geek" },
                    new Category { Id = 30, Name = "music", Description = "Music", Slug = "music" },
                    new Category { Id = 31, Name = "travel", Description = "Travel", Slug = "travel" },
                    new Category { Id = 32, Name = "puerto_rico", Description = "Puerto Rico", Slug = "puerto-rico" },
                    new Category { Id = 33, Name = "ruby", Description = "Ruby", Slug = "ruby" },
                    new Category { Id = 34, Name = "math", Description = "Math", Slug = "math" },
                    new Category { Id = 35, Name = "personal", Description = "Personal", Slug = "personal" },
                    new Category { Id = 36, Name = "albacore", Description = "Albacore", Slug = "albacore" },
                    new Category { Id = 37, Name = "Windows", Description = "Windows", Slug = "windows" },
                    new Category { Id = 38, Name = "grub", Description = "GRUB", Slug = "grub" },
                    new Category { Id = 39, Name = "linux", Description = "Linux", Slug = "linux" },
                    new Category { Id = 40, Name = "jekyll", Description = "Jekyll", Slug = "jekyll" },
                    new Category { Id = 41, Name = "liquid", Description = "Liquid", Slug = "liquid" },
                    new Category { Id = 42, Name = "github-pages", Description = "GitHub Pages", Slug = "github-pages" },
                    new Category { Id = 43, Name = "git", Description = "Git", Slug = "git" },
                    new Category { Id = 44, Name = "zsh", Description = "ZSH", Slug = "zsh" },
                    new Category { Id = 45, Name = "Philosophy", Description = "Philosophy", Slug = "philosophy" },
                    new Category { Id = 46, Name = "Ruby", Description = "Ruby", Slug = "ruby" },
                    new Category { Id = 47, Name = "Linux", Description = "Linux", Slug = "linux" },
                    new Category { Id = 48, Name = "Unbuntu", Description = "Unbuntu", Slug = "unbuntu" },
                    new Category { Id = 49, Name = "Programming", Description = "Programming", Slug = "programming" },
                    new Category { Id = 50, Name = "gh-pages", Description = "gh-pages", Slug = "gh-pages" }
                );

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
