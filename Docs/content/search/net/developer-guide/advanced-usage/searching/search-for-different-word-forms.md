---
id: search-for-different-word-forms
url: search/net/search-for-different-word-forms
title: Search for different word forms
weight: 20
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
The search for different word forms allows you to search for nouns in the singular or plural, adjectives in the degree of comparison, forms of regular and irregular verbs, etc.

Search for different word forms is enabled if the [UseWordFormsSearch](https://apireference.groupdocs.com/net/search/groupdocs.search.options/searchoptions/properties/usewordformssearch) property of the [SearchOptions](https://apireference.groupdocs.com/net/search/groupdocs.search.options/searchoptions) class is set to true. By default, the search for different word forms is disabled.

To generate various forms of words, a class that implements the [IWordFormsProvider](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/iwordformsprovider) interface is used. The default class is [EnglishWordFormsProvider](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/englishwordformsprovider), which supports English-only word forms. To add support for word forms in other languages, see the [Word forms provider]({{< ref "search/net/developer-guide/advanced-usage/managing-dictionaries/word-forms-provider.md" >}}) page.

The following example demonstrates how to perform search for different word forms in an index.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";
 
// Creating an index in the specified folder
Index index = new Index(indexFolder);
 
// Indexing documents from the specified folder
index.Add(documentsFolder);
 
// Creating a search options instance
SearchOptions options = new SearchOptions();
options.UseWordFormsSearch = true; // Enabling search for word forms
 
// Searching in the index
SearchResult result = index.Search("relative", options);
 
// The following words can be found:
// relative
// relatives
// relatively
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
