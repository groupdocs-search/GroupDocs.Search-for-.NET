---
id: groupdocs-search-for-net-20-6-release-notes
url: search/net/groupdocs-search-for-net-20-6-release-notes
title: GroupDocs.Search for .NET 20.6 Release Notes
weight: 3
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 20.6{{< /alert >}}

## Major Features

There are the following new features in this release:

*   Support Linux for GroupDocs.Search for .NET Core
*   Improve formatting of text extracted from index

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-2190 | Support Linux for GroupDocs.Search for .NET Core | Improvement |
| SEARCHNET-2278 | Improve formatting of text extracted from index | Improvement |

## Public API and Backward Incompatible Changes

### Support Linux for GroupDocs.Search for .NET Core

This investigation confirms the ability of the .NET Core assembly to work in Linux. The following issues are known:

*   There is no support for the .MHTML (.MHT) format in Linux.
*   There is no support for the .ONE format in Linux.

##### Public API changes

None.

##### Use cases

None.

### Improve formatting of text extracted from index

This improvement allows you to choose between two alternatives:

1.  Indexing is faster, but with loss of formatting quality in some cases (mostly relevant for PDF format).
2.  Improve the formatting of text extracted during indexing, but with loss of indexing speed (mainly relevant for the PDF format).

By default, the raw mode is used if possible.

##### Public API changes 

Property **bool UseRawTextExtraction** has been added to **GroupDocs.Search.IndexSettings** class.

##### Use cases 

The following example demonstrates how to disable raw text extraction mode to improve formatting of extracted text:


```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";
 
// Setting not to use of raw text extraction mode
IndexSettings settings = new IndexSettings();
settings.UseRawTextExtraction = false;
 
// Creating an index
Index index = new Index(indexFolder, settings);
 
// Indexing documents in the document folder
index.Add(documentFolder);
```