//ExStart:HomeController
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using GroupDocs.Search;
using GroupDocs.Viewer.Config;
using GroupDocs.Viewer.Converter.Options;
using GroupDocs.Viewer.Handler;
using UserInterfaceExample.Helpers;
using UserInterfaceExample.Models;

namespace UserInterfaceExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ViewerHtmlHandler _htmlHandler;
        //private readonly ViewerImageHandler _imageHandler;
        private string _storagePath = AppDomain.CurrentDomain.GetData("DataDirectory").ToString(); // App_Data folder path
        private string _tempPath = AppDomain.CurrentDomain.GetData("DataDirectory") + "\\Temp";
        private string _defaultIndexFolder = AppDomain.CurrentDomain.GetData("DataDirectory") + "\\MyIndexes";
        private string _defaultDocumentsFolderName = AppDomain.CurrentDomain.GetData("DataDirectory") + "\\DocumentsExample";

        private readonly ViewerConfig _config;


        public HomeController()
        {

            LicenseHelper.SetGroupDocsViewerLicense();

            _config = new ViewerConfig
            {
                StoragePath = _storagePath,
                TempPath = _tempPath,
                UseCache = true
            };

            _htmlHandler = new ViewerHtmlHandler(_config);
            //_imageHandler = new ViewerImageHandler(_config);
            
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetDefaultFolders()
        {
            AjaxResponse ajaxResponse = GetDefaultFoldersAjaxResponse();
            return Json(ajaxResponse);
        }

        [HttpPost]
        public JsonResult InitModel()
        {
            AjaxResponse ajaxResponse = GetIndexAjaxResponse();
            return Json(ajaxResponse);
        }


        [HttpPost]
        public JsonResult LoadDocument(string fullName)
        {
            if (!string.IsNullOrEmpty(fullName))
            {
                var result = new ViewDocumentResponse
                {
                    pageCss = new string[] {},
                    lic = true,
                    url = fullName,
                    path = fullName,
                    name = fullName
                };


                var docInfo = _htmlHandler.GetDocumentInfo(new GroupDocs.Viewer.Domain.Options.DocumentInfoOptions(fullName));

                result.documentDescription =
                    new FileDataJsonSerializer(docInfo.Pages, new FileDataOptions()).Serialize(false);
                result.docType = docInfo.DocumentType;
                result.fileType = docInfo.FileType;

                var htmlOptions = new HtmlOptions {IsResourcesEmbedded = true};

                var htmlPages = _htmlHandler.GetPages(fullName, htmlOptions);
                result.pageHtml = htmlPages.Select(_ => _.HtmlContent).ToArray();

                //NOTE: Fix for incomplete cells document
                for (int i = 0; i < result.pageHtml.Length; i++)
                {
                    var html = result.pageHtml[i];
                    var indexOfScript = html.IndexOf("script");
                    if (indexOfScript > 0)
                        result.pageHtml[i] = html.Substring(0, indexOfScript);
                }

                AjaxResponse ajaxResponse = AjaxResponse.Successful(string.Empty, result);

                return Json(ajaxResponse);
            }
            return null;
        }



        [HttpPost]
        public JsonResult CreateIndex(string indexFolder)
        {
            IndexHelper.AddIndex(indexFolder);
            AjaxResponse ajaxResponse = GetIndexAjaxResponse();
            return Json(ajaxResponse);
        }


        [HttpPost]
        public JsonResult DeleteIndex(Guid indexId)
        {
            IndexHelper.DeleteIndex(indexId);
            AjaxResponse ajaxResponse = GetIndexAjaxResponse();
            return Json(ajaxResponse);
        }

        [HttpPost]
        public JsonResult AddFolderToIndex(Guid indexId, string folderName)
        {
            IndexHelper.AddToIndex(indexId, folderName);
            AjaxResponse ajaxResponse = GetIndexAjaxResponse();
            return Json(ajaxResponse);
        }

        public JsonResult RunSearch(Guid selectedIndexId, string searchQuery)
        {
            SearchResults results = IndexHelper.Search(selectedIndexId, searchQuery);
            AjaxResponse response = GetSearchAjaxResponse(results);
            return Json(response);
        }     
        #region Private Methods

        private AjaxResponse GetDefaultFoldersAjaxResponse()
        {
            DefaultFoldersInfo content = new DefaultFoldersInfo();
            content.DefaultDocumentsFolder = _defaultDocumentsFolderName;
            content.DefaultIndexFolder = _defaultIndexFolder;

            AjaxResponse ajaxResponse = AjaxResponse.Successful(string.Empty, content);
            return ajaxResponse;
        }
        private AjaxResponse GetIndexAjaxResponse()
        {

            List<IndexInfo> result = IndexHelper.Indexes.Select(index => new IndexInfo
            {
                IndexId = index.IndexId,
                IndexFolder = string.IsNullOrEmpty(index.IndexFolder) ? index.IndexFolder : new DirectoryInfo(index.IndexFolder).Name,
                IndexFullFolder = index.IndexFolder,
                InMemory = index.IndexingSettings.InMemoryIndex
            }).ToList();

            AjaxResponse ajaxResponse = AjaxResponse.Successful(string.Empty, result);
            return ajaxResponse;
        }

        private AjaxResponse GetSearchAjaxResponse(SearchResults results)
        {
            AjaxResponse ajaxResponse;
            if (results.Count > 0)
            {
                List<SearchResultInfo> result = new List<SearchResultInfo>();
                foreach (DocumentResultInfo documentResultInfo in results)
                {
                    FileInfo fi = new FileInfo(documentResultInfo.FileName);
                    SearchResultInfo searchResultInfo = new SearchResultInfo
                    {
                        FileName = fi.Name,
                        FullName = fi.FullName,
                        Relevance = documentResultInfo.Relevance
                    };

                    result.Add(searchResultInfo);
                }
                ajaxResponse = AjaxResponse.Successful(string.Empty, result);
            }
            else
            {
                ajaxResponse = AjaxResponse.Failed(Resources.MainResource.NothingFoundText, null);
            }
            return ajaxResponse;
        }
        #endregion Private Methods
    }
}
//ExEnd:HomeController