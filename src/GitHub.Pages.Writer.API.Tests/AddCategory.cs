using FluentAssertions;
using GitHub.Pages.Writer.API.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace GitHub.Pages.Writer.API.Tests
{
    public class AddCategory : MetaWeblogProviderFacts
    {
        public AddCategory(WebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Should_return_category_id()
        {
            //arrange
            Storage.Setup(c => c.AddCategory(It.IsAny<Category>())).Returns(1);

            //act
            var id = await metaWeblog.AddCategoryAsync("key", "ChrisPelatari", "", new NewCategory { description = "description", name = "name", slug = "slug" });

            id.Should().Be(1);
        }
    }
}

