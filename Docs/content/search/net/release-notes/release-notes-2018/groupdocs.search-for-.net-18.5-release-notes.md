---
id: groupdocs-search-for-net-18-5-release-notes
url: search/net/groupdocs-search-for-net-18-5-release-notes
title: GroupDocs.Search for .NET 18.5 Release Notes
weight: 6
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 18.5.{{< /alert >}}

## Major Features

There are 3 enhancements in this regular monthly release:

*   Implement searching by parts
*   Implement ability to specify the number of searching threads
*   Add SearchingTime field to SearchResults

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-1207 | Implement searching by parts | Enhancement |
| SEARCHNET-1502 | Implement ability to specify the number of searching threads | Enhancement |
| SEARCHNET-1551 | Add SearchingTime field to SearchResults | Enhancement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Search for .NET 18.5. It includes not only new and obsoleted public methods, but also a description of any changes in the behaviour behind the scenes in GroupDocs.Search which may affect existing code. Any behaviour introduced that could be seen as a regression and modifies existing behaviour is especially important and is documented here.{{< /alert >}}

### Implement searching by parts

##### Description

This enhancement allows a user to run searching by parts (chunks). In huge indexes for terabytes of documents the search executes not immediately and can take some time. Searching by parts (chunks) makes it possible to get part of results much faster.

##### Public API changes

Class **ChunkSearchToken** has been added to **GroupDocs.Search** namespace.  
Property **ChunkSearchToken NextChunkSearchToken** has been added to **GroupDocs.Search.SearchResults** class.  
Property **bool IsChunkSearch** has been added to **GroupDocs.Search.SearchParameters** class.  
Method **Search(ChunkSearchToken)** has been added to **GroupDocs.Search.Index** class.  
Method **Search(ChunkSearchToken, Cancellation)** has been added to **GroupDocs.Search.Index** class.

##### Usecases

This example shows how to perform the search of all chunks consistently:

**C#**

```csharp
string indexFolder = "c:\\MyIndex\\";
string documentFolder1 = "c:\\MyDocuments1\\";
string documentFolder2 = "c:\\MyDocuments2\\";
string documentFolder3 = "c:\\MyDocuments3\\";
string query = "query";

Index index = new Index(indexFolder, true);

index1.AddToIndex(documentFolder1);
index1.AddToIndex(documentFolder2);
index1.AddToIndex(documentFolder3);

SearchParameters sp = new SearchParameters();
sp.IsChunkSearch = true;

SearchResults result = index.Search("query", sp);
int chankCount = 1;

while (result.NextChunkSearchToken != null)
{
    Console.WriteLine("Document count " + chankCount + " ('" + query + "'): " + result.Count);
    Console.WriteLine("Occurrence count " + chankCount + " ('" + query + "'): " + result.TotalHitCount);

    result = index.Search(result.NextChunkSearchToken);
    chankCount++;
}
```

### Implement ability to specify the number of searching threads

##### Description

This enhancement allows user to specify number of searching threads.

##### Public API changes

Enum **NumberOfThreads** has been added to **GroupDocs.Search** namespace.  
Property **NumberOfThreads** SearchingThreads has been added to **GroupDocs.Search.SearchParameters** class.  
**NumberOfThreads** contains the following values:

*   Default
*   One
*   Two
*   Three
*   Four
*   Five
*   Six
*   Seven
*   Eight

##### Usecases

This example shows how to specify the number of searching threads for index:

**C#**

```csharp
string indexFolder = "c:\\MyIndex\\";
string documentFolder = "c:\\MyDocuments\\";
string query = "query";

IndexingSettings settings = new IndexingSettings();
// specifying count of threads for searching
settings.SearchingThreads = NumberOfThreads.One;

Index index = new Index(indexFolder, true, settings);
index.AddToIndex(documentFolder);

// searching using specified above count of threads
SearchResults result = index.Search("query");
```

### Add SearchingTime field to SearchResults

##### Description

This enhancement allows a user to see in search results the time when searching started and finished and total searching time.

##### Public API changes

Field **DateTime StartTime** has been added to **GroupDocs.Search.SearchResults** class.  
Field **DateTime EndTime** has been added to **GroupDocs.Search.SearchResults** class.  
Field **TimeSpan SearchingTime** has been added to **GroupDocs.Search.SearchResults** class.

##### Usecases

This example shows how to use fields with searching time:

**C#**

```csharp
string indexFolder = "c:\\MyIndex\\";
string documentFolder = "c:\\MyDocuments\\";
string query = "query";

Index index = new Index(indexFolder, true);
index.AddToIndex(documentFolder);
SearchResults result = index.Search(query);

Console.WriteLine("Searching starts: {0}\nSearching ends: {1}\tSearching time: {2}", result.StartTime, result.EndTime, result.SearchingTime);
```
