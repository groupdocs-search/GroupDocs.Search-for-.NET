using GroupDocs.Search.IndexBrowser.ViewModels;
using GroupDocs.Search.IndexBrowser.XmlStorage;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace GroupDocs.Search.IndexBrowser
{
    class Settings
    {
        private const string WindowStateKey = "WindowState";
        private const string HeightKey = "Height";
        private const string WidthKey = "Width";
        private const string LeftKey = "Left";
        private const string TopKey = "Top";

        private const string LicensePathKey = "LicensePath";
        private const string IndexesKey = "Indexes";
        private const string IndexKey = "Index";

        private const WindowState WindowStateDefault = WindowState.Normal;
        private const double HeightDefault = 600;
        private const double WidthDefault = 800;
        private const double LeftDefault = 0;
        private const double TopDefault = 0;

        private static readonly string LicensePathDefault = string.Empty;
        private static readonly ObservableCollection<IndexDescriptorViewModel> IndexesDefault = new ObservableCollection<IndexDescriptorViewModel>();

        public Settings()
        {
            WindowState = WindowStateDefault;
            Height = HeightDefault;
            Width = WidthDefault;
            Left = LeftDefault;
            Top = TopDefault;

            Indexes = IndexesDefault;
            LicensePath = LicensePathDefault;
        }

        public WindowState WindowState { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Left { get; set; }
        public double Top { get; set; }

        public string LicensePath { get; set; }
        public ObservableCollection<IndexDescriptorViewModel> Indexes { get; set; }

        public void Save(XmlWriter writer)
        {
            writer.Write(WindowStateKey, (int)WindowState);
            writer.Write(HeightKey, Height);
            writer.Write(WidthKey, Width);
            writer.Write(LeftKey, Left);
            writer.Write(TopKey, Top);

            writer.Write(LicensePathKey, LicensePath);
            var indexesWriter = writer.CreateChildWriter(IndexesKey);
            foreach (var index in Indexes)
            {
                var indexWriter = indexesWriter.CreateChildWriter(IndexKey);
                index.Save(indexWriter);
            }
        }

        public void Load(XmlReader reader)
        {
            WindowState = (WindowState)reader.Read(WindowStateKey, (int)WindowStateDefault);
            Height = reader.Read(HeightKey, HeightDefault);
            Width = reader.Read(WidthKey, WidthDefault);
            Left = reader.Read(LeftKey, LeftDefault);
            Top = reader.Read(TopKey, TopDefault);

            LicensePath = reader.Read(LicensePathKey, LicensePathDefault);
            var indexesReader = reader.GetChildReader(IndexesKey);
            if (indexesReader == null)
            {
                Indexes = IndexesDefault;
            }
            else
            {
                var indexReaders = indexesReader.GetChildReaders(IndexKey);
                var indexes = indexReaders.Select(r => new IndexDescriptorViewModel(r));
                Indexes = new ObservableCollection<IndexDescriptorViewModel>(indexes);
            }
        }
    }
}
