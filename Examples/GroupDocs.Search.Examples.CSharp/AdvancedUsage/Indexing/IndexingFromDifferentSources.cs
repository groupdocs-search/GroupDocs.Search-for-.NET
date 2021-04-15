using Amazon.S3;
using Amazon.S3.Model;
using GroupDocs.Search.Common;
using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Indexing
{
    class IndexingFromDifferentSources
    {
        public static void IndexingFromFile()
        {
            string indexFolder = @".\AdvancedUsage\Indexing\IndexingFromDifferentSources\IndexingFromFile";
            string documentFilePath = Path.Combine(Utils.DocumentsPath, "Lorem ipsum.pdf");

            // Creating an index
            IndexSettings settings = new IndexSettings();
            settings.UseRawTextExtraction = false;
            Index index = new Index(indexFolder, settings);

            // Creating a document object
            Document document = Document.CreateFromFile(documentFilePath);
            Document[] documents = new Document[]
            {
                document,
            };

            // Indexing document from the file
            IndexingOptions options = new IndexingOptions();
            index.Add(documents, options);

            // Searching in the index
            string query = "lorem";
            SearchResult result = index.Search(query);

            Utils.TraceResult(query, result);
        }

        public static void IndexingFromStream()
        {
            string indexFolder = @".\AdvancedUsage\Indexing\IndexingFromDifferentSources\IndexingFromStream";
            string documentFilePath = Path.Combine(Utils.DocumentsPath, "Lorem ipsum.pdf");

            // Creating an index
            Index index = new Index(indexFolder);

            // Creating a document object
            Stream stream = File.OpenRead(documentFilePath); // Opening a stream
            Document document = Document.CreateFromStream(documentFilePath, DateTime.Now, ".pdf", stream);
            Document[] documents = new Document[]
            {
                document,
            };

            // Indexing document from the stream
            IndexingOptions options = new IndexingOptions();
            index.Add(documents, options);

            // Closing the document stream after indexing is complete
            stream.Close();

            // Searching in the index
            string query = "lorem";
            SearchResult result = index.Search(query);

            Utils.TraceResult(query, result);
        }

        public static void IndexingFromStructure()
        {
            string indexFolder = @".\AdvancedUsage\Indexing\IndexingFromDifferentSources\IndexingFromStructure";
            string documentFilePath = Path.Combine(Utils.DocumentsPath, "Lorem ipsum.txt");

            // Creating an index
            Index index = new Index(indexFolder);

            // Creating a document object
            string text = File.ReadAllText(documentFilePath);
            DocumentField[] fields = new DocumentField[]
            {
                new DocumentField(CommonFieldNames.Content, text),
            };
            Document document = Document.CreateFromStructure("ExampleDocument", DateTime.Now, fields);
            Document[] documents = new Document[]
            {
                document,
            };

            // Indexing document from the structure
            IndexingOptions options = new IndexingOptions();
            index.Add(documents, options);

            // Searching in the index
            string query = "lorem";
            SearchResult result = index.Search(query);

            Utils.TraceResult(query, result);
        }

        public static void IndexingFromUrl()
        {
            string indexFolder = @".\AdvancedUsage\Indexing\IndexingFromDifferentSources\IndexingFromUrl";
            string url = "http://unec.edu.az/application/uploads/2014/12/pdf-sample.pdf";

            // Creating an index
            IndexSettings settings = new IndexSettings();
            settings.TextStorageSettings = new TextStorageSettings(Compression.High);
            settings.UseRawTextExtraction = false;
            Index index = new Index(indexFolder, settings, true);

            index.Events.ErrorOccurred += (s, a) =>
            {
                Console.WriteLine(a.Message);
            };

            // Creating a document object
            string documentKey = url;
            IDocumentLoader documentLoader = new DocumentLoaderFromUrl(documentKey, url, ".pdf");
            Document document = Document.CreateLazy(DocumentSourceKind.Stream, documentKey, documentLoader);
            Document[] documents = new Document[]
            {
                document,
            };

            // Indexing the lazy-loaded document
            IndexingOptions options = new IndexingOptions();
            index.Add(documents, options);

            // Searching in the index
            string query = "files";
            SearchResult result = index.Search(query);

            Utils.TraceResult(query, result);
        }

        public static void IndexingFromFtp()
        {
            string indexFolder = @".\AdvancedUsage\Indexing\IndexingFromDifferentSources\IndexingFromFtp";
            string url = "ftp://example.com/ExampleDocument.pdf";

            // Creating an index
            IndexSettings settings = new IndexSettings();
            settings.TextStorageSettings = new TextStorageSettings(Compression.High);
            settings.UseRawTextExtraction = false;
            Index index = new Index(indexFolder, settings, true);

            index.Events.ErrorOccurred += (s, a) =>
            {
                Console.WriteLine(a.Message);
            };

            // Creating a document object
            string documentKey = url;
            IDocumentLoader documentLoader = new DocumentLoaderFromUrl(documentKey, url, ".pdf");
            Document document = Document.CreateLazy(DocumentSourceKind.Stream, documentKey, documentLoader);
            Document[] documents = new Document[]
            {
                document,
            };

            // Indexing the lazy-loaded document
            IndexingOptions options = new IndexingOptions();
            index.Add(documents, options);

            // Searching in the index
            string query = "some";
            SearchResult result = index.Search(query);

            Utils.TraceResult(query, result);
        }

        private class DocumentLoaderFromUrl : IDocumentLoader
        {
            private readonly string documentKey;
            private readonly string url;
            private readonly string extension;

            public DocumentLoaderFromUrl(string documentKey, string url, string extension)
            {
                this.documentKey = documentKey;
                this.url = url;
                this.extension = extension;
            }

            public Document LoadDocument()
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol =
                    SecurityProtocolType.Ssl3 |
                    SecurityProtocolType.Tls |
                    SecurityProtocolType.Tls12 |
                    SecurityProtocolType.Tls11;

                WebRequest request = WebRequest.Create(url);
                using (WebResponse response = request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                {
                    MemoryStream memoryStream = new MemoryStream();
                    stream.CopyTo(memoryStream);
                    memoryStream.Position = 0;
                    Document document = Document.CreateFromStream(documentKey, DateTime.Now, extension, memoryStream);
                    return document;
                }
            }

            public void CloseDocument()
            {
            }
        }

        public static void IndexingFromAmazon()
        {
            string indexFolder = @".\AdvancedUsage\Indexing\IndexingFromDifferentSources\IndexingFromAmazon";
            string key = "example.pdf";

            // Creating an index
            Index index = new Index(indexFolder);

            // Creating a document object
            string documentKey = "documentKey";
            IDocumentLoader documentLoader = new DocumentLoaderFromAmazon(documentKey, ".pdf", key);
            Document document = Document.CreateLazy(DocumentSourceKind.Stream, documentKey, documentLoader);
            Document[] documents = new Document[]
            {
                document,
            };

            // Indexing the lazy-loaded document
            IndexingOptions options = new IndexingOptions();
            index.Add(documents, options);

            // Searching in the index
            string query = "some";
            SearchResult result = index.Search(query);

            Utils.TraceResult(query, result);
        }

        private class DocumentLoaderFromAmazon : IDocumentLoader
        {
            private readonly string documentKey;
            private readonly string extension;
            private readonly string storageKey;

            public DocumentLoaderFromAmazon(string documentKey, string extension, string storageKey)
            {
                this.documentKey = documentKey;
                this.extension = extension;
                this.storageKey = storageKey;
            }

            public Document LoadDocument()
            {
                AmazonS3Client client = new AmazonS3Client();
                string bucketName = "my-bucket";
                GetObjectRequest request = new GetObjectRequest
                {
                    Key = storageKey,
                    BucketName = bucketName,
                };
                var task = client.GetObjectAsync(request);
                task.Wait();
                using (GetObjectResponse response = task.Result)
                {
                    MemoryStream memoryStream = new MemoryStream();
                    response.ResponseStream.CopyTo(memoryStream);
                    memoryStream.Position = 0;
                    Document document = Document.CreateFromStream(documentKey, DateTime.Now, extension, memoryStream);
                    return document;
                }
            }

            public void CloseDocument()
            {
            }
        }

        public static void IndexingFromAzure()
        {
            string indexFolder = @".\AdvancedUsage\Indexing\IndexingFromDifferentSources\IndexingFromAzure";
            string blobName = "example.pdf";

            // Creating an index
            Index index = new Index(indexFolder);

            // Creating a document object
            string documentKey = "documentKey";
            IDocumentLoader documentLoader = new DocumentLoaderFromAzure(documentKey, ".pdf", blobName);
            Document document = Document.CreateLazy(DocumentSourceKind.Stream, documentKey, documentLoader);
            Document[] documents = new Document[]
            {
                document,
            };

            // Indexing the lazy-loaded document
            IndexingOptions options = new IndexingOptions();
            index.Add(documents, options);

            // Searching in the index
            string query = "some";
            SearchResult result = index.Search(query);

            Utils.TraceResult(query, result);
        }

        private class DocumentLoaderFromAzure : IDocumentLoader
        {
            private readonly string documentKey;
            private readonly string extension;
            private readonly string blobName;

            public DocumentLoaderFromAzure(string documentKey, string extension, string blobName)
            {
                this.documentKey = documentKey;
                this.extension = extension;
                this.blobName = blobName;
            }

            public Document LoadDocument()
            {
                string accountName = "***";
                string accountKey = "***";
                string endpoint = $"https://{accountName}.blob.core.windows.net/";
                string containerName = "***";
                StorageCredentials storageCredentials = new StorageCredentials(accountName, accountKey);
                CloudStorageAccount cloudStorageAccount = new CloudStorageAccount(
                    storageCredentials, new Uri(endpoint), null, null, null);
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = cloudBlobClient.GetContainerReference(containerName);
                container.CreateIfNotExists();

                CloudBlob blob = container.GetBlobReference(blobName);
                MemoryStream memoryStream = new MemoryStream();
                blob.DownloadToStream(memoryStream);
                memoryStream.Position = 0;

                Document document = Document.CreateFromStream(documentKey, DateTime.Now, extension, memoryStream);
                return document;
            }

            public void CloseDocument()
            {
            }
        }
    }
}
