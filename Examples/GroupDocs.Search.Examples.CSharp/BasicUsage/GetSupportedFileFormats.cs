using GroupDocs.Search.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupDocs.Search.Examples.CSharp.BasicUsage
{
    class GetSupportedFileFormats
    {
        public static void Run()
        {
            Utils.PrintHeaderFromPath(@"./BasicUsage/GetSupportedFileFormats");

            IEnumerable<FileType> supportedFileTypes = FileType
                .GetSupportedFileTypes()
                .OrderBy(ft => ft.Extension);

            foreach (FileType fileType in supportedFileTypes)
            {
                Console.WriteLine(fileType.Extension.PadRight(8) + " - " + fileType.Description);
            }
        }
    }
}
