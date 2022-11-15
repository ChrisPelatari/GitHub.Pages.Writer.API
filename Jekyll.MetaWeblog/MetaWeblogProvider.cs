﻿using System;
using WilderMinds.MetaWeblog;
using YamlDotNet.Serialization;

namespace Jekyll.MetaWeblog
{
    public class MetaWeblogProvider : IMetaWeblogProvider
    {
        public MetaWeblogProvider(IConfiguration config)
        {
            Config = config;
        }

        public IConfiguration Config { get; }

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

        public Task<Author[]> GetAuthorsAsync(string blogid, string username, string password)
        {
            throw new NotImplementedException();
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
                userid = username,
                firstname = "Chris",
                lastname = "Pelatari",
                url = Config["url"]
            });
        }

        public async Task<BlogInfo[]> GetUsersBlogsAsync(string key, string username, string password)
        { 
            var configYaml = await File.ReadAllTextAsync(Path.Combine(Config["folder"], "_config.yml"));
            var deserializer = new Deserializer();
            var config = deserializer.Deserialize<Dictionary<string, string>>(configYaml);
            return await Task.FromResult<BlogInfo[]>(new BlogInfo[] { new BlogInfo { blogid = "1", blogName = config["title"], url = Config["url"] } });
        }

        public Task<MediaObjectInfo> NewMediaObjectAsync(string blogid, string username, string password, MediaObject mediaObject)
        {
            throw new NotImplementedException();
        }
    }
}

