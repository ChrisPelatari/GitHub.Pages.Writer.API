namespace GitHub.Pages.Writer.API.Tests;

public class EditPost : MetaWeblogProviderFacts
{
    public EditPost(WebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task should_edit_post()
    {
        var originalTitle = "Test Post";
        var post = new Post
        {
            title = originalTitle,
            description = "Test Description",
            dateCreated = DateTime.Now,
            categories = new string[] { "Test Category" }
        };

        var result = await metaWeblog.AddPostAsync("1", "ChrisPelatari", "", post, true);

        result.Should().Be($"{Config["blog:url"]}/{string.Join("/", post.categories)}/{post.dateCreated.Year}/{post.dateCreated.Month}/{post.dateCreated.Day}/{post.title}.html");

        post.title = "Test Post 2";
        post.description = "Test Description 2";
        post.dateCreated = DateTime.Now;
        post.categories = new string[] { "Test Category 2" };

        var editResult = await metaWeblog.EditPostAsync("1", "ChrisPelatari", "", post, true);

        editResult.Should().BeTrue();
    }
}