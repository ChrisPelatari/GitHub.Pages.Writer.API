using GitHub.Pages.Writer.API.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace GitHub.Pages.Writer.API.Tests {
    public partial class MetaWeblogProviderFacts : IClassFixture<WebApplicationFactory<Program>>, IDisposable {
        protected IConfiguration Config;
        TestSetup setup = new();
        protected Mock<IFileStorage> Storage = new();
        protected MetaWeblogProvider metaWeblog;
        BlogDbContext context;
        SqliteConnection connection = new SqliteConnection("Filename=:memory:");

        public MetaWeblogProviderFacts(WebApplicationFactory<Program> factory) {
            connection.Open();
            var options = new DbContextOptionsBuilder<BlogDbContext>()
            .UseSqlite(connection)
            .Options;

            context = new BlogDbContext(options);
            context.Database.EnsureCreated();
            Config = setup.ServiceProvider.GetService<IConfiguration>()!;

            metaWeblog = new MetaWeblogProvider(Config, Storage.Object, context);

            Factory = factory.WithWebHostBuilder(builder => {
                builder.ConfigureTestServices(services => {
                    services.Replace(new ServiceDescriptor(typeof(BlogDbContext), context));
                    services.Replace(new ServiceDescriptor(typeof(IFileStorage), Storage.Object));
                });
            });

        }
        public WebApplicationFactory<Program> Factory { get; }

        public void Dispose() { 
            connection.Dispose();
        }
    }
}

