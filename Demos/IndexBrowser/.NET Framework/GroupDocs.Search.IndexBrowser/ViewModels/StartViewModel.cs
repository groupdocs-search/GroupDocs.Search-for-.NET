using GroupDocs.Search.IndexBrowser.Utils;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;

namespace GroupDocs.Search.IndexBrowser.ViewModels
{
    class StartViewModel : ViewModelBase
    {
        private readonly MainViewModel mainViewModel;
        private IndexDescriptorViewModel selectedIndex;

        public StartViewModel(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;

            LoadLicenseCommand = new RelayCommand(OnLoadLicense);
            CreateIndexCommand = new RelayCommand(OnCreateIndex);
            AddIndexCommand = new RelayCommand(OnAddIndex);
            LoadIndexCommand = new RelayCommand(OnLoadIndex, () => SelectedIndex != null);
            RemoveIndexCommand = new RelayCommand(OnRemoveIndex, () => SelectedIndex != null);

            Init();
        }

        public RelayCommand LoadLicenseCommand { get; private set; }
        public RelayCommand CreateIndexCommand { get; private set; }
        public RelayCommand AddIndexCommand { get; private set; }
        public RelayCommand LoadIndexCommand { get; private set; }
        public RelayCommand RemoveIndexCommand { get; private set; }

        public ObservableCollection<IndexDescriptorViewModel> Indexes => mainViewModel.Settings.Indexes;

        public IndexDescriptorViewModel SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                if (UpdateProperty(ref selectedIndex, value))
                {
                    LoadIndexCommand.NotifyCanExecuteChanged();
                    RemoveIndexCommand.NotifyCanExecuteChanged();
                }
            }
        }

        private async void Init()
        {
            var result = await SetLicense();
            if (!result)
            {
                mainViewModel.AddLogEntry("License is not set");
            }
        }

        private async void OnLoadLicense()
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog(App.Current.MainWindow) == true)
            {
                var path = openFileDialog.FileName;
                mainViewModel.Settings.LicensePath = path;

                await SetLicense();
            }
        }

        private void OnCreateIndex()
        {
            var viewModel = new CreateIndexViewModel(mainViewModel);
            mainViewModel.CurrentViewModel = viewModel;
        }

        private void OnAddIndex()
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                dialog.Description = "Select the index folder";
                dialog.ShowNewFolderButton = false;
                var result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    var fullPath = Path.GetFullPath(dialog.SelectedPath);
                    if (!IsFolderInTheList(fullPath))
                    {
                        var name = Path.GetFileName(fullPath);
                        var indexViewModel = new IndexDescriptorViewModel(name, fullPath);
                        Indexes.Add(indexViewModel);
                        SelectedIndex = indexViewModel;
                    }
                }
            }
        }

        private void OnLoadIndex()
        {
            var indexDescriptor = SelectedIndex;
            var index = new Index(indexDescriptor.Path, false);
            mainViewModel.AddLogEntry("Loaded index: " + indexDescriptor.Path);

            var viewModel = new LoadedIndexViewModel(mainViewModel, indexDescriptor.Name, index);
            mainViewModel.CurrentViewModel = viewModel;
        }

        private void OnRemoveIndex()
        {
            Indexes.Remove(SelectedIndex);
            SelectedIndex = null;
        }

        private bool IsFolderInTheList(string fullPath)
        {
            for (int i = 0; i < Indexes.Count; i++)
            {
                var idvm = Indexes[i];
                var current = Path.GetFullPath(idvm.Path);
                if (current == fullPath)
                {
                    return true;
                }
            }
            return false;
        }

        private async Task<bool> SetLicense()
        {
            mainViewModel.WindowEnabled = false;
            try
            {
                var licensePath = mainViewModel.Settings.LicensePath;
                if (!string.IsNullOrWhiteSpace(licensePath))
                {
                    mainViewModel.AddLogEntry("Setting license: " + licensePath);

                    await Task.Factory.StartNew(() =>
                    {
                        var license = new License();
                        license.SetLicense(licensePath);
                    });

                    mainViewModel.AddLogEntry("License is set");
                    return true;
                }
                return false;
            }
            finally
            {
                mainViewModel.WindowEnabled = true;
            }
        }
    }
}
