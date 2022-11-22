using WilderMinds.MetaWeblog;

namespace GitHub.Pages.Writer.API.Services {
    public interface IFileStorage {
        MediaObjectInfo SaveMedia(MediaObject mediaObject);
    }
}
