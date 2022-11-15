using System;
using Xunit;
using FluentAssertions;
using WilderMinds.MetaWeblog;

namespace Jekyll.MetaWeblog.Tests
{
    public class MetaWeblogProviderFacts : IClassFixture<TestSetup>
    {
        readonly TestSetup _testSetup;
        readonly ServiceProvider _serviceProvider;
        readonly IConfiguration? Config;
        readonly MetaWeblogProvider metaWeblog;

        public MetaWeblogProviderFacts(TestSetup testSetup)
        {
            _testSetup = testSetup;
            _serviceProvider = testSetup.ServiceProvider;
            Config = _serviceProvider.GetService<IConfiguration>();
            metaWeblog = new(Config);
        }

        [Fact]
        public async Task GetUserInfo_should_return_user_info()
        {
            //arrange
            var userinfo = await metaWeblog.GetUserInfoAsync("1", "ChrisPelatari", "3");
            
            userinfo.Should().NotBeNull();
            userinfo.userid.Should().Be("ChrisPelatari");
            userinfo.firstname.Should().Be("Chris");
            userinfo.lastname.Should().Be("Pelatari");
            userinfo.url.Should().Be("https://localhost:7043");
        }

        [Fact]
        public async Task GetUsersBlogs_should_return_blog_info()
        {
            //arrange
            var bloginfo = await metaWeblog.GetUsersBlogsAsync("1", "ChrisPelatari", "3");

            bloginfo.Length.Should().Be(1);
            bloginfo[0].Should().NotBeNull();
            bloginfo[0].blogid.Should().Be("1");
            bloginfo[0].blogName.Should().Be("Blue Fenix Productions");
            bloginfo[0].url.Should().Be("https://localhost:7043");
        }

        [Fact]
        public async Task GetAuthors_should_return_author()
        {
            var author = await metaWeblog.GetAuthorsAsync("1", "ChrisPelatari", "3");

            author.Length.Should().Be(1);
            author[0].display_name.Should().Be("Chris Pelatari");
            author[0].user_id.Should().Be("ChrisPelatari");
            author[0].user_login.Should().Be("ChrisPelatari");
        }
    }
}

