using GitHub.Pages.Writer.API.Models;
using GitHub.Pages.Writer.API.Services;
using System;
using WilderMinds.MetaWeblog;

namespace GitHub.Pages.Writer.API
{
    public class MetaWeblogProvider : IMetaWeblogProvider
    {
        private readonly BlogDbContext db;

        public MetaWeblogProvider(IConfiguration config, IFileStorage storage, BlogDbContext db)
        {
            Config = config;
            Storage = storage;
            this.db = db;
        }

        public IConfiguration Config { get; }
        public IFileStorage Storage { get; }

        public async Task<int> AddCategoryAsync(string key, string username, string password, NewCategory category)
        {
            db.Categories.Add(new Category { Name = category.name, Description= category.description, ParentID = category.parent_id, Slug = category.slug });
            return await db.SaveChangesAsync();
        }

        public Task<string> AddPageAsync(string blogid, string username, string password, Page page, bool publish)
        {
            //create a jekyll markdown file with the following front matter:
            //---
            //layout: page
            //title: "Test Page"
            //date: 2021-08-01 12:00:00 -0400
            //categories: Test Category
            //---
            //Test Description
            var fileName = $"{Config["local:folder"]}/{page.title}.md";
            var frontMatter = $"---\nlayout: page\ntitle: \"{page.title}\"\ndate: {page.dateCreated.ToString("yyyy-MM-dd HH:mm:ss zzz")}";
            if (page.categories != null && page.categories.Length > 0)
                frontMatter += $"\ncategories: {string.Join(", ", page.categories)}";
            frontMatter += $"\n---\n{page.description}";

            if (File.Exists(fileName))
                File.Delete(fileName);

            File.WriteAllText(fileName, frontMatter);

            return Task.FromResult(
                $"{Config["blog:url"]}/{page.title}.html"
            );
        }

        public Task<string> AddPostAsync(string blogid, string username, string password, Post post, bool publish)
        {
            //create a jekyll markdown file with the following front matter:
            //---
            //layout: post
            //title: "Test Post"
            //date: 2021-08-01 12:00:00 -0400
            //categories: Test Category
            //---
            //Test Description
            var fileName = $"{Config["local:folder"]}/{post.dateCreated.Year}-{post.dateCreated.Month}-{post.dateCreated.Day}-{post.title}.md";
            var frontMatter = $"---\nlayout: post\ntitle: \"{post.title}\"\ndate: {post.dateCreated.ToString("yyyy-MM-dd HH:mm:ss zzz")}";
            if (post.categories != null && post.categories.Length > 0)
                frontMatter += $"\ncategories: {string.Join(", ", post.categories)}";
            frontMatter += $"\n---\n{post.description}";

            if (File.Exists(fileName))
                File.Delete(fileName);

            File.WriteAllText(fileName, frontMatter);

            return Task.FromResult(
                $"{Config["blog:url"]}/{string.Join("/", post.categories)}/{post.dateCreated.Year}/{post.dateCreated.Month}/{post.dateCreated.Day}/{post.title}.html"
            );
        }

        public Task<bool> DeletePageAsync(string blogid, string username, string password, string pageid)
        {
            //delete the jekyll markdown file
            var fileName = $"{Config["local:folder"]}/{pageid}.md";
            if (File.Exists(fileName))
                File.Delete(fileName);

            return Task.FromResult(true);
        }

        public Task<bool> DeletePostAsync(string key, string postid, string username, string password, bool publish)
        {
            //delete the jekyll markdown file
            var fileName = $"{Config["local:folder"]}/_posts/{postid}.md";
            if (File.Exists(fileName))
                File.Delete(fileName);

            return Task.FromResult(true);
        }

        public Task<bool> EditPageAsync(string blogid, string pageid, string username, string password, Page page, bool publish)
        {
            //update the jekyll markdown file with the following front matter:
            //---
            //layout: page
            //title: "Test Page"
            //date: 2021-08-01 12:00:00 -0400
            //categories: Test Category
            //---
            //Test Description
            var fileName = $"{Config["local:folder"]}/{pageid}.md";
            var frontMatter = $"---\nlayout: page\ntitle: \"{page.title}\"\ndate: {page.dateCreated.ToString("yyyy-MM-dd HH:mm:ss zzz")}";
            if (page.categories != null && page.categories.Length > 0)
                frontMatter += $"\ncategories: {string.Join(", ", page.categories)}";
            frontMatter += $"\n---\n{page.description}";

            if (File.Exists(fileName))
                File.Delete(fileName);

            File.WriteAllText(fileName, frontMatter);

            return Task.FromResult(true);
        }

        public Task<bool> EditPostAsync(string postid, string username, string password, Post post, bool publish)
        {
            throw new NotImplementedException();
        }

        public async Task<Author[]> GetAuthorsAsync(string blogid, string username, string password)
        {
            var author = new Author[] {
                new Author
                {
                    display_name = Config["blog:Author:display_name"],
                    user_id = Config["blog:Author:user_id"],
                    user_login = Config["blog:Author:user_login"]
                }
            };

            return await Task.FromResult(author);
        }

        public async Task<CategoryInfo[]> GetCategoriesAsync(string blogid, string username, string password)
        {
            //implicit conversion from Category to CategoryInfo
            return await Task.FromResult(db.Categories.ToArray().Select(c => (CategoryInfo)c).ToArray());
        }

        public Task<Page> GetPageAsync(string blogid, string pageid, string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<Page[]> GetPagesAsync(string blogid, string username, string password, int numPages)
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPostAsync(string postid, string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<Post[]> GetRecentPostsAsync(string blogid, string username, string password, int numberOfPosts)
        {
            throw new NotImplementedException();
        }

        public Task<Tag[]> GetTagsAsync(string blogid, string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<UserInfo> GetUserInfoAsync(string key, string username, string password)
        {
            return Task.FromResult<UserInfo>(new UserInfo {
                userid = Config["blog:Author:user_id"],
                firstname = Config["blog:Author:first_name"],
                lastname = Config["blog:Author:last_name"],
                url = Config["blog:url"]
            });
        }

        public async Task<BlogInfo[]> GetUsersBlogsAsync(string key, string username, string password)
        { 
            return await Task.FromResult<BlogInfo[]>(new BlogInfo[] { new BlogInfo { blogid = Config["blog:id"], blogName = Config["blog:name"], url = Config["blog:url"] } });
        }

        public async Task<MediaObjectInfo> NewMediaObjectAsync(string blogid, string username, string password, MediaObject mediaObject)
        {
            //TODO: save mediaObject.bits to disk
            var image = $"{Storage.SaveMedia(mediaObject).url}";
            //TODO: return url to local jekyll install
            var url = $"{Config["blog:url"]}/assets/images/{image}";
            return await Task.FromResult<MediaObjectInfo>(new MediaObjectInfo { url = url });
        }
    }
}

