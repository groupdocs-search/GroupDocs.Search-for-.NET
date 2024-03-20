using GroupDocs.Search.IndexBrowser.Utils;
using GroupDocs.Search.Options;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace GroupDocs.Search.IndexBrowser.ViewModels
{
    class CreateIndexViewModel : ViewModelBase
    {
        private readonly MainViewModel mainViewModel;
        private string name;
        private string folder;
        private bool inMemoryIndex;
        private bool useStopWords;
        private bool useCharacterReplacements;
        private bool cacheDocumentText = true;
        private readonly ObservableCollection<Compression> textCompressions;
        private Compression textCompression = Compression.High;
        private readonly ObservableCollection<IndexType> indexTypes;
        private IndexType indexType = IndexType.NormalIndex;

        public CreateIndexViewModel(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;

            SelectFolderCommand = new RelayCommand(OnSelectFolder);
            ApplyCommand = new RelayCommand(OnApply, () => IsNameValid() && (InMemoryIndex || IsFolderValid()));
            CancelCommand = new RelayCommand(OnCancel);

            textCompressions = new ObservableCollection<Compression>()
            {
                Compression.None,
                Compression.Normal,
                Compression.High,
            };
            indexTypes = new ObservableCollection<IndexType>()
            {
                IndexType.NormalIndex,
                IndexType.MetadataIndex,
                IndexType.CompactIndex,
            };
        }

        public RelayCommand SelectFolderCommand { get; private set; }
        public RelayCommand ApplyCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }

        public string Name
        {
            get { return name; }
            set
            {
                if (UpdateProperty(ref name, value))
                {
                    ApplyCommand.NotifyCanExecuteChanged();
                }
            }
        }

        public string Folder
        {
            get { return folder; }
            set
            {
                if (UpdateProperty(ref folder, value))
                {
                    ApplyCommand.NotifyCanExecuteChanged();
                    TryUpdateName();
                }
            }
        }

        public bool InMemoryIndex
        {
            get { return inMemoryIndex; }
            set
            {
                if (UpdateProperty(ref inMemoryIndex, value))
                {
                    NotifyPropertyChanged(nameof(IsFolderEnabled));
                    ApplyCommand.NotifyCanExecuteChanged();
                }
            }
        }

        public bool IsFolderEnabled
        {
            get { return !inMemoryIndex; }
        }

        public bool UseStopWords
        {
            get { return useStopWords; }
            set { UpdateProperty(ref useStopWords, value); }
        }

        public bool UseCharacterReplacements
        {
            get { return useCharacterReplacements; }
            set { UpdateProperty(ref useCharacterReplacements, value); }
        }

        public bool CacheDocumentText
        {
            get { return cacheDocumentText; }
            set { UpdateProperty(ref cacheDocumentText, value); }
        }

        public ObservableCollection<Compression> TextCompressions
        {
            get { return textCompressions; }
        }

        public Compression TextCompression
        {
            get { return textCompression; }
            set { UpdateProperty(ref textCompression, value); }
        }

        public ObservableCollection<IndexType> IndexTypes
        {
            get { return indexTypes; }
        }

        public IndexType IndexType
        {
            get { return indexType; }
            set { UpdateProperty(ref indexType, value); }
        }

        private Index CreateIndex()
        {
            var indexSettings = new IndexSettings();
            indexSettings.UseStopWords = UseStopWords;
            indexSettings.IndexType = IndexType;
            if (CacheDocumentText)
            {
                indexSettings.TextStorageSettings = new TextStorageSettings(TextCompression);
            }

            Index index;
            if (InMemoryIndex)
            {
                index = new Index(indexSettings);
            }
            else
            {
                var fullPath = Path.GetFullPath(Folder);
                index = new Index(fullPath, indexSettings, true);
            }
            return index;
        }

        private bool IsNameValid()
        {
            return !string.IsNullOrWhiteSpace(Name);
        }

        private bool IsFolderValid()
        {
            try
            {
                var fullPath = Path.GetFullPath(Folder);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private void OnSelectFolder()
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                dialog.Description = "Select a folder for the new index";
                dialog.ShowNewFolderButton = true;
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    Folder = dialog.SelectedPath;
                }
            }
        }

        private void TryUpdateName()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                try
                {
                    Name = Path.GetFileName(Folder);
                }
                catch (Exception)
                {
                }
            }
        }

        private void OnApply()
        {
            var path = InMemoryIndex ? "<In Memory>" : Folder;
            var indexDescriptor = new IndexDescriptorViewModel(Name, path);
            if (!InMemoryIndex)
            {
                mainViewModel.Settings.Indexes.Add(indexDescriptor);
            }
            var index = CreateIndex();
            mainViewModel.AddLogEntry("Created index: " + indexDescriptor.Path);

            var viewModel = new LoadedIndexViewModel(mainViewModel, indexDescriptor.Name, index);
            mainViewModel.CurrentViewModel = viewModel;
        }

        private void OnCancel()
        {
            mainViewModel.CloseCurrentView();
        }
    }
}
