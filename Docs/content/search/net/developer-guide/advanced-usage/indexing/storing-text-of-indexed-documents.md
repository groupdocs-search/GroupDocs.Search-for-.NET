---
id: storing-text-of-indexed-documents
url: search/net/storing-text-of-indexed-documents
title: Storing text of indexed documents
weight: 19
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
Text extracted from indexed documents can be stored in an index to provide the extracted text to the user faster when called the [GetDocumentText](https://apireference.groupdocs.com/net/search/groupdocs.search/index/methods/getdocumenttext/index) method, as well as to accelerate text generation with highlighting of search results.

To specify storage parameters, use the [TextStorageSettings](https://apireference.groupdocs.com/net/search/groupdocs.search/indexsettings/properties/textstoragesettings) property of the [IndexSettings](https://apireference.groupdocs.com/net/search/groupdocs.search/indexsettings) class. The default value is null, which means that the text of the documents is not stored in the index.

When saving text in the index, the [Compression](https://apireference.groupdocs.com/net/search/groupdocs.search.options/textstoragesettings/properties/compression) property is used to specify the compression ratio of the saved text. Compression can be normal, high, or text can be saved without compression. The choice of compression ratio affects the final size of the index, as well as the speed of indexing. A high compression ratio reduces index size and indexing speed, and the lack of compression makes index size and indexing speed maximum. The default compression ratio is normal.

The example below demonstrates storing text in an index using the high compression ratio.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";
 
// Creating an index settings instance
IndexSettings settings = new IndexSettings();
settings.TextStorageSettings = new TextStorageSettings(Compression.High); // Setting high compression ratio for the index text storage
 
// Creating an index in the specified folder
Index index = new Index(indexFolder, settings);
 
// Indexing documents
index.Add(documentsFolder);
 
// Searching
SearchResult result = index.Search("Einstein");
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
