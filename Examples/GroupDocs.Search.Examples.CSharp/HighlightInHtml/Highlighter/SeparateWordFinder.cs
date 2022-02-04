namespace GroupDocs.Search.Examples.CSharp.HighlightInHtml.Highlighter
{
    internal class SeparateWordFinder : WordFinder, IFinder
    {
        public SeparateWordFinder(
            ISuperFinder superFinder,
            string word)
            : base(superFinder, word)
        {
        }

        protected override void HandleWordFound()
        {
            var word = new FoundWord(TextNode, TextNodeCharacterIndex, Word.Length, true);
            SuperFinder.AddFoundWord(word);
        }
    }
}
