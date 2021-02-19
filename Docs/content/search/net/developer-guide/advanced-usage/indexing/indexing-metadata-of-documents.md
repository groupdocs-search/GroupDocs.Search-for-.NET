---
id: indexing-metadata-of-documents
url: search/net/indexing-metadata-of-documents
title: Indexing metadata of documents
weight: 11
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
GroupDocs.Search allows creating of full-text and / or metadata index on documents. To index only metadata without main content of documents, you only need to set IndexType.MetadataIndex when creating an index. The size of an index of this type will be very small.

The following example demonstrates the creation of the metadata index.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";
 
// Creating an instance of index settings
IndexSettings settings = new IndexSettings();
settings.IndexType = IndexType.MetadataIndex; // Setting index type
 
// Creating an index in the specified folder
Index index = new Index(indexFolder, settings);
 
// Indexing documents from the specified folder
index.Add(documentsFolder);
 
// Searching in the index
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
