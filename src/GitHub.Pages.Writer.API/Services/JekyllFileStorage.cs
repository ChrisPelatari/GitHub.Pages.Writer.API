using WilderMinds.MetaWeblog;

namespace GitHub.Pages.Writer.API.Services {
    public class JekyllFileStorage : IFileStorage {
        public JekyllFileStorage(IConfiguration config) {
            Config = config;
        }

        public IConfiguration Config { get; }

        public MediaObjectInfo SaveMedia(MediaObject mediaObject) {
            var fileName = $"{Config["local:folder"]}/{Config["local:media"]}/{mediaObject.name}";

            if (File.Exists(fileName)) 
                File.Delete(fileName);

            File.WriteAllBytes(fileName, Convert.FromBase64String(mediaObject.bits));

            return new MediaObjectInfo { url = $"{Config["blog:url"]}/{Config["local:media"]}/{mediaObject.name}" };
        }
    }
}
