using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace GitHub.Pages.Writer.API.Tests {
    public partial class MetaWeblogProviderFacts {
        public class GetAuthors : MetaWeblogProviderFacts {
            public GetAuthors(WebApplicationFactory<Program> factory) : base(factory) {
            }

            [Fact]
            public async Task should_return_author() {
                var author = await metaWeblog.GetAuthorsAsync("1", "ChrisPelatari", "");

                author.Length.Should().Be(1);
                author[0].display_name.Should().Be("Chris Pelatari");
                author[0].user_id.Should().Be("ChrisPelatari");
                author[0].user_login.Should().Be("ChrisPelatari");
            }
        }
    }
}

