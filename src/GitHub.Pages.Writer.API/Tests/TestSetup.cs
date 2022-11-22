using System;
using Microsoft.AspNetCore.Mvc;

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
            serviceCollection.AddTransient<MetaWeblogProvider, MetaWeblogProvider>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }
}

