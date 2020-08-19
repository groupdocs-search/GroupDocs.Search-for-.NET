---
id: groupdocs-search-for-net-20-8-release-notes
url: search/net/groupdocs-search-for-net-20-8-release-notes
title: GroupDocs.Search for .NET 20.8 Release Notes
weight: 4
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 20.8{{< /alert >}}

## Major Features

There are the following features and improvementes in this release:

*   Implement indexing from stream
*   Implement support for indexing .DICOM files

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-1932 | Implement indexing from stream | New Feature |
| SEARCHNET-2362 | Implement support for indexing .DICOM files | Improvement |

## Public API and Backward Incompatible Changes

### Implement indexing from stream

This feature provides the ability to index documents from streams and data structures.

##### Public API changes

Enum **DocumentSourceKind** has been added to **GroupDocs.Search.Common** namespace.  
Value **File** has been added to **GroupDocs.Search.Common.DocumentSourceKind** enum.  
Value **Stream** has been added to **GroupDocs.Search.Common.DocumentSourceKind** enum.  
Value **Structure** has been added to **GroupDocs.Search.Common.DocumentSourceKind** enum.

Class **Document** has been added to **GroupDocs.Search.Common** namespace.  
Property **DocumentSourceKind DocumentSourceKind** has been added to **GroupDocs.Search.Common.Document** class.  
Property **string DocumentKey** has been added to **GroupDocs.Search.Common.Document** class.  
Property **bool IsLazy** has been added to **GroupDocs.Search.Common.Document** class.  
Property **DateTime ModificationDate** has been added to **GroupDocs.Search.Common.Document** class.  
Property **string Extension** has been added to **GroupDocs.Search.Common.Document** class.  
Property **DocumentField[] AdditionalFields** has been added to **GroupDocs.Search.Common.Document** class.  
Property **string[] Attributes** has been added to **GroupDocs.Search.Common.Document** class.  
Static method **Document CreateFromFile(string)** has been added to **GroupDocs.Search.Common.Document** class.  
Static method **Document CreateFromStream(string, DateTime, string, Stream)** has been added to **GroupDocs.Search.Common.Document** class.  
Static method **Document CreateFromStructure(string, DateTime, DocumentField[])** has been added to **GroupDocs.Search.Common.Document** class.  
Static method **Document CreateLazy(DocumentSourceKind, string, IDocumentLoader)** has been added to **GroupDocs.Search.Common.Document** class.

Interface **IDocumentLoader** has been added to **GroupDocs.Search.Common** namespace.  
Method **Document LoadDocument()** has been added to **GroupDocs.Search.Common.IDocumentLoader** interface.  
Method **void CloseDocument()** has been added to **GroupDocs.Search.Common.IDocumentLoader** interface.

Property **Document Document** has been added to **GroupDocs.Search.Events.FileIndexingEventArgs** class.  
Property **string DocumentKey** has been added to **GroupDocs.Search.Events.FileIndexingEventArgs** class.

Property **string LastDocumentKey** has been added to **GroupDocs.Search.Events.OperationProgressEventArgs** class.

Method **ExtractedItemInfo[] GetContainerItems(Stream)** has been added to **GroupDocs.Search.Common.IContainerItemExtractor** interface.

Method **DocumentField[] GetFields(Stream)** has been added to **GroupDocs.Search.Common.IFieldExtractor** interface.

Method **void Add(Document[], IndexingOptions)** has been added to **GroupDocs.Search.Index** class.

##### Use cases

The following example demonstrates how to index document from a stream.

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentFilePath = @"c:\MyDocuments\ExampleDocument.pdf";
  
// Creating an index
Index index = new Index(indexFolder);
  
// Creating a document object
Stream stream = File.OpenRead(documentFilePath);
Document document = Document.CreateFromStream(documentFilePath, DateTime.Now, ".pdf", stream);
Document[] documents = new Document[]
{
    document,
};
  
// Indexing document from the stream
IndexingOptions options = new IndexingOptions();
index.Add(documents, options);
  
// Closing the document stream after indexing is complete
stream.Close();
```

### Implement support for indexing .DICOM files

This improvement adds support for indexing .DICOM files.

##### Public API changes

Static field **FileType DICOM** has been added to **GroupDocs.Search.Results.FileType** class.

##### Use cases

None.

