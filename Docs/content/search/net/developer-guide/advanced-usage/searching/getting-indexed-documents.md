---
id: getting-indexed-documents
url: search/net/getting-indexed-documents
title: Getting indexed documents
weight: 7
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
This page contains a description of how to get a list of indexed documents from an index, and how to get the text of indexed documents in HTML format.

## Getting indexed documents

To get a list of indexed documents from an index, use the [GetIndexedDocuments](https://apireference.groupdocs.com/net/search/groupdocs.search/index/methods/getindexeddocuments) method of the [Index](https://apireference.groupdocs.com/net/search/groupdocs.search/index) class. Documents with the extensions ZIP, PST, OST can also contain internal documents. To get a list of internal documents, use the [GetIndexedDocumentItems](https://apireference.groupdocs.com/net/search/groupdocs.search/index/methods/getindexeddocumentitems) method of the [Index](https://apireference.groupdocs.com/net/search/groupdocs.search/index) class. For ZIP archives, this way you can access documents of arbitrary nesting depth. An example of obtaining a list of documents from an index is presented below.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";
 
// Creating an index in the specified folder
Index index = new Index(indexFolder);
 
// Indexing documents from the specified folder
index.Add(documentsFolder);
 
// Getting list of indexed documents
DocumentInfo[] documents = index.GetIndexedDocuments();
for (int i = 0; i < documents.Length; i++)
{
    DocumentInfo document = documents[i];
    Console.WriteLine(document.FilePath);
    DocumentInfo[] items = index.GetIndexedDocumentItems(document); // Getting list of document items
    for (int j = 0; j < items.Length; j++)
    {
        DocumentInfo item = items[j];
        Console.WriteLine("\t" + item.InnerPath);
    }
}
```

## Getting text of indexed documents

The text of the indexed document can also be extracted from an index if the option to save the text of documents in the index has been enabled. If this option was not enabled when creating an index, then when the [GetDocumentText](https://apireference.groupdocs.com/net/search/groupdocs.search/index/methods/getdocumenttext/index) method of the [Index](https://apireference.groupdocs.com/net/search/groupdocs.search/index) class is called, the text of the document will be retrieved again. Details about saving the text of documents in an index can be found on the page [Storing text of indexed documents]({{< ref "search/net/developer-guide/advanced-usage/indexing/storing-text-of-indexed-documents.md" >}}).

The generated text of the document is passed to an object of a class derived from the abstract class [OutputAdapter](https://apireference.groupdocs.com/net/search/groupdocs.search.common/outputadapter) to its constructor. Details on the output adapters are presented on the page [Output adapters]({{< ref "search/net/developer-guide/advanced-usage/searching/output-adapters.md" >}}).

After generating the text of a document into a file, this file can be opened by an Internet browser. The following example shows how to extract document text from an index.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";
 
// Creating an index in the specified folder
Index index = new Index(indexFolder);
 
// Indexing documents from the specified folder
index.Add(documentsFolder);
 
// Getting list of indexed documents
DocumentInfo[] documents = index.GetIndexedDocuments();
 
// Getting a document text
if (documents.Length > 0)
{
    FileOutputAdapter outputAdapter = new FileOutputAdapter(@"C:\Text.html");
    index.GetDocumentText(documents[0], outputAdapter);
}
```

To extract the text of a document from an index, the method overloading is also presented, which takes an instance of the [TextOptions](https://apireference.groupdocs.com/net/search/groupdocs.search.options/textoptions) class as a parameter. In this class, the following options can be specified:

*   [CustomExtractor](https://apireference.groupdocs.com/net/search/groupdocs.search.options/textoptions/properties/customextractor) is a custom extractor used during indexing, it is necessary if the text of the document was not saved in the index;
*   [AdditionalFields](https://apireference.groupdocs.com/net/search/groupdocs.search.options/textoptions/properties/additionalfields) are additional document fields added during document indexing which are also necessary if the document text was not saved in the index;
*   [Cancellation](https://apireference.groupdocs.com/net/search/groupdocs.search.options/textoptions/properties/cancellation) is an object used to cancel the operation;
*   [MetadataIndexingOptions](https://apireference.groupdocs.com/net/search/groupdocs.search.options/textoptions/properties/metadataindexingoptions) is an object for specifying metadata indexing options.

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
