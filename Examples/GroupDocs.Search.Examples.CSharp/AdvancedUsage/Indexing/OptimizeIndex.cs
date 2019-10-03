using GroupDocs.Search.Common;
using GroupDocs.Search.Options;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Indexing
{
    class OptimizeIndex
    {
        public static void Run()
        {
            string indexFolder = @".\AdvancedUsage\Indexing\OptimizeIndex";
            string documentsFolder1 = Utils.DocumentsPath;
            string documentsFolder2 = Utils.DocumentsPath2;
            string documentsFolder3 = Utils.DocumentsPath3;

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            index.Add(documentsFolder1); // Indexing documents from the specified folder
            index.Add(documentsFolder2); // Each call to Add creates at least one new segment in the index
            index.Add(documentsFolder3);

            MergeOptions options = new MergeOptions();
            options.Cancellation = new Cancellation(); // Creating cancellation object to be able to cancel the operation
            options.Cancellation.CancelAfter(30000); // Setting maximum duration of the operation to 30 seconds

            // There are 3 segments in the index now

            // Merging segments of the index
            index.Optimize(options);

            // And now in the index there is only 1 segment
        }
    }
}
