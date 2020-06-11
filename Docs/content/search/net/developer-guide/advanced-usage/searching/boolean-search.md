---
id: boolean-search
url: search/net/boolean-search
title: Boolean search
weight: 1
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
This page contains the boolean search definition, a description of all boolean operators used for boolean search, and boolean query examples.

## Boolean search terms

Boolean search is a type of search that allows you to combine queries with boolean operators AND, OR, NOT to create a boolean query and further obtain more relevant results. For example, a boolean query might be "Albert AND Einstein". This will limit the search results to only documents that contain both words.

## Operator AND

The AND operator allows you to find only those documents that are found for each nested search query separately. The following example demonstrates the use of the AND operator in text and object form queries. The queries search for documents in the text of which there are both words "theory" and "relativity".

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";
 
// Creating an index in the specified folder
Index index = new Index(indexFolder);
 
// Indexing documents from the specified folder
index.Add(documentsFolder);
 
// Search with text query
SearchResult result1 = index.Search("theory AND relativity");
 
// Search with object query
SearchQuery wordQuery1 = SearchQuery.CreateWordQuery("theory");
SearchQuery wordQuery2 = SearchQuery.CreateWordQuery("relativity");
SearchQuery andQuery = SearchQuery.CreateAndQuery(wordQuery1, wordQuery2);
SearchResult result2 = index.Search(andQuery);
```

## Operator OR

The OR operator allows you to find all the documents that are found for at least one nested search query. The example demonstrates the use of the OR operator in text and object form queries. The queries search for documents in the text of which there is at least one of the words "Einstein" and "relativity".

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";
 
// Creating an index in the specified folder
Index index = new Index(indexFolder);
 
// Indexing documents from the specified folder
index.Add(documentsFolder);
 
// Search with text query
SearchResult result1 = index.Search("Einstein OR relativity");
 
// Search with object query
SearchQuery wordQuery1 = SearchQuery.CreateWordQuery("Einstein");
SearchQuery wordQuery2 = SearchQuery.CreateWordQuery("relativity");
SearchQuery orQuery = SearchQuery.CreateOrQuery(wordQuery1, wordQuery2);
SearchResult result2 = index.Search(orQuery);
```

## Operator NOT

The NOT operator allows you to invert the result of a nested search query and find all documents in which for the nested search query are found no occurrences. The example demonstrates the use of the NOT operator in text and object form queries. The queries search for documents in the text of which the word "relativity" is presented but the word "Einstein" is not.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";
 
// Creating an index in the specified folder
Index index = new Index(indexFolder);
 
// Indexing documents from the specified folder
index.Add(documentsFolder);
 
// Search with text query
SearchResult result1 = index.Search("relativity AND NOT Einstein");
 
// Search with object query
SearchQuery wordQuery1 = SearchQuery.CreateWordQuery("relativity");
SearchQuery wordQuery2 = SearchQuery.CreateWordQuery("Einstein");
SearchQuery notQuery = SearchQuery.CreateNotQuery(wordQuery2);
SearchQuery andQuery = SearchQuery.CreateAndQuery(wordQuery1, notQuery);
SearchResult result2 = index.Search(andQuery);
```

## Complex queries

Boolean search operators can be combined using parentheses. The example below shows how to use parentheses to construct complex boolean search queries. In the example the query is presented in text and object form and searches for documents containing the words "theory" and "relativity" and not containing the words "Einstein" and "Albert".

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";
 
// Creating an index in the specified folder
Index index = new Index(indexFolder);
 
// Indexing documents from the specified folder
index.Add(documentsFolder);
 
// Search with text query
SearchResult result1 = index.Search("(theory AND relativity) AND NOT (Einstein OR Albert)");
 
// Search with object query
SearchQuery theoryWordQuery = SearchQuery.CreateWordQuery("theory");
SearchQuery relativityWordQuery = SearchQuery.CreateWordQuery("relativity");
SearchQuery andQuery = SearchQuery.CreateAndQuery(theoryWordQuery, relativityWordQuery);
 
SearchQuery einsteinWordQuery = SearchQuery.CreateWordQuery("Einstein");
SearchQuery albertWordQuery = SearchQuery.CreateWordQuery("Albert");
SearchQuery orQuery = SearchQuery.CreateOrQuery(einsteinWordQuery, albertWordQuery);
SearchQuery notQuery = SearchQuery.CreateNotQuery(orQuery);
 
SearchQuery rootQuery = SearchQuery.CreateAndQuery(andQuery, notQuery);
SearchResult result2 = index.Search(rootQuery);
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
