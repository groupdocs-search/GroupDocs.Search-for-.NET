using GroupDocs.Search.Examples.CSharp.AdvancedUsage.CreatingAnIndex;
using GroupDocs.Search.Examples.CSharp.AdvancedUsage.Indexing;
using GroupDocs.Search.Examples.CSharp.AdvancedUsage.ManagingDictionaries;
using GroupDocs.Search.Examples.CSharp.AdvancedUsage.Searching;
using GroupDocs.Search.Examples.CSharp.BasicUsage;
using GroupDocs.Search.Examples.CSharp.GettingStarted;
using System;

namespace GroupDocs.Search.Examples.CSharp
{
    class RunExamples
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Open RunExamples.cs. \nIn the Main() method, uncomment the example that you want to run.");
            Console.WriteLine("=====================================================");

            //NOTE: Please uncomment the example you want to try out

            #region Getting Started ----------------------------------------------------------------------------------------------------

            SetLicenseFromFile.Run();
            //SetLicenseFromStream.Run();
            //SetMeteredLicense.Run();
            HelloWorld.Run();

            #endregion Getting Started ----------------------------------------------------------------------------------------------------

            #region Basic Usage ----------------------------------------------------------------------------------------------------

            //BuildYourFirstSearchSolution.RunSynchronousIndexing();
            //BuildYourFirstSearchSolution.RunAsynchronousIndexing();

            //BuildSearchQuery.Run();

            //WorkWithSearchResults.ObtainSearchResultInformation();
            //WorkWithSearchResults.HighlightSearchResults();

            //GetSupportedFileFormats.Run();

            #endregion Basic Usage ----------------------------------------------------------------------------------------------------

            #region Advanced Usage ----------------------------------------------------------------------------------------------------

            // Creating an Index ----------------------------------------------------------------------------------------------------

            //UsingEvents.OperationFinishedEvent();
            //UsingEvents.ErrorOccurredEvent();
            //UsingEvents.OperationProgressChangedEvent();
            //UsingEvents.PasswordRequiredEvent();
            //UsingEvents.FileIndexingEvent();
            //UsingEvents.StatusChangedEvent();
            //UsingEvents.SearchPhaseCompletedEvent();

            //UsingIndexRepository.Run();

            // Indexing ----------------------------------------------------------------------------------------------------

            //CharacterReplacementDuringIndexing.Run();

            //CharacterTypes.RegularCharacters();
            //CharacterTypes.BlendedCharacters();

            //CustomTextExtractors.Run();

            //DeleteIndexedPaths.Run();

            //DocumentFilteringDuringIndexing.SettingAFilter();
            //DocumentFilteringDuringIndexing.CreationTimeFilters();
            //DocumentFilteringDuringIndexing.ModificationTimeFilters();
            //DocumentFilteringDuringIndexing.FilePathFilters();
            //DocumentFilteringDuringIndexing.FileLengthFilters();
            //DocumentFilteringDuringIndexing.FileExtensionFilter();
            //DocumentFilteringDuringIndexing.LogicalNotFilter();
            //DocumentFilteringDuringIndexing.LogicalAndFilter();
            //DocumentFilteringDuringIndexing.LogicalOrFilter();

            //IndexingAdditionalFields.Run();

            //IndexingMetadataOfDocuments.Run();

            //IndexingOptionsProperties.CancellationProperty();
            //IndexingOptionsProperties.IsAsyncProperty();
            //IndexingOptionsProperties.ThreadsProperty();

            //IndexingPasswordProtectedDocuments.IndexingUsingThePasswordDictionary();
            //IndexingPasswordProtectedDocuments.IndexingUsingThePasswordRequiredEvent();

            //IndexingReports.Run();

            //IndexingWithStopWords.Run();

            //Logging.UseOfStandardFileLogger();
            //Logging.ImplementingCustomLogger();

            //MergeIndexes.Run();

            //OptimizeIndex.Run();

            //StoringTextOfIndexedDocuments.Run();

            //TextFileEncodingDetection.Run();

            //UpdateIndex.UpdateIndexedDocuments();
            //UpdateIndex.UpdateIndexVersion();

            // Searching ----------------------------------------------------------------------------------------------------

            //BooleanSearch.OperatorAnd();
            //BooleanSearch.OperatorOr();
            //BooleanSearch.OperatorNot();
            //BooleanSearch.ComplexQueries();

            //CaseSensitiveSearch.QueryInTextForm();
            //CaseSensitiveSearch.QueryInObjectForm();

            //DateRangeSearch.CreatingDateRangeSearchQueries();
            //DateRangeSearch.SpecifyingDateRangeSearchFormats();

            //DocumentFilteringInSearchResult.SettingAFilter();
            //DocumentFilteringInSearchResult.FilePathFilters();
            //DocumentFilteringInSearchResult.FileExtensionFilter();
            //DocumentFilteringInSearchResult.CombiningFilters();

            //FacetedSearch.SimpleFacetedSearch();
            //FacetedSearch.ComplexQuery();

            //FuzzySearch.SettingFuzzySearchAlgorithm();
            //FuzzySearch.SettingStepFunction();

            //GettingIndexedDocuments.GettingDocuments();
            //GettingIndexedDocuments.GettingTextOfIndexedDocuments();

            //HighlightingSearchResults.HighlightingInEntireDocument();
            //HighlightingSearchResults.HighlightingInSegments();

            //HomophoneSearch.Run();

            //KeyboardLayoutCorrection.Run();

            //NumericRangeSearch.Run();

            //OutputAdapters.Run();

            //PhraseSearch.SimplePhraseSearch();
            //PhraseSearch.PhraseSearchWithWildcards();
            //PhraseSearch.PhraseSearchWithWildcards2();

            //QueriesInTextAndObjectForm.Run();

            //RegularExpressionSearch.Run();

            //SearchByChunks.Run();

            //SearchForDifferentWordForms.Run();

            //SearchReports.Run();

            //SearchResults.Run();

            //SpellChecking.Run();

            //SynonymSearch.Run();

            //UsingAliases.Run();

            //WildcardSearch.QueryInTextForm();

            // Managing Dictionaries ----------------------------------------------------------------------------------------------------

            //AliasDictionary.Run();

            //Alphabet.Run();

            //CharacterReplacements.Run();

            //DocumentPasswords.Run();

            //HomophoneDictionary.Run();

            //SpellingCorrector.Run();

            //StopWordDictionary.Run();

            //SynonymDictionary.Run();

            //WordFormsProvider.Run();

            #endregion Advanced Usage ----------------------------------------------------------------------------------------------------

            Console.WriteLine();
            Console.WriteLine("All done.");
            Console.ReadKey();
        }
    }
}
