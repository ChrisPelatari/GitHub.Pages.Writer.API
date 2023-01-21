using GitHub.Pages.Writer.API.Models;
using WilderMinds.MetaWeblog;

namespace GitHub.Pages.Writer.API.Services {
    public interface IFileStorage {
        int AddCategory(Category category);
        string AddPage(string title);
        MediaObjectInfo SaveMedia(MediaObject mediaObject);
        string PostFileName(string postid);
        string AddPost(Post post);
        void WritePost(string fileName, string frontMatter);
    }
}
