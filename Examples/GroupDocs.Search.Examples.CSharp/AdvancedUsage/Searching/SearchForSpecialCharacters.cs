using GroupDocs.Search.Dictionaries;
using GroupDocs.Search.Results;
using System.Text;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Searching
{
    class SearchForSpecialCharacters
    {
        public static void Run()
        {
            string indexFolder = @"./AdvancedUsage/Searching/SearchForSpecialCharacters";
            string documentsFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating an index in the specified folder
            Index index = new Index(indexFolder, true);

            // Setting character types
            index.Dictionaries.Alphabet.SetRange(new char[] { '&' }, CharacterType.Letter);
            index.Dictionaries.Alphabet.SetRange(new char[] { '-' }, CharacterType.Separator);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Defining a search query
            string word = "rock&roll-music";

            // Replacing separators with the space characters
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < word.Length; i++)
            {
                char character = word[i];
                CharacterType characterType = index.Dictionaries.Alphabet.GetCharacterType(character);
                if (characterType == CharacterType.Separator)
                {
                    result.Append(' ');
                }
                else
                {
                    result.Append(character);
                }
            }

            // Escaping special characters
            const string specialCharacters = "():\"&|!^~*?\\";
            for (int i = result.Length - 1; i >= 0; i--)
            {
                char c = result[i];
                if (specialCharacters.Contains(c.ToString()))
                {
                    result.Insert(i, '\\');
                }
            }

            string query = result.ToString();
            if (query.Contains(" "))
            {
                query = "\"" + query + "\"";
            }

            // Searching
            SearchResult searchResult = index.Search(query);

            Utils.TraceResult(query, searchResult);
        }
    }
}
