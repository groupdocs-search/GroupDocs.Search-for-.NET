using GroupDocs.Search.Common;
using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Searching
{
    class ReverseImageSearch
    {
        public static void Run()
        {
            string indexFolder = @"./AdvancedUsage/Searching/ReverseImageSearch";
            string documentsFolder = Utils.ImagesPath;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating an index
            Index index = new Index(indexFolder);

            // Setting the image indexing options
            IndexingOptions indexingOptions = new IndexingOptions();
            indexingOptions.ImageIndexingOptions.EnabledForContainerItemImages = true;
            indexingOptions.ImageIndexingOptions.EnabledForEmbeddedImages = true;
            indexingOptions.ImageIndexingOptions.EnabledForSeparateImages = true;

            // Indexing documents in a document folder
            index.Add(documentsFolder, indexingOptions);

            // Setting the image search options
            ImageSearchOptions imageSearchOptions = new ImageSearchOptions();
            imageSearchOptions.HashDifferences = 10;
            imageSearchOptions.MaxResultCount = 10000;
            imageSearchOptions.SearchDocumentFilter = SearchDocumentFilter.CreateFileExtension(".zip", ".png", ".jpg");

            // Creating a reference image for search
            SearchImage searchImage = SearchImage.Create(Utils.ImagesPath + "ic_arrow_downward_black_18dp.png");

            // Searching in the index
            ImageSearchResult result = index.Search(searchImage, imageSearchOptions);

            Console.WriteLine("Images found: " + result.ImageCount);
            for (int i = 0; i < result.ImageCount; i++)
            {
                FoundImageFrame image = result.GetFoundImage(i);
                Console.WriteLine(image.DocumentInfo.ToString());
            }
        }
    }
}
