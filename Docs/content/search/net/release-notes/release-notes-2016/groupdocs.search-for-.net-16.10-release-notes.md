---
id: groupdocs-search-for-net-16-10-release-notes
url: search/net/groupdocs-search-for-net-16-10-release-notes
title: GroupDocs.Search for .NET 16.10 Release Notes
weight: 3
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 16.10{{< /alert >}}

## Major Features

There are 4 features or enhancements in this regular monthly release. The most notable are:

*   Fix Query Parser to parse file names with extensions with one Field Name
*   Add found words to the search results to make it possible to see what exactly was found
*   Improve Indexing and Update functionality to notify user about the progress percentage
*   Implement Exact phrase Search feature

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-470 | Fix Query Parser to parse file names with extensions with one Field Name | Bug |
| SEARCHNET-468 | Add found words to the search results to make it possible to see what exactly was found | Enhancement |
| SEARCHNET-270 | Improve Indexing and Update functionality to notify user about the progress percentage | Enhancement |
| SEARCHNET-449 | Implement Exact phrase Search feature | New Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Search for .NET 16.10.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Search which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Improve Indexing and Update functionality to notify user about the progress percentage

This enhancement allows user to see the progress percentage of indexing or updating.

**C#**

```csharp
string indexFolder = "MyIndex";
string documentsFolder = @"c:\MyDocuments";

Index index = new Index(indexFolder, true);
index.OperationProgressChanged += index_OperationProgressChanged; // event subscribing

index.AddToIndex(documentsFolder);

        ...

void index_OperationProgressChanged(object sender, Events.OperationProgressArg e)
{
	Console.WriteLine("Current progress: {0}\n{1}",e.ProgressPercentage, e.Message); // event argument contains information about the current progress of operation
}

```

### Add found words to the search results to make it possible to see what exactly was found

This enhancement allows the user to see the words from the found documents which satisfy the search query. For example if the user uses fuzzy search or regex search he can get search results containing documents with exactly the same words as in the search query and additionally documents with similar words, not exactly the same as in the query. If the user makes fuzzy search with query "cost" he can get documents with another word, like "coat" or something else depending on fuzziness level. In the search results user can see found words for every found document.

**C#**

```csharp
string indexFolder = @"MyIndex";
string documentsFolder = @"c:\MyDocuments";
string fuzzySearchQuery = "fuzzy query";
string regexSearchQuery = @"^Ride.$";

Index index = new Index(indexFolder, true);
index.AddToIndex(documentsFolder);

SearchParameters fuzzySearchParameters = new SearchParameters();
fuzzySearchParameters.FuzzySearch.Enabled = true;
fuzzySearchParameters.FuzzySearch.SimilarityLevel = 0.6;
SearchResults fuzzySearchResults = index.Search(fuzzySearchQuery, fuzzySearchParameters);

foreach (DocumentResultInfo documentResultInfo in fuzzySearchResults)
{
    Console.WriteLine("Document {0} was found with query \"{1}\"\nWords list that was found in document:", documentResultInfo.FileName, fuzzySearchQuery);
    foreach (string term in documentResultInfo.Terms)
    {
        Console.Write("{0}; ", term);
    }
    Console.WriteLine();
}

SearchResults regexSearchResults = index.Search(regexSearchQuery);

foreach (DocumentResultInfo documentResultInfo in regexSearchResults)
{
    Console.WriteLine("Document {0} was found with query \"{1}\"\nWords list that was found in document:", documentResultInfo.FileName, regexSearchResults);
    foreach (string term in documentResultInfo.Terms)
    {
        Console.Write("{0}; ", term);
    }
    Console.WriteLine();
}

```

### Implementation of Exact Phrase Search Feature

This feature allows user to search by exact phrase.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";;
string searchQuery = "\"exact search query\""; // search query for exact search should be in double quotes

Index index = new Index(indexFolder, true);
index.AddToIndex(documentsFolder);

SearchResults searchResults = index.Search(searchQuery);

```
