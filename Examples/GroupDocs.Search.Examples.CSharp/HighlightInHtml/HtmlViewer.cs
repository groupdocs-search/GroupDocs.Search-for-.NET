using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;
using System;
using System.Collections.Generic;
using System.IO;

namespace GroupDocs.Search.Examples.CSharp.HighlightInHtml.ViewerCache
{
    internal class HtmlViewer : IDisposable
    {
        private readonly IndexedFileInfo _fileInfo;
        private readonly GroupDocs.Viewer.Viewer _viewer;
        private readonly HtmlViewOptions _viewOptions;

        public HtmlViewer(
            IndexedFileInfo fileInfo,
            string password)
        {
            _fileInfo = fileInfo;
            Directory.CreateDirectory(_fileInfo.FileCacheFolderPath);

            var loadOptions = new LoadOptions
            {
                Password = password,
            };
            _viewer = new GroupDocs.Viewer.Viewer(_fileInfo.FilePath, loadOptions);
            _viewOptions = CreateHtmlViewOptions();
        }

        public void Dispose()
        {
            _viewer?.Dispose();
        }

        public IList<Page> GetPages()
        {
            var viewInfoOptions = ViewInfoOptions.FromHtmlViewOptions(_viewOptions);
            var viewInfo = _viewer.GetViewInfo(viewInfoOptions);
            return viewInfo.Pages;
        }

        public void CreateCacheForPage(int pageNumber)
        {
            _viewer.View(_viewOptions, pageNumber);
        }

        private HtmlViewOptions CreateHtmlViewOptions()
        {
            HtmlViewOptions htmlViewOptions = HtmlViewOptions.ForExternalResources(
                pageNumber =>
                {
                    string cacheFilePath = _fileInfo.GetHtmlPageFilePath(pageNumber);
                    return File.Create(cacheFilePath);
                },
                (pageNumber, resource) =>
                {
                    string cacheFilePath = _fileInfo.GetHtmlPageResourceFilePath(pageNumber, resource.FileName);
                    return File.Create(cacheFilePath);
                },
                (pageNumber, resource) =>
                {
                    return _fileInfo.GetHtmlPageResourceUrl(pageNumber, resource.FileName);
                });

            htmlViewOptions.SpreadsheetOptions = SpreadsheetOptions.ForOnePagePerSheet();
            htmlViewOptions.SpreadsheetOptions.TextOverflowMode = TextOverflowMode.HideText;
            htmlViewOptions.SpreadsheetOptions.RenderGridLines = true;

            return htmlViewOptions;
        }
    }
}
