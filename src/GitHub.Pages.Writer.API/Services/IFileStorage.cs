using GitHub.Pages.Writer.API.Models;
using WilderMinds.MetaWeblog;

namespace GitHub.Pages.Writer.API.Services {
    public interface IFileStorage {
        int AddCategory(Category category);
                Category[] GetCategories (string blogId, string username, string password);
                MediaObjectInfo SaveMedia(MediaObject mediaObject);
    }
}
