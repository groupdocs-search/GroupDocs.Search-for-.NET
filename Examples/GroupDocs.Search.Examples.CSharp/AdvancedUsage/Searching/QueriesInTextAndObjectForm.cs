using GroupDocs.Search.Options;
using GroupDocs.Search.Results;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Searching
{
    class QueriesInTextAndObjectForm
    {
        public static void Run()
        {
            string indexFolder = @"./AdvancedUsage/Searching/QueriesInTextAndObjectForm";
            string documentsFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating index
            Index index = new Index(indexFolder);

            // Indexing
            index.Add(documentsFolder);

            // Creating subquery 1 - simple word query
            SearchQuery subquery1 = SearchQuery.CreateWordQuery("future");
            subquery1.SearchOptions = new SearchOptions(); // Setting search options only for subquery 1
            subquery1.SearchOptions.FuzzySearch.Enabled = true;
            subquery1.SearchOptions.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(3); // The maximum number of differences is 3

            // Creating subquery 2 - wildcard query
            SearchQuery subquery2 = SearchQuery.CreateWildcardQuery(1);

            // Creating subquery 3 - regular expression query 
            SearchQuery subquery3 = SearchQuery.CreateRegexQuery(@"(.)\1");

            // Combining subqueries into one query - phrase search query
            SearchQuery query = SearchQuery.CreatePhraseSearchQuery(subquery1, subquery2, subquery3);

            // Creating overall search options with increased capacity of occurrences
            SearchOptions options = new SearchOptions();
            options.MaxOccurrenceCountPerTerm = 1000000;
            options.MaxTotalOccurrenceCount = 10000000;

            // Searching
            SearchResult result = index.Search(query, options);

            // The result may contain the following word sequences:
            // futile * blessed
            // father * excellent
            // tyre * assyria
            // return * 229

            Utils.TraceResult(query.ToString(), result);
        }
    }
}
