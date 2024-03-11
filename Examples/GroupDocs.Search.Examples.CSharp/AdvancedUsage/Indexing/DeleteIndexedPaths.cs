using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Indexing
{
    class DeleteIndexedPaths
    {
        public static void Run()
        {
            string indexFolder = @"./AdvancedUsage/Indexing/DeleteIndexedPaths";
            string documentsFolder1 = Utils.DocumentsPath;
            string documentsFolder2 = Utils.DocumentsPath2;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folders
            index.Add(documentsFolder1);
            index.Add(documentsFolder2);

            // Getting indexed paths from the index
            string[] indexedPaths1 = index.GetIndexedPaths();

            // Writing indexed paths to the console
            Console.WriteLine("Indexed paths:");
            foreach (string path in indexedPaths1)
            {
                Console.WriteLine("\t" + path);
            }

            // Deleting index path from the index
            DeleteResult deleteResult = index.Delete(new string[] { documentsFolder1 }, new UpdateOptions());
            Console.WriteLine("\nDeleted paths: " + deleteResult.SuccessCount);

            // Getting indexed paths after deletion
            string[] indexedPaths2 = index.GetIndexedPaths();

            Console.WriteLine("\nIndexed paths:");
            foreach (string path in indexedPaths2)
            {
                Console.WriteLine("\t" + path);
            }
        }
    }
}
