using System;
using FluentAssertions;
using GitHub.Pages.Writer.API.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace GitHub.Pages.Writer.API.Tests
{
	public class GetCategories : MetaWeblogProviderFacts
    { 
        public GetCategories(WebApplicationFactory<Program> factory) : base(factory)
        { }

        [Fact]
        public async Task Should_return_categories()
        {
            //arrange
            var categories = new[]
            {
                new Category { Name = "Category1",
                 Description = "Description1",
                 Slug = "category1" },
                new Category { Name = "Category2",
                 Description = "Description2",
                 Slug = "category2" }
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

            //act
            var cats = await metaWeblog.GetCategoriesAsync("blog", "username", "password");

            //assert
            cats.Should().NotBeNull();
            cats.Length.Should().Be(2);
            cats[0].title.Should().Be("Category1");
            cats[1].title.Should().Be("Category2");
        }
    }
}

