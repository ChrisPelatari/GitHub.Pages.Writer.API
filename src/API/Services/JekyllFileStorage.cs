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
            throw new NotImplementedException();
        }

        public async Task<Category[]> GetCategories(string blogId, string username, string password) {
            return db.Categories.ToArray();
        }

        public MediaObjectInfo SaveMedia(MediaObject mediaObject) {
            var fileName = $"{Config["local:folder"]}/{Config["local:media"]}/{mediaObject.name}";

            if (File.Exists(fileName))
                File.Delete(fileName);

            File.WriteAllBytes(fileName, Convert.FromBase64String(mediaObject.bits));

            return new MediaObjectInfo { url = $"{Config["blog:url"]}/{Config["local:media"]}/{mediaObject.name}" };
        }
    }
}
