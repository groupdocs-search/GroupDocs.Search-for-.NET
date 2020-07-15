---
id: queries-in-text-and-object-form
url: search/net/queries-in-text-and-object-form
title: Queries in text and object form
weight: 15
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
There are two ways to create a search query: in text or object form.

A search query in text form is simpler but less flexible. The flexibility of queries in object form lies in the fact that it is possible for each subquery to set separate search options. In object form, you can also use, for example, regular expression query as a part of more complex one. All combinations of nesting search queries in object form can be found on the page [Nesting search queries in object form]({{< ref "search/net/developer-guide/advanced-usage/searching/nesting-search-queries-in-object-form.md" >}}).

The correlation of two forms of search queries is that each text query before search is transformed to query in object form. Therefore, processor handles queries in object form faster.

The full specification of the query language in text form is presented on the page [Query language specification]({{< ref "search/net/developer-guide/advanced-usage/searching/query-language-specification.md" >}}). Syntax with examples of all elements allowed in text search queries is presented on the page [Search operation table]({{< ref "search/net/developer-guide/advanced-usage/searching/search-operation-table.md" >}}).

Each example in this documentation is usually given with the search query in text and object form.

The example of complex query in object form is given below.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";
 
// Creating index
Index index = new Index(indexFolder);
 
// Indexing
index.Add(documentsFolder);
 
// Creating subquery 1 - simple word query
SearchQuery subquery1 = SearchQuery.CreateWordQuery("future");
subquery1.SearchOptions = new SearchOptions(); // Setting search options only for subquery 1
subquery1.SearchOptions.FuzzySearch.Enabled = true;
subquery1.SearchOptions.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(3); // The maximum number of differences is 3
 
// Creating subquery 2 - numeric range query
SearchQuery subquery2 = SearchQuery.CreateNumericRangeQuery(1, 1000000);
 
// Creating subquery 3 - regular expression query 
SearchQuery subquery3 = SearchQuery.CreateRegexQuery(@"(.)\1");
 
// Combining subqueries into one query - phrase search query
SearchQuery query = SearchQuery.CreatePhraseSearchQuery(subquery1, subquery2, subquery3);
 
// Creating overall search options with increased capacity of occurrences
SearchOptions options = new SearchOptions();
options.MaxOccurrenceCountPerTerm = 1000000;
options.MaxTotalOccurrenceCount = 10000000;
 
// Searching
SearchResult result = index.Search(query, options);
 
// The result may contain the following word sequences:
// futile 12 blessed
// father 7 excellent
// tyre 8 assyria
// return 147 229
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
