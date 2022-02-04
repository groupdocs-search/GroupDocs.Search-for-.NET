using Aspose.Html.Dom;

namespace GroupDocs.Search.Examples.CSharp.HighlightInHtml.Highlighter
{
    internal class FoundWord
    {
        private const string HighlightedClassName = "highlighted-term";
        private const string CountedClassName = "counted-term";
        private const string CountedAndHighlighted = CountedClassName + " " + HighlightedClassName;

        private readonly Text textNode;
        private readonly int termStart;
        private readonly int termLength;
        private readonly bool isCounted;

        public FoundWord(
            Text textNode,
            int termStart,
            int termLength,
            bool isCounted)
        {
            this.textNode = textNode;
            this.termStart = termStart;
            this.termLength = termLength;
            this.isCounted = isCounted;
        }

        public void Highlight()
        {
            var node = textNode;
            int startIndex = termStart;
            int length = termLength;
            int textContentLength = node.TextContent.Length;
            if (startIndex >= textContentLength)
            {
                return;
            }
            int newLength = textContentLength - startIndex;
            if (length >= newLength)
            {
                length = newLength;
            }

            var termNode = node.SplitText(startIndex);
            var lastTextNode = termNode.SplitText(length);

            var span = termNode.OwnerDocument.CreateElement("span");
            span.ClassName = isCounted ?
                CountedAndHighlighted :
                HighlightedClassName;

            termNode.ParentNode.ReplaceChild(span, termNode);
            span.AppendChild(termNode);
        }
    }
}
