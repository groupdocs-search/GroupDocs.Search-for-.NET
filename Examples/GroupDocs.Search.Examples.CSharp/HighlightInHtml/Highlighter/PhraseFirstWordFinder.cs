using System;
using System.Collections.Generic;

namespace GroupDocs.Search.Examples.CSharp.HighlightInHtml.Highlighter
{
    internal class PhraseFirstWordFinder : WordFinder, IFinder
    {
        public const string AnyWordWildcard = "*";

        private readonly string[] phrase;

        public PhraseFirstWordFinder(
            ISuperFinder superFinder,
            string[] phrase)
            : base(superFinder, phrase[0])
        {
            if (phrase.Length < 2)
            {
                throw new ArgumentException("The phrase must be at least 2 characters long.");
            }

            this.phrase = phrase;
        }

        protected override void HandleWordFound()
        {
            const int nextWordIndex = 1;
            var nextWord = phrase[nextWordIndex];

            var foundWord = new FoundWord(TextNode, TextNodeCharacterIndex, Word.Length, true);
            var node = SuperFinder.AddFoundWord(foundWord);
            var foundWords = new List<LinkedListNode<FoundWord>>();
            foundWords.Add(node);

            IFinder finder;
            if (nextWord == AnyWordWildcard)
            {
                finder = new PhraseAnyWordFinder(SuperFinder, phrase, nextWordIndex, foundWords);
            }
            else
            {
                finder = new PhraseNextWordFinder(SuperFinder, phrase, nextWordIndex, foundWords);
            }
            SuperFinder.Add(finder);
        }
    }
}
