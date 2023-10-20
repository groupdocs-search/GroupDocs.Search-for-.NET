using GroupDocs.Search.Common;
using GroupDocs.Search.Results;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Searching
{
    class PhraseSearch
    {
        public static void SimplePhraseSearch()
        {
            string indexFolder = @"./AdvancedUsage/Searching/PhraseSearch/SimplePhraseSearch";
            string documentsFolder = Utils.DocumentsPath;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Search for the phrase 'sollicitudin at ligula' in text form
            string query1 = "\"sollicitudin at ligula\"";
            SearchResult result1 = index.Search(query1);

            // Search for the phrase 'sollicitudin at ligula' in object form
            SearchQuery word1 = SearchQuery.CreateWordQuery("sollicitudin");
            SearchQuery word2 = SearchQuery.CreateWordQuery("at");
            SearchQuery word3 = SearchQuery.CreateWordQuery("ligula");
            SearchQuery query2 = SearchQuery.CreatePhraseSearchQuery(word1, word2, word3);
            SearchResult result2 = index.Search(query2);

            Utils.TraceResult(query1, result1);
            Utils.TraceResult(query2.ToString(), result2);
        }

        public static void PhraseSearchWithWildcards()
        {
            string indexFolder = @"./AdvancedUsage/Searching/PhraseSearch/PhraseSearchWithWildcards";
            string documentsFolder = Utils.DocumentsPath;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Search for the phrase in text form
            string query1 = "\"sollicitudin *0~~3 ligula\"";
            SearchResult result1 = index.Search(query1);

            // Search for the phrase in object form
            SearchQuery word1 = SearchQuery.CreateWordQuery("sollicitudin");
            SearchQuery wildcard2 = SearchQuery.CreateWildcardQuery(0, 3);
            SearchQuery word3 = SearchQuery.CreateWordQuery("ligula");
            SearchQuery query2 = SearchQuery.CreatePhraseSearchQuery(word1, wildcard2, word3);
            SearchResult result2 = index.Search(query2);

            // The search can find the following phrases:
            // "sollicitudin of ligula"
            // "sollicitudin ligula"

            Utils.TraceResult(query1, result1);
            Utils.TraceResult(query2.ToString(), result2);
        }

        public static void PhraseSearchWithWildcards2()
        {
            string indexFolder = @"./AdvancedUsage/Searching/PhraseSearch/PhraseSearchWithWildcards2";
            string documentsFolder = Utils.DocumentsPath;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Search for the phrase in text form
            string query1 = "\"sollicitudin  *0~~3  ?(0~4)la\"";
            SearchResult result1 = index.Search(query1);

            // Search for the phrase in object form
            SearchQuery word1 = SearchQuery.CreateWordQuery("sollicitudin");
            SearchQuery wildcard2 = SearchQuery.CreateWildcardQuery(0, 3);
            WordPattern pattern = new WordPattern();
            pattern.AppendWildcard(0, 4);
            pattern.AppendString("la");
            SearchQuery wordPattern3 = SearchQuery.CreateWordPatternQuery(pattern);
            SearchQuery query2 = SearchQuery.CreatePhraseSearchQuery(word1, wildcard2, wordPattern3);
            SearchResult result2 = index.Search(query2);

            // The search can find the following phrases:
            // "sollicitudin of ligula"
            // "sollicitudin ligula"
            // "sollicitudin, nulla"

            Utils.TraceResult(query1, result1);
            Utils.TraceResult(query2.ToString(), result2);
        }
    }
}
