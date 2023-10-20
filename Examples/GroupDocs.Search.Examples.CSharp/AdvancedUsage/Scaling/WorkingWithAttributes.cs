using GroupDocs.Search.Common;
using GroupDocs.Search.Options;
using GroupDocs.Search.Scaling;
using GroupDocs.Search.Scaling.Configuring;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Scaling
{
    class WorkingWithAttributes
    {
        public static void Run()
        {
            string basePath = @"./AdvancedUsage/Scaling/WorkingWithAttributes/";
            int basePort = 49100;

            Configuration configuration = ConfiguringSearchNetwork.Configure(basePath, basePort);

            SearchNetworkNode[] nodes = SearchNetworkDeployment.Deploy(basePath, basePort, configuration);
            SearchNetworkNode masterNode = nodes[0];

            SearchNetworkNodeEvents.Subscibe(masterNode);

            IndexingDocuments.AddDirectories(masterNode, Utils.DocumentsPath);

            AddAttribute(masterNode, "Lorem ipsum.pdf", "First");

            AddAttribute(masterNode, "English.docx", "Second");

            GettingDocumentsInNetwork.GetIndexedDocuments(masterNode);

            foreach (SearchNetworkNode node in nodes)
            {
                node.Dispose();
            }
        }

        public static void AddAttribute(SearchNetworkNode node, string documentKey, string attribute)
        {
            Console.WriteLine();
            Console.WriteLine("Adding attribute: " + attribute);

            Indexer indexer = node.Indexer;

            AttributeChangeBatch batch = new AttributeChangeBatch();
            batch.Add(documentKey, attribute);
            ChangeAttributesOptions options = new ChangeAttributesOptions();
            indexer.ChangeAttributes(batch, options);
        }
    }
}
