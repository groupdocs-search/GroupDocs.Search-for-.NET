using GroupDocs.Search.Options;
using GroupDocs.Search.Scaling;
using GroupDocs.Search.Scaling.Configuring;
using GroupDocs.Search.Scaling.Results;
using System;
using System.Collections.Generic;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Scaling
{
    class TextSearchInNetwork
    {
        public static void Run()
        {
            string basePath = @"./AdvancedUsage/Scaling/TextSearchInNetwork/";
            int basePort = 49100;

            Configuration configuration = ConfiguringSearchNetwork.Configure(basePath, basePort);

            SearchNetworkNode[] nodes = SearchNetworkDeployment.Deploy(basePath, basePort, configuration);
            SearchNetworkNode masterNode = nodes[0];

            SearchNetworkNodeEvents.Subscibe(masterNode);

            IndexingDocuments.AddDirectories(masterNode, Utils.DocumentsPath);

            SearchAll(masterNode, "tempor", false);

            foreach (SearchNetworkNode node in nodes)
            {
                node.Dispose();
            }
        }

        public static List<NetworkFoundDocument> SearchAll(
            SearchNetworkNode node,
            string word,
            bool useSynonymSearch)
        {
            Searcher searcher = node.Searcher;

            SearchQuery query = SearchQuery.CreateWordQuery(word);
            Console.WriteLine();
            Console.WriteLine("First time search for: " + query);
            SearchOptions options = new SearchOptions();
            options.IsChunkSearch = true;
            options.UseSynonymSearch = useSynonymSearch;
            int totalOccurrences = 0;
            List<NetworkFoundDocument> documents = new List<NetworkFoundDocument>();

            NetworkSearchResult result = searcher.SearchFirst(query, options);

            AddDocsFromResult(documents, result);
            totalOccurrences += result.OccurrenceCount;
            TraceResult(result);

            while (result.NextChunkSearchToken != null)
            {
                Console.WriteLine();
                Console.WriteLine("Next time search for: " + query);

                result = searcher.SearchNext(result.NextChunkSearchToken);

                AddDocsFromResult(documents, result);
                totalOccurrences += result.OccurrenceCount;
                TraceResult(result);
            }

            Console.WriteLine();
            Console.WriteLine("Total occurrences: " + totalOccurrences);

            return documents;
        }

        private static void AddDocsFromResult(List<NetworkFoundDocument> documents, NetworkSearchResult result)
        {
            for (int i = 0; i < result.DocumentCount; i++)
            {
                documents.Add(result.GetFoundDocument(i));
            }
        }

        private static void TraceResult(NetworkSearchResult result)
        {
            Console.WriteLine("Search in node " + result.NodeIndex + " gave occurrences: " + result.OccurrenceCount);
        }
    }
}
