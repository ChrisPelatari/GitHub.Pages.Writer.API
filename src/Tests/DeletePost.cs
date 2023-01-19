namespace GitHub.Pages.Writer.API.Tests;

public class DeletePost : MetaWeblogProviderFacts
{
    public DeletePost(WebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task should_delete_post()
    {
        var post = new Post
        {
            title = "Test Post",
            description = "Test Description",
            dateCreated = DateTime.Now,
            categories = new string[] { "Test Category" }
        };

        var result = await metaWeblog.AddPostAsync("1", "ChrisPelatari", "", post, true);

        result.Should().Be($"{Config["blog:url"]}/{string.Join("/", post.categories)}/{post.dateCreated.Year}/{post.dateCreated.Month}/{post.dateCreated.Day}/{post.title}.html");

        var deleteResult = await metaWeblog.DeletePostAsync("1", "ChrisPelatari", "", result, true);

        deleteResult.Should().BeTrue();
    }
}