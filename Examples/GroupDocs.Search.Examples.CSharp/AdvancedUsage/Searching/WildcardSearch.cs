using GroupDocs.Search.Common;
using GroupDocs.Search.Results;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Searching
{
    class WildcardSearch
    {
        public static void QueryInTextForm()
        {
            string indexFolder = @"./AdvancedUsage/Searching/WildcardSearch/QueryInTextForm";
            string documentsFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Search in the index
            string query1 = "m???is";
            SearchResult result1 = index.Search(query1); // Search for 'mauris', 'mollis', 'mattis', 'magnis', etc.
            string query2 = "pri?(1~7)";
            SearchResult result2 = index.Search(query2); // Search for 'private', 'principles', 'principle', etc.

            Utils.TraceResult(query1, result1);
            Utils.TraceResult(query2, result2);
        }

        public static void QueryInObjectForm()
        {
            string indexFolder = @"./AdvancedUsage/Searching/WildcardSearch/QueryInObjectForm";
            string documentsFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Search with pattern "m???is"
            // Search for 'mauris', 'mollis', 'mattis', 'magnis', etc.
            WordPattern pattern1 = new WordPattern();
            pattern1.AppendString("m");
            pattern1.AppendOneCharacterWildcard();
            pattern1.AppendOneCharacterWildcard();
            pattern1.AppendOneCharacterWildcard();
            pattern1.AppendString("is");
            SearchQuery query1 = SearchQuery.CreateWordPatternQuery(pattern1);
            SearchResult result1 = index.Search(query1);

            // Search with pattern "pri?(1~7)"
            // Search for 'private', 'principles', 'principle', etc.
            WordPattern pattern2 = new WordPattern();
            pattern2.AppendString("pri");
            pattern2.AppendWildcard(1, 7);
            SearchQuery query2 = SearchQuery.CreateWordPatternQuery(pattern2);
            SearchResult result2 = index.Search(query2);

            Utils.TraceResult(query1.ToString(), result1);
            Utils.TraceResult(query2.ToString(), result2);
        }
    }
}
