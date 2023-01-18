using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace GitHub.Pages.Writer.API.Tests
{
    public class GetUsersBlogs : MetaWeblogProviderFacts
    {
        public GetUsersBlogs(WebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task should_return_blog_info()
        {
            //arrange
            var bloginfo = await metaWeblog.GetUsersBlogsAsync("1", "ChrisPelatari", "");

            bloginfo.Length.Should().Be(1);
            bloginfo[0].Should().NotBeNull();
            bloginfo[0].blogid.Should().Be("1");
            bloginfo[0].blogName.Should().Be("Blue Fenix Productions");
            bloginfo[0].url.Should().Be("http://localhost:4000");
        }
    }
}
