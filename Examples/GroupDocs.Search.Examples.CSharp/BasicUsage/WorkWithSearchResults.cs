using GroupDocs.Search.Common;
using GroupDocs.Search.Highlighters;
using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using System;
using System.IO;

namespace GroupDocs.Search.Examples.CSharp.BasicUsage
{
    class WorkWithSearchResults
    {
        public static void ObtainSearchResultInformation()
        {
            string indexFolder = @"./BasicUsage/WorkWithSearchResults/ObtainSearchResultInformation";
            string documentFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating an index
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentFolder);

            // Creating search options
            SearchOptions options = new SearchOptions();
            options.FuzzySearch.Enabled = true; // Enabling the fuzzy search
            options.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(3); // Setting the maximum number of differences to 3

            // Search for documents containing the word 'favourable' or the phrase 'ipsum dolor'
            SearchResult result = index.Search("favourable OR \"ipsum dolor\"", options);

            // Printing the result
            Console.WriteLine("Documents: " + result.DocumentCount);
            Console.WriteLine("Total occurrences: " + result.OccurrenceCount);
            for (int i = 0; i < result.DocumentCount; i++)
            {
                FoundDocument document = result.GetFoundDocument(i);
                Console.WriteLine("\tDocument: " + document.DocumentInfo.FilePath);
                Console.WriteLine("\tOccurrences: " + document.OccurrenceCount);
                for (int j = 0; j < document.FoundFields.Length; j++)
                {
                    FoundDocumentField field = document.FoundFields[j];
                    Console.WriteLine("\t\tField: " + field.FieldName);
                    Console.WriteLine("\t\tOccurrences: " + document.OccurrenceCount);
                    // Printing found terms
                    if (field.Terms != null)
                    {
                        for (int k = 0; k < field.Terms.Length; k++)
                        {
                            Console.WriteLine("\t\t\t" + field.Terms[k].PadRight(20) + field.TermsOccurrences[k]);
                        }
                    }
                    // Printing found phrases
                    if (field.TermSequences != null)
                    {
                        for (int k = 0; k < field.TermSequences.Length; k++)
                        {
                            string sequence = string.Join(" ", field.TermSequences[k]);
                            Console.WriteLine("\t\t\t" + sequence.PadRight(30) + field.TermSequencesOccurrences[k]);
                        }
                    }
                }
            }
        }

        public static void HighlightSearchResults()
        {
            string indexFolder = @"./BasicUsage/WorkWithSearchResults/HighlightSearchResults";
            string documentFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating an index settings instance
            IndexSettings settings = new IndexSettings();
            settings.TextStorageSettings = new TextStorageSettings(Compression.High); // Enabling storage of extracted text in the index

            // Creating an index in the specified folder
            Index index = new Index(indexFolder, settings);

            // Indexing documents from the specified folder
            index.Add(documentFolder);

            // Search for the word 'solicitude'
            SearchResult result = index.Search("solicitude");

            // Highlighting occurrences in text
            if (result.DocumentCount > 0)
            {
                FoundDocument document = result.GetFoundDocument(0); // Getting the first found document
                string path = @"./BasicUsage/WorkWithSearchResults/Highlighted.html";
                OutputAdapter outputAdapter = new FileOutputAdapter(OutputFormat.Html, path); // Creating an output adapter to the file
                Highlighter highlighter = new DocumentHighlighter(outputAdapter); // Creating the highlighter object
                index.Highlight(document, highlighter); // Generating HTML formatted text with highlighted occurrences

                Console.WriteLine();
                Console.WriteLine("Generated HTML file can be opened with Internet browser.");
                Console.WriteLine("The file can be found by the following path:");
                Console.WriteLine(Path.GetFullPath(path));
            }
        }
    }
}
