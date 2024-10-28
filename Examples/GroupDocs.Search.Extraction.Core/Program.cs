using System;

namespace GroupDocs.Search.Extraction
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The child process has started.");
            using (var host = new GroupDocs.Search.ExtractionHost(args))
            {
                host.Run();
            }
            Console.WriteLine("The child process is terminating.");
        }
    }
}
