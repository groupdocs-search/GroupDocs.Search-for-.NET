using GroupDocs.Search.Common;
using GroupDocs.Search.Highlighters;
using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace GroupDocs.Search.IndexBrowser.ViewModels
{
    class FoundDocumentViewModel : ViewModelBase
    {
        private const string GeneratedHtmlFileName = "GeneratedHtml.html";

        private readonly LoadedIndexViewModel index;
        private readonly FoundDocument result;
        private int occurrenceIndex = -1;
        private string tempFileName;

        public FoundDocumentViewModel(LoadedIndexViewModel index, FoundDocument result)
        {
            this.index = index;
            this.result = result;
        }

        public string FileName
        {
            get { return Path.GetFileName(result.DocumentInfo.FilePath); }
        }

        public string FullPath
        {
            get { return result.DocumentInfo.FilePath; }
        }

        public string DisplayText
        {
            get { return result.DocumentInfo.ToString(); }
        }

        public int OccurrenceCount
        {
            get { return result.OccurrenceCount; }
        }

        public string Html
        {
            get
            {
                var adapter = new StringOutputAdapter(OutputFormat.Html);
                var highlighter = new DocumentHighlighter(adapter);
                index.Index.Highlight(result, highlighter);
                var text = adapter.GetResult();
                return text;
            }
        }

        public string HtmlUrl
        {
            get
            {
                if (OccurrenceIndex < 0)
                {
                    return tempFileName;
                }
                else
                {
                    var result = tempFileName + "#hit" + OccurrenceIndex.ToString(CultureInfo.InvariantCulture);
                    return result;
                }
            }
        }

        public int OccurrenceIndex
        {
            get { return occurrenceIndex; }
            set
            {
                if (UpdateProperty(ref occurrenceIndex, value))
                {
                    NotifyPropertyChanged(nameof(OccurrenceIndexText));
                }
            }
        }

        public string OccurrenceIndexText
        {
            get { return occurrenceIndex >= 0 ? (occurrenceIndex + 1).ToString() : string.Empty; }
        }

        public async Task LoadAsync()
        {
            OccurrenceIndex = -1;
            if (tempFileName == null)
            {
                try
                {
                    var folder = Path.GetTempPath();
                    tempFileName = Path.Combine(folder, GeneratedHtmlFileName);
                    await Task.Factory.StartNew(() =>
                    {
                        var adapter = new FileOutputAdapter(OutputFormat.Html, tempFileName);
                        var highlighter = new DocumentHighlighter(adapter);
                        var options = new HighlightOptions();
                        index.Index.Highlight(result, highlighter, options);
                        var text = File.ReadAllText(tempFileName);
                        text = text.Replace(": rgba(255, 216, 0, 1);", ":LightGreen");
                        File.WriteAllText(tempFileName, text);
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

        public void NavigateNext()
        {
            if (CanNavigateNext)
            {
                OccurrenceIndex++;
                NotifyPropertyChanged(nameof(HtmlUrl));
            }
        }

        public bool CanNavigateNext
        {
            get { return tempFileName != null && OccurrenceIndex < result.OccurrenceCount - 1; }
        }

        public void NavigatePrevious()
        {
            if (CanNavigatePrevious)
            {
                OccurrenceIndex--;
                NotifyPropertyChanged(nameof(HtmlUrl));
            }
        }

        public bool CanNavigatePrevious
        {
            get { return tempFileName != null && OccurrenceIndex > 0; }
        }
    }
}
