using GroupDocs.Search.Options;
using GroupDocs.Search.Scaling;
using GroupDocs.Search.Scaling.Configuring;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Scaling
{
    class SynchronizingShards
    {
        public static void Run()
        {
            string basePath = @"./AdvancedUsage/Scaling/SynchronizingShards/";
            int basePort = 49100;

            Utils.PrintHeaderFromPath(basePath);

            Configuration configuration = ConfiguringSearchNetwork.Configure(basePath, basePort);

            SearchNetworkNode[] nodes = SearchNetworkDeployment.Deploy(basePath, basePort, configuration);
            SearchNetworkNode masterNode = nodes[0];

            SearchNetworkNodeEvents.Subscibe(masterNode);

            IndexingDocuments.AddDirectories(masterNode, Utils.DocumentsPath);

            SynchronizeShards(masterNode);

            foreach (SearchNetworkNode node in nodes)
            {
                node.Dispose();
            }
        }

        public static void SynchronizeShards(SearchNetworkNode node)
        {
            Console.WriteLine();
            Console.WriteLine("Synchronizing shards");
            Indexer indexer = node.Indexer;
            SynchronizeOptions options = new SynchronizeOptions();
            indexer.Synchronize(options);
        }
    }
}
