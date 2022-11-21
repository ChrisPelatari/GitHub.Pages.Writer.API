using GitHub.Pages.Writer.API.Services;
using System;
using WilderMinds.MetaWeblog;

namespace GitHub.Pages.Writer.API
{
    public class MetaWeblogProvider : IMetaWeblogProvider
    {
        public MetaWeblogProvider(IConfiguration config, IFileStorage storage)
        {
            Config = config;
            Storage = storage;
        }

        public IConfiguration Config { get; }
        public IFileStorage Storage { get; }

        public Task<int> AddCategoryAsync(string key, string username, string password, NewCategory category)
        {
            throw new NotImplementedException();
        }

        public Task<string> AddPageAsync(string blogid, string username, string password, Page page, bool publish)
        {
            throw new NotImplementedException();
        }

        public Task<string> AddPostAsync(string blogid, string username, string password, Post post, bool publish)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePageAsync(string blogid, string username, string password, string pageid)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePostAsync(string key, string postid, string username, string password, bool publish)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditPageAsync(string blogid, string pageid, string username, string password, Page page, bool publish)
        {
            throw new NotImplementedException();
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

        public Task<CategoryInfo[]> GetCategoriesAsync(string blogid, string username, string password)
        {
            throw new NotImplementedException();
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

