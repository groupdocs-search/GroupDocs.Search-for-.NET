---
id: groupdocs-search-for-net-17-11-release-notes
url: search/net/groupdocs-search-for-net-17-11-release-notes
title: GroupDocs.Search for .NET 17.11 Release Notes
weight: 2
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 17.11{{< /alert >}}

## Major Features

There are 3 enhancements and features in this regular monthly release. The most notable are:

*   Implement support of MSG, EML, EMLX file formats.
*   Improve indexing performance for Pdf documents.
*   Implement Metadata Index feature.

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-1238 | Implement support of MSG, EML, EMLX file formats | Enhancement |
| SEARCHNET-1257 | Improve indexing performance for Pdf documents | Enhancement |
| SEARCHNET-248 | Implement Metadata Index feature | New Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Search for .NET 17.11. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Search which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Implement support of MSG, EML, EMXL file formats

Previously, API allows to index email messages from Microsoft Outlook files (PST and OST). All search results found in OST or PST files are stored in **OutlookEmailMessageResultInfo**. Now in this enhancement supports for indexing of email messages in MSG, EML, EMXL file formats.

##### Public API changes

None.

Following is the code to index email messages:

**C#**

```csharp
// Create or load index
Index index = new Index(Utilities.indexPath);
index.AddToIndex(Utilities.documentsPath); // Documents with "MSG", "EML", "EMXL" extension will be indexed
SearchResults searchResults = index.Search(searchString);
```

#### Improve indexing performance for Pdf documents

Performance of indexing of PDF documents is improved in this enhancement.

##### Public API changes

None.

#### Implement MetaData Index

This feature allows indexing only metadata of documents.Metadata index contains only metadata (file name, creation date, and modification date).

##### Public API changes

Enum **IndexType** has been added to **GroupDocs.Search** namespace.  
Value **Normal** has been added to **GroupDocs.Search.IndexType** enum.  
Value **MetadataIndex** has been added to **GroupDocs.Search.IndexType** enum.  
Property **IndexType IndexType** has been added to **GroupDocs.Search.IndexingSettings** class.

Following is the code shows how to create metadata index:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";
// Creating indexing settings object
IndexingSettings settings = new IndexingSettings();
settings.IndexType = IndexType.MetadataIndex;

// Creating index
Index index = new Index(indexFolder, settings);

// Indexing
index.AddToIndex(documentsFolder);
```
