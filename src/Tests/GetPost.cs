namespace GitHub.Pages.Writer.API.Tests;

public class GetPost : MetaWeblogProviderFacts
{
    public GetPost(WebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task should_get_post()
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

        var getResult = await metaWeblog.GetPostAsync("1", "ChrisPelatari", "");

        getResult.Should().NotBeNull();
        getResult.title.Should().Be(post.title);
        getResult.description.Should().Be(post.description);
        getResult.dateCreated.Should().Be(post.dateCreated);
        getResult.categories.Should().BeEquivalentTo(post.categories);
    }
}