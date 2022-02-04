using Aspose.Html;
using Aspose.Html.Dom;
using System;
using System.Collections.Generic;

namespace GroupDocs.Search.Examples.CSharp.HighlightInHtml.Highlighter
{
    internal class TextSource
    {
        private readonly CharacterHolder characterHolder;
        private readonly bool[] isSeparator;
        private readonly HTMLDocument document;
        private readonly List<Text> textNodes = new List<Text>();
        private int nodeIndex;
        private int charIndex = -1;

        public TextSource(
            CharacterHolder characterHolder,
            bool[] isSeparator,
            HTMLDocument document)
        {
            this.characterHolder = characterHolder;
            this.isSeparator = isSeparator;
            this.document = document;

            Init();
        }

        public bool ReadCharacter()
        {
            if (nodeIndex >= textNodes.Count)
            {
                return false;
            }

            int oldNodeIndex = nodeIndex;
            charIndex++;
            var currentNode = textNodes[nodeIndex];
            var currentNodeText = currentNode.TextContent;
            if (charIndex >= currentNodeText.Length)
            {
                charIndex = 0;
                nodeIndex++;
                if (nodeIndex >= textNodes.Count)
                {
                    return false;
                }
                else
                {
                    currentNode = textNodes[nodeIndex];
                    currentNodeText = currentNode.TextContent;
                }
            }

            char character = currentNodeText[charIndex];
            characterHolder.TextNode = currentNode;
            characterHolder.NewNode = oldNodeIndex != nodeIndex;
            characterHolder.TextNodeCharacterIndex = charIndex;
            characterHolder.Character = character;
            characterHolder.UpperCaseCharacter = char.ToUpperInvariant(character);
            characterHolder.IsSeparator = isSeparator[character];
            return true;
        }

        private void Init()
        {
            foreach (var child in document.Children)
            {
                Find(child);
            }
        }

        private void Find(Node node)
        {
            if (node.NodeName.Equals("STYLE", StringComparison.InvariantCultureIgnoreCase) ||
                node.NodeName.Equals("TITLE", StringComparison.InvariantCultureIgnoreCase) ||
                node.NodeName.Equals("HEAD", StringComparison.InvariantCultureIgnoreCase) ||
                node.NodeName.Equals("SCRIPT", StringComparison.InvariantCultureIgnoreCase))
            {
                return;
            }

            if (node.NodeType == 3)
            {
                var text = node.TextContent;
                if (!string.IsNullOrEmpty(text))
                {
                    textNodes.Add((Text)node);
                }
            }
            else
            {
                foreach (var child in node.ChildNodes)
                {
                    Find(child);
                }
            }
        }
    }
}
