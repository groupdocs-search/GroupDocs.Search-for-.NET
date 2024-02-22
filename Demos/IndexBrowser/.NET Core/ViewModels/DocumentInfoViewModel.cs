using GroupDocs.Search.Common;
using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GroupDocs.Search.IndexBrowser.ViewModels
{
    class DocumentInfoViewModel : ViewModelBase
    {
        private const string GeneratedHtmlFileName = "GeneratedHtml.html";

        private readonly Index index;
        private readonly DocumentInfo documentInfo;
        private string tempFileName;

        public DocumentInfoViewModel(Index index, DocumentInfo documentInfo)
        {
            this.index = index;
            this.documentInfo = documentInfo;
        }

        public string FilePath => documentInfo.FilePath;

        public string HtmlUrl => tempFileName;

        public async Task LoadAsync()
        {
            if (tempFileName == null)
            {
                try
                {
                    var folder = Path.GetTempPath();
                    tempFileName = Path.Combine(folder, GeneratedHtmlFileName);
                    await Task.Factory.StartNew(() =>
                    {
                        var adapter = new FileOutputAdapter(OutputFormat.Html, tempFileName);
                        index.GetDocumentText(documentInfo, adapter);
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    tempFileName = null;
                }
            }
        }

        public void Unload()
        {
            if (tempFileName != null)
            {
                try
                {
                    File.Delete(tempFileName);
                    tempFileName = null;
                    NotifyPropertyChanged(nameof(HtmlUrl));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
