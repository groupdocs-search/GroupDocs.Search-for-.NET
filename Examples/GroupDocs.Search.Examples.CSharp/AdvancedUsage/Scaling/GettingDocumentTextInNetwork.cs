using GroupDocs.Search.Common;
using GroupDocs.Search.Options;
using GroupDocs.Search.Scaling;
using GroupDocs.Search.Scaling.Configuring;
using GroupDocs.Search.Scaling.Results;
using System;
using System.Collections.Generic;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Scaling
{
    class GettingDocumentTextInNetwork
    {
        public static void Run()
        {
            string basePath = @"./AdvancedUsage/Scaling/GettingDocumentText/";
            int basePort = 49100;

            Configuration configuration = ConfiguringSearchNetwork.Configure(basePath, basePort);

            SearchNetworkNode[] nodes = SearchNetworkDeployment.Deploy(basePath, basePort, configuration);
            SearchNetworkNode masterNode = nodes[0];

            SearchNetworkNodeEvents.Subscibe(masterNode);

            IndexingDocuments.AddDirectories(masterNode, Utils.DocumentsPath);

            GetDocumentText(masterNode, "English.txt");

            foreach (SearchNetworkNode node in nodes)
            {
                node.Dispose();
            }
        }

        public static void GetDocumentText(SearchNetworkNode node, string containsInPath)
        {
            Searcher searcher = node.Searcher;

            List<NetworkDocumentInfo> documents = new List<NetworkDocumentInfo>();
            int[] shardIndices = node.GetShardIndices();
            for (int i = 0; i < shardIndices.Length; i++)
            {
                int shardIndex = shardIndices[i];
                NetworkDocumentInfo[] infos = searcher.GetIndexedDocuments(shardIndex);
                documents.AddRange(infos);
                for (int j = 0; j < infos.Length; j++)
                {
                    NetworkDocumentInfo info = infos[j];
                    NetworkDocumentInfo[] items = searcher.GetIndexedDocumentItems(info);
                    documents.AddRange(items);
                }
            }

            for (int i = 0; i < documents.Count; i++)
            {
                NetworkDocumentInfo document = documents[i];
                if (document.DocumentInfo.ToString().Contains(containsInPath))
                {
                    Console.WriteLine();
                    Console.WriteLine(document.DocumentInfo.ToString());

                    StringOutputAdapter outputAdapter = new StringOutputAdapter(OutputFormat.PlainText);
                    searcher.GetDocumentText(document, outputAdapter);

                    Console.WriteLine(outputAdapter.GetResult());
                    break;
                }
            }
        }
    }
}
