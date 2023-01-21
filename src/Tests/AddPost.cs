namespace GitHub.Pages.Writer.API.Tests;

public class AddPost : MetaWeblogProviderFacts
{
    public AddPost(WebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task should_add_post()
    {
        //arrange
        var post = new Post
        {
            title = "Test Post",
            description = "Test Description",
            dateCreated = DateTime.Now,
            categories = new string[] { "Test Category" }
        };

        var result = await metaWeblog.AddPostAsync("1", "ChrisPelatari", "", post, true);

        result.Should().Be($"{Config["blog:url"]}/{string.Join("/", post.categories)}/{post.dateCreated.Year}/{post.dateCreated.Month}/{post.dateCreated.Day}/{post.title}.html");

        File.Delete($"{Config["local:folder"]}_posts/{post.dateCreated.Year}-{post.dateCreated.ToString("MM-dd")}-{post.title}.md");
    }
}