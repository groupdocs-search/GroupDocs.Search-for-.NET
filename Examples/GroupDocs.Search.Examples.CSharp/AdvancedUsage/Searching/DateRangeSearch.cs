using GroupDocs.Search.Options;
using GroupDocs.Search.Results;
using System;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Searching
{
    class DateRangeSearch
    {
        public static void CreatingDateRangeSearchQueries()
        {
            string indexFolder = @"./AdvancedUsage/Searching/DateRangeSearch/CreatingDateRangeSearchQueries";
            string documentsFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Search for dates using query in text form
            string query1 = "daterange(2017-01-01 ~~ 2019-12-31)";
            SearchResult result1 = index.Search(query1);

            // Search for dates using query in text form
            SearchQuery query2 = SearchQuery.CreateDateRangeQuery(new DateTime(2017, 1, 1), new DateTime(2019, 12, 31));
            SearchResult result2 = index.Search(query2);

            Utils.TraceResult(query1, result1);
            Utils.TraceResult(query2.ToString(), result2);
        }

        public static void SpecifyingDateRangeSearchFormats()
        {
            string indexFolder = @"./AdvancedUsage/Searching/DateRangeSearch/SpecifyingDateRangeSearchFormats";
            string documentsFolder = Utils.DocumentsPath;

            Utils.PrintHeaderFromPath(indexFolder);

            // Creating an index in the specified folder
            Index index = new Index(indexFolder);

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Setting date formats
            SearchOptions options = new SearchOptions();
            options.DateFormats.Clear(); // Removing default date formats
            DateFormatElement[] elements = new DateFormatElement[]
            {
                DateFormatElement.MonthTwoDigits,
                DateFormatElement.DateSeparator,
                DateFormatElement.DayOfMonthTwoDigits,
                DateFormatElement.DateSeparator,
                DateFormatElement.YearFourDigits,
            };
            // Creating a date format pattern 'MM/dd/yyyy'
            DateFormat dateFormat = new DateFormat(elements, "/");
            options.DateFormats.Add(dateFormat);

            // Searching in the index.
            // For the given query, for example, the date 09/27/2019 will be found,
            // but the date 2019-09-27 will not be found, because it is presented in a format that is not specified in the search options.
            string query = "daterange(2017-01-01 ~~ 2019-12-31)";
            SearchResult result = index.Search(query, options);

            Utils.TraceResult(query, result);
        }
    }
}
