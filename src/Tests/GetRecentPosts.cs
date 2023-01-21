namespace GitHub.Pages.Writer.API.Tests;

public class GetRecentPosts : MetaWeblogProviderFacts
{
    public GetRecentPosts(WebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task should_get_recent_posts()
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

        var getRecentPostsResult = await metaWeblog.GetRecentPostsAsync("1", "ChrisPelatari", "", 10);

        getRecentPostsResult.Should().NotBeEmpty();
        getRecentPostsResult.Length.Should().BeGreaterThan(0);
    }
}