---
id: delete-indexed-documents
url: search/net/delete-indexed-documents
title: Delete indexed documents
weight: 4
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---

GroupDocs.Search has the ability to remove individual documents from the index that are indexed from a stream or structure. To remove documents indexed by a file system path, see [Deleting indexed paths]({{< ref "search/net/developer-guide/advanced-usage/indexing/delete-indexed-paths.md" >}}).

The following example shows how to remove documents from an index by document key.

**C#**

```csharp
// Implementing document loader
public class DocumentLoader : IDocumentLoader
{
    private readonly string filePath;
    private readonly string documentKey;

    public DocumentLoader(string filePath)
    {
        this.filePath = filePath;
        documentKey = Path.GetFileName(filePath);
    }

    public string DocumentKey
    {
        get { return documentKey; }
    }

    public void CloseDocument()
    {
    }

    public Document LoadDocument()
    {
        string extension = Path.GetExtension(filePath);
        byte[] buffer = File.ReadAllBytes(filePath);
        Stream stream = new MemoryStream(buffer);
        Document document = Document.CreateFromStream(documentKey, DateTime.Now, extension, stream);
        return document;
    }
}

...

string filePath = @"c:\MyDocuments\SomeDocument.pdf";
string indexFolder = @"c:\MyIndex\";

// Creating an index in the specified folder
Index index = new Index(indexFolder);

// Indexing the document from stream
DocumentLoader documentLoader = new DocumentLoader(filePath);
Document document = Document.CreateLazy(DocumentSourceKind.Stream, documentLoader.DocumentKey, documentLoader);
Document[] documents = new Document[] { document };
index.Add(documents, new IndexingOptions());

// Searching in the index
SearchResult searchResult = index.Search("Einstein");

// Deleting indexed document from the index
string[] documentKeys = new string[] { documentLoader.DocumentKey };
DeleteResult deleteResult = index.Delete(new UpdateOptions(), documentKeys);
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
