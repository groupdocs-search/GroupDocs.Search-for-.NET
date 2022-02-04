using System.IO;

namespace GroupDocs.Search.Examples.CSharp.HighlightInHtml
{
    internal class IndexedFileInfo
    {
        private readonly string _viewerCacheFolderPath;
        private readonly string _filePath;
        private readonly string _fileFolderName;
        private readonly string _fileCacheFolderPath;

        public IndexedFileInfo(string viewerCacheFolderPath, string filePath)
        {
            _viewerCacheFolderPath = viewerCacheFolderPath;
            _filePath = filePath;
            var fileName = Path.GetFileName(_filePath);
            _fileFolderName = fileName.Replace(".", "_");
            _fileCacheFolderPath = Path.Combine(viewerCacheFolderPath, _fileFolderName);
        }

        public string ViewerCacheFolderPath => _viewerCacheFolderPath;

        public string FilePath => _filePath;

        public string FileFolderName => _fileFolderName;

        public string FileCacheFolderPath => _fileCacheFolderPath;

        public string GetHtmlPageFilePath(int pageNumber)
        {
            string pageFileName = $"p{pageNumber}.html";
            string pageFilePath = Path.Combine(_fileCacheFolderPath, pageFileName);
            return pageFilePath;
        }

        public string GetHtmlPageResourceFilePath(int pageNumber, string resourceFileName)
        {
            string resFileName = GetResourceFileName(pageNumber, resourceFileName);
            string resFilePath = Path.Combine(_fileCacheFolderPath, resFileName);
            return resFilePath;
        }

        public string GetHtmlPageResourceUrl(int pageNumber, string resourceFileName)
        {
            return GetResourceFileName(pageNumber, resourceFileName);
        }

        private static string GetResourceFileName(int pageNumber, string resourceFileName)
        {
            var resFileName = $"p{pageNumber}_{resourceFileName}";
            return resFileName;
        }
    }
}
