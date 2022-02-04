using GroupDocs.Search.Dictionaries;
using GroupDocs.Search.Examples.CSharp.HighlightInHtml.Highlighter;
using GroupDocs.Search.Examples.CSharp.HighlightInHtml.ViewerCache;
using GroupDocs.Search.Results;
using GroupDocs.Viewer.Results;
using System.Collections.Generic;
using System.IO;

namespace GroupDocs.Search.Examples.CSharp.HighlightInHtml
{
    internal class HighlightService
    {
        private const string Key = "<style>";
        private const string HighlightStyle = @".highlighted-term { background-color:#ADFF2F; } ";

        private readonly IndexedFileInfo _fileInfo;
        private readonly string _password;
        private readonly string _backupPath;

        private IList<Page> _pages;

        public HighlightService(
            IndexedFileInfo fileInfo,
            string password)
        {
            _fileInfo = fileInfo;
            _password = password;
            _backupPath = Path.Combine(_fileInfo.ViewerCacheFolderPath, _fileInfo.FileFolderName + "_backup");

            using (var htmlViewer = new HtmlViewer(_fileInfo, _password))
            {
                _pages = htmlViewer.GetPages();
                foreach (var page in _pages)
                {
                    htmlViewer.CreateCacheForPage(page.Number);
                }
            }

            Directory.Move(_fileInfo.FileCacheFolderPath, _backupPath);
        }

        public void Highlight(FoundDocument foundDocument, Alphabet alphabet)
        {
            Utils.CopyFiles(_backupPath, _fileInfo.FileCacheFolderPath);

            foreach (var page in _pages)
            {
                var pageFilePath = _fileInfo.GetHtmlPageFilePath(page.Number);

                var text = File.ReadAllText(pageFilePath);

                var result = HtmlHighlighter.Handle(
                    text,
                    false,
                    alphabet,
                    foundDocument.Terms,
                    foundDocument.TermSequences);

                // Inserting the highlighting style
                int index = result.IndexOf(Key);
                if (index > 0 && index + Key.Length < result.Length)
                {
                    result = result.Insert(index + Key.Length, HighlightStyle);
                }

                File.WriteAllText(pageFilePath, result);
            }
        }
    }
}
