using GroupDocs.Search.WebForms.Products.Common.Entity.Web;
using GroupDocs.Search.WebForms.Products.Common.Resources;
using GroupDocs.Search.WebForms.Products.Common.Util.Comparator;
using GroupDocs.Search.WebForms.Products.Search.Entity.Web;
using GroupDocs.Search.WebForms.Products.Search.Entity.Web.Request;
using GroupDocs.Search.WebForms.Products.Search.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace GroupDocs.Search.WebForms.Products.Search.Controllers
{
    /// <summary>
    /// The search API controller.
    /// </summary>
    [ApiController]
    [Route("search")]
    public class SearchApiController : ControllerBase
    {
        private readonly Common.Config.GlobalConfiguration globalConfiguration;
        /// <summary>
        /// The constructor.
        /// </summary>
        public SearchApiController()
        {
            globalConfiguration = new Common.Config.GlobalConfiguration();
        }

        /// <summary>
        /// Loads configuration.
        /// </summary>
        /// <returns>The configuration.</returns>
        [HttpGet]
        [Route("loadConfig")]
        public IActionResult LoadConfig()
        {
            SearchService.InitIndex(globalConfiguration);

            return Ok(globalConfiguration.Search);
        }

        /// <summary>
        /// Gets all files and directories from storage.
        /// </summary>
        /// <param name="fileTreeRequest">The posted data with path.</param>
        /// <returns>The list of files and directories.</returns>
        [HttpPost]
        [Route("loadFileTree")]
        public IActionResult LoadFileTree(PostedDataEntity fileTreeRequest)
        {
            List<IndexedFileDescriptionEntity> filesList = new List<IndexedFileDescriptionEntity>();

            string filesDirectory = string.IsNullOrEmpty(fileTreeRequest.path) ?
                                    globalConfiguration.Search.GetFilesDirectory() :
                                    fileTreeRequest.path;

            if (!string.IsNullOrEmpty(globalConfiguration.Search.GetFilesDirectory()))
            {
                filesList = LoadFiles(filesDirectory);
            }

            return Ok(filesList);
        }

        /// <summary>
        /// Loads documents.
        /// </summary>
        /// <param name="filesDirectory">The files directory.</param>
        /// <returns>The list of documents.</returns>
        public List<IndexedFileDescriptionEntity> LoadFiles(string filesDirectory)
        {
            List<string> allFiles = new List<string>(Directory.GetFiles(filesDirectory));
            allFiles.AddRange(Directory.GetDirectories(filesDirectory));
            List<IndexedFileDescriptionEntity> fileList = new List<IndexedFileDescriptionEntity>();

            allFiles.Sort(new FileNameComparator());
            allFiles.Sort(new FileDateComparator());

            foreach (string file in allFiles)
            {
                FileInfo fileInfo = new FileInfo(file);

                if (!(Path.GetFileName(file).StartsWith(".") ||
                      fileInfo.Attributes.HasFlag(FileAttributes.Hidden) ||
                      Path.GetFileName(file).Equals(Path.GetFileName(globalConfiguration.Search.GetFilesDirectory())) ||
                      Path.GetFileName(file).Equals(Path.GetFileName(globalConfiguration.Search.GetIndexDirectory())) ||
                      Path.GetFileName(file).Equals(Path.GetFileName(globalConfiguration.Search.GetIndexedFilesDirectory()))))
                {
                    IndexedFileDescriptionEntity fileDescription = new IndexedFileDescriptionEntity
                    {
                        guid = Path.GetFullPath(file),
                        name = Path.GetFileName(file),
                        // set is directory true/false
                        isDirectory = fileInfo.Attributes.HasFlag(FileAttributes.Directory)
                    };
                    // set file size
                    if (!fileDescription.isDirectory)
                    {
                        fileDescription.size = fileInfo.Length;
                    }

                    if (filesDirectory.Contains(globalConfiguration.Search.GetIndexedFilesDirectory()))
                    {
                        string value;
                        if (SearchService.FileIndexingStatusDict.TryGetValue(fileDescription.guid, out value))
                        {
                            fileDescription.documentStatus = value;
                        }
                        else
                        {
                            fileDescription.documentStatus = "Indexing";
                        }
                    }

                    fileList.Add(fileDescription);
                }
            }

            return fileList;
        }

        /// <summary>
        /// Uploads document.
        /// </summary>
        /// <returns>The uploaded document object.</returns>
        [HttpPost]
        [Route("uploadDocument")]
        public IActionResult UploadDocument()
        {
            string url = HttpContext.Request.Form["url"];
            // get documents storage path
            string documentStoragePath = globalConfiguration.Search.GetFilesDirectory();
            bool rewrite = bool.Parse(HttpContext.Request.Form["rewrite"]);
            string fileSavePath = "";
            if (string.IsNullOrEmpty(url))
            {
                if (HttpContext.Request.Form.Keys != null)
                {
                    // Get the uploaded document from the Files collection
                    var httpPostedFile = HttpContext.Request.Form.Files["file"];
                    if (httpPostedFile != null)
                    {
                        if (rewrite)
                        {
                            // Get the complete file path
                            fileSavePath = Path.Combine(documentStoragePath, httpPostedFile.FileName);
                        }
                        else
                        {
                            fileSavePath = Resources.GetFreeFileName(documentStoragePath, httpPostedFile.FileName);
                        }

                        // Save the uploaded file to "UploadedFiles" folder
                        using (var fs = System.IO.File.Create(fileSavePath))
                        {
                            httpPostedFile.CopyTo(fs);
                        }
                    }
                }
            }
            else
            {
                using (WebClient client = new WebClient())
                {
                    // get file name from the URL
                    Uri uri = new Uri(url);
                    string fileName = Path.GetFileName(uri.LocalPath);
                    if (rewrite)
                    {
                        // Get the complete file path
                        fileSavePath = Path.Combine(documentStoragePath, fileName);
                    }
                    else
                    {
                        fileSavePath = Resources.GetFreeFileName(documentStoragePath, fileName);
                    }
                    // Download the Web resource and save it into the current filesystem folder.
                    client.DownloadFile(url, fileSavePath);
                }
            }

            UploadedDocumentEntity uploadedDocument = new UploadedDocumentEntity
            {
                guid = fileSavePath
            };

            return Ok(uploadedDocument);
        }

        /// <summary>
        /// Adds files to the index.
        /// </summary>
        /// <param name="postedData">The file array.</param>
        [HttpPost]
        [Route("addFilesToIndex")]
        public IActionResult AddFilesToIndex(PostedDataEntity[] postedData)
        {
            try
            {
                SearchService.AddFilesToIndex(postedData, globalConfiguration);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.ToString());
            }
        }

        /// <summary>
        /// Performs a search.
        /// </summary>
        /// <param name="postedData">The search query.</param>
        /// <returns>The search result.</returns>
        [HttpPost]
        [Route("search")]
        public IActionResult Search(SearchPostedData postedData)
        {
            var result = SearchService.Search(postedData, globalConfiguration);
            return Ok(result);
        }

        /// <summary>
        /// Deletes a file.
        /// </summary>
        /// <param name="postedData">The file to delete.</param>
        [HttpPost]
        [Route("removeFromIndex")]
        public IActionResult RemoveFromIndex(PostedDataEntity postedData)
        {
            SearchService.RemoveFileFromIndex(postedData.guid);
            return Ok();
        }

        /// <summary>
        /// Gets document statuses.
        /// </summary>
        /// <param name="postedData">The file array.</param>
        /// <returns>The list of indexed files with statuses.</returns>
        [HttpPost]
        [Route("getFileStatus")]
        public IActionResult GetFileStatus(PostedDataEntity[] postedData)
        {
            var indexingFilesList = new List<IndexedFileDescriptionEntity>();

            foreach (var file in postedData)
            {
                var indexingFile = new IndexedFileDescriptionEntity();

                string value;
                if (SearchService.FileIndexingStatusDict.TryGetValue(file.guid, out value))
                {
                    if (value.Equals("PasswordRequired"))
                    {
                        return Problem("Password required.");
                    }

                    indexingFile.documentStatus = value;
                }
                else
                {
                    indexingFile.documentStatus = "Indexing";
                }

                indexingFile.guid = file.guid;

                indexingFilesList.Add(indexingFile);
            }

            return Ok(indexingFilesList);
        }
    }
}
