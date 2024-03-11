using GroupDocs.Search.Common;
using GroupDocs.Search.Options;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Indexing
{
    class MergeIndexes
    {
        public static void Run()
        {
            string indexFolder1 = @"./AdvancedUsage/Indexing/MergeIndexes/Index1";
            string indexFolder2 = @"./AdvancedUsage/Indexing/MergeIndexes/Index2";
            string documentsFolder1 = Utils.DocumentsPath;
            string documentsFolder2 = Utils.DocumentsPath2;

            Utils.PrintHeaderFromPath(indexFolder1);

            Index index1 = new Index(indexFolder1); // Creating index1
            index1.Add(documentsFolder1); // Indexing documents

            Index index2 = new Index(indexFolder2); // Creating index2
            index2.Add(documentsFolder2); // Indexing documents

            MergeOptions options = new MergeOptions();
            options.Cancellation = new Cancellation(); // Creating cancellation object to be able to cancel the oparation
            options.Cancellation.CancelAfter(5000); // Setting a time limit for the operation of 5 seconds

            Console.WriteLine("\nBefore merge index1:");
            Utils.TraceIndexedDocuments(index1);
            Console.WriteLine("\nBefore merge index2:");
            Utils.TraceIndexedDocuments(index2);

            // Merging index2 into index1
            // Files of index2 will not be changed
            index1.Merge(index2, options);

            Console.WriteLine("\n\nAfter merge index1:");
            Utils.TraceIndexedDocuments(index1);
            Console.WriteLine("\nAfter merge index2:");
            Utils.TraceIndexedDocuments(index2);
        }
    }
}
