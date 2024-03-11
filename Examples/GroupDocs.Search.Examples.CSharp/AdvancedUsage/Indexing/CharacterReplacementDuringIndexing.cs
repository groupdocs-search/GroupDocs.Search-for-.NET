using GroupDocs.Search.Dictionaries;
using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Indexing
{
    class CharacterReplacementDuringIndexing
    {
        public static void Run()
        {
            string indexFolder = @"./AdvancedUsage/Indexing/CharacterReplacementDuringIndexing";
            string documentFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            // Enabling character replacements in the index settings
            IndexSettings settings = new IndexSettings();
            settings.UseCharacterReplacements = true;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder, settings);

            // Configuring character replacements
            // Deleting all existing character replacements from the dictionary
            index.Dictionaries.CharacterReplacements.Clear();
            // Creating new character replacements
            CharacterReplacementPair[] characterReplacements = new CharacterReplacementPair[Char.MaxValue + 1];
            for (int i = 0; i < characterReplacements.Length; i++)
            {
                char character = (char)i;
                char replacement = Char.ToLower(character);
                characterReplacements[i] = new CharacterReplacementPair(character, replacement);
            }
            // Adding character replacements to the dictionary
            index.Dictionaries.CharacterReplacements.AddRange(characterReplacements);

            // Indexing documents from the specified folder
            index.Add(documentFolder);

            // Searching in the index
            // Case-sensitive search is no longer possible for this index, since all characters are lowercase
            // By default, case-insensitive search is performed
            string query = "Promotion";
            SearchOptions options = new SearchOptions();
            options.UseCaseSensitiveSearch = true;
            SearchResult result = index.Search(query, options);

            Utils.TraceResult(query, result);
        }
    }
}
