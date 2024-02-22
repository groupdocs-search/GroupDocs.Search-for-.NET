using System;

namespace GroupDocs.Search.IndexBrowser.ViewModels
{
    class IndexPropertyViewModel : ViewModelBase
    {
        private readonly string name;
        private readonly Func<string> valueGetter;

        public IndexPropertyViewModel(
            string name,
            Func<string> valueGetter)
        {
            this.name = name;
            this.valueGetter = valueGetter;
        }

        public string Name => name;

        public string Value => valueGetter();
    }
}
