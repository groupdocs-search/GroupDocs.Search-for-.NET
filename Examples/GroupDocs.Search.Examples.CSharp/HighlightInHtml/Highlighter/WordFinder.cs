using Aspose.Html.Dom;
using System;

namespace GroupDocs.Search.Examples.CSharp.HighlightInHtml.Highlighter
{
    internal abstract class WordFinder : IFinder
    {
        private readonly ISuperFinder superFinder;
        private readonly CharacterHolder characterHolder;
        private readonly bool isCaseSensitive;
        private readonly string originalWord;
        private readonly string upperCaseWord;
        private int characterIndex;

        private Text textNode;
        private int textNodeCharacterIndex;

        private bool previousIsSeparator = true;

        public WordFinder(
            ISuperFinder superFinder,
            string word)
        {
            if (word.Length == 0)
            {
                throw new ArgumentException("The word cannot be empty.");
            }

            this.superFinder = superFinder;
            characterHolder = superFinder.CharacterHolder;
            isCaseSensitive = superFinder.IsCaseSensitive;
            originalWord = word;
            upperCaseWord = word.ToUpperInvariant();
        }

        public ISuperFinder SuperFinder => superFinder;

        public string Word => originalWord;

        public Text TextNode => textNode;

        public int TextNodeCharacterIndex => textNodeCharacterIndex;

        public void HandleCharacter()
        {
            char character = characterHolder.Character;
            char upperCaseCharacter = characterHolder.UpperCaseCharacter;
            bool isSeparator = characterHolder.IsSeparator;

            if (characterIndex < originalWord.Length)
            {
                bool isMatch = isCaseSensitive ?
                    character == originalWord[characterIndex] :
                    upperCaseCharacter == upperCaseWord[characterIndex];
                if (isMatch)
                {
                    if (characterIndex == 0)
                    {
                        if (previousIsSeparator || characterHolder.NewNode)
                        {
                            characterIndex++;
                            textNode = characterHolder.TextNode;
                            textNodeCharacterIndex = characterHolder.TextNodeCharacterIndex;
                        }
                    }
                    else // characterIndex > 0
                    {
                        characterIndex++;
                    }
                }
                else
                {
                    characterIndex = 0;
                }
            }
            else
            {
                if (isSeparator || characterHolder.NewNode)
                {
                    HandleWordFound();
                }
                characterIndex = 0;
            }

            previousIsSeparator = isSeparator;
        }

        public void Flush()
        {
        }

        protected abstract void HandleWordFound();
    }
}
