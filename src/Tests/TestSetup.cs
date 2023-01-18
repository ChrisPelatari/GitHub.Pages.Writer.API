using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WilderMinds.MetaWeblog;

namespace GitHub.Pages.Writer.API.Tests
{
	public class TestSetup
	{
        public TestSetup()
        {
            var serviceCollection = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(
                     path: "appsettings.json",
                     optional: false,
                     reloadOnChange: true)
               .Build();
            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddMetaWeblog<MetaWeblogProvider>();
            serviceCollection.AddDbContext<BlogDbContext>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }
}

