using GroupDocs.Search.Common;
using GroupDocs.Search.Options;
using GroupDocs.Search.Scaling;
using GroupDocs.Search.Scaling.Configuring;
using System;
using System.Collections.Generic;
using System.IO;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Scaling
{
    class IndexingDocuments
    {
        public static void Run()
        {
            string basePath = @"./AdvancedUsage/Scaling/IndexingDocuments/";
            int basePort = 49100;

            Utils.PrintHeaderFromPath(basePath);

            Configuration configuration = ConfiguringSearchNetwork.Configure(basePath, basePort);

            SearchNetworkNode[] nodes = SearchNetworkDeployment.Deploy(basePath, basePort, configuration);
            SearchNetworkNode masterNode = nodes[0];

            SearchNetworkNodeEvents.Subscibe(masterNode);

            AddDirectories(masterNode, Utils.DocumentsPath);

            foreach (SearchNetworkNode node in nodes)
            {
                node.Dispose();
            }
        }

        public static void AddDirectories(SearchNetworkNode node, params string[] directoryPaths)
        {
            List<string> files = new List<string>();
            for (int i = 0; i < directoryPaths.Length; i++)
            {
                string[] array = Directory.GetFiles(directoryPaths[i], "*.*", SearchOption.AllDirectories);
                files.AddRange(array);
            }
            AddFiles(node, files.ToArray());
        }

        public static void AddFiles(SearchNetworkNode node, params string[] filePaths)
        {
            Console.WriteLine();
            Console.WriteLine("Adding documents to the search network");

            Stream[] streams = new Stream[filePaths.Length];
            Document[] documents = new Document[filePaths.Length];
            string[] passwords = new string[filePaths.Length];
            for (int i = 0; i < filePaths.Length; i++)
            {
                string filePath = filePaths[i];
                DateTime modificationDate = File.GetLastWriteTime(filePath);
                string fileName = Path.GetFileName(filePath);
                string extension = Path.GetExtension(filePath);
                Stream stream = File.OpenRead(filePath);
                streams[i] = stream;
                Document document = Document.CreateFromStream(
                    fileName,
                    modificationDate,
                    extension,
                    stream);
                documents[i] = document;
            }

            Indexer indexer = node.Indexer;
            IndexingOptions options = new IndexingOptions();
            options.UseRawTextExtraction = false;
            options.ImageIndexingOptions.EnabledForSeparateImages = true;
            options.ImageIndexingOptions.EnabledForEmbeddedImages = true;
            options.ImageIndexingOptions.EnabledForContainerItemImages = true;
            options.OcrIndexingOptions.EnabledForSeparateImages = true;
            options.OcrIndexingOptions.EnabledForEmbeddedImages = true;
            options.OcrIndexingOptions.EnabledForContainerItemImages = true;
            indexer.Add(documents, passwords, options);

            for (int i = 0; i < streams.Length; i++)
            {
                streams[i].Close();
            }
        }
    }
}
