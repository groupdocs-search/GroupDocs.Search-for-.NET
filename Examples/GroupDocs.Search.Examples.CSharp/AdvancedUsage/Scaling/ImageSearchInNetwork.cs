using GroupDocs.Search.Common;
using GroupDocs.Search.Options;
using GroupDocs.Search.Scaling;
using GroupDocs.Search.Scaling.Configuring;
using GroupDocs.Search.Scaling.Results;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Scaling
{
    class ImageSearchInNetwork
    {
        public static void Run()
        {
            string basePath = @"./AdvancedUsage/Scaling/ImageSearchInNetwork/";
            int basePort = 49100;

            Configuration configuration = ConfiguringSearchNetwork.Configure(basePath, basePort);

            SearchNetworkNode[] nodes = SearchNetworkDeployment.Deploy(basePath, basePort, configuration);
            SearchNetworkNode masterNode = nodes[0];

            SearchNetworkNodeEvents.Subscibe(masterNode);

            IndexingDocuments.AddDirectories(masterNode, Utils.ImagesPath);

            SearchImage searchImage = SearchImage.Create(Utils.ImagesPath + "ic_arrow_back_black_18dp.png");
            ImageSearch(masterNode, searchImage, 8);

            foreach (SearchNetworkNode node in nodes)
            {
                node.Dispose();
            }
        }

        public static void ImageSearch(
            SearchNetworkNode node,
            SearchImage searchImage,
            int hashDifferences)
        {
            Console.WriteLine();
            Console.WriteLine("First image search");

            Searcher searcher = node.Searcher;
            ImageSearchOptions options = new ImageSearchOptions();
            options.HashDifferences = hashDifferences;
            int total = 0;

            NetworkImageSearchResult result = searcher.SearchFirst(searchImage, options);
            Console.WriteLine("Images found (shard " + result.ShardIndex + "): " + result.ImageCount);
            total += result.ImageCount;

            while (result.NetworkImageSearchToken != null)
            {
                Console.WriteLine();
                Console.WriteLine("Next image search");

                result = searcher.SearchNext(result.NetworkImageSearchToken);
                Console.WriteLine("Images found (shard " + result.ShardIndex + "): " + result.ImageCount);
                total += result.ImageCount;
            }

            Console.WriteLine();
            Console.WriteLine("Total images found (diffs = " + hashDifferences + "): " + total);
        }
    }
}
