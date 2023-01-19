namespace GitHub.Pages.Writer.API.Tests;

public class DeletePage : MetaWeblogProviderFacts
{
    public DeletePage(WebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task should_delete_page()
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

        var deleteResult = await metaWeblog.DeletePageAsync("1", "ChrisPelatari", "", result);

        deleteResult.Should().BeTrue();
    }
}