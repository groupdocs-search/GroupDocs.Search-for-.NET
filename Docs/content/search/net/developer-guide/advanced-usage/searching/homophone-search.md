---
id: homophone-search
url: search/net/homophone-search
title: Homophone search
weight: 9
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
Homophone search, or in other words phonic search, allows you to find not only the words specified in the search query, but also the homophones, words that are pronounced the same but differ in meaning.

To enable homophone search, you must set the [UseHomophoneSearch](https://apireference.groupdocs.com/net/search/groupdocs.search.options/searchoptions/properties/usehomophonesearch) property of the [SearchOptions](https://apireference.groupdocs.com/net/search/groupdocs.search.options/searchoptions) class to true. By default, homophone search is disabled.

The default homophone dictionary contains homophones only for the English language. To manage the homophone dictionary, see the [Homophone dictionary]({{< ref "search/net/developer-guide/advanced-usage/managing-dictionaries/homophone-dictionary.md" >}}) page in the [Managing dictionaries]({{< ref "search/net/developer-guide/advanced-usage/managing-dictionaries/_index.md" >}}) section.

The following example demonstrates the homophone search.

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
options.UseHomophoneSearch = true; // Enabling homophone search
 
// Search for the word 'coal'
// In addition to the word 'coal', the words 'cole' and 'kohl' will also be found
SearchResult result = index.Search("coal", options);
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
