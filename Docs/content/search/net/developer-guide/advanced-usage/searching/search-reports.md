---
id: search-reports
url: search/net/search-reports
title: Search reports
weight: 23
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
Each time you perform a search in an index, a report is generated for that search. An array of search reports can be obtained by calling [GetSearchReports](https://apireference.groupdocs.com/net/search/groupdocs.search/index/methods/getsearchreports) method of the [Index](https://apireference.groupdocs.com/net/search/groupdocs.search/index) class. Reports are stored in the index only while the index is loaded into RAM for use. If you reload the index, the reports will not be restored.

You can configure the maximum number of stored reports using the [MaxSearchReportCount](https://apireference.groupdocs.com/net/search/groupdocs.search/indexsettings/properties/maxsearchreportcount) property of the [IndexSettings](https://apireference.groupdocs.com/net/search/groupdocs.search/indexsettings) class. The default value is 10. Learn more about index settings on the page [Search index settings]({{< ref "search/net/developer-guide/advanced-usage/creating-an-index/search-index-settings.md" >}}).

Each index search report contains the following information:

*   The start time of the search;
*   The end time of the search;
*   The search duration;
*   The number of documents found;
*   The total number of occurrences found;
*   The search query;
*   The search options.

The following example demonstrates how to get search reports from an index.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";
 
// Creating an index in the specified folder
Index index = new Index(indexFolder);
 
// Indexing documents from the specified folder
index.Add(documentsFolder);
 
// Searching in index
SearchResult result1 = index.Search("Einstein");
SearchResult result2 = index.Search("\"Theory of Relativity\"");
 
// Getting search reports
SearchReport[] reports = index.GetSearchReports();
 
// Printing reports to the console
foreach (SearchReport report in reports)
{
    Console.WriteLine("Query: " + report.TextQuery);
    Console.WriteLine("Time: " + report.StartTime);
    Console.WriteLine("Duration: " + report.SearchDuration);
    Console.WriteLine("Documents: " + report.DocumentCount);
    Console.WriteLine("Occurrences: " + report.OccurrenceCount);
    Console.WriteLine();
}
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
