namespace GitHub.Pages.Writer.API.Tests
{
    public class GetTags : MetaWeblogProviderFacts
    {
        public GetTags(WebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task should_return_tags()
        {
            var tags = await metaWeblog.GetTagsAsync("1", "ChrisPelatari", "");

            tags.Length.Should().Be(50);
        }
    }
}