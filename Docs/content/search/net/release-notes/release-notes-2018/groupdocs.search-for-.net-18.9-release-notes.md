---
id: groupdocs-search-for-net-18-9-release-notes
url: search/net/groupdocs-search-for-net-18-9-release-notes
title: GroupDocs.Search for .NET 18.9 Release Notes
weight: 2
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 18.9.{{< /alert >}}

## Major Features

There are 3 enhancements in this regular monthly release.

*   Implement ability to extract the list of indexed documents
*   Implement ability to extract document text
*   Implement functionality of saving encodings

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-1673 | Implement ability to extract the list of indexed documents | Enhancement |
| SEARCHNET-1672 | Implement ability to extract document text | Enhancement |
| SEARCHNET-1653 | Implement functionality of saving encodings | Enhancement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Search for .NET 18.9. It includes not only new and obsoleted public methods, but also a description of any changes in the behaviour behind the scenes in GroupDocs.Search which may affect existing code. Any behaviour introduced that could be seen as a regression and modifies existing behaviour is especially important and is documented here.{{< /alert >}}

### Implement ability to extract the list of indexed documents

##### Description

This enhancement allows getting a list of indexed documents and items from container documents like ZIP archives, OST and PST files.

##### Public API changes

Class **DocumentInfo** has been added to **GroupDocs.Search** namespace.  
Property **string DocumentFullPath** has been added to **GroupDocs.Search.DocumentInfo** class.  
Property **string ItemPath** has been added to **GroupDocs.Search.DocumentInfo** class.

Method **DocumentInfo\[\] GetIndexedDocuments()** nas been added to **GroupDocs.Search.Index** class.  
Method **DocumentInfo\[\] GetIndexedDocumentItems(DocumentInfo)** nas been added to **GroupDocs.Search.Index** class.

##### Usecases

This example shows how to get a list of indexed documents from an index:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
 
// Creating index from existing folder
Index index = new Index(indexFolder);
 
// Getting list of indexed documents
DocumentInfo[] documents = index.GetIndexedDocuments();
 
// Getting items of container document
DocumentInfo[] items = index.GetIndexedDocumentItems(documents[0]);
```

### Implement ability to extract document text

##### Description

This enhancement allows extracting document text from the index archive or from a document directly if archiving is not used. An extracted text can be used to check an encoding that is used for indexing text documents. Also, it can be used for quick manual checking of the presence or absence of any words in documents.

##### Public API changes

Method **string ExtractDocumentText(DocumentInfo, IFieldExtractor)** has been added to **GroupDocs.Search.Index** class.  
Method **void ExtractDocumentText(string, DocumentInfo, IFieldExtractor)** has been added to **GroupDocs.Search.Index** class.

##### Usecases

This example shows how to extract document text from the index:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
  
// Creating index from existing folder
Index index = new Index(indexFolder);
  
// Getting list of indexed documents
DocumentInfo[] documents = index.GetIndexedDocuments();
 
// Extracting HTML formatted document text
string htmlText = index.ExtractDocumentText(documents[0], null);
```

This example shows how to extract document text to a file:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
  
// Creating index from existing folder
Index index = new Index(indexFolder);
  
// Getting list of indexed documents
DocumentInfo[] documents = index.GetIndexedDocuments();
 
// Extracting HTML formatted document text to a file
index.ExtractDocumentText(@"c:\DocumentText.html", documents[0], null);
```

### Implement functionality of saving encodings

##### Description

This enhancement implements automatic saving of encodings which were used to extract text from TXT files. In practice, this means that there is no longer any need to provide an encoding when generating document text with highlighted found words.

##### Public API changes

None.

##### Usecases

This example shows how to generate HTML formatted text with highlighted found words:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";
 
// Creating index
Index index = new Index(indexFolder);
 
// Subscribing to file indexing event
index.FileIndexing += (sender, args) =>
{
    // Setting encoding for each text file during indexing
    args.Encoding = Encodings.windows_1251;
};
 
// Adding text documents encoded in windows-1251 to index
index.AddToIndex(documentFolder);
 
// Searching for word 'человеческий'
SearchResults results = index.Search("человеческий");
 
// Generating HTML formatted text with highlighted found words
// There is no need to provide the encoding again - it is saved in the index
string htmlText = index.HighlightInText(results[0]);
```
