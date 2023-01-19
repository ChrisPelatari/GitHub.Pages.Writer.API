namespace GitHub.Pages.Writer.API.Tests;

public class GetPages : MetaWeblogProviderFacts
{
    public GetPages(WebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task should_get_pages()
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

        var getPagesResult = await metaWeblog.GetPagesAsync("1", "ChrisPelatari", "", 1);

        getPagesResult.Should().NotBeNull();
        getPagesResult.Count().Should().Be(1);
        getPagesResult.First().title.Should().Be(page.title);
        getPagesResult.First().description.Should().Be(page.description);
        getPagesResult.First().dateCreated.Should().Be(page.dateCreated);
        getPagesResult.First().categories.Should().BeEquivalentTo(page.categories);
    }
}