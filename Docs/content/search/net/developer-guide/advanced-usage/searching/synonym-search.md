---
id: synonym-search
url: search/net/synonym-search
title: Synonym search
weight: 27
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
Synonym search allows you to find not only the words specified in the search query, but also the synonyms, words that means the same.

To enable synonym search, you must set the [UseSynonymSearch](https://apireference.groupdocs.com/net/search/groupdocs.search.options/searchoptions/properties/usesynonymsearch) property of the [SearchOptions](https://apireference.groupdocs.com/net/search/groupdocs.search.options/searchoptions) class to true. By default, synonym search is disabled.

The default synonym dictionary contains synonyms only for the English language. To manage the synonym dictionary, see the [Synonym dictionary]({{< ref "search/net/developer-guide/advanced-usage/managing-dictionaries/synonym-dictionary.md" >}}) page in the [Managing dictionaries]({{< ref "search/net/developer-guide/advanced-usage/managing-dictionaries/_index.md" >}}) section.

The following example demonstrates the synonym search.

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
options.UseSynonymSearch = true; // Enabling synonym search
 
// Search for the word 'answer'
// In addition to the word 'answer', the words 'reply' and 'response' will also be found
SearchResult result = index.Search("answer", options);
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
