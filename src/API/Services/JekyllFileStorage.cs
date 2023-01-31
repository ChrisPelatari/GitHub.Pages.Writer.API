﻿using System.Diagnostics;
using System.Text.RegularExpressions;
using GitHub.Pages.Writer.API.Models;
using WilderMinds.MetaWeblog;

namespace GitHub.Pages.Writer.API.Services;

public class JekyllFileStorage : IFileStorage {
        private readonly BlogDbContext db;
        public IConfiguration Config { get; }

        // Configuration
        string postsDirectory = "_posts";
        string draftsDirectory = "_drafts";
        string configFile = "_config.yml";
        string extension = ".md"; // Assume the extension is .md
        string title = "My Post Title";
        string templateFile = "_includes/post_template.md";
        string editor = "code.exe"; // Assume the editor is Notepad

        public JekyllFileStorage(IConfiguration config, BlogDbContext context) {
            Config = config;
            this.db = context;
        }

        public int AddCategory(Category category) {
            db.Categories.Add(category);
            db.SaveChanges();
            return category.Id;
        }

        public string AddPage(string title) {            
            return
            $"{Config["local:folder"]}/{title}.md";
        }

        public string AddPost(Post post) {
            // Get the date and time
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString("HH:mm:ss");
            string postTime = $"{date} {time}";

            // Write the post

            string filename = date + "-" + TransformToSlug(title, extension);
            string content = ReadFile(templateFile);
            CreateFile(postsDirectory, filename, content, title, editor, postTime);
                
            return $"{Config["local:folder"]}_posts/{post.dateCreated.ToString("yyyy-MM-dd")}-{post.title}.md";
        }

        public async Task<Category[]> GetCategories(string blogId, string username, string password) {
            return await Task.FromResult(db.Categories.ToArray());
        }

        public string PostFileName(string postid) {
            var fileName = $"{Config["local:folder"]}{postid.Replace("\\", "/")}.md";
            return fileName;
        }

        public MediaObjectInfo SaveMedia(MediaObject mediaObject) {
            var fileName = $"{Config["local:folder"]}/{Config["local:media"]}/{mediaObject.name}";

            if (File.Exists(fileName))
                File.Delete(fileName);

            File.WriteAllBytes(fileName, Convert.FromBase64String(mediaObject.bits));

            return new MediaObjectInfo { url = $"{Config["blog:url"]}/{Config["local:media"]}/{mediaObject.name}" };
        }

        public void WritePost(string fileName, string frontMatter) { 
            File.WriteAllText(fileName, frontMatter);
        }        

        static string ReadFile(string templateFile)
        {
            return File.ReadAllText(templateFile);
        }

        static void CreateFile(string directory, string filename, string content, string title, string editor, string postTime)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            WriteFile(content, title, directory, filename, postTime);
            if (!string.IsNullOrEmpty(editor))
            {
                System.Threading.Thread.Sleep(1000);
                Process.Start(editor, Path.Combine(directory, filename));
            }            
        }

        static void WriteFile(string content, string title, string directory, string filename, string postTime)
        {
            string parsedContent = content.Replace("title:", $"title: \"{title}\"");
            parsedContent = parsedContent.Replace("date:", $"date: {postTime}");
            File.WriteAllText(Path.Combine(directory, filename), parsedContent);
        }

        static string TransformToSlug(string title, string extension)
        {
            string characters = @"(""|'|!|\?|:|\s\z)";
            string whitespace = @"\s";
            return $"{Regex.Replace(Regex.Replace(title, characters, ""), whitespace, "-").ToLower()}{extension}";
        }
    }