namespace GitHub.Pages.Writer.API.Tests;

public class EditPage : MetaWeblogProviderFacts
{
    public EditPage(WebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task should_edit_page()
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

        page.title = "Test Page 2";
        page.description = "Test Description 2";
        page.dateCreated = DateTime.Now;
        page.categories = new string[] { "Test Category 2" };

        var editResult = await metaWeblog.EditPageAsync("1", "ChrisPelatari", "", result, page, true);

        editResult.Should().BeTrue();
    }
}