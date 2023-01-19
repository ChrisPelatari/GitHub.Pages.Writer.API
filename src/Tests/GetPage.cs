namespace GitHub.Pages.Writer.API.Tests;

public class GetPage : MetaWeblogProviderFacts
{
    public GetPage(WebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task should_get_page()
    {
        var page = new Page
        {
            title = "Test Page",
            description = "Test Description",
            dateCreated = DateTime.Now,
            categories = new string[] { "Test Category" }
        };

        var result = await metaWeblog.AddPageAsync("1", "ChrisPelatari", "", page, true);

        result.Should().Be($"{Config["blog:url"]}/{page.title}.html");

        var getResult = await metaWeblog.GetPageAsync("1", "ChrisPelatari", "", result);

        getResult.Should().NotBeNull();
        getResult.title.Should().Be(page.title);
        getResult.description.Should().Be(page.description);
        getResult.dateCreated.Should().Be(page.dateCreated);
        getResult.categories.Should().BeEquivalentTo(page.categories);
    }
}