---
id: indexing-reports
url: search/net/indexing-reports
title: Indexing reports
weight: 14
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
Indexing reports are created for indexing and updating operations. Indexing reports can be retrieved from the index using the [GetIndexingReports](https://apireference.groupdocs.com/net/search/groupdocs.search/index/methods/getindexingreports) method. Reports are stored in the index only while the index is loaded into RAM for use. If you reload the index, the reports will not be restored.

You can configure the maximum number of stored reports using the [MaxIndexingReportCount](https://apireference.groupdocs.com/net/search/groupdocs.search/indexsettings/properties/maxindexingreportcount) property of the [IndexSettings](https://apireference.groupdocs.com/net/search/groupdocs.search/indexsettings) class. The default value is 5. Learn more about index settings on the page [Search index settings]({{< ref "search/net/developer-guide/advanced-usage/creating-an-index/search-index-settings.md" >}}.

Each index report contains the following information:

*   The total number of documents in the index;
*   The total number of words in the index;
*   The total length of indexed documents in MB;
*   Number of index segments;
*   The total size of the index on disk in bytes;
*   The indexing start time;
*   The indexing end time;
*   The indexing duration;
*   List of errors;
*   List of indexed documents;
*   List of updated documents;
*   List of removed documents.

The following example demonstrates how to get indexing reports from an index.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder1 = @"c:\MyDocuments1\";
string documentsFolder2 = @"c:\MyDocuments2\";
 
// Creating an index in the specified folder
Index index = new Index(indexFolder);
 
// Indexing documents
index.Add(documentsFolder1);
index.Add(documentsFolder2);
 
// Getting indexing reports
IndexingReport[] reports = index.GetIndexingReports();
 
// Printing information from reports to the console
foreach (IndexingReport report in reports)
{
    Console.WriteLine("Time: " + report.StartTime);
    Console.WriteLine("Duration: " + report.IndexingTime);
    Console.WriteLine("Documents total: " + report.TotalDocumentsInIndex);
    Console.WriteLine("Terms total: " + report.TotalTermCount);
    Console.WriteLine("Indexed documents size (MB): " + report.IndexedDocumentsSize);
    Console.WriteLine("Index size (MB): " + (report.TotalIndexSize / 1024.0 / 1024.0));
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
