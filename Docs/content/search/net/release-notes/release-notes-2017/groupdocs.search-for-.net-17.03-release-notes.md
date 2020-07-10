---
id: groupdocs-search-for-net-17-03-release-notes
url: search/net/groupdocs-search-for-net-17-03-release-notes
title: GroupDocs.Search for .NET 17.03 Release Notes
weight: 10
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 17.3{{< /alert >}}

## Major Features

There are 9 features bug fixes and enhancements in this regular monthly release. The most notable are:

*   Implement optimization of fuzzy search
*   Implement optimization of regex search
*   Implement flow for support all methods in previous index versions
*   Implement Numeric Range search feature
*   Implement function that is a relation between max mistake count and word length for Fuzzy Search
*   Implement limitation for number of search results

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-887 | Implement optimization of fuzzy search | Enhancement |
| SEARCHNET-888 | Implement optimization of regex search | Enhancement |
| SEARCHNET-799 | Implement flow for support all methods in previous index versions | New Feature |
| SEARCHNET-230 | Implement Numeric Range search feature | New Feature |
| SEARCHNET-709 | Implement function that is a relation between max mistake count and word length for Fuzzy Search | New Feature |
| SEARCHNET-845 | Implement limitation for number of search results | New Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Search for .NET 17.3. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Search which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Implement Flow for Support All Methods in Previous Index Versions

This feature allows using some features in old versions of the index by the new simplified procedure of updating any old index to the new version of it.  
Only search functionality supported for old index version. Merging and adding new documents to the index is not supported.

There are two ways to update index up to actual version:

Run **index.Update()** method  
Run any of AddToIndex or Merge methods with true in **updateIfNecessary** parameter

**Public API Changes**  
Method **AddToIndex(string item, bool updateIfNecessary)** has been added to **GroupDocs.Search.Index** class.  
Method **AddToIndexAsync(string item, bool updateIfNecessary)** has been added to **GroupDocs.Search.Index** class.  
Method **AddToIndex(string\[\] items, bool updateIfNecessary)** has been added to **GroupDocs.Search.Index** class.  
Method **AddToIndexAsync(string\[\] items, bool updateIfNecessary)** has been added to **GroupDocs.Search.Index** class.  
Method **Merge(bool updateIfNecessary)** has been added to **GroupDocs.Search.Index** class.  
Method **Merge(Index mergedIndex, bool updateIfNecessary)** has been added to **GroupDocs.Search.Index** class.  
Method **Merge(IndexRepository repository, bool updateIfNecessary)** has been added to **GroupDocs.Search.Index** class.  
Method **MergeAsync(bool updateIfNecessary)** has been added to **GroupDocs.Search.Index** class.  
Method **MergeAsync(Index mergedIndex, bool updateIfNecessary)** has been added to **GroupDocs.Search.Index** class.  
Method **MergeAsync(IndexRepository repository, bool updateIfNecessary)** has been added to **GroupDocs.Search.Index** class.

This is the example how to add documents to old version index:

**C#**

```csharp
// This index should be exist and should have one of previous version
string oldIndexFolder = @"c:\MyOldIndex";
string documentsFolder = @"c:\MyNewDocuments";

// Load index
Index index = new Index(oldIndexFolder);
// Add documents to index. Index will be updated to actual version before adding new documents.
index.AddToIndex(documentsFolder, true);


```

#### Implement Numeric Range Search Feature

This feature allows users searching a certain range of numbers within the index.

This example shows how to run numeric range search:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";
// Numeric range query for searching any number in range beetween 13 and 42
string query = "13~~42";

Index index = new Index(indexFolder);
index.AddToIndex(documentsFolder);

// Search for numbers
SearchResults results = index.Search(query);


```

#### Implement Function That is a Relation Between Max Mistake Count and Word Length for Fuzzy Search

This feature allows specifying a discrete function that returns max mistake count for each word length and uses this function during the fuzzy search.  
This feature was designed for advanced scenarios and allows to apply fine-grained settings to control the balance between fuzzy search algorithm accuracy and performance.

**Public API Changes**  
Class **FuzzyAlgorithm** has been added to **GroupDocs.Search** namespace.  
Class **SimilarityLevel** has been added to **GroupDocs.Search** namespace.  
Class **TableDiscreteFunction** has been added to **GroupDocs.Search** namespace.  
Property **GroupDocs.Search.FuzzyAlgorithm FuzzyAlgorithm** has been added to **GroupDocs.Search.FuzzySearchParameters** class.  
Property **double SimilarityLevel** in class **GroupDocs.Search.FuzzySearchParameters** has been marked as obsolete.

This example shows how to use max mistake count function as a fuzzy algorithm:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";
string query = "discree";

Index index = new Index(indexFolder);
index.AddToIndex(documentsFolder);

SearchParameters parameters = new SearchParameters();
// Turning on fuzzy search feature
parameters.FuzzySearch.Enabled = true;
 // Setting up fuzzy algorithm
parameters.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(3, new int[] { 0, 1, 1, 2 });
// This function returns 0 when input value is 3 or less,
// returns 1 when input value is 4 or 5,
// and returns 2 when input value is 6 or greater.

// Search for "discree" with a maximum of 2 mistakes
SearchResults results = index.Search(query, parameters);

```

This example shows how to use the constant value of max mistake count for each term in query regardless of its length:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";
string query = "discree";

Index index = new Index(indexFolder);
index.AddToIndex(documentsFolder);

SearchParameters parameters = new SearchParameters();
// Turning on fuzzy search feature
parameters.FuzzySearch.Enabled = true;
// This function returns 2 for terms of any length
parameters.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(0, new int[] { 2 });

// Search for "discree" with a maximum of 2 mistakes
SearchResults results = index.Search(query, parameters);

```

This example shows how to use similarity level object as a fuzzy algorithm:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";
string query = "discree";

Index index = new Index(indexFolder);
index.AddToIndex(documentsFolder);

SearchParameters parameters = new SearchParameters();
 // Turning on fuzzy search feature
parameters.FuzzySearch.Enabled = true;
// Setting up fuzzy algorithm
parameters.FuzzySearch.FuzzyAlgorithm = new SimilarityLevel(0.7);

// Search for "discree" with a maximum of 2 mistakes
SearchResults results = index.Search(query, parameters);

```

#### Implement Limitation for Number of Search Results

This feature allows the limited number of search results for each term in a query and number of total search results.  
Limitation the number of search results allows to decrease search time and prevent out of memory error when the number of results is very large.

**Public API Changes**  
Property **int MaxHitCountPerTerm** has been added to **GroupDocs.Search.SearchParameters** class.  
Property **int MaxTotalHitCount** has been added to **GroupDocs.Search.SearchParameters** class.  
Property **bool Truncated** has been added to **GroupDocs.Search.SearchResults** class.  
Property **string Message** has been added to **GroupDocs.Search.SearchResults** class.

This example shows how to limit the number of search results:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";
string query = "discrete";

Index index = new Index(indexFolder);
index.AddToIndex(documentsFolder);

SearchParameters parameters = new SearchParameters();
parameters.MaxHitCountPerTerm = 200; // Setting the limitation of result count for each term in a query. The default value is 100000.
parameters.MaxTotalHitCount = 800; // Setting the limitation of total result count for a query. The default value is 500000.

SearchResults results = index.Search(query, parameters); // Search for "discrete" with limitation of 200 occurrences
if (results.Truncated)
{
    Console.WriteLine(results.Message);
}

```
