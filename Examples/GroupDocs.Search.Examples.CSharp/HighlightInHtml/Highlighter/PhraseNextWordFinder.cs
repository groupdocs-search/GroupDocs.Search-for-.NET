using Aspose.Html.Dom;
using System;
using System.Collections.Generic;

namespace GroupDocs.Search.Examples.CSharp.HighlightInHtml.Highlighter
{
    internal class PhraseNextWordFinder : IFinder
    {
        private readonly string word;
        private readonly ISuperFinder superFinder;
        private readonly CharacterHolder characterHolder;
        private readonly string[] phrase;
        private readonly int wordIndex;
        private readonly List<LinkedListNode<FoundWord>> foundWords;

        private readonly bool isCaseSensitive;
        private readonly string originalWord;
        private readonly string upperCaseWord;
        private int characterIndex;

        private bool passNonSeparator;
        private Text textNode;
        private int textNodeCharacterIndex;

        private bool previousIsSeparator = true;

        public PhraseNextWordFinder(
            ISuperFinder superFinder,
            string[] phrase,
            int wordIndex,
            List<LinkedListNode<FoundWord>> foundWords)
        {
            word = phrase[wordIndex];
            if (word == PhraseFirstWordFinder.AnyWordWildcard)
            {
                throw new ArgumentException("The current word of the phrase cannot be the wildcard.");
            }

            this.superFinder = superFinder;
            characterHolder = superFinder.CharacterHolder;
            this.phrase = phrase;
            this.wordIndex = wordIndex;
            this.foundWords = foundWords;

            isCaseSensitive = superFinder.IsCaseSensitive;
            originalWord = word;
            upperCaseWord = word.ToUpperInvariant();
        }

        public void HandleCharacter()
        {
            char character = characterHolder.Character;
            char upperCaseCharacter = characterHolder.UpperCaseCharacter;
            bool isSeparator = characterHolder.IsSeparator;

            passNonSeparator |= !isSeparator;

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
                    if (passNonSeparator)
                    {
                        HandleWordNotFound();
                    }
                    else
                    {
                        characterIndex = 0;
                    }
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
            superFinder.RemoveFoundWords(foundWords);
        }

        private void HandleWordNotFound()
        {
            superFinder.Remove(this);

            superFinder.RemoveFoundWords(foundWords);
        }

        private void HandleWordFound()
        {
            superFinder.Remove(this);

            var foundWord = new FoundWord(textNode, textNodeCharacterIndex, word.Length, false);
            var node = superFinder.AddFoundWord(foundWord);
            foundWords.Add(node);

            int nextWordIndex = wordIndex + 1;
            if (nextWordIndex >= phrase.Length)
            {
                // Do nothing
            }
            else
            {
                var nextWord = phrase[nextWordIndex];
                IFinder finder;
                if (nextWord == PhraseFirstWordFinder.AnyWordWildcard)
                {
                    finder = new PhraseAnyWordFinder(superFinder, phrase, nextWordIndex, foundWords);
                }
                else
                {
                    finder = new PhraseNextWordFinder(superFinder, phrase, nextWordIndex, foundWords);
                }
                superFinder.Add(finder);
            }
        }
    }
}
