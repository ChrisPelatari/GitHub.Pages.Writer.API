using System;
using Xunit;
using FluentAssertions;
using Moq;
using WilderMinds.MetaWeblog;

namespace Jekyll.MetaWeblog.Tests
{
    public class MetaWeblogProviderFacts : IClassFixture<TestSetup>
    {
        private readonly TestSetup _testSetup;
        ServiceProvider _serviceProvider;
        IConfiguration Config;

        public MetaWeblogProviderFacts(TestSetup testSetup)
        {
            _testSetup = testSetup;
            _serviceProvider = testSetup.ServiceProvider;
            Config = _serviceProvider.GetService<IConfiguration>();
        }

        [Fact]
        public async Task GetUserInfo_Should_return_user_info()
        {
            //arrange
            var mwp = new MetaWeblogProvider(Config);
            var userinfo = await mwp.GetUserInfoAsync("1", "ChrisPelatari", "3");
            

            userinfo.Should().NotBeNull();
            userinfo.userid.Should().Be("ChrisPelatari");
            userinfo.firstname.Should().Be("Chris");
            userinfo.lastname.Should().Be("Pelatari");
            userinfo.url.Should().Be("https://localhost:7043");
        }
    }
}

