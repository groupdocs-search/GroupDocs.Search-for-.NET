---
id: groupdocs-search-for-net-18-2-release-notes
url: search/net/groupdocs-search-for-net-18-2-release-notes
title: GroupDocs.Search for .NET 18.2 Release Notes
weight: 8
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 18.2.{{< /alert >}}

## Major Features

There are 3 enhancements in this regular monthly release. The most notable are:

*   Implement compact index feature
*   Implement option for multithreaded indexing 
*   Improve index structure to increase indexing speed

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-1157 | Implement compact index feature | Enhancement |
| SEARCHNET-1321 | Implement option for multithreaded indexing | Enhancement |
| SEARCHNET-1414 | Improve index structure to increase indexing speed | Enhancement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Search for .NET 18.2. It includes not only new and obsoleted public methods, but also a description of any changes in the behaviour behind the scenes in GroupDocs.Search which may affect existing code. Any behaviour introduced that could be seen as a regression and modifies existing behaviour is especially important and is documented here.{{< /alert >}}

### Implement compact index feature

##### Description

This feature allows creating index that consumes up to 5 times less disk space.This is possible for the reason of containing the only number of word occurrences without positions. For the same reason index of this type does not support phrase search and date range search.

##### Public API changes

Value **CompactIndex** has been added to **GroupDocs.Search.IndexType** enum.

##### Usecases

This example shows how to create compact index:

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// Creating indexing settings object
IndexingSettings indexingSettings = new IndexingSettings();
// Setting compact index type
indexingSettings.IndexType = IndexType.CompactIndex;

// Creating index
Index index = new Index(indexFolder, indexingSettings);

// Indexing
index.AddToIndex(documentsFolder);

// Searching
SearchResults result = index.Search("Einstein");
```

### Implement option for multithreaded indexing

##### Description

This enhancement allows performing indexing in multiple threads. Multithreaded indexing is faster, but uses more memory and may cause memory overflow error. If you have only 8 GB of RAM installed it is recommended to use not more than 2 threads for indexing. If you have 16 GB of RAM installed you can use 4 threads for indexing. Note that there is a restriction on the use of more than 4 threads.

##### Public API changes

Method **void AddToIndex(string, int)** has been added to **GroupDocs.Search.Index** class.  
Method **void AddToIndex(string, int, bool)** has been added to **GroupDocs.Search.Index** class.  
Method **void AddToIndexAsync(string, int)** has been added to **GroupDocs.Search.Index** class.  
Method **void AddToIndexAsync(string, int, bool)** has been added to **GroupDocs.Search.Index** class.  
Method **void AddToIndex(string\[\], int)** has been added to **GroupDocs.Search.Index** class.  
Method **void AddToIndex(string\[\], int, bool)** has been added to **GroupDocs.Search.Index** class.  
Method **void AddToIndexAsync(string\[\], int)** has been added to **GroupDocs.Search.Index** class.  
Method **void AddToIndexAsync(string\[\], int, bool)** has been added to **GroupDocs.Search.Index** class.

##### Usecases

This example shows how to run multithreaded indexing synchronously:

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Indexing in 2 threads
index.AddToIndex(documentsFolder, 2);

// Searching
SearchResults result = index.Search("Einstein");
```

This example shows how to run multithreaded indexing asynchronously:

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Indexing in 2 threads
index.AddToIndexAsync(documentsFolder, 2);

// User can perform a search after the completion of the indexing operation
```

### Improve index structure to increase indexing speed

##### Description

This enhancement is implemented to increase indexing performance. As a result, the performance of single-threaded indexing has been improved by about 8%.

##### Public API changes

None.

##### Usecases

None.
