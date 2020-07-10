---
id: groupdocs-search-for-net-16-11-release-notes
url: search/net/groupdocs-search-for-net-16-11-release-notes
title: GroupDocs.Search for .NET 16.11 Release Notes
weight: 2
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 16.11{{< /alert >}}

## Major Features

There is one feature in this regular monthly release:

*   Implement Case sensitive search feature

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-452 | Implement Case sensitive search feature | New Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Search for .NET 16.11.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Search which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Implement Case Sensitive Search Feature

This feature allows using a case sensitive search.

**C#**

```csharp
            string indexFolder = @"MyIndex";
            string documentsFolder = @"c:\MyDocuments";
            string caseSensitiveSearchQuery = "Case Sensitive Search Query";

            bool inMemoryIndex = false;
            bool caseSensitive = true;
            IndexingSettings settings = new IndexingSettings(inMemoryIndex, caseSensitive);

            Index index = new Index(indexFolder, settings);
            index.AddToIndex(documentsFolder);

            SearchParameters parameters = new SearchParameters();
            parameters.UseCaseSensitiveSearch = true; // using case sensitive search feature

            SearchResults searchResults = index.Search(caseSensitiveSearchQuery, parameters);


```
