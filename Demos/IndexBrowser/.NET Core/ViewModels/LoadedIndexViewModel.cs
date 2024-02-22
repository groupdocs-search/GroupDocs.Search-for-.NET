using GroupDocs.Search.Events;
using GroupDocs.Search.IndexBrowser.Utils;
using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace GroupDocs.Search.IndexBrowser.ViewModels
{
    class LoadedIndexViewModel : ViewModelBase
    {
        private readonly Dispatcher dispatcher;
        private readonly MainViewModel mainViewModel;
        private Index index;
        private double progressPercentage;
        private readonly SearchOptionsViewModel searchOptions;

        private SearchResult searchResult;
        private readonly ObservableCollection<FoundDocumentViewModel> searchResults = new ObservableCollection<FoundDocumentViewModel>();
        private FoundDocumentViewModel selectedDocument;

        private string searchQuery;

        private readonly ObservableCollection<IndexPropertyViewModel> indexProperties;

        private readonly IndexedDocumentsViewModel indexedDocuments;

        private readonly ObservableCollection<PathViewModel> selectedPaths = new ObservableCollection<PathViewModel>();

        public LoadedIndexViewModel(
            MainViewModel mainViewModel,
            string indexName,
            Index index)
        {
            dispatcher = Dispatcher.CurrentDispatcher;
            this.mainViewModel = mainViewModel;
            this.index = index;
            searchOptions = new SearchOptionsViewModel(this);
            indexProperties = new ObservableCollection<IndexPropertyViewModel>()
            {
                new IndexPropertyViewModel("Name", () => indexName),
                new IndexPropertyViewModel("Path", () => index.IndexInfo.IndexFolder),
                new IndexPropertyViewModel("ID", () => index.IndexInfo.IndexId.ToString()),
                new IndexPropertyViewModel("Version", () => index.IndexInfo.Version),
                new IndexPropertyViewModel("In memory index", () => index.IndexSettings.InMemoryIndex.ToString()),
                new IndexPropertyViewModel("Use stop words", () => index.IndexSettings.UseStopWords.ToString()),
                new IndexPropertyViewModel("Max indexing reports", () => index.IndexSettings.MaxIndexingReportCount.ToString()),
                new IndexPropertyViewModel("Max search reports", () => index.IndexSettings.MaxSearchReportCount.ToString()),
                new IndexPropertyViewModel("Use character replacements", () => index.IndexSettings.UseCharacterReplacements.ToString()),
                new IndexPropertyViewModel("Document filter", () => index.IndexSettings.DocumentFilter == null ? "<empty>" : index.IndexSettings.DocumentFilter.ToString()),
                new IndexPropertyViewModel("Text storage compression", () => index.IndexSettings.TextStorageSettings == null ? "<no storage>" : index.IndexSettings.TextStorageSettings.Compression.ToString()),
                new IndexPropertyViewModel("Index type", () => index.IndexSettings.IndexType.ToString()),
                new IndexPropertyViewModel("Search threads", () => index.IndexSettings.SearchThreads.ToString()),
            };
            selectedPaths.CollectionChanged += OnSelectedPathsChanged;

            CloseIndexCommand = new RelayCommand(
                OnCloseIndex,
                () => this.index.IndexInfo.IndexStatus == Common.IndexStatus.Failed || this.index.IndexInfo.IndexStatus == Common.IndexStatus.Ready);
            AddDirectoryCommand = new RelayCommand(OnAddDirectory);
            AddFileCommand = new RelayCommand(OnAddFile);
            ClearListCommand = new RelayCommand(OnClearList);
            AddToIndexCommand = new RelayCommand(OnAddToIndex, () => SelectedPaths.Count > 0);
            UpdateIndexCommand = new RelayCommand(OnUpdateIndex);
            OptimizeIndexCommand = new RelayCommand(OnOptimizeIndex);

            SearchCommand = new RelayCommand(
                OnSearch,
                () => !string.IsNullOrEmpty(SearchQuery));
            NavigateToNextCommand = new RelayCommand(
                OnNavigateToNext,
                () => SelectedDocument != null && SelectedDocument.CanNavigateNext);
            NavigateToPreviousCommand = new RelayCommand(
                OnNavigateToPrevious,
                () => SelectedDocument != null && SelectedDocument.CanNavigatePrevious);

            Subscribe();
            indexedDocuments = new IndexedDocumentsViewModel(mainViewModel, this.index);
            indexedDocuments.ExtractDocumentList();
        }

        public RelayCommand CloseIndexCommand { get; private set; }

        public RelayCommand AddDirectoryCommand { get; private set; }
        public RelayCommand AddFileCommand { get; private set; }
        public RelayCommand ClearListCommand { get; private set; }

        public RelayCommand AddToIndexCommand { get; private set; }
        public RelayCommand UpdateIndexCommand { get; private set; }
        public RelayCommand OptimizeIndexCommand { get; private set; }

        public RelayCommand SearchCommand { get; private set; }
        public RelayCommand NavigateToPreviousCommand { get; private set; }
        public RelayCommand NavigateToNextCommand { get; private set; }

        public Index Index => index;

        public bool WindowEnabled => mainViewModel.WindowEnabled;

        public string IndexPath => index.IndexInfo.IndexFolder;

        public string IndexStatus
        {
            get { return index.IndexInfo.IndexStatus.ToString(); }
        }

        public string IndexProgress
        {
            get { return ProgressPercentage.ToString("F0") + "%"; }
        }

        public double ProgressPercentage
        {
            get { return progressPercentage; }
            set
            {
                if (UpdateProperty(ref progressPercentage, value))
                {
                    NotifyPropertyChanged(nameof(IndexProgress));
                }
            }
        }

        public SearchOptionsViewModel SearchOptions => searchOptions;

        public string SearchQuery
        {
            get { return searchQuery; }
            set
            {
                if (UpdateProperty(ref searchQuery, value))
                {
                    SearchCommand.NotifyCanExecuteChanged();
                }
            }
        }

        public int DocumentCount
        {
            get { return SearchResult == null ? 0 : SearchResult.DocumentCount; }
        }

        public int OccurrenceCount
        {
            get { return SearchResult == null ? 0 : SearchResult.OccurrenceCount; }
        }

        public SearchResult SearchResult
        {
            get { return searchResult; }
            set
            {
                if (UpdateProperty(ref searchResult, value))
                {
                    NotifyPropertyChanged(nameof(DocumentCount));
                    NotifyPropertyChanged(nameof(OccurrenceCount));
                }
            }
        }

        public ObservableCollection<FoundDocumentViewModel> SearchResults
        {
            get { return searchResults; }
        }

        public FoundDocumentViewModel SelectedDocument
        {
            get { return selectedDocument; }
            set { SetSelectedDocument(value); }
        }

        public bool HasSelectedDocument => selectedDocument != null;

        public ObservableCollection<IndexPropertyViewModel> IndexProperties => indexProperties;

        public IndexedDocumentsViewModel IndexedDocuments => indexedDocuments;

        public ObservableCollection<PathViewModel> SelectedPaths => selectedPaths;

        public void RemovePath(PathViewModel path)
        {
            SelectedPaths.Remove(path);
        }

        private async void SetSelectedDocument(FoundDocumentViewModel value)
        {
            mainViewModel.WindowEnabled = false;
            try
            {
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
                NotifyPropertyChanged(nameof(HasSelectedDocument));
                NavigateToPreviousCommand.NotifyCanExecuteChanged();
                NavigateToNextCommand.NotifyCanExecuteChanged();
            }
            finally
            {
                mainViewModel.WindowEnabled = true;
            }
        }

        private async void OnSearch()
        {
            mainViewModel.WindowEnabled = false;
            try
            {
                await Task.Factory.StartNew(() =>
                {
                    SearchResult = index.Search(SearchQuery, SearchOptions.SearchOptions);
                });

                SearchResults.Clear();
                try
                {
                    foreach (var result in SearchResult)
                    {
                        var resultVM = new FoundDocumentViewModel(this, result);
                        SearchResults.Add(resultVM);
                    }
                    mainViewModel.AddLogEntry(
                        "Search result: " + SearchResult.OccurrenceCount + " occurrences in " + SearchResult.DocumentCount + " documents.");
                }
                catch (Exception e)
                {
                    mainViewModel.AddLogEntry(e.Message);
                }
            }
            finally
            {
                mainViewModel.WindowEnabled = true;
            }
        }

        private void OnNavigateToNext()
        {
            SelectedDocument.NavigateNext();
            NavigateToNextCommand.NotifyCanExecuteChanged();
            NavigateToPreviousCommand.NotifyCanExecuteChanged();
        }

        private void OnNavigateToPrevious()
        {
            SelectedDocument.NavigatePrevious();
            NavigateToNextCommand.NotifyCanExecuteChanged();
            NavigateToPreviousCommand.NotifyCanExecuteChanged();
        }

        private void Subscribe()
        {
            index.Events.ErrorOccurred += OnIndexErrorOccurred;
            index.Events.OperationFinished += OnIndexOperationFinished;
            index.Events.OperationProgressChanged += OnIndexOperationProgressChanged;
            index.Events.OptimizationProgressChanged += OnIndexOptimizationProgressChanged;
            index.Events.StatusChanged += OnIndexStatusChanged;
        }

        private void Unsubscribe()
        {
            index.Events.ErrorOccurred -= OnIndexErrorOccurred;
            index.Events.OperationFinished -= OnIndexOperationFinished;
            index.Events.OperationProgressChanged -= OnIndexOperationProgressChanged;
            index.Events.OptimizationProgressChanged -= OnIndexOptimizationProgressChanged;
            index.Events.StatusChanged -= OnIndexStatusChanged;
        }

        private void OnCloseIndex()
        {
            Unsubscribe();
            index.Dispose();
            mainViewModel.CloseCurrentView();
        }

        private void OnClearList()
        {
            SelectedPaths.Clear();
        }

        private void OnAddFile()
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "Select files for indexing";
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == true)
            {
                for (int i = 0; i < dialog.FileNames.Length; i++)
                {
                    var path = dialog.FileNames[i];
                    var vm = new PathViewModel(this, path);
                    SelectedPaths.Add(vm);
                }
            }
        }

        private void OnAddDirectory()
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                dialog.Description = "Select a folder with documents";
                dialog.ShowNewFolderButton = false;
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    var vm = new PathViewModel(this, dialog.SelectedPath);
                    SelectedPaths.Add(vm);
                }
            }
        }

        private void OnAddToIndex()
        {
            var paths = SelectedPaths
                .Select(pvm => Path.GetFullPath(pvm.Path))
                .ToArray();
            IndexingOptions options = new IndexingOptions();
            options.IsAsync = true;
            index.Add(paths, options);
        }

        private void OnUpdateIndex()
        {
            UpdateOptions options = new UpdateOptions();
            options.IsAsync = true;
            index.Update(options);
        }

        private void OnOptimizeIndex()
        {
            MergeOptions options = new MergeOptions();
            options.IsAsync = true;
            index.Optimize(options);
        }

        private void OnIndexErrorOccurred(object sender, IndexErrorEventArgs e)
        {
            dispatcher.Invoke(() =>
            {
                mainViewModel.AddLogEntry(e.Time, e.Message);
            });
        }

        private void OnIndexOperationFinished(object sender, OperationFinishedEventArgs e)
        {
            dispatcher.Invoke(() =>
            {
                mainViewModel.AddLogEntry(e.Time, "Operation finished: " + e.OperationType);
            });
        }

        private void OnIndexOperationProgressChanged(object sender, OperationProgressEventArgs e)
        {
            dispatcher.Invoke(() =>
            {
                ProgressPercentage = e.ProgressPercentage;
            });
        }

        private void OnIndexOptimizationProgressChanged(object sender, OptimizationProgressEventArgs e)
        {
            dispatcher.Invoke(() =>
            {
                ProgressPercentage = e.ProgressPercentage;
            });
        }

        private void OnIndexStatusChanged(object sender, BaseIndexEventArgs e)
        {
            dispatcher.Invoke(() =>
            {
                CloseIndexCommand.NotifyCanExecuteChanged();
                ProgressPercentage = 0;
                NotifyPropertyChanged(nameof(IndexStatus));

                if (index.IndexInfo.IndexStatus == Common.IndexStatus.Ready)
                {
                    indexedDocuments.ExtractDocumentList();
                }
            });
        }

        private void OnSelectedPathsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            AddToIndexCommand.NotifyCanExecuteChanged();
        }
    }
}
