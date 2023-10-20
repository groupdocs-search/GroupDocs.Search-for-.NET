using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Searching
{
    class SearchResults
    {
        public static void Run()
        {
            string indexFolder = @"./AdvancedUsage/Searching/SearchResults";
            string documentFolder = Utils.DocumentsPath;

            // Creating an index
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentFolder);

            // Creating search options
            SearchOptions options = new SearchOptions();
            options.FuzzySearch.Enabled = true; // Enabling the fuzzy search
            options.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(3); // Setting the maximum number of differences to 3

            // Search for documents containing the word 'water' or the phrase 'Lorem ipsum'
            string query = "water OR \"Lorem ipsum\"";
            SearchResult result = index.Search(query, options);

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
    }
}
