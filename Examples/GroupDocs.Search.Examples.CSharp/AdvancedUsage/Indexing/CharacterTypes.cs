using GroupDocs.Search.Dictionaries;
using GroupDocs.Search.Results;
using System.Collections.Generic;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Indexing
{
    class CharacterTypes
    {
        public static void RegularCharacters()
        {
            string indexFolder = @".\AdvancedUsage\Indexing\CharacterTypes\RegularCharacters";
            string documentFolder = Utils.DocumentsPath;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Configuring the alphabet
            // Setting the separator type for all characters in the alphabet
            index.Dictionaries.Alphabet.Clear();
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

            // Indexing documents from the specified folder
            index.Add(documentFolder);

            // Searching in the index
            string query = "travelling";
            SearchResult result = index.Search(query);

            Utils.TraceResult(query, result);
        }

        public static void BlendedCharacters()
        {
            string indexFolder = @".\AdvancedUsage\Indexing\CharacterTypes\BlendedCharacters";
            string documentFolder = Utils.DocumentsPath;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Setting hyphen character type to blended
            index.Dictionaries.Alphabet.SetRange(new char[] { '-' }, CharacterType.Blended);

            // Indexing documents from the specified folder
            index.Add(documentFolder);

            // Searching in the index
            string query1 = "Elliot-Murray-Kynynmound";
            SearchResult result1 = index.Search(query1);
            string query2 = "Elliot";
            SearchResult result2 = index.Search(query2);
            string query3 = "Murray";
            SearchResult result3 = index.Search(query3);
            string query4 = "Kynynmound";
            SearchResult result4 = index.Search(query4);

            Utils.TraceResult(query1, result1);
            Utils.TraceResult(query2, result2);
            Utils.TraceResult(query3, result3);
            Utils.TraceResult(query4, result4);
        }
    }
}
