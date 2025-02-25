using GroupDocs.Search.Common;
using GroupDocs.Search.Results;
using JiebaNet.Segmenter;
using System.Collections.Generic;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Indexing
{
    class CustomTextSegmenter
    {
        public static void Run()
        {
            string indexFolder = @"./AdvancedUsage/Indexing/CustomTextSegmenter";
            string documentsFolder = Utils.DocumentsZHPath;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating an index in the specified folder
            Index index = new Index(indexFolder, true);

            // Using Jieba segmenter to break text into words
            JiebaWordSplitter jiebaWordSplitter = new JiebaWordSplitter();
            index.Events.FileIndexing += (s, e) =>
            {
                if (e.DocumentFullPath.EndsWith("Chinese.txt"))
                {
                    // We know that the text in this document is in Chinese
                    e.WordSplitter = jiebaWordSplitter;
                }
            };

            // Indexing Chinese documents
            index.Add(documentsFolder);

            // Searching in the index
            string query = "考虑"; // Consider
            SearchResult result = index.Search(query);
            Utils.TraceResult(query, result);
        }

        // Implementing custom word splitter
        public class JiebaWordSplitter : IWordSplitter
        {
            private readonly JiebaSegmenter segmenter;

            public JiebaWordSplitter()
            {
                segmenter = new JiebaSegmenter();
            }

            public IEnumerable<string> Split(string text)
            {
                IEnumerable<string> segments = segmenter.Cut(text, cutAll: false);
                return segments;
            }
        }
    }
}
