using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using System;

namespace GroupDocs.Search.Examples.CSharp.BasicUsage
{
    class BuildSearchQuery
    {
        public static void Run()
        {
            string indexFolder = @"./BasicUsage/BuildSearchQuery";
            string documentsFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating index in the specified folder
            Index index = new Index(indexFolder);

            // Subscribe to the event
            index.Events.ErrorOccurred += (sender, args) =>
            {
                Console.WriteLine(args.Message); // Writing error messages to the console
            };

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Simple search query
            {
                string query = "volutpat";
                SearchResult result = index.Search(query);
                Console.WriteLine("Query: " + query);
                Console.WriteLine("Documents: " + result.DocumentCount);
                Console.WriteLine("Occurrences: " + result.OccurrenceCount);
                Console.WriteLine();
            }

            // Wildcard search query
            {
                string query = "?ffect";
                SearchResult result = index.Search(query); // Search for words 'affect', 'effect', ets.
                Console.WriteLine("Query: " + query);
                Console.WriteLine("Documents: " + result.DocumentCount);
                Console.WriteLine("Occurrences: " + result.OccurrenceCount);
                Console.WriteLine();
            }

            // Faceted search query
            {
                string query = "Content: magna";
                SearchResult result = index.Search(query); // Search for word 'magna' only in 'Content' field
                Console.WriteLine("Query: " + query);
                Console.WriteLine("Documents: " + result.DocumentCount);
                Console.WriteLine("Occurrences: " + result.OccurrenceCount);
                Console.WriteLine();
            }

            // Numeric range search query
            {
                string query = "2000 ~~ 3000";
                SearchResult result = index.Search(query); // Search for numbers from 2000 to 3000
                Console.WriteLine("Query: " + query);
                Console.WriteLine("Documents: " + result.DocumentCount);
                Console.WriteLine("Occurrences: " + result.OccurrenceCount);
                Console.WriteLine();
            }

            // Date range search query
            {
                SearchOptions options = new SearchOptions(); // Creating a search options object
                options.DateFormats.Clear(); // Removing default date formats

                // Creating a date format pattern 'MM/dd/yyyy'
                DateFormatElement[] elements = new DateFormatElement[]
                {
                    DateFormatElement.MonthTwoDigits,
                    DateFormatElement.DateSeparator,
                    DateFormatElement.DayOfMonthTwoDigits,
                    DateFormatElement.DateSeparator,
                    DateFormatElement.YearFourDigits,
                };
                DateFormat dateFormat = new DateFormat(elements, "/");
                options.DateFormats.Add(dateFormat); // Adding the date format pattern to the date format collection

                string query = "daterange(2000-01-01 ~~ 2001-06-15)"; // Dates in the search query are always specified in the format 'yyyy-MM-dd'
                SearchResult result = index.Search(query, options); // Search in index
                Console.WriteLine("Query: " + query);
                Console.WriteLine("Documents: " + result.DocumentCount);
                Console.WriteLine("Occurrences: " + result.OccurrenceCount);
                Console.WriteLine();
            }

            // Regular expression search query
            {
                string query = "^(.)\\1{2,}"; // The caret character at the beginning indicates that this is a regular expression search query
                SearchResult result = index.Search(query); // Search for three or more identical characters in a row
                Console.WriteLine("Query: " + query);
                Console.WriteLine("Documents: " + result.DocumentCount);
                Console.WriteLine("Occurrences: " + result.OccurrenceCount);
                Console.WriteLine();
            }

            // Boolean search query
            {
                string query = "justo AND NOT 3456";
                SearchResult result = index.Search(query);
                Console.WriteLine("Query: " + query);
                Console.WriteLine("Documents: " + result.DocumentCount);
                Console.WriteLine("Occurrences: " + result.OccurrenceCount);
                Console.WriteLine();
            }

            // Boolean search query 2
            {
                string query = "FileName: Engl?(1~3) OR Content: (3456 AND consequat)";
                // Search for documents whose paths contain 'English', 'England', ets., or documents containing both '3456' and 'consequat' in the content
                SearchResult result = index.Search(query);
                Console.WriteLine("Query: " + query);
                Console.WriteLine("Documents: " + result.DocumentCount);
                Console.WriteLine("Occurrences: " + result.OccurrenceCount);
                Console.WriteLine();
            }

            // Phrase search query
            {
                string query = "\"ipsum dolor sit amet\"";
                SearchResult result = index.Search(query); // Search for the phrase 'ipsum dolor sit amet'
                Console.WriteLine("Query: " + query);
                Console.WriteLine("Documents: " + result.DocumentCount);
                Console.WriteLine("Occurrences: " + result.OccurrenceCount);
                Console.WriteLine();
            }
        }
    }
}
