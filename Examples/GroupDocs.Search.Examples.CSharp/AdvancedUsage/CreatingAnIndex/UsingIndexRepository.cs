using GroupDocs.Search.Results;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.CreatingAnIndex
{
    class UsingIndexRepository
    {
        public static void Run()
        {
            string indexFolder1 = @"./AdvancedUsage/CreatingAnIndex/UsingIndexRepository/Index1";
            string indexFolder2 = @"./AdvancedUsage/CreatingAnIndex/UsingIndexRepository/Index2";
            string documentFolder1 = Utils.DocumentsPath;
            string documentFolder2 = Utils.DocumentsPath2;

            Utils.PrintHeaderFromPath(indexFolder1);

            // Creating an index repository instance
            IndexRepository indexRepository = new IndexRepository();

            // Subscribing to an event
            indexRepository.Events.OperationProgressChanged += (sender, args) =>
            {
                Console.WriteLine("Indexed document:\n\t" + args.LastDocumentPath);
            };

            // Creating or loading an index and adding to the index repository
            Index index1 = new Index(indexFolder1);
            indexRepository.AddToRepository(index1);

            // Creating or loading an index and adding to the index repository
            Index index2 = new Index(indexFolder2);
            indexRepository.AddToRepository(index2);

            // Adding documents to the index 1
            index1.Add(documentFolder1);

            // Adding documents to the index 2
            index2.Add(documentFolder2);

            // Changing, deleting, adding documents to document folders
            // ...

            // Updating all indexes in the repository
            indexRepository.Update();

            // Searching in the repository
            string query = "decisively";
            SearchResult result = indexRepository.Search(query);

            Utils.TraceResult(query, result);
        }
    }
}
