using GroupDocs.Search.Common;
using GroupDocs.Search.Highlighters;
using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using System;
using System.IO;
using System.Text;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Searching
{
    class HighlightingSearchResults
    {
        public static void HighlightingInEntireDocument()
        {
            string indexFolder = @"./AdvancedUsage/Searching/HighlightingSearchResults/HighlightingInEntireDocument";
            string documentFolder = Utils.ArchivesPath;

            // Creating an index settings instance
            IndexSettings settings = new IndexSettings();
            settings.TextStorageSettings = new TextStorageSettings(Compression.High); // Enabling storage of extracted text in the index

            // Creating an index in the specified folder
            Index index = new Index(indexFolder, settings);

            // Indexing documents from the specified folder
            index.Add(documentFolder);

            // Search for the word 'ipsum'
            SearchResult result = index.Search("ipsum");

            // Highlighting occurrences in the text
            if (result.DocumentCount > 0)
            {
                {
                    FoundDocument document = result.GetFoundDocument(0); // Getting the first found document
                    OutputAdapter outputAdapter = new FileOutputAdapter(OutputFormat.Html, @"./AdvancedUsage/Searching/HighlightingSearchResults/Highlighted.html"); // Creating an output adapter to a file
                    Highlighter highlighter = new DocumentHighlighter(outputAdapter); // Creating the highlighter object
                    HighlightOptions options = new HighlightOptions(); // Creating the highlight options
                    options.HighlightColor = new Color(150, 255, 150); // Setting highlight color
                    options.UseInlineStyles = false; // Using CSS styles to highlight occurrences
                    options.GenerateHead = true; // Generating Head tag in output HTML
                    index.Highlight(document, highlighter, options); // Generating HTML formatted text with highlighted occurrences
                }
                {
                    FoundDocument document = result.GetFoundDocument(0); // Getting the first found document
                    StructureOutputAdapter outputAdapter = new StructureOutputAdapter(OutputFormat.PlainText); // Creating the output adapter
                    Highlighter highlighter = new DocumentHighlighter(outputAdapter); // Creating the highlighter instance
                    HighlightOptions options = new HighlightOptions(); // Creating the highlight options
                    options.TermHighlightStartTag = "<Term>"; // Setting the start tag for the found word
                    options.TermHighlightEndTag = "</Term>"; // Setting the end tag for the found word
                    index.Highlight(document, highlighter, options); // Generating plain text with highlighted occurrences

                    DocumentField[] fields = outputAdapter.GetResult();
                    Console.WriteLine(document.ToString());
                    for (int i = 0; i < fields.Length; i++)
                    {
                        // Printing field names of the found document
                        DocumentField field = fields[i];
                        Console.WriteLine("\t" + field.Name);
                    }
                }
            }
        }

        public static void HighlightingInFragments()
        {
            string indexFolder = @"./AdvancedUsage/Searching/HighlightingSearchResults/HighlightingInFragments";
            string documentFolder = Utils.ArchivesPath;

            // Creating an index settings instance
            IndexSettings settings = new IndexSettings();
            settings.TextStorageSettings = new TextStorageSettings(Compression.High); // Enabling storage of extracted text in the index

            // Creating an index in the specified folder
            Index index = new Index(indexFolder, settings);

            // Indexing documents from the specified folder
            index.Add(documentFolder);

            // Search for the word 'ipsum'
            SearchResult result = index.Search("ipsum");

            // Assigning highlight options
            HighlightOptions options = new HighlightOptions();
            options.TermsBefore = 5;
            options.TermsAfter = 5;
            options.TermsTotal = 15;
            options.HighlightColor = new Color(127, 200, 255);
            options.UseInlineStyles = true;

            // Highlighting found words in separate text fragments of a document
            FoundDocument document = result.GetFoundDocument(0);
            FragmentHighlighter highlighter = new FragmentHighlighter(OutputFormat.Html);
            index.Highlight(document, highlighter, options);

            // Getting the result
            StringBuilder stringBuilder = new StringBuilder();
            FragmentContainer[] fragmentContainers = highlighter.GetResult();
            for (int i = 0; i < fragmentContainers.Length; i++)
            {
                FragmentContainer container = fragmentContainers[i];
                string[] fragments = container.GetFragments();
                if (fragments.Length > 0)
                {
                    stringBuilder.AppendLine("\n<br>" + container.FieldName + "<br>");
                    stringBuilder.AppendLine();
                    for (int j = 0; j < fragments.Length; j++)
                    {
                        // Printing HTML markup to console
                        stringBuilder.AppendLine(fragments[j]);
                        stringBuilder.AppendLine();
                    }
                }
            }
            Console.WriteLine(stringBuilder.ToString());
            File.WriteAllText(@"./AdvancedUsage/Searching/HighlightingSearchResults/Fragments.html", stringBuilder.ToString());
        }
    }
}
