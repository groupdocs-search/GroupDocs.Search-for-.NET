---
id: groupdocs-search-for-net-18-01-release-notes
url: search/net/groupdocs-search-for-net-18-01-release-notes
title: GroupDocs.Search for .NET 18.01 Release Notes
weight: 9
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 18.01.{{< /alert >}}

## Major Features

There are 5 enhancements in this regular monthly release. The most notable are::

*   Implement breaking of search process 
*   Implement search method with query in the form of an object tree as a parameter 
*   Implement ability to set a collection of date formats for date range search 
*   Change date format in date range search query in accordance with ISO 8601 
*   Implement use of wildcards in phrase search

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-1100 | Implement breaking of search process | Enhancement |
| SEARCHNET-1204 | Implement search method with query in the form of an object tree as a parameter | Enhancement |
| SEARCHNET-1319 | Implement ability to set a collection of date formats for date range search | Enhancement |
| SEARCHNET-1320 | Change date format in date range search query in accordance with ISO 8601 | Enhancement  |
| SEARCHNET-1299 | Implement use of wildcards in phrase search | Enhancement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Search for .NET 18.01. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Search which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Implement breaking of search process

##### Description

This enhancement is implemented for the possibility of canceling the search operation by request and for time limitation of searching.

##### Public API changes

Class **Cancellation** has been added to **GroupDocs.Search** namespace.  
Property **bool IsCancelled** has been added to **GroupDocs.Search.Cancellation** class.  
Method **void Cancel()** has been added to **GroupDocs.Search.Cancellation** class.  
Method **void CancelAfter(int)** has been added to **GroupDocs.Search.Cancellation** class.

Method **SearchResults Search(string, SearchParameters, Cancellation)** has been added to **GroupDocs.Search.Index** class.  
Method **SearchResults Search(SearchQuery, SearchParameters, Cancellation)** has been added to **GroupDocs.Search.Index** class.

Method **SearchResults Search(string, SearchParameters, Cancellation)** has been added to **GroupDocs.Search.IndexRepository** class.  
Method **SearchResults Search(SearchQuery, SearchParameters, Cancellation)** has been added to **GroupDocs.Search.IndexRepository** class.

##### Usecases

This example shows how to cancel the search operation by request:

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Indexing
index.AddToIndex(documentsFolder);

// Creating cancellation object
Cancellation cancellation = new Cancellation();
// Imitating cancelling by request
Thread thread = new Thread(() =>
{
    // Cancelling after 1 second of searching
    Thread.Sleep(1000);
    cancellation.Cancel();
});
thread.Start();

// Creating search parameters object
SearchParameters searchParameters = new SearchParameters();
searchParameters.FuzzySearch.Enabled = true;
searchParameters.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(3);

// Searching
SearchResults result = index.Search("\"information technology\"", searchParameters, cancellation);
```

This example shows how to search with time limitation:

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Indexing
index.AddToIndex(documentsFolder);

// Creating cancellation object
Cancellation cancellation = new Cancellation();
// Cancelling after 1 second of searching
cancellation.CancelAfter(1000);

// Creating search parameters object
SearchParameters searchParameters = new SearchParameters();
searchParameters.FuzzySearch.Enabled = true;
searchParameters.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(3);

// Searching
SearchResults result = index.Search("\"information technology\"", searchParameters, cancellation);
```

### Implement search method with query in the form of an object tree as a parameter

##### Description

This enhancement facilitates the creation of complex queries and reduces the number of errors in queries. In addition, it is a more flexible way to create queries.

##### Public API changes

Class **SearchQuery** has been added to **GroupDocs.Search** namespace.  
Property **string FieldName** has been added to **GroupDocs.Search.SearchQuery** class.  
Property **int ChildCount** has been added to **GroupDocs.Search.SearchQuery** class.  
Property **SearchQuery FirstChild** has been added to **GroupDocs.Search.SearchQuery** class.  
Property **SearchQuery SecondChild** has been added to **GroupDocs.Search.SearchQuery** class.  
Property **SearchParameters SearchParameters** has been added to **GroupDocs.Search.SearchQuery** class.  
Method **SearchQuery CreateWordQuery(string)** has been added to **GroupDocs.Search.SearchQuery** class.  
Method **SearchQuery CreateRegexQuery(string, RegexOptions)** has been added to **GroupDocs.Search.SearchQuery** class.  
Method **SearchQuery CreateNumericRangeQuery(long, long)** has been added to **GroupDocs.Search.SearchQuery** class.  
Method **SearchQuery CreateDateRangeQuery(DateTime, DateTime)** has been added to **GroupDocs.Search.SearchQuery** class.  
Method **SearchQuery CreatePhraseSearchQuery(SearchQuery\[\])** has been added to **GroupDocs.Search.SearchQuery** class.  
Method **SearchQuery CreateFieldQuery(string, SearchQuery)** has been added to **GroupDocs.Search.SearchQuery** class.  
Method **SearchQuery CreateNotQuery(SearchQuery)** has been added to **GroupDocs.Search.SearchQuery** class.  
Method **SearchQuery CreateAndQuery(SearchQuery, SearchQuery)** has been added to **GroupDocs.Search.SearchQuery** class.  
Method **SearchQuery CreateOrQuery(SearchQuery, SearchQuery)** has been added to **GroupDocs.Search.SearchQuery** class.

Property **SearchQuery SearchQuery** has been added to **GroupDocs.Search.SearchingReport** class.

Method **SearchResults Search(SearchQuery, SearchParameters)** has been added to **GroupDocs.Search.Index** class.  
Method **SearchResults Search(SearchQuery, SearchParameters)** has been added to **GroupDocs.Search.IndexRepository** class.

##### Usecases

This example shows how to perform search with query in the object tree form:

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Indexing
index.AddToIndex(documentsFolder);

// Creating subquery 1
SearchQuery subquery1 = SearchQuery.CreateWordQuery("future");
subquery1.SearchParameters = new SearchParameters();
subquery1.SearchParameters.FuzzySearch.Enabled = true;
subquery1.SearchParameters.FuzzySearch.ConsiderTranspositions = true;
subquery1.SearchParameters.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(3);

// Creating subquery 2
SearchQuery subquery2 = SearchQuery.CreateNumericRangeQuery(1, 1000000);

// Creating subquery 3
SearchQuery subquery3 = SearchQuery.CreateRegexQuery(@"(.)\1");

// Combining subqueries into one query
SearchQuery query = SearchQuery.CreatePhraseSearchQuery(subquery1, subquery2, subquery3);

// Creating search parameters object with increased capacity of results
SearchParameters searchParameters = new SearchParameters();
searchParameters.MaxHitCountPerTerm = 1000000;
searchParameters.MaxTotalHitCount = 10000000;

// Searching
SearchResults result = index.Search(query, searchParameters);

// The results may contain the following word sequences:
// futile 12 blessed
// father 7 excellent
// tyre 8 assyria
// return 147 229
```

### Change date format in date range search query in accordance with ISO 8601

##### Description

This enhancement is implemented to be closer to international standards.  
The new date format is 'yyyy-MM-dd'.

##### Public API changes

None.

##### Usecases

This example shows how to perform date range search with new date format:

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Indexing
index.AddToIndex(documentsFolder);

// Searching
SearchResults result = index.Search("daterange(2015-10-25~~2017-01-03)");

```

### Implement ability to set a collection of date formats for date range search

##### Description

This enhancement provides the ability to set a collection of date formats for date range search.  
The default collection contains three date formats: 'dd.MM.yyyy', 'MM/dd/yyyy', 'yyyy-MM-dd'.

##### Public API changes

Class **DateFormatElement** has been added to **GroupDocs.Search** namespace.  
Property **string Format** has been added to **GroupDocs.Search.DateFormatElement** class.  
Property **string SingleFormat** has been added to **GroupDocs.Search.DateFormatElement** class.  
Property **string DateSeparator** has been added to **GroupDocs.Search.DateFormatElement** class.  
Property **DateFormatElement DayOfMonth** has been added to **GroupDocs.Search.DateFormatElement** class.  
Property **DateFormatElement DayOfMonthTwoDigits** has been added to **GroupDocs.Search.DateFormatElement** class.  
Property **DateFormatElement Month** has been added to **GroupDocs.Search.DateFormatElement** class.  
Property **DateFormatElement MonthTwoDigits** has been added to **GroupDocs.Search.DateFormatElement** class.  
Property **DateFormatElement MonthAbbreviatedName** has been added to **GroupDocs.Search.DateFormatElement** class.  
Property **DateFormatElement MonthFullName** has been added to **GroupDocs.Search.DateFormatElement** class.  
Property **DateFormatElement Year** has been added to **GroupDocs.Search.DateFormatElement** class.  
Property **DateFormatElement YearTwoDigits** has been added to **GroupDocs.Search.DateFormatElement** class.  
Property **DateFormatElement YearFourDigits** has been added to **GroupDocs.Search.DateFormatElement** class.

Class **DateFormat** has been added to **GroupDocs.Search** namespace.  
Property **string DateSeparator** has been added to **GroupDocs.Search.DateFormat** class.

Class **DateFormatCollection** has been added to **GroupDocs.Search** namespace.  
Property **int Count** has been added to **GroupDocs.Search.DateFormatCollection** class.  
Property **bool IsReadOnly** has been added to **GroupDocs.Search.DateFormatCollection** class.  
Method **void Add(DateFormat)** has been added to **GroupDocs.Search.DateFormatCollection** class.  
Method **void Clear()** has been added to **GroupDocs.Search.DateFormatCollection** class.  
Method **void Contains(DateFormat)** has been added to **GroupDocs.Search.DateFormatCollection** class.  
Method **void CopyTo(DateFormat\[\], int)** has been added to **GroupDocs.Search.DateFormatCollection** class.  
Method **void Remove(DateFormat)** has been added to **GroupDocs.Search.DateFormatCollection** class.  
Method **void GetEnumerator()** has been added to **GroupDocs.Search.DateFormatCollection** class.

Property **DateFormatCollection DateFormats** has been added to **GroupDocs.Search.SearchParameters** class.

##### Usecases

This example shows how to set custom collection of date formats and perform date range search:

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Indexing
index.AddToIndex(documentsFolder);

// Creating search parameters object
SearchParameters searchParameters = new SearchParameters();

// Deleting default formats
searchParameters.DateFormats.Clear();

// Adding format 'MM/dd/yyyy'
DateFormatElement[] formatElements1 = new DateFormatElement[]
{
    DateFormatElement.MonthTwoDigits,
    DateFormatElement.DateSeparator,
    DateFormatElement.DayOfMonthTwoDigits,
    DateFormatElement.DateSeparator,
    DateFormatElement.YearFourDigits,
};
DateFormat format1 = new DateFormat(formatElements1, "/");
searchParameters.DateFormats.Add(format1);

// Adding format 'dd.MM.yyyy'
DateFormatElement[] formatElements2 = new DateFormatElement[]
{
    DateFormatElement.DayOfMonthTwoDigits,
    DateFormatElement.DateSeparator,
    DateFormatElement.MonthTwoDigits,
    DateFormatElement.DateSeparator,
    DateFormatElement.YearFourDigits,
};
DateFormat format2 = new DateFormat(formatElements2, ".");
searchParameters.DateFormats.Add(format2);

// Searching
SearchResults result = index.Search("daterange(1991-11-24~~1992-12-25)", searchParameters);
```

### Implement use of wildcards in phrase search

##### Description

This enhancement is implemented to make it possible to search phrase with wildcards.  
Syntax in text form query:  
\***D**  
or  
\***N**~~**M**,  
where **D** is constant distance between consecutive terms in phrase; **N** is minimal value of variable distance; **M** is maximal value of variable distance. All values **D**, **N**, and **M** must be in the range from 0 to 255.

##### Public API changes

Method **SearchQuery CreateWildcardQuery(byte)** has been added to **GroupDocs.Search.SearchQuery** class.  
Method **SearchQuery CreateWildcardQuery(byte, byte)** has been added to **GroupDocs.Search.SearchQuery** class.

##### Usecases

This example shows how to perform phrase search with wildcards using query in the object tree form:

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Indexing
index.AddToIndex(documentsFolder);

// Creating subquery of date range search
SearchQuery subquery1 = SearchQuery.CreateDateRangeQuery(new DateTime(2011, 6, 17), new DateTime(2013, 1, 1));

// Creating subquery of wildcard with number of missed words from 0 to 2
SearchQuery subquery2 = SearchQuery.CreateWildcardQuery(0, 2);

// Creating subquery of simple word
SearchQuery subquery3 = SearchQuery.CreateWordQuery("birth");
subquery3.SearchParameters = new SearchParameters();
subquery3.SearchParameters.FuzzySearch.Enabled = true;
subquery3.SearchParameters.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(1);

// Combining subqueries into one query
SearchQuery query = SearchQuery.CreatePhraseSearchQuery(subquery1, subquery2, subquery3);

// Creating search parameters object with increased capacity of results
SearchParameters searchParameters = new SearchParameters();
searchParameters.MaxHitCountPerTerm = 1000000;
searchParameters.MaxTotalHitCount = 10000000;

// Searching
SearchResults result = index.Search(query, searchParameters);

// The results may contain the following word sequences:
// 03/29/2012 * * births
// 29.07.2011 * birth
// 2013-01-01 birth

```

This example shows how to perform phrase search with wildcards using the query in the text form:

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Indexing
index.AddToIndex(documentsFolder);

// Searching for 'First law of thermodynamics'
// Note that wildcard is used instead of 'of' because it is not indexed as a stop word
SearchResults result1 = index.Search("\"First law *1 thermodynamics\"");

// Searching for 'Frodo spoke to Pippin' and 'Frodo stripped the blankets from Pippin'
SearchResults result2 = index.Search("\"Frodo *1~~5 Pippin\"");
```
