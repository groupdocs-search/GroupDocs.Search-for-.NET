using Aspose.Html.Dom;
using System;
using System.Collections.Generic;

namespace GroupDocs.Search.Examples.CSharp.HighlightInHtml.Highlighter
{
    internal class PhraseAnyWordFinder : IFinder
    {
        private readonly ISuperFinder superFinder;
        private readonly CharacterHolder characterHolder;
        private readonly string[] phrase;
        private readonly int wordIndex;
        private readonly List<LinkedListNode<FoundWord>> foundWords;

        private int characterIndex;

        private Text textNode;
        private int textNodeCharacterIndex;

        public PhraseAnyWordFinder(
            ISuperFinder superFinder,
            string[] phrase,
            int wordIndex,
            List<LinkedListNode<FoundWord>> foundWords)
        {
            var word = phrase[wordIndex];
            if (word != PhraseFirstWordFinder.AnyWordWildcard)
            {
                throw new ArgumentException("The current word of the phrase must be the wildcard.");
            }

            this.superFinder = superFinder;
            characterHolder = superFinder.CharacterHolder;
            this.phrase = phrase;
            this.wordIndex = wordIndex;
            this.foundWords = foundWords;
        }

        public void HandleCharacter()
        {
            bool isSeparator = characterHolder.IsSeparator;

            if (characterIndex == 0)
            {
                if (!isSeparator)
                {
                    textNode = characterHolder.TextNode;
                    textNodeCharacterIndex = characterHolder.TextNodeCharacterIndex;
                    characterIndex++;
                }
            }
            else
            {
                if (isSeparator || characterHolder.NewNode)
                {
                    HandleWordFound();
                }
                else
                {
                    characterIndex++;
                }
            }
        }

        public void Flush()
        {
            superFinder.RemoveFoundWords(foundWords);
        }

        private void HandleWordFound()
        {
            superFinder.Remove(this);

            var foundWord = new FoundWord(textNode, textNodeCharacterIndex, characterIndex, false);
            var node = superFinder.AddFoundWord(foundWord);
            foundWords.Add(node);

            int nextWordIndex = wordIndex + 1;
            if (nextWordIndex >= phrase.Length)
            {
                throw new InvalidOperationException("The wildcard cannot be at the end of a phrase.");
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
