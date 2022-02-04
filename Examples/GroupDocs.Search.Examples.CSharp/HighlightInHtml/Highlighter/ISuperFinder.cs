using System.Collections.Generic;

namespace GroupDocs.Search.Examples.CSharp.HighlightInHtml.Highlighter
{
    internal interface ISuperFinder
    {
        CharacterHolder CharacterHolder { get; }

        bool IsCaseSensitive { get; }

        void Add(IFinder finder);

        void Remove(IFinder finder);

        LinkedListNode<FoundWord> AddFoundWord(FoundWord foundWord);

        void RemoveFoundWords(List<LinkedListNode<FoundWord>> foundWords);
    }
}
