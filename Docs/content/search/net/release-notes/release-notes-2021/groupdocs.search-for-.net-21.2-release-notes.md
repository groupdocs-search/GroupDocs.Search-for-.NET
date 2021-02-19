---
id: groupdocs-search-for-net-21-2-release-notes
url: search/net/groupdocs-search-for-net-21-2-release-notes
title: GroupDocs.Search for .NET 21.2 Release Notes
weight: 1
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---

{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 21.2{{< /alert >}}

## Major Features

There are the following improvementes in this release:

- Implement ability to perform boolean search with stop words
- Implement ability to get status of indexed file
- Implement ability to delete files indexed from stream

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-2486 | Implement ability to perform boolean search with stop words | Improvement |
| SEARCHNET-2487 | Implement ability to get status of indexed file | Improvement |
| SEARCHNET-2485 | Implement ability to delete files indexed from stream | Improvement |

## Public API and Backward Incompatible Changes

### Implement ability to perform boolean search with stop words

This improvement allows to perform boolean search on queries containing stop words. Now stop words in a boolean search query do not lead to an empty result, but are simply ignored.

##### Public API changes

None.

##### Use cases

The following example demonstrates a logical search using a stop word in a query.

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";

// Creating an index
Index index = new Index(indexFolder);

// Indexing documents in a document folder
index.Add(documentFolder);

// Searching in the index. The word 'of' is the stop word by default.
SearchResult result = index.Search("Theory AND of AND relativity");
```

### Implement ability to get status of indexed file

This improvement adds new properties to the **DocumentInfo** class: DocumentSourceKind and IndexedWithError, which allow to get the type of the document indexing source and the indexing error indicator.

##### Public API changes

Property **DocumentSourceKind DocumentSourceKind** has been added to **GroupDocs.Search.Results.DocumentInfo** class.  
Property **bool IndexedWithError** has been added to **GroupDocs.Search.Results.DocumentInfo** class.

##### Use cases

The following example demonstrates how to get the type of source of an indexed document and the indexing error indicator.

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";

// Creating an index
Index index = new Index(indexFolder);

// Indexing documents in a document folder
index.Add(documentFolder);

// Getting information about indexed documents
DocumentInfo[] infos = index.GetIndexedDocuments();
for (int i = 0; i < infos.Length; i++)
{
    DocumentInfo info = infos[i];
    Console.WriteLine("Document source kind: " + info.DocumentSourceKind);
    Console.WriteLine("Indexed with error: " + info.IndexedWithError);
}
```

### Implement ability to delete files indexed from stream

This improvement allows to delete documents from an index that have been indexed from a stream or from a structure.

##### Public API changes

Method **DeleteResult Delete(UpdateOptions, string[])** has been added to **GroupDocs.Search.Index** class.

##### Use cases

The following example demonstrates how to delete documents from an index by key.

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentPath = @"c:\MyDocuments\Document.pdf";
string documentKey = "My Document.pdf";

// Creating an index
Index index = new Index(indexFolder);

// Indexing a document from stream
using (Stream stream = File.OpenRead(documentPath))
{
    Document document = Document.CreateFromStream(documentKey, DateTime.Now, ".pdf", stream);
    index.Add(new Document[] { document }, new IndexingOptions());
}

// Deleting the document from the index by key
index.Delete(new UpdateOptions(), new string[] { documentKey });
```

