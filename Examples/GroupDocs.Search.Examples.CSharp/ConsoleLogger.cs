using GroupDocs.Search.Common;
using System;

namespace GroupDocs.Search.Examples.CSharp
{
    class ConsoleLogger : ILogger
    {
        public void Error(string message)
        {
            Console.WriteLine("Error: " + message);
        }

        public void Trace(string message)
        {
            Console.WriteLine("Trace: " + message);
        }
    }
}
