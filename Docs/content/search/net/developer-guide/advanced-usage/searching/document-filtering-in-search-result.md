---
id: document-filtering-in-search-result
url: search/net/document-filtering-in-search-result
title: Document filtering in search result
weight: 4
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
This page contains a description of the document filters used during the search.

## Setting a filter

To specify which of the documents found should be returned as a result of the search, the [SearchDocumentFilter](https://apireference.groupdocs.com/net/search/groupdocs.search.options/searchoptions/properties/searchdocumentfilter) property of the [SearchOptions](https://apireference.groupdocs.com/net/search/groupdocs.search.options/searchoptions) class is used. If the document found does not match the filter, it will not be returned. The default value is null, which means that all documents found will be returned. The following example shows how to set a document filter for searching.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";
 
// Creating an index in the specified folder
Index index = new Index(indexFolder);
 
// Indexing documents from the specified folder
index.Add(documentsFolder);
 
// Creating a search options object
SearchOptions options = new SearchOptions();
options.SearchDocumentFilter = SearchDocumentFilter.CreateFileExtension(".txt"); // Setting a document filter
 
// Search in the index
// Only text documents will be returned as the result of the search
SearchResult result = index.Search("relativity", options);
```

## File path filters

The first supported type of search document filters allows you to set a regular expression for getting those documents whose full paths match the specified pattern. This type of filters uses the **System.Text.RegularExpressions.Regex** class to compare with a pattern.

**C#**

```csharp
// The filter returns only files that contain the word 'Einstein' in their paths, not case sensitive
ISearchDocumentFilter filter = SearchDocumentFilter.CreateFilePathRegularExpression("Einstein", RegexOptions.IgnoreCase);
```

## File extension filter

The next supported type of search document filters allows you to specify a list of valid file extensions for indexing.

**C#**

```csharp
// This filter returns only FB2 and EPUB documents
ISearchDocumentFilter filter = SearchDocumentFilter.CreateFileExtension(".fb2", ".epub");
```

## Attribute filter

The next supported type of search document filters allows you to search only those documents with which the specified text attribute is associated. You can learn more about attributes on the [Document attributes]({{< ref "search/net/developer-guide/advanced-usage/indexing/document-attributes.md" >}}) page.

**C#**

```csharp
// This filter returns only documents that have attribute "main"
ISearchDocumentFilter filter = SearchDocumentFilter.CreateAttribute("main");
```

## Combining filters

Search document filters can be combined using composite filters AND, OR, NOT. The following example shows how to combine search document filters.

**C#**

```csharp
// Creating an AND composite filter that returns all FB2 and EPUB documents that have the word 'Einstein' in their full paths
ISearchDocumentFilter filter1 = SearchDocumentFilter.CreateFilePathRegularExpression("Einstein", RegexOptions.IgnoreCase);
ISearchDocumentFilter filter2 = SearchDocumentFilter.CreateFileExtension(".fb2", ".epub");
ISearchDocumentFilter andFilter = SearchDocumentFilter.CreateAnd(filter1, filter2);
 
// Creating an OR composite filter that returns all DOC, DOCX, PDF and all documents that have the word Einstein in their full paths
ISearchDocumentFilter filter3 = SearchDocumentFilter.CreateFilePathRegularExpression("Einstein", RegexOptions.IgnoreCase);
ISearchDocumentFilter filter4 = SearchDocumentFilter.CreateFileExtension(".doc", ".docx", ".pdf");
ISearchDocumentFilter orFilter = SearchDocumentFilter.CreateOr(filter3, filter4);
 
// Creating a filter that returns all found documents except of TXT documents
ISearchDocumentFilter filter5 = SearchDocumentFilter.CreateFileExtension(".txt");
ISearchDocumentFilter notFilter = SearchDocumentFilter.CreateNot(filter5);
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
