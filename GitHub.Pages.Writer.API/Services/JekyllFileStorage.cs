using WilderMinds.MetaWeblog;

namespace GitHub.Pages.Writer.API.Services {
    public class JekyllFileStorage : IFileStorage {
        public JekyllFileStorage(IConfiguration config) {
            Config = config;
        }

        public IConfiguration Config { get; }

        public MediaObjectInfo SaveMedia(MediaObject mediaObject) {
            throw new NotImplementedException();
        }
    }
}
