using GitHub.Pages.Writer.API.Models;
using WilderMinds.MetaWeblog;

namespace GitHub.Pages.Writer.API.Services {
    public class JekyllFileStorage : IFileStorage {
        private readonly BlogDbContext db;

        public JekyllFileStorage(IConfiguration config, BlogDbContext context) {
            Config = config;
            this.db = context;
        }

        public IConfiguration Config { get; }

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
    }
}
