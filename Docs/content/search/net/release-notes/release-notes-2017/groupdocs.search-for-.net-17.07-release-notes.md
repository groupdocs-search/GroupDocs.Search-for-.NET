---
id: groupdocs-search-for-net-17-07-release-notes
url: search/net/groupdocs-search-for-net-17-07-release-notes
title: GroupDocs.Search for .NET 17.07 Release Notes
weight: 6
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 17.7{{< /alert >}}

## Major Features

There are 3 features and enhancements in this regular monthly release. The most notable are:

*   SEARCHNET-1059 Implement support for FictionBook (fb2) format
*   SEARCHNET-244 Implement Indexing Report functionality
*   SEARCHNET-242 Implement Search Report functionality

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-1059 | Implement support of FictionBook (fb2) format | New Feature |
| SEARCHNET-244 | Implement Indexing Report functionality | New Feature |
| SEARCHNET-242 | Implement Search Report functionality | New Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Search for .NET 17.7. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Search which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Implement search report functionality

The feature allows making the report with detailed information about searching.

**Public API Changes**  
**SearchingReport** class has been added to **GroupDocs.Search** namespace.  
**SearchingReport\[\] GetSearchingReport()** method has been added to **GroupDocs.Search.Index** class.

Usage:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

Index index = new Index(indexFolder);
index.AddToIndex(documentsFolder);

SearchResults results1 = index.Search(query1, params1);
SearchResults results2 = index.Search(query2, params2);
SearchResults results3 = index.Search(query3, params3);

// Get searching report
SearchingReport[] report = index.GetSearchingReport();

foreach (SearchingReport record in report)
{
  Console.WriteLine("Searching takes {0}, {1} results was found.", record.SearchingTime, record.ResultCount);
}

```

#### Implement indexing report functionality

The feature allows making the report with detailed information about indexing.

**Public API Changes  
****IndexingReport** class has been added to **GroupDocs.Search** namespace.  
**IndexingReport\[\] GetIndexingReport()** method has been added to **GroupDocs.Search.Index** class.

This example demonstrates how to get indexing report:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

Index index = new Index(indexFolder);
index.AddToIndex(documentsFolder);

// Get indexing report
IndexingReport[] report = index.GetIndexingReport();

foreach (IndexingReport record in report)
{
  Console.WriteLine("Indexing takes {0}, index size: {1}.", record.IndexingTime, record.TotalIndexSize);
}

```

#### Implement support for FictionBook (fb2) format

Implemented support of FictionBook (fb2) format.

**Public API Changes**  
Enum value **FictionBook** has been added to **GroupDocs.Search.DocumentType** enum.
