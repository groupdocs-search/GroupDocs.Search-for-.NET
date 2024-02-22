using GroupDocs.Search.IndexBrowser.Utils;

namespace GroupDocs.Search.IndexBrowser.ViewModels
{
    class PathViewModel : ViewModelBase
    {
        private readonly LoadedIndexViewModel loadedIndexViewModel;
        private readonly string path;

        public PathViewModel(
            LoadedIndexViewModel loadedIndexViewModel,
            string path)
        {
            this.loadedIndexViewModel = loadedIndexViewModel;
            this.path = path;

            RemoveCommand = new RelayCommand(OnRemove);
        }

        public RelayCommand RemoveCommand { get; private set; }

        public string Path => path;

        private void OnRemove()
        {
            loadedIndexViewModel.RemovePath(this);
        }
    }
}
