using GroupDocs.Search.Options;
using GroupDocs.Search.Results;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Searching
{
    class FacetedSearch
    {
        public static void SimpleFacetedSearch()
        {
            string indexFolder = @".\AdvancedUsage\Searching\FacetedSearch\SimpleFacetedSearch";
            string documentsFolder = Utils.DocumentsPath;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Search in the content field with text query
            string query1 = "content: Pellentesque";
            SearchResult result1 = index.Search(query1);

            // Search in the content field with object query
            SearchQuery wordQuery = SearchQuery.CreateWordQuery("Pellentesque");
            SearchQuery fieldQuery = SearchQuery.CreateFieldQuery(CommonFieldNames.Content, wordQuery);
            SearchResult result2 = index.Search(fieldQuery);

            Utils.TraceResult(query1, result1);
            Utils.TraceResult(fieldQuery.ToString(), result2);
        }

        public static void ComplexQuery()
        {
            string indexFolder = @".\AdvancedUsage\Searching\FacetedSearch\ComplexQuery";
            string documentsFolder = Utils.DocumentsPath;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Search with text query
            string query1 = "(filename: (lorem AND ipsum)) OR (content: (\"lectus eu aliquam\" OR \"dignissim turpis\"))";
            SearchResult result1 = index.Search(query1);

            // Search with object query
            SearchQuery word6Query = SearchQuery.CreateWordQuery("lorem");
            SearchQuery word7Query = SearchQuery.CreateWordQuery("ipsum");
            SearchQuery andQuery = SearchQuery.CreateAndQuery(word6Query, word7Query);
            SearchQuery filenameQuery = SearchQuery.CreateFieldQuery(CommonFieldNames.FileName, andQuery);

            SearchQuery word1Query = SearchQuery.CreateWordQuery("lectus");
            SearchQuery word2Query = SearchQuery.CreateWordQuery("eu");
            SearchQuery word3Query = SearchQuery.CreateWordQuery("aliquam");
            SearchQuery word4Query = SearchQuery.CreateWordQuery("dignissim");
            SearchQuery word5Query = SearchQuery.CreateWordQuery("turpis");

            SearchQuery phrase1Query = SearchQuery.CreatePhraseSearchQuery(word1Query, word2Query, word3Query);
            SearchQuery phrase2Query = SearchQuery.CreatePhraseSearchQuery(word4Query, word5Query);
            SearchQuery orQuery = SearchQuery.CreateOrQuery(phrase1Query, phrase2Query);
            SearchQuery contentQuery = SearchQuery.CreateFieldQuery(CommonFieldNames.Content, orQuery);

            SearchQuery rootQuery = SearchQuery.CreateOrQuery(filenameQuery, contentQuery);
            SearchResult result2 = index.Search(rootQuery);

            Utils.TraceResult(query1, result1);
            Utils.TraceResult(rootQuery.ToString(), result2);
        }

        public static void UsingStandardFieldNames()
        {
            string indexFolder = @".\AdvancedUsage\Searching\FacetedSearch\UsingStandardFieldNames";
            string documentsFolder = Utils.DocumentsPath;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Search in the content field with text query
            string query1 = WordsFieldNames.Company + ": Dycum";
            SearchResult result1 = index.Search(query1);

            // Search in the content field with object query
            SearchQuery wordQuery = SearchQuery.CreateWordQuery("Dycum");
            SearchQuery fieldQuery = SearchQuery.CreateFieldQuery(WordsFieldNames.Company, wordQuery);
            SearchResult result2 = index.Search(fieldQuery);

            Utils.TraceResult(query1, result1);
            Utils.TraceResult(fieldQuery.ToString(), result2);
        }
    }
}
