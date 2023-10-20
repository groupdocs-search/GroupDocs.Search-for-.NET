using GroupDocs.Search.Results;
using System;

namespace GroupDocs.Search.Examples.CSharp.GettingStarted
{
    class HelloWorld
    {
        public static void Run()
        {
            string indexFolder = @"./GettingStarted/HelloWorld";
            string documentsFolder = Utils.DocumentsPath;

            // Creating index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Searching in index
            SearchResult result = index.Search("Lorem");

            Console.WriteLine("Documents found: " + result.DocumentCount);
        }
    }
}
