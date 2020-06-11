---
id: groupdocs-search-for-net-17-04-release-notes
url: search/net/groupdocs-search-for-net-17-04-release-notes
title: GroupDocs.Search for .NET 17.04 Release Notes
weight: 9
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 17.4{{< /alert >}}

## Major Features

There are 2 features bug fixes and enhancements in this regular monthly release. The most notable are:

*   SEARCHNET-457 Implement using Dates Ranges in search
*   SEARCHNET-905 Implement definition of TableDiscreteFunction class as step function

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-457 | Implement using Dates Ranges in search | New Feature |
| SEARCHNET-905 | Implement definition of TableDiscreteFunction class as step function | New Feature |

##   
Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Search for .NET 17.4. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Search which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Implement using Dates Ranges in Search

This feature allows the user to search in the range between two dates.  
Date range search can be combined with the faceted search to search in chosen fields.  
Supported date format for query: "M.d.yyyy"  
Supported date formats in documents:

*   dd.mm.yyyy
*   dd-mm-yyyy
*   dd/mm/yyyy
*   mm.dd.yyyy
*   mm-dd-yyyy
*   mm/dd/yyyy
*   yyyy MMMM dd
*   dd MMM dd

**Public API Changes**  
None.

This example shows how to use date range search:

**C#**

```csharp
Index index = new Index(@"c:\MyIndex\");
index.AddToIndex(@"c:\MyDocuments");

// This query will find all dates between beginning of 2000 year and ending of 2017 in any documents fields // (content, creation date, modification date and other). 
SearchResults results = index.Search("daterange(1.1.2015~~12.31.2017)");

```

This example shows how to use date range search with faceted search:

**C#**

```csharp
Index index = new Index(@"c:\MyIndex\");
index.AddToIndex(@"c:\MyDocuments");

// This query will find all dates between beginning of 2000 year and ending of 2017 only in documents content. 
SearchResults results = index.Search("content:daterange(1.1.2015~~12.31.2017)");

```

#### Implement definition of TableDiscreteFunction class as step function

This feature represents a convenient way to define table discrete function as a step function.

**Public API Changes**  
Class **Step** has been added to **GroupDocs.Search** namespace.  
Constructor **TableDiscreteFunction(int firstStepLevel, params Step\[\] steps)** has been added to **GroupDocs.Search.TableDiscreteFunction** class.

This example shows how to define table discrete function as step function:

**C#**

```csharp
var table1 = new TableDiscreteFunction(3, new int[] { 0, 1, 1, 2, 3 }); 
// Defining as table function 
var table2 = new TableDiscreteFunction(0, new Step(4, 1), new Step(6, 2), new Step(7, 3)); // Defining as step function 
// Both of these functions return 0 when input value is 3 or less, 
// return 1 when input value is 4 or 5, 
// return 2 when input value is 6, 
// and return 3 when input value is 7 or greater.

```

This example shows how to define the constant function:

**C#**

```csharp
var table = new TableDiscreteFunction(2); // This function returns 2 for terms of any length

```

This example shows how to use step function in fuzzy search:

**C#**

```csharp
string documentsFolder = @"c:\MyDocuments\";
string indexFolder = @"c:\MyIndex\";
Index index = new Index(indexFolder);
index.AddToIndex(documentsFolder);

TableDiscreteFunction adaptiveDiscreteFunction = new TableDiscreteFunction(0, new Step(4, 1), new Step(5, 2), new Step(6, 3));
// Function returns 0 mistakes for words of less than 4 characters, // 1 mistake for words of 4 characters, // 2 mistakes for words of 5 characters, // and 3 mistakes for words of 6 and more characters 
SearchParameters adaptiveSearchParameters = new SearchParameters();
adaptiveSearchParameters.FuzzySearch.Enabled = true;
adaptiveSearchParameters.FuzzySearch.FuzzyAlgorithm = adaptiveDiscreteFunction;
// Fuzzy search will allow 1 mistake for "user" word, 2 mistakes for "query" word and 3 mistakes for "search" word 
SearchResults adaptiveResults = index.Search("user search query", adaptiveSearchParameters);

TableDiscreteFunction constanDiscreteFunction = new TableDiscreteFunction(2);
// Function returns 2 mistakes for word of any length
SearchParameters constantSearchParameters = new SearchParameters();
constantSearchParameters.FuzzySearch.Enabled = true;
constantSearchParameters.FuzzySearch.FuzzyAlgorithm = constanDiscreteFunction;
// Fuzzy search will allow 2 mistakes for all three words in query
SearchResults constantResults = index.Search("user search query", constantSearchParameters);

```
