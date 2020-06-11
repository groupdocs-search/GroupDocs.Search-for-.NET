---
id: groupdocs-search-for-net-17-10-release-notes
url: search/net/groupdocs-search-for-net-17-10-release-notes
title: GroupDocs.Search for .NET 17.10 Release Notes
weight: 3
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 17.10{{< /alert >}}

## Major Features

There are 3 enhancements in this regular monthly release. The most notable are:

SEARCHNET-1188 Implement option to cache document texts with high compression level  
SEARCHNET-1195 Implement safe updating of index files to increase reliability  
SEARCHNET-1211 Implement calling ProgressChanged event for skipped and filtered documents

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-1188 | Implement option to cache document texts with high compression level | Enhancement |
| SEARCHNET-1195 | Implement safe updating of index files to increase reliability | Enhancement |
| SEARCHNET-1211 | Implement calling ProgressChanged event for skipped and filtered documents | Enhancement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Search for .NET 17.10. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Search which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Implement option to cache document texts with high compression level

This feature allows to cache text of indexed documents in index with high compression level.

With high compression level archives takes 33% less of disc space than when using normal compression level.

But indexing time of text documents will be longer by 25%.

**Public API Changes**  
Value **High** has been added to **GroupDocs.Search.Compression** enumeration.

This example shows how to cache text of indexed documents in index:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// Creating indexing settings object
IndexingSettings settings = new IndexingSettings();
// Enabling source document text caching with high compression level
settings.TextStorageSettings = new TextStorageSettings(Compression.High);

// Creating index
Index index = new Index(indexFolder, settings);

// Indexing
index.AddToIndex(documentsFolder);
```

#### Implement safe updating of index files to increase reliability

This enhancement allows to check if critical error has occured and index should be reloaded to continue adding documents, updating, and merging.

If IndexStatus property is set to Failed then index will not perform tasks which change index files.

**Public API Changes  
**None.

This example shows how to check if index should be reloaded:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Indexing
index.AddToIndex(documentsFolder);

// Checking the need to reload
if (index.IndexStatus == IndexStatus.Failed)
{
    // Reloading index
    index = new Index(indexFolder);
}

```

#### Implement calling ProgressChanged event for skipped and filtered documents

This enhancement allows to notify user about status and name of just processed document.

Now ProgressChangedEvent is also raised for skipped and filtered documents.

**Public API Changes**  
Enum **DocumentStatus** has been added to **GroupDocs.Search** namespace.  
Value **SuccessfullyProcessed** has been added to **GroupDocs.Search.DocumentStatus** enum.  
Value **Skipped** has been added to **GroupDocs.Search.DocumentStatus** enum.  
Value **ProcessedWithError** has been added to **GroupDocs.Search.DocumentStatus** enum.  
Property **int SkippedDocumentsCount** has been added to **GroupDocs.Search.Events.OperationProgressEventArgs** class.  
Property **string LastDocumentPath** has been added to **GroupDocs.Search.Events.OperationProgressEventArgs** class.  
Property **DocumentStatus LastDocumentStatus** has been added to **GroupDocs.Search.Events.OperationProgressEventArgs** class.

This example shows how to check skipped document count and how to get just processed document's name and processing result:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";
Index index = new Index(indexFolder);

index.OperationProgressChanged += (sender, args) =>
{
    Console.WriteLine(
       "Document {0}\t{1}\nprocessed {2} of {3} (skipped: {4}\tsuccessfuly processed: {5}\nProgress: {6:F2}%\n",
       args.LastDocumentStatus,
       args.LastDocumentPath,
       args.SkippedDocumentsCount + args.ProcessedDocumentsCount,
       args.TotalDocumentsCount,
       args.SkippedDocumentsCount,
       args.ProcessedDocumentsCount,
       args.ProgressPercentage);
};
index.AddToIndex(documentsFolder);

```
