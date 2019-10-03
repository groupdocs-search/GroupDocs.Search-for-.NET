using GroupDocs.Search.Dictionaries;
using GroupDocs.Search.Results;
using System.Collections.Generic;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.ManagingDictionaries
{
    class Alphabet
    {
        public static void Run()
        {
            string indexFolder = @".\AdvancedUsage\ManagingDictionaries\Alphabet\Index";
            string documentsFolder = Utils.DocumentsPath;

            // Creating or opening an index from the specified folder
            Index index = new Index(indexFolder);

            if (index.Dictionaries.Alphabet.Count > 0)
            {
                // Setting a type of all characters to Separator
                index.Dictionaries.Alphabet.Clear();
            }

            // Creating a list of letter characters
            List<char> list = new List<char>();
            for (char i = (char)0x0030; i <= 0x0039; i++)
            {
                list.Add(i); // Digits
            }
            for (char i = (char)0x0041; i <= 0x005A; i++)
            {
                list.Add(i); // Latin capital letters
            }
            list.Add((char)0x005F); // Low line
            for (char i = (char)0x0061; i <= 0x007A; i++)
            {
                list.Add(i); // Latin small letters
            }
            // Setting the type of characters in the alphabet
            char[] characters = list.ToArray();
            index.Dictionaries.Alphabet.SetRange(characters, CharacterType.Letter);

            if (index.Dictionaries.Alphabet.GetCharacterType('-') != CharacterType.Blended)
            {
                // Setting a type of hyphen character to Blended
                index.Dictionaries.Alphabet.SetRange(new char[] { '-' }, CharacterType.Blended);
            }

            // Export the alphabet to a file
            string fileName = @".\AdvancedUsage\ManagingDictionaries\Alphabet\Alphabet.dat";
            index.Dictionaries.Alphabet.ExportDictionary(fileName);

            // Import the alphabet from a file
            index.Dictionaries.Alphabet.ImportDictionary(fileName);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Search in the index
            string query = "Elliot-Murray-Kynynmound";
            SearchResult result = index.Search(query);

            Utils.TraceResult(query, result);
        }
    }
}
