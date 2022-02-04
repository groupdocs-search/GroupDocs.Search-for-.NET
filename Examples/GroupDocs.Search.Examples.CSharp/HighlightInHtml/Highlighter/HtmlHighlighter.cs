using Aspose.Html;
using GroupDocs.Search.Dictionaries;

namespace GroupDocs.Search.Examples.CSharp.HighlightInHtml.Highlighter
{
    internal static class HtmlHighlighter
    {
        public static string Handle(
            string pageData,
            bool isCaseSensitive,
            Alphabet alphabet,
            string[] terms,
            string[][] phrases)
        {
            int characterCount = 1 << 16;
            var isSeparator = new bool[characterCount];
            for (int i = 0; i < isSeparator.Length; i++)
            {
                char character = (char)i;
                var type = alphabet.GetCharacterType(character);
                isSeparator[i] = type == CharacterType.Separator || type == CharacterType.Blended;
            }

            using (var document = new HTMLDocument(pageData, string.Empty))
            {
                var characterHolder = new CharacterHolder();
                var textSource = new TextSource(characterHolder, isSeparator, document);
                var superFinder = new SuperFinder(characterHolder, isCaseSensitive, terms, phrases);

                while (true)
                {
                    bool success = textSource.ReadCharacter();
                    if (!success)
                    {
                        break;
                    }

                    superFinder.HandleCharacter();
                }
                superFinder.Flush();

                superFinder.HighlightFoundWords();

                return document.DocumentElement.OuterHTML;
            }
        }
    }
}
