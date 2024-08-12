using GroupDocs.Search.Scaling.Configuring;
using GroupDocs.Search.Scaling;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Scaling
{
    class SearchNetworkNodeEvents
    {
        public static void Run()
        {
            string basePath = @"./AdvancedUsage/Scaling/SearchNetworkNodeEvents/";
            // If an error occurs about using a busy network port, you need to change the value of the base port
            int basePort = 49140;

            Utils.PrintHeaderFromPath(basePath);

            Configuration configuration = ConfiguringSearchNetwork.Configure(basePath, basePort);

            SearchNetworkNode[] nodes = SearchNetworkDeployment.Deploy(basePath, basePort, configuration);
            SearchNetworkNode masterNode = nodes[0];

            Subscibe(masterNode);

            foreach (SearchNetworkNode node in nodes)
            {
                node.Dispose();
            }
        }

        public static void Subscibe(SearchNetworkNode node)
        {
            node.Events.IndexingCompleted += (s, e) =>
            {
                Console.WriteLine("Indexing complete");
            };
            node.Events.DeletionCompleted += (s, e) =>
            {
                Console.WriteLine("Deleting complete");
            };
            node.Events.OptimizationCompleted += (s, e) =>
            {
                Console.WriteLine("Optimization complete");
            };
            node.Events.SynchronizationCompleted += (s, e) =>
            {
                Console.WriteLine("Synchronization complete");
            };
            node.Events.AttributeChangesCompleted += (s, e) =>
            {
                Console.WriteLine("Attribute changes complete");
            };
            node.Events.StatusChanged += (s, e) =>
            {
                Console.WriteLine("Status changed: " + e.OldStatus + " -> " + e.NewStatus);
            };
            node.Events.DataExtracted += (s, e) =>
            {
                Console.WriteLine("Data extracted (" + e.ExtractorIndex + "): " + e.DocumentKey);
            };
            node.Events.DocumentIndexed += (s, e) =>
            {
                Console.WriteLine("Document indexed (" + e.ShardIndex + "): " + e.DocumentKey);
            };
            node.Events.DocumentDeleted += (s, e) =>
            {
                Console.WriteLine("Document deleted (" + e.ShardIndex + "): " + e.DocumentKey);
            };
            node.Events.ErrorOccurred += (s, e) =>
            {
                Console.WriteLine("Error occurred (" + e.NodeIndex + ", " + e.ServiceIndex + "): " + e.Message);
            };
            node.Events.IndexingProgressChanged += (s, e) =>
            {
                Console.WriteLine("Indexing progress changed (" + e.NodeIndex + ", " + e.ServiceIndex + "): " + e.ProgressPercentage);
            };
            node.Events.OptimizationProgressChanged += (s, e) =>
            {
                Console.WriteLine("Optimization progress changed (" + e.NodeIndex + ", " + e.ServiceIndex + "): " + e.ProgressPercentage);
            };
        }
    }
}
