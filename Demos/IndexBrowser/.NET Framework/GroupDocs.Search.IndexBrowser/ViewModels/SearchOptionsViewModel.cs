using GroupDocs.Search.IndexBrowser.Utils;
using GroupDocs.Search.Options;

namespace GroupDocs.Search.IndexBrowser.ViewModels
{
    class SearchOptionsViewModel : ViewModelBase
    {
        private readonly LoadedIndexViewModel loadedIndexViewModel;
        private readonly SearchOptions searchOptions;

        public SearchOptionsViewModel(LoadedIndexViewModel loadedIndexViewModel)
        {
            this.loadedIndexViewModel = loadedIndexViewModel;

            IncreaseFuzzyMistakesCommand = new RelayCommand(() =>
            {
                FuzzySearchMaxMistakeCount++;
            }, () =>
            {
                return FuzzySearchMaxMistakeCount < 10;
            });

            DecreaseFuzzyMistakesCommand = new RelayCommand(() =>
            {
                FuzzySearchMaxMistakeCount--;
            }, () =>
            {
                return FuzzySearchMaxMistakeCount > 1;
            });

            IncreaseCorrectorMistakesCommand = new RelayCommand(() =>
            {
                SpellingCorrectorMaxMistakeCount++;
            }, () =>
            {
                return SpellingCorrectorMaxMistakeCount < 10;
            });

            DecreaseCorrectorMistakesCommand = new RelayCommand(() =>
            {
                SpellingCorrectorMaxMistakeCount--;
            }, () =>
            {
                return SpellingCorrectorMaxMistakeCount > 1;
            });

            searchOptions = new SearchOptions();
            searchOptions.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(2);
            searchOptions.MaxTotalOccurrenceCount = 100000000;
            searchOptions.MaxOccurrenceCountPerTerm = 100000000;
        }

        public RelayCommand IncreaseFuzzyMistakesCommand { get; private set; }
        public RelayCommand DecreaseFuzzyMistakesCommand { get; private set; }

        public RelayCommand IncreaseCorrectorMistakesCommand { get; private set; }
        public RelayCommand DecreaseCorrectorMistakesCommand { get; private set; }

        public SearchOptions SearchOptions => searchOptions;

        public bool IsCaseSensitiveSearch
        {
            get => SearchOptions.UseCaseSensitiveSearch;
            set => SearchOptions.UseCaseSensitiveSearch = value;
        }

        public bool IsFuzzySearchEnabled
        {
            get => SearchOptions.FuzzySearch.Enabled;
            set => SearchOptions.FuzzySearch.Enabled = value;
        }

        public int FuzzySearchMaxMistakeCount
        {
            get => SearchOptions.FuzzySearch.FuzzyAlgorithm.GetMaxMistakeCount(7);
            set
            {
                SearchOptions.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(value);
                NotifyPropertyChanged(nameof(FuzzySearchMaxMistakeCount));
                IncreaseFuzzyMistakesCommand.NotifyCanExecuteChanged();
                DecreaseFuzzyMistakesCommand.NotifyCanExecuteChanged();
            }
        }

        public bool FuzzySearchOnlyBestResults
        {
            get => SearchOptions.FuzzySearch.OnlyBestResults;
            set => SearchOptions.FuzzySearch.OnlyBestResults = value;
        }

        public bool IsSpellingCorrectorEnabled
        {
            get => SearchOptions.SpellingCorrector.Enabled;
            set => SearchOptions.SpellingCorrector.Enabled = value;
        }

        public int SpellingCorrectorMaxMistakeCount
        {
            get => SearchOptions.SpellingCorrector.MaxMistakeCount;
            set
            {
                SearchOptions.SpellingCorrector.MaxMistakeCount = value;
                NotifyPropertyChanged(nameof(SpellingCorrectorMaxMistakeCount));
                IncreaseCorrectorMistakesCommand.NotifyCanExecuteChanged();
                DecreaseCorrectorMistakesCommand.NotifyCanExecuteChanged();
            }
        }

        public bool SpellingCorrectorOnlyBestResults
        {
            get => SearchOptions.SpellingCorrector.OnlyBestResults;
            set => SearchOptions.SpellingCorrector.OnlyBestResults = value;
        }

        public bool UseKeyboardLayoutCorrector
        {
            get => SearchOptions.KeyboardLayoutCorrector.Enabled;
            set => SearchOptions.KeyboardLayoutCorrector.Enabled = value;
        }

        public bool UseSynonymSearch
        {
            get => SearchOptions.UseSynonymSearch;
            set => SearchOptions.UseSynonymSearch = value;
        }

        public bool UseHomophoneSearch
        {
            get => SearchOptions.UseHomophoneSearch;
            set => SearchOptions.UseHomophoneSearch = value;
        }

        public bool UseWordFormsSearch
        {
            get => SearchOptions.UseWordFormsSearch;
            set => SearchOptions.UseWordFormsSearch = value;
        }

        public int MaxTotalOccurrences
        {
            get => SearchOptions.MaxTotalOccurrenceCount;
            set => SearchOptions.MaxTotalOccurrenceCount = value;
        }

        public int MaxOccurrencesPerTerm
        {
            get => SearchOptions.MaxOccurrenceCountPerTerm;
            set => SearchOptions.MaxOccurrenceCountPerTerm = value;
        }
    }
}
