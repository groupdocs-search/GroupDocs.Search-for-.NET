using GroupDocs.Search.IndexBrowser.Utils;
using System.Collections.ObjectModel;
using System.Linq;

namespace GroupDocs.Search.IndexBrowser.ViewModels
{
    class IndexedDocumentsViewModel : ViewModelBase
    {
        private readonly MainViewModel mainViewModel;
        private readonly Index index;
        private ObservableCollection<DocumentInfoViewModel> documents;
        private DocumentInfoViewModel selectedDocument;

        public IndexedDocumentsViewModel(MainViewModel mainViewModel, Index index)
        {
            this.mainViewModel = mainViewModel;
            this.index = index;

            ExtractDocumentListCommand = new RelayCommand(OnExtractDocumentList);
        }

        public RelayCommand ExtractDocumentListCommand { get; private set; }

        public bool WindowEnabled => mainViewModel.WindowEnabled;

        public ObservableCollection<DocumentInfoViewModel> Documents
        {
            get => documents;
            set => UpdateProperty(ref documents, value);
        }

        public DocumentInfoViewModel SelectedDocument
        {
            get => selectedDocument;
            set { SetSelectedDocument(value); }
        }

        public void ExtractDocumentList()
        {
            OnExtractDocumentList();
        }

        private async void SetSelectedDocument(DocumentInfoViewModel value)
        {
            mainViewModel.WindowEnabled = false;

            if (selectedDocument != value)
            {
                if (selectedDocument != null)
                {
                    selectedDocument.Unload();
                }

                selectedDocument = value;

                if (selectedDocument != null)
                {
                    await selectedDocument.LoadAsync();
                }
            }

            NotifyPropertyChanged(nameof(SelectedDocument));

            mainViewModel.WindowEnabled = true;
        }

        private void OnExtractDocumentList()
        {
            var documents = index.GetIndexedDocuments();
            Documents = new ObservableCollection<DocumentInfoViewModel>(documents.Select(di => new DocumentInfoViewModel(index, di)));
        }
    }
}
