using GroupDocs.Search.Scaling;
using GroupDocs.Search.Scaling.Configuring;
using GroupDocs.Search.Scaling.Results;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Scaling
{
    class GettingDocumentsInNetwork
    {
        public static void Run()
        {
            string basePath = @"./AdvancedUsage/Scaling/GettingDocumentsInNetwork/";
            // If an error occurs about using a busy network port, you need to change the value of the base port
            int basePort = 49108;

            Utils.PrintHeaderFromPath(basePath);

            Configuration configuration = ConfiguringSearchNetwork.Configure(basePath, basePort);

            SearchNetworkNode[] nodes = SearchNetworkDeployment.Deploy(basePath, basePort, configuration);
            SearchNetworkNode masterNode = nodes[0];

            SearchNetworkNodeEvents.Subscibe(masterNode);

            IndexingDocuments.AddDirectories(masterNode, Utils.DocumentsPath);

            GetIndexedDocuments(masterNode);

            foreach (SearchNetworkNode node in nodes)
            {
                node.Dispose();
            }
        }

        public static void GetIndexedDocuments(SearchNetworkNode node)
        {
            Searcher searcher = node.Searcher;
            Indexer indexer = node.Indexer;

            int[] shardIndices = node.GetShardIndices();
            Console.WriteLine();
            for (int i = 0; i < shardIndices.Length; i++)
            {
                int shardIndex = shardIndices[i];
                NetworkDocumentInfo[] infos = searcher.GetIndexedDocuments(shardIndex);
                for (int j = 0; j < infos.Length; j++)
                {
                    NetworkDocumentInfo info = infos[j];
                    int nodeIndex = node.GetNodeIndex(info.ShardIndex);
                    Console.WriteLine(nodeIndex + ": " + info.ShardIndex + ": " + info.DocumentInfo.FilePath);
                    string[] attributes = indexer.GetAttributes(info.DocumentInfo.FilePath);
                    for (int k = 0; k < attributes.Length; k++)
                    {
                        Console.WriteLine("\t\t" + attributes[k]);
                    }

                    NetworkDocumentInfo[] items = searcher.GetIndexedDocumentItems(info);
                    for (int k = 0; k < items.Length; k++)
                    {
                        NetworkDocumentInfo item = items[k];
                        Console.WriteLine("\t" + nodeIndex + ": " + item.ShardIndex + ": " + item.DocumentInfo.ToString());
                    }
                }
            }
        }
    }
}
