using System;
using Xunit;
using FluentAssertions;
using Moq;
using WilderMinds.MetaWeblog;

namespace Jekyll.MetaWeblog.Tests
{
    public class MetaWeblogProviderFacts
    {
        public MetaWeblogProviderFacts()
        {
        }

        [Fact]
        public async Task GetUserInfo_Should_return_user_info()
        {
            //arrange
            Mock<MetaWeblogProvider> mwp = new();

            mwp.Setup(m => m.GetUserInfoAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new Task<UserInfo>(() => new UserInfo
            {
                userid = "1",
                firstname = "Chris",
                lastname = "Pelatari",
                email = "chris@example.com",
                url = "https://example.com"
            }));

            var userinfo = await mwp.Object.GetUserInfoAsync("1", "2", "3");
            //   mwp.Verify

            userinfo.Should().NotBeNull();
            userinfo.userid.Should().Be("1");
            userinfo.firstname.Should().Be("Chris");
            userinfo.lastname.Should().Be("Pelatari");
            userinfo.email.Should().Be("chris@example.com");
            userinfo.url.Should().Be("https://example.com");
        }
    }
}

