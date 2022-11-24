using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace GitHub.Pages.Writer.API.Tests {
    public partial class MetaWeblogProviderFacts {
        public class GetUserInfo : MetaWeblogProviderFacts {
            public GetUserInfo(WebApplicationFactory<Program> factory) : base(factory) {
            }

            [Fact]
            public async Task should_return_user_info() {
                //arrange
                var userinfo = await metaWeblog.GetUserInfoAsync("1", "ChrisPelatari", "");

                userinfo.Should().NotBeNull();
                userinfo.userid.Should().Be("ChrisPelatari");
                userinfo.firstname.Should().Be("Chris");
                userinfo.lastname.Should().Be("Pelatari");
                userinfo.url.Should().Be("http://localhost:4000");
            }
        }
    }
}

