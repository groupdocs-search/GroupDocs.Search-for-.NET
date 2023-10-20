using GroupDocs.Search.Dictionaries;
using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.ManagingDictionaries
{
    class CharacterReplacements
    {
        public static void Run()
        {
            string indexFolder = @"./AdvancedUsage/ManagingDictionaries/CharacterReplacements/Index";
            string documentsFolder = Utils.DocumentsPath;

            // Enabling character replacements in the index settings
            IndexSettings settings = new IndexSettings();
            settings.UseCharacterReplacements = true;

            // Creating an index from in specified folder
            Index index = new Index(indexFolder, settings);

            if (index.Dictionaries.CharacterReplacements.Count > 0)
            {
                // Deleting all character replacements from the dictionary
                index.Dictionaries.CharacterReplacements.Clear();
            }

            // Adding character replacement
            index.Dictionaries.CharacterReplacements.AddRange(new CharacterReplacementPair[] { new CharacterReplacementPair('-', '~') });

            if (index.Dictionaries.CharacterReplacements.Contains('-'))
            {
                char replacement = index.Dictionaries.CharacterReplacements.GetReplacement('-');
                Console.WriteLine("The replacement for hyphen is " + replacement);

                // Deleting the hyphen character replacement from the dictionary
                index.Dictionaries.CharacterReplacements.RemoveRange(new char[] { '-' });
            }

            // Creating new character replacements
            CharacterReplacementPair[] characterReplacements = new CharacterReplacementPair[Char.MaxValue + 1];
            for (int i = 0; i < characterReplacements.Length; i++)
            {
                char character = (char)i;
                char replacement = char.ToLower(character);
                characterReplacements[i] = new CharacterReplacementPair(character, replacement);
            }
            // Adding character replacements to the dictionary
            index.Dictionaries.CharacterReplacements.AddRange(characterReplacements);

            // Export character replacements to a file
            string fileName = @"./AdvancedUsage/ManagingDictionaries/CharacterReplacements/CharacterReplacements.dat";
            index.Dictionaries.CharacterReplacements.ExportDictionary(fileName);

            // Import character replacements from a file
            index.Dictionaries.CharacterReplacements.ImportDictionary(fileName);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Search in the index
            string query = "Elliot";
            SearchOptions options = new SearchOptions();
            options.UseCaseSensitiveSearch = true;
            SearchResult result = index.Search(query, options);

            Utils.TraceResult(query, result);
        }
    }
}
