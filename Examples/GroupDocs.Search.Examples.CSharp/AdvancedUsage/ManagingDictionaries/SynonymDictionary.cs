using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.ManagingDictionaries
{
    class SynonymDictionary
    {
        public static void Run()
        {
            string indexFolder = @"./AdvancedUsage/ManagingDictionaries/SynonymDictionary/Index";
            string documentsFolder = Utils.DocumentsPath2;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating an index from in specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Getting synonyms for word 'make'
            string[] synonyms = index.Dictionaries.SynonymDictionary.GetSynonyms("make");
            Console.WriteLine("Synonyms for 'make':");
            for (int i = 0; i < synonyms.Length; i++)
            {
                Console.WriteLine(synonyms[i]);
            }

            // Getting groups of synonyms to which word 'make' belongs to
            string[][] groups = index.Dictionaries.SynonymDictionary.GetSynonymGroups("make");
            Console.WriteLine("Synonym groups for 'make':");
            for (int i = 0; i < groups.Length; i++)
            {
                string[] group = groups[i];
                for (int j = 0; j < group.Length; j++)
                {
                    Console.Write(group[j] + " ");
                }
                Console.WriteLine();
            }

            if (index.Dictionaries.SynonymDictionary.Count > 0)
            {
                // Removing all synonyms from the dictionary
                index.Dictionaries.SynonymDictionary.Clear();
            }

            // Adding synonyms to the dictionary
            string[][] synonymGroups = new string[][]
            {
                new string[] { "achieve", "accomplish", "attain", "reach" },
                new string[] { "accept", "take", "have" },
                new string[] { "improve", "better" },
            };
            index.Dictionaries.SynonymDictionary.AddRange(synonymGroups);

            // Export synonyms to a file
            string fileName = @"./AdvancedUsage/ManagingDictionaries/SynonymDictionary/Synonyms.dat";
            index.Dictionaries.SynonymDictionary.ExportDictionary(fileName);

            // Import synonyms from a file
            index.Dictionaries.SynonymDictionary.ImportDictionary(fileName);

            // Search in the index
            string query = "better";
            SearchOptions options = new SearchOptions();
            options.UseSynonymSearch = true; // Enabling synonym search
            SearchResult result = index.Search(query, options);

            Utils.TraceResult(query, result);
        }
    }
}
