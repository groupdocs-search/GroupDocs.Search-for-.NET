using GroupDocs.Search.Common;
using GroupDocs.Search.Highlighters;
using GroupDocs.Search.Options;
using GroupDocs.Search.Scaling;
using GroupDocs.Search.Scaling.Configuring;
using GroupDocs.Search.Scaling.Results;
using System;
using System.Collections.Generic;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Scaling
{
    class HighlightingResultsInNetwork
    {
        public static void Run()
        {
            string basePath = @"./AdvancedUsage/Scaling/HighlightingResultsInNetwork/";
            // If an error occurs about using a busy network port, you need to change the value of the base port
            int basePort = 49116;

            Utils.PrintHeaderFromPath(basePath);

            Configuration configuration = ConfiguringSearchNetwork.Configure(basePath, basePort);

            SearchNetworkNode[] nodes = SearchNetworkDeployment.Deploy(basePath, basePort, configuration);
            SearchNetworkNode masterNode = nodes[0];

            SearchNetworkNodeEvents.Subscibe(masterNode);

            IndexingDocuments.AddDirectories(masterNode, Utils.DocumentsPath);

            List<NetworkFoundDocument> documents = TextSearchInNetwork.SearchAll(masterNode, "resources", false);

            HighlightInDocument(masterNode, documents[0], 3);

            foreach (SearchNetworkNode node in nodes)
            {
                node.Dispose();
            }
        }

        public static void HighlightInDocument(
            SearchNetworkNode node,
            NetworkFoundDocument document,
            int maxFragments)
        {
            Searcher searcher = node.Searcher;

            FragmentHighlighter highlighter = new FragmentHighlighter(OutputFormat.PlainText);

            HighlightOptions options = new HighlightOptions();
            options.TermsAfter = 5;
            options.TermsBefore = 5;
            options.TermsTotal = 15;
            searcher.Highlight(document, highlighter, options);

            FragmentContainer[] result = highlighter.GetResult();
            Console.WriteLine();
            for (int i = 0; i < result.Length; i++)
            {
                FragmentContainer container = result[i];
                if (container.Count == 0) continue;

                string[] fragments = container.GetFragments();
                Console.WriteLine(container.FieldName);
                int count = Math.Min(fragments.Length, maxFragments);
                for (int j = 0; j < count; j++)
                {
                    Console.WriteLine("\t" + fragments[j]);
                }
            }
        }
    }
}
