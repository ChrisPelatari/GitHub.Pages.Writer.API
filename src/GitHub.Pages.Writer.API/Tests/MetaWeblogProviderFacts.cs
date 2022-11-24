using Xunit;
using FluentAssertions;
using WilderMinds.MetaWeblog;
using Moq;
using GitHub.Pages.Writer.API.Services;

namespace GitHub.Pages.Writer.API.Tests
{
  public class MetaWeblogProviderFacts : IClassFixture<TestSetup>
    {
        readonly ServiceProvider _serviceProvider;
        readonly IConfiguration? Config;
        readonly Mock<IFileStorage> Storage;
        readonly MetaWeblogProvider metaWeblog;

        public MetaWeblogProviderFacts(TestSetup testSetup)
        {
            _serviceProvider = testSetup.ServiceProvider;
            Config = _serviceProvider.GetService<IConfiguration>();
            Storage = new();
            metaWeblog = new(Config, Storage.Object);
        }

        public class GetUserInfo : MetaWeblogProviderFacts {
            public GetUserInfo(TestSetup testSetup) : base(testSetup) {
            }

            [Fact]
            public async Task should_return_user_info() {
                //arrange
                var userinfo = await metaWeblog.GetUserInfoAsync("1", "ChrisPelatari", "");

                userinfo.Should().NotBeNull();
                userinfo.userid.Should().Be("ChrisPelatari");
                userinfo.firstname.Should().Be("Chris");
                userinfo.lastname.Should().Be("Pelatari");
                userinfo.url.Should().Be("http://localhost:4000");
            }
        }

        public class GetUsersBlogs : MetaWeblogProviderFacts {
            public GetUsersBlogs(TestSetup testSetup) : base(testSetup) {
            }

            [Fact]
            public async Task should_return_blog_info() {
                //arrange
                var bloginfo = await metaWeblog.GetUsersBlogsAsync("1", "ChrisPelatari", "");

                bloginfo.Length.Should().Be(1);
                bloginfo[0].Should().NotBeNull();
                bloginfo[0].blogid.Should().Be("1");
                bloginfo[0].blogName.Should().Be("Blue Fenix Productions");
                bloginfo[0].url.Should().Be("http://localhost:4000");
            }
        }

        public class GetAuthors : MetaWeblogProviderFacts {
            public GetAuthors(TestSetup testSetup) : base(testSetup) {
            }

            [Fact]
            public async Task should_return_author() {
                var author = await metaWeblog.GetAuthorsAsync("1", "ChrisPelatari", "");

                author.Length.Should().Be(1);
                author[0].display_name.Should().Be("Chris Pelatari");
                author[0].user_id.Should().Be("ChrisPelatari");
                author[0].user_login.Should().Be("ChrisPelatari");
            }
        }

        public class NewMediaObject : MetaWeblogProviderFacts {
            public NewMediaObject(TestSetup testSetup) : base(testSetup) {
            }

            [Fact]
             public async Task should_return_MediaObjectInfo() {
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
}

