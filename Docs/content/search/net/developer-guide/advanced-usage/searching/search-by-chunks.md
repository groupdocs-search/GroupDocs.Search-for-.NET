---
id: search-by-chunks
url: search/net/search-by-chunks
title: Search by chunks
weight: 18
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
The GroupDocs.Search API provides the ability to perform search by chunks. This means that in one call to the [Search](https://apireference.groupdocs.com/net/search/groupdocs.search/index/methods/search/index) method of the [Index](https://apireference.groupdocs.com/net/search/groupdocs.search/index) class, only in one index segment search is performed. This feature becomes relevant when searching in large indexes containing tens and hundreds of thousands of documents.

When performing search by chunks, the [Search](https://apireference.groupdocs.com/net/search/groupdocs.search/index/methods/search/index) method is first called with the [IsChunkSearch](https://apireference.groupdocs.com/net/search/groupdocs.search.options/searchoptions/properties/ischunksearch) flag set to true in the search options. And then the search in each subsequent segment is performed using the [SearchNext](https://apireference.groupdocs.com/net/search/groupdocs.search/index/methods/searchnext/index) method with passing [ChunkSearchToken](https://apireference.groupdocs.com/net/search/groupdocs.search.results/searchresult/properties/nextchunksearchtoken) of the next chunk as an argument.

The following example demonstrates the search by chunks.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";
string query = "Einstein";
 
// Creating an index in the specified folder
Index index = new Index(indexFolder);
 
// Indexing documents from the specified folder
index.Add(documentsFolder);
 
// Creating a search options instance
SearchOptions options = new SearchOptions();
options.IsChunkSearch = true; // Enabling the search by chunks
 
// Starting the search by chunks
SearchResult result = index.Search(query, options);
Console.WriteLine("Document count: " + result.DocumentCount);
Console.WriteLine("Occurrence count: " + result.OccurrenceCount);
 
// Continuing the search by chunks
while (result.NextChunkSearchToken != null)
{
    result = index.SearchNext(result.NextChunkSearchToken);
    Console.WriteLine("Document count: " + result.DocumentCount);
    Console.WriteLine("Occurrence count: " + result.OccurrenceCount);
}
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
