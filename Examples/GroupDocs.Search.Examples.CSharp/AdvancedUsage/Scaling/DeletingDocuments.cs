using GroupDocs.Search.Options;
using GroupDocs.Search.Scaling;
using GroupDocs.Search.Scaling.Configuring;
using System;
using System.IO;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Scaling
{
    class DeletingDocuments
    {
        public static void Run()
        {
            string basePath = @"./AdvancedUsage/Scaling/DeletingDocuments/";
            int basePort = 49100;

            Utils.PrintHeaderFromPath(basePath);

            Configuration configuration = ConfiguringSearchNetwork.Configure(basePath, basePort);

            SearchNetworkNode[] nodes = SearchNetworkDeployment.Deploy(basePath, basePort, configuration);
            SearchNetworkNode masterNode = nodes[0];

            SearchNetworkNodeEvents.Subscibe(masterNode);

            IndexingDocuments.AddDirectories(masterNode, Utils.DocumentsPath);

            TextSearchInNetwork.SearchAll(masterNode, "nulla", false);

            DeleteDocuments(masterNode, "Lorem ipsum.pdf", "Lorem ipsum.docx");

            TextSearchInNetwork.SearchAll(masterNode, "nulla", false);

            foreach (SearchNetworkNode node in nodes)
            {
                node.Dispose();
            }
        }

        public static void DeleteDocuments(SearchNetworkNode node, params string[] filePaths)
        {
            Console.WriteLine();
            Console.WriteLine("Deleting documents");

            string[] fileNames = new string[filePaths.Length];
            for (int i = 0; i < filePaths.Length; i++)
            {
                string filePath = filePaths[i];
                string fileName = Path.GetFileName(filePath);
                fileNames[i] = fileName;
            }

            Indexer indexer = node.Indexer;

            DeleteOptions options = new DeleteOptions();
            indexer.Delete(fileNames, options);
        }
    }
}
