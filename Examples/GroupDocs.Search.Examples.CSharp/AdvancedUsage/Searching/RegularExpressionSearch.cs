using GroupDocs.Search.Results;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Searching
{
    class RegularExpressionSearch
    {
        public static void Run()
        {
            string indexFolder = @"./AdvancedUsage/Searching/RegularExpressionSearch";
            string documentsFolder = Utils.DocumentsPath;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Search for the phrase in text form
            string query1 = "^^(.)\\1{1,}"; // The first caret character at the beginning indicates that this is a regular expression search query
            SearchResult result1 = index.Search(query1); // Search for two or more identical characters at the beginning of a word

            // Search for the phrase in object form
            SearchQuery query2 = SearchQuery.CreateRegexQuery("^(.)\\1{1,}"); // Search for two or more identical characters at the beginning of a word
            SearchResult result2 = index.Search(query2);

            Utils.TraceResult(query1, result1);
            Utils.TraceResult(query2.ToString(), result2);
        }
    }
}
