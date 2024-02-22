using GroupDocs.Search.IndexBrowser.XmlStorage;

namespace GroupDocs.Search.IndexBrowser.ViewModels
{
    class IndexDescriptorViewModel : ViewModelBase
    {
        private const string NameKey = "Name";
        private const string PathKey = "Path";

        private readonly string name;
        private readonly string path;

        public IndexDescriptorViewModel(string name, string path)
        {
            this.name = name;
            this.path = path;
        }

        public IndexDescriptorViewModel(XmlReader reader)
        {
            this.name = reader.Read(NameKey, string.Empty);
            this.path = reader.Read(PathKey, string.Empty);
        }

        public string Name => name;

        public string Path => path;

        public void Save(XmlWriter writer)
        {
            writer.Write(NameKey, name);
            writer.Write(PathKey, path);
        }
    }
}
