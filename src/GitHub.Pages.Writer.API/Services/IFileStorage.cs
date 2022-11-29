using GitHub.Pages.Writer.API.Models;
using WilderMinds.MetaWeblog;

namespace GitHub.Pages.Writer.API.Services {
    public interface IFileStorage {
        int AddCategory(Category category);
        MediaObjectInfo SaveMedia(MediaObject mediaObject);
    }
}
