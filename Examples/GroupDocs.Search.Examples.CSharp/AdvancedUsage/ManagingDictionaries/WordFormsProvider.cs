using GroupDocs.Search.Dictionaries;
using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using System;
using System.Collections.Generic;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.ManagingDictionaries
{
    public class SimpleWordFormsProvider : IWordFormsProvider
    {
        public string[] GetWordForms(string word)
        {
            List<string> result = new List<string>();

            // We assume that the input word is in the plural, then we add the singular
            if (word.Length > 2 &&
                word.EndsWith("es", StringComparison.InvariantCultureIgnoreCase))
            {
                result.Add(word.Substring(0, word.Length - 2));
            }
            if (word.Length > 1 &&
            word.EndsWith("s", StringComparison.InvariantCultureIgnoreCase))
            {
                result.Add(word.Substring(0, word.Length - 1));
            }

            // Then we assume that the input word is in the singular, we add the plural
            if (word.Length > 1 &&
            word.EndsWith("y", StringComparison.InvariantCultureIgnoreCase))
            {
                result.Add(word.Substring(0, word.Length - 1) + "is");
            }
            result.Add(word + "s");
            result.Add(word + "es");
            // All rules are implemented in the EnglishWordFormsProvider class

            return result.ToArray();
        }
    }

    class WordFormsProvider
    {
        public static void Run()
        {
            string indexFolder = @".\AdvancedUsage\ManagingDictionaries\WordFormsProvider\Index";
            string documentsFolder = Utils.DocumentsPath;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Setting the custom word forms provider instance
            index.Dictionaries.WordFormsProvider = new SimpleWordFormsProvider();

            // Creating a search options instance
            SearchOptions options = new SearchOptions();
            options.UseWordFormsSearch = true; // Enabling search for word forms

            // Searching in the index
            string query = "mrs";
            SearchResult result = index.Search(query, options);

            // The following words can be found:
            // mrs
            // mr

            Utils.TraceResult(query, result);
        }
    }
}
