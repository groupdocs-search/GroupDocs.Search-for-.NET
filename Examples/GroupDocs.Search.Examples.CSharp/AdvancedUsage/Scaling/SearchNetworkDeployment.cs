using Aspose.Html.Dom;
using GroupDocs.Search.Scaling;
using GroupDocs.Search.Scaling.Configuring;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Scaling
{
    class SearchNetworkDeployment
    {
        public static void Run()
        {
            string basePath = @"./AdvancedUsage/Scaling/SearchNetworkDeployment/";
            // If an error occurs about using a busy network port, you need to change the value of the base port
            int basePort = 49136;

            Utils.PrintHeaderFromPath(basePath);

            Configuration configuration = ConfiguringSearchNetwork.Configure(basePath, basePort);

            SearchNetworkNode[] nodes = Deploy(basePath, basePort, configuration);

            foreach (SearchNetworkNode node in nodes)
            {
                node.Dispose();
            }
        }

        /// <summary>
        /// One or more nodes can be created on one server.
        /// Only one node accepts the configuration,
        /// which is automatically propagated to all nodes when the network is started.
        /// </summary>
        public static SearchNetworkNode[] Deploy(string basePath, int basePort, Configuration configuration)
        {
            int sendTimeout = 3000;
            int receiveTimeout = 3000;

            // Each of the following 3 nodes can run on a separate server or in conjunction with others
            SearchNetworkNode node1 = new SearchNetworkNode(
                1,
                basePath + "Node1",
                new TcpSettings(basePort + 1, sendTimeout, receiveTimeout));
            node1.Start();
            SearchNetworkNode node2 = new SearchNetworkNode(
                2,
                basePath + "Node2",
                new TcpSettings(basePort + 2, sendTimeout, receiveTimeout));
            node2.Start();
            SearchNetworkNode node3 = new SearchNetworkNode(
                3,
                basePath + "Node3",
                new TcpSettings(basePort + 3, sendTimeout, receiveTimeout));
            node3.Start();

            SearchNetworkNode node0 = new SearchNetworkNode(
                0,
                basePath + "Node0",
                new TcpSettings(basePort, sendTimeout, receiveTimeout),
                new ConsoleLogger(),
                configuration);

            node0.Events.ConfigurationCompleted += (s, e) =>
            {
                Console.WriteLine("Configuration complete");
            };

            Console.WriteLine();
            Console.WriteLine("Configuring the search network");
            node0.ConfigureAllNodes();

            Console.WriteLine("Launching the search network");
            node0.Start();

            SearchNetworkNode[] nodes = new SearchNetworkNode[]
            {
                node0, node1, node2, node3,
            };
            return nodes;
        }
    }
}
