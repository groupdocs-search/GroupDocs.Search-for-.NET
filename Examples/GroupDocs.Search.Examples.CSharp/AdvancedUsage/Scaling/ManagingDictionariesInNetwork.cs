using GroupDocs.Search.Dictionaries;
using GroupDocs.Search.Scaling;
using GroupDocs.Search.Scaling.Configuring;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Scaling
{
    class ManagingDictionariesInNetwork
    {
        public static void Run()
        {
            string basePath = @"./AdvancedUsage/Scaling/ManagingDictionaries/";
            // If an error occurs about using a busy network port, you need to change the value of the base port
            int basePort = 49128;

            Utils.PrintHeaderFromPath(basePath);

            Configuration configuration = ConfiguringSearchNetwork.Configure(basePath, basePort);

            SearchNetworkNode[] nodes = SearchNetworkDeployment.Deploy(basePath, basePort, configuration);
            SearchNetworkNode masterNode = nodes[0];

            SearchNetworkNodeEvents.Subscibe(masterNode);

            AddSynonyms(masterNode, new string[] { "efficitur", "tristique", "venenatis" }, true);

            IndexingDocuments.AddDirectories(masterNode, Utils.DocumentsPath);

            TextSearchInNetwork.SearchAll(masterNode, "tristique", false);
            TextSearchInNetwork.SearchAll(masterNode, "tristique", true);

            foreach (SearchNetworkNode node in nodes)
            {
                node.Dispose();
            }
        }

        public static void AddSynonyms(SearchNetworkNode node, string[] group, bool clearBeforeAdding)
        {
            Console.WriteLine();
            Console.WriteLine("Adding synonyms");

            Indexer indexer = node.Indexer;

            int[] indices = node.GetShardIndices();
            SynonymDictionary dictionary = indexer.GetSynonymDictionary(indices[0]);

            if (clearBeforeAdding)
            {
                dictionary.Clear();
            }
            dictionary.AddRange(new string[][] { group });

            indexer.SetDictionary(dictionary);
        }
    }
}
