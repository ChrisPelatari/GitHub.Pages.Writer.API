namespace GitHub.Pages.Writer.API.Tests;

public class GetPost : MetaWeblogProviderFacts
{
    public GetPost(WebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task should_get_post()
    {
        //arrange
        var post = new Post
        {
            title = "Test Post",
            description = "Test Description",
            dateCreated = DateTime.Now,
            categories = new string[] { "Test Category" }
        };
        string expected = $"{Config["blog:url"]}/{string.Join("/", post.categories)}/{post.dateCreated.Year}/{post.dateCreated.Month}/{post.dateCreated.Day}/{post.title}.html";
        Storage.Setup(b => b.AddPost(It.IsAny<Post>())).Returns(expected);

        //act
        var result = await metaWeblog.AddPostAsync("1", "ChrisPelatari", "", post, true);

        //assert
        result.Should().Be(expected);
    }
}