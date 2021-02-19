---
id: document-attributes
url: search/net/document-attributes
title: Document attributes
weight: 6
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
Document attributes is a special feature designed for marking indexed documents with text labels without the need for re-indexing. Added attributes can be further used to filter documents during the search.

To add and delete attributes of indexed documents, use the [ChangeAttributes](https://apireference.groupdocs.com/search/net/groupdocs.search/index/methods/changeattributes) method of the [Index](https://apireference.groupdocs.com/search/net/groupdocs.search/index) class. This method accepts an [AttributeChangeBatch](https://apireference.groupdocs.com/search/net/groupdocs.search.common/attributechangebatch) object containing the required attribute changes as a parameter.

The following example demonstrates how to add and remove attributes from indexed documents.

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";
  
// Creating an index
Index index = new Index(indexFolder);
  
// Indexing documents in a document folder
index.Add(documentFolder);
  
// Creating an attribute change container object
AttributeChangeBatch batch = new AttributeChangeBatch();
// Adding one attribute to all indexed documents
batch.AddToAll("public");
// Removing one attribute from one indexed document
batch.Remove(@"c:\MyDocuments\KeyPoints.doc", "public");
// Adding two attributes to one indexed document
batch.Add(@"c:\MyDocuments\KeyPoints.doc", "main", "key");
  
// Applying attribute changes in the index
index.ChangeAttributes(batch);
 
// Searching in the index
SearchOptions options = new SearchOptions();
// Creating a document filter by attribute
options.SearchDocumentFilter = SearchDocumentFilter.CreateAttribute("main");
SearchResult result = index.Search("Einstein", options);
```

Attributes can be associated with documents during indexing using the [FileIndexing](https://apireference.groupdocs.com/search/net/groupdocs.search.events/eventhub/events/fileindexing) event. The following example demonstrates this.

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";
 
// Creating an index
Index index = new Index(indexFolder);
 
// Subscribing to the FileIndexing event for adding attributes
index.Events.FileIndexing += (sender, args) =>
{
    if (args.DocumentFullPath.EndsWith("KeyPoints.doc"))
    {
        // Adding two attributes
        args.Attributes = new string[] { "main", "key" };
    }
};
 
// Indexing documents in a document folder
index.Add(documentFolder);
 
// Searching in the index
SearchOptions options = new SearchOptions();
// Creating a document filter by attribute
options.SearchDocumentFilter = SearchDocumentFilter.CreateAttribute("main");
SearchResult result = index.Search("Einstein", options);
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
