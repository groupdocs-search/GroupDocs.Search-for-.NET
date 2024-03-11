using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.ManagingDictionaries
{
    class HomophoneDictionary
    {
        public static void Run()
        {
            string indexFolder = @"./AdvancedUsage/ManagingDictionaries/HomophoneDictionary/Index";
            string documentsFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating an index from in specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Getting homophones for word 'braid'
            string[] homophones = index.Dictionaries.HomophoneDictionary.GetHomophones("braid");
            Console.WriteLine("Homophones for 'braid':");
            for (int i = 0; i < homophones.Length; i++)
            {
                Console.WriteLine(homophones[i]);
            }

            // Getting groups of homophones to which word 'braid' belongs to
            string[][] groups = index.Dictionaries.HomophoneDictionary.GetHomophoneGroups("braid");
            Console.WriteLine("Homophone groups for 'braid':");
            for (int i = 0; i < groups.Length; i++)
            {
                string[] group = groups[i];
                for (int j = 0; j < group.Length; j++)
                {
                    Console.Write(group[j] + " ");
                }
                Console.WriteLine();
            }

            if (index.Dictionaries.HomophoneDictionary.Count > 0)
            {
                // Removing all homophones from the dictionary
                index.Dictionaries.HomophoneDictionary.Clear();
            }

            // Adding homophones to the dictionary
            string[][] homophoneGroups = new string[][]
            {
                new string[] { "awe", "oar", "or", "ore" },
                new string[] { "aye", "eye", "i" },
                new string[] { "call", "caul" },
            };
            index.Dictionaries.HomophoneDictionary.AddRange(homophoneGroups);

            // Export homophones to a file
            string fileName = @"./AdvancedUsage/ManagingDictionaries/HomophoneDictionary/Homophones.dat";
            index.Dictionaries.HomophoneDictionary.ExportDictionary(fileName);

            // Import homophones from a file
            index.Dictionaries.HomophoneDictionary.ImportDictionary(fileName);

            // Search in the index
            string query = "caul";
            SearchOptions options = new SearchOptions();
            options.UseHomophoneSearch = true;
            SearchResult result = index.Search(query, options);

            Utils.TraceResult(query, result);
        }
    }
}
