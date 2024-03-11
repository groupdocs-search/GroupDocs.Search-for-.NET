using GroupDocs.Search.Dictionaries;
using GroupDocs.Search.Results;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.ManagingDictionaries
{
    class AliasDictionary
    {
        public static void Run()
        {
            string indexFolder = @"./AdvancedUsage/ManagingDictionaries/AliasDictionary/Index";
            string documentsFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating or opening an index from the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            if (index.Dictionaries.AliasDictionary.Count > 0)
            {
                // Deleting all existing aliases
                index.Dictionaries.AliasDictionary.Clear();
            }

            // Adding aliases to the alias dictionary
            index.Dictionaries.AliasDictionary.Add("t", "(gravida OR promotion)");
            index.Dictionaries.AliasDictionary.Add("e", "(viverra OR farther)");
            AliasReplacementPair[] pairs = new AliasReplacementPair[]
            {
                new AliasReplacementPair("d", "daterange(2017-01-01 ~~ 2019-12-31)"),
                new AliasReplacementPair("n", "(400 ~~ 4000)"),
            };
            index.Dictionaries.AliasDictionary.AddRange(pairs);

            if (index.Dictionaries.AliasDictionary.Contains("e"))
            {
                // Getting an alias replacement
                string replacement = index.Dictionaries.AliasDictionary.GetText("e");
                Console.WriteLine("e - " + replacement);
            }

            // Export aliases to a file
            string fileName = @"./AdvancedUsage/ManagingDictionaries/AliasDictionary/Aliases.dat";
            index.Dictionaries.AliasDictionary.ExportDictionary(fileName);

            // Import aliases from a file
            index.Dictionaries.AliasDictionary.ImportDictionary(fileName);

            // Search in the index
            string query = "@t OR @e";
            SearchResult result = index.Search(query);

            Utils.TraceResult(query, result);
        }
    }
}
