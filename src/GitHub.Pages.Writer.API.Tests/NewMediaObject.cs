using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using WilderMinds.MetaWeblog;

namespace GitHub.Pages.Writer.API.Tests
{
    public class NewMediaObject : MetaWeblogProviderFacts
    {
        public NewMediaObject(WebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task should_return_MediaObjectInfo()
        {
            //arrange
            Storage.Setup(i => i.SaveMedia(It.IsAny<MediaObject>())).Returns(new MediaObjectInfo { url = $"{Config["blog:url"]}/assets/images/picture.png" });

            //act
            var info = await metaWeblog.NewMediaObjectAsync("1", "ChrisPelatari", "", new MediaObject { name = "picture.png", type = "image/png", bits = "bits" });

            //assert
            info.Should().NotBeNull();
            info.url.Should().StartWith(Config["blog:url"]);
            info.url.Should().Contain("assets/images");
            info.url.Should().EndWith("picture.png");
        }
    }
}
