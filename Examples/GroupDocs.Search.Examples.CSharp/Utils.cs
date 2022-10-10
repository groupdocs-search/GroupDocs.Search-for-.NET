using GroupDocs.Search.Common;
using GroupDocs.Search.Highlighters;
using GroupDocs.Search.Results;
using System;
using System.IO;

namespace GroupDocs.Search.Examples.CSharp
{
    class Utils
    {
        public const string LicensePath = @"C:/Licenses/GroupDocs.Search.lic";

#if NETCOREAPP
        public const string BasePath = @"../../../../";
#else
        public const string BasePath = @"../../../";
#endif

        public const string DocumentsPath = BasePath + @"Resources/Documents/";
        public const string DocumentsPath2 = BasePath + @"Resources/Documents2/";
        public const string DocumentsPath3 = BasePath + @"Resources/Documents3/";
        public const string DocumentsPath4 = BasePath + @"Resources/Documents4/";
        public const string ImagesPath = BasePath + @"Resources/Images/";
        public const string DocumentsPNG = BasePath + @"Resources/DocumentsPNG/";
        public const string PasswordProtectedDocumentsPath = BasePath + @"Resources/PasswordProtectedDocuments/";
        public const string LogPath = BasePath + @"Resources/Log/";
        public const string DocumentsUtf32Path = BasePath + @"Resources/DocumentsUtf32/";
        public const string ArchivesPath = BasePath + @"Resources/Archives/";

        public const string OldIndexPath = BasePath + @"Resources/Index_19_4/";

        public static void TraceResult(string query, SearchResult result)
        {
            Console.WriteLine();
            Console.WriteLine("Query: " + query);
            Console.WriteLine("Documents: " + result.DocumentCount);
            Console.WriteLine("Occurrences: " + result.OccurrenceCount);
        }

        public static void TraceIndexedDocuments(Index index)
        {
            Console.WriteLine();
            Console.WriteLine("Indexed documents:");
            DocumentInfo[] documents = index.GetIndexedDocuments();
            for (int i = 0; i < documents.Length; i++)
            {
                Console.WriteLine("\t" + documents[i].FilePath);
            }
        }

        public static void Highlight(Index index, FoundDocument document, string filePath)
        {
            if (document == null) return;

            FileOutputAdapter outputAdapter = new FileOutputAdapter(filePath);
            HtmlHighlighter highlighter = new HtmlHighlighter(outputAdapter);
            index.Highlight(document, highlighter);
        }

        public static void CleanDirectory(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void CopyFiles(string sourcePath, string destinationPath)
        {
            DirectoryInfo source = new DirectoryInfo(sourcePath);
            DirectoryInfo target = new DirectoryInfo(destinationPath);
            target.Create();

            foreach (DirectoryInfo dir in source.GetDirectories())
            {
                CopyFiles(dir.FullName, target.CreateSubdirectory(dir.FullName).FullName);
            }

            foreach (FileInfo file in source.GetFiles())
            {
                file.CopyTo(Path.Combine(target.FullName, file.Name), true);
            }
        }
    }
}
