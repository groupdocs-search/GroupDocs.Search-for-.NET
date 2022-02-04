using System.Collections.Generic;

namespace GroupDocs.Search.Examples.CSharp.HighlightInHtml.Highlighter
{
    internal class SuperFinder : ISuperFinder
    {
        private readonly CharacterHolder characterHolder;
        private readonly bool isCaseSensitive;
        private readonly List<IFinder> finders = new List<IFinder>();
        private readonly List<IFinder> toRemove = new List<IFinder>();

        private readonly LinkedList<FoundWord> foundWords = new LinkedList<FoundWord>();

        public SuperFinder(
            CharacterHolder characterHolder,
            bool isCaseSensitive,
            string[] terms,
            string[][] phrases)
        {
            this.characterHolder = characterHolder;
            this.isCaseSensitive = isCaseSensitive;

            if (terms != null)
            {
                foreach (var term in terms)
                {
                    var finder = new SeparateWordFinder(this, term);
                    finders.Add(finder);
                }
            }
            if (phrases != null)
            {
                foreach (var phrase in phrases)
                {
                    var finder = new PhraseFirstWordFinder(this, phrase);
                    finders.Add(finder);
                }
            }
        }

        public CharacterHolder CharacterHolder => characterHolder;

        public bool IsCaseSensitive => isCaseSensitive;

        public void HandleCharacter()
        {
            if (toRemove.Count > 0)
            {
                for (int i = 0; i < toRemove.Count; i++)
                {
                    finders.Remove(toRemove[i]);
                }
                toRemove.Clear();
            }

            for (int i = 0; i < finders.Count; i++)
            {
                var finder = finders[i];
                finder.HandleCharacter();
            }
        }

        public void Flush()
        {
            for (int i = 0; i < finders.Count; i++)
            {
                var finder = finders[i];
                finder.Flush();
            }
        }

        public void Add(IFinder finder)
        {
            finders.Add(finder);
        }

        public void Remove(IFinder finder)
        {
            toRemove.Add(finder);
        }

        public LinkedListNode<FoundWord> AddFoundWord(FoundWord foundWord)
        {
            var node = foundWords.AddFirst(foundWord);
            return node;
        }

        public void RemoveFoundWords(List<LinkedListNode<FoundWord>> words)
        {
            foreach (var node in words)
            {
                foundWords.Remove(node);
            }
        }

        public void HighlightFoundWords()
        {
            while (foundWords.Count > 0)
            {
                var foundWord = foundWords.First.Value;
                foundWords.RemoveFirst();
                foundWord.Highlight();
            }
        }
    }
}
