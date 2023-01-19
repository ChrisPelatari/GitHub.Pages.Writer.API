using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using WilderMinds.MetaWeblog;

namespace GitHub.Pages.Writer.API.Tests;

public class AddPage : MetaWeblogProviderFacts
{
    public AddPage(WebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task should_add_page()
    {
        var page = new Page
        {
            title = "Test Page",
            description = "Test Description",
            dateCreated = DateTime.Now,
            categories = new string[] { "Test Category" }
        };

        var result = await metaWeblog.AddPageAsync("1", "ChrisPelatari", "", page, true);

        result.Should().Be("1");
    }
}
