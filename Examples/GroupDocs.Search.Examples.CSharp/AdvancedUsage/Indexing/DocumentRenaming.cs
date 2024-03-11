using GroupDocs.Search.Common;
using System;
using System.IO;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Indexing
{
    class DocumentRenaming
    {
        public static void Run()
        {
            string indexFolder = @"./AdvancedUsage/Indexing/DocumentRenaming/Index";
            string documentFolder = @"./AdvancedUsage/Indexing/DocumentRenaming/Documents/";

            Utils.PrintHeaderFromPath(indexFolder);

            // Prepare data
            Utils.CleanDirectory(documentFolder);
            Utils.CopyFiles(Utils.DocumentsPath, documentFolder);


            // Creating an index
            Index index = new Index(indexFolder);

            // Indexing documents in a document folder
            index.Add(documentFolder);

            Console.WriteLine("\nBefore renaming:");
            Utils.TraceIndexedDocuments(index);

            // Renaming a document
            string oldDocumentPath = documentFolder + "Lorem ipsum.txt";
            string newDocumentPath = documentFolder + "Lorem ipsum renamed.txt";
            File.Move(oldDocumentPath, newDocumentPath);

            // Notifying the index about renaming
            Notification notification = Notification.CreateRenameNotification(oldDocumentPath, newDocumentPath);
            bool result = index.Notify(notification);
            Console.WriteLine("\nSuccessful rename: " + result);

            // Updating the index
            // The renamed document will not be reindexed
            index.Update();

            Console.WriteLine("\nAfter renaming:");
            Utils.TraceIndexedDocuments(index);
        }
    }
}
