---
id: groupdocs-search-for-net-21-3-release-notes
url: search/net/groupdocs-search-for-net-21-3-release-notes
title: GroupDocs.Search for .NET 21.3 Release Notes
weight: 2
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---

{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 21.3{{< /alert >}}

## Major Features

There are the following improvementes in this release:

- Implement additional options for highlighting search results
- Implement serialization and deserialization of search results

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-2029 | Implement additional options for highlighting search results | Improvement |
| SEARCHNET-2531 | Implement serialization and deserialization of search results | Improvement |

## Public API and Backward Incompatible Changes

### Implement additional options for highlighting search results

This improvement adds the following features:
- Setting the color for highlighting search results in the output HTML.
- Option to set the inline highlighting style or via CSS.
- Option not to generate Head section in the output HTML.

##### Public API changes

Class **Color** has been added to **GroupDocs.Search.Options** namespace.  
Constructor **Color(int, int, int, int)** has been added to **GroupDocs.Search.Options.Color** class.  
Constructor **Color(int, int, int)** has been added to **GroupDocs.Search.Options.Color** class.  
Property **int Alpha** has been added to **GroupDocs.Search.Options.Color** class.  
Property **int Red** has been added to **GroupDocs.Search.Options.Color** class.  
Property **int Green** has been added to **GroupDocs.Search.Options.Color** class.  
Property **int Blue** has been added to **GroupDocs.Search.Options.Color** class.

Property **bool UseInlineStyles** has been added to **GroupDocs.Search.Options.HighlightOptions** class.  
Property **Color HighlightColor** has been added to **GroupDocs.Search.Options.HighlightOptions** class.

Property **bool GenerateHead** has been added to **GroupDocs.Search.Options.TextOptions** class.

##### Use cases

The following example demonstrates the use of the new options.

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";

// Creating an index
Index index = new Index(indexFolder);

// Indexing documents in a document folder
index.Add(documentFolder);

// Searching in the index
SearchResult result = index.Search("Einstein");
FoundDocument document = result.GetFoundDocument(0);

// Highlighting search results in the text of a document
OutputAdapter outputAdapter = new FileOutputAdapter(@"c:\Result.html");
Highlighter highlighter = new HtmlHighlighter(outputAdapter);
HighlightOptions options = new HighlightOptions();
options.HighlightColor = new Color(0, 127, 0);
options.GenerateHead = true;
options.UseInlineStyles = false;
index.Highlight(document, highlighter, options);
```

### Implement serialization and deserialization of search results

This improvement adds methods for serializing and deserializing search results to classes: **DocumentInfo**, **FoundDocument**, **FoundDocumentField**.
This can be useful, for example, to send serialized search results to a frontend and then use the serialized data as parameters for queries from the frontend.

##### Public API changes

Method **byte[] Serialize()** has been added to **GroupDocs.Search.Results.DocumentInfo** class.  
Method **DocumentInfo Deserialize(byte[])** has been added to **GroupDocs.Search.Results.DocumentInfo** class.

Method **byte[] Serialize()** has been added to **GroupDocs.Search.Results.FoundDocument** class.  
Method **FoundDocument Deserialize(byte[])** has been added to **GroupDocs.Search.Results.FoundDocument** class.

Method **byte[] Serialize()** has been added to **GroupDocs.Search.Results.FoundDocumentField** class.  
Method **FoundDocumentField Deserialize(byte[])** has been added to **GroupDocs.Search.Results.FoundDocumentField** class.

##### Use cases

The following example demonstrates how to serialize and deserialize search result objects.

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";

// Creating an index
Index index = new Index(indexFolder);

// Indexing documents in a document folder
index.Add(documentFolder);

// Searching in the index
SearchResult result = index.Search("Einstein");
FoundDocument document = result.GetFoundDocument(0);

// Serializing a found document object
byte[] bytes = document.Serialize();

// Deserializing the found document object
FoundDocument restoredDocument = FoundDocument.Deserialize(bytes);

// Using restored document for highlighting search results
OutputAdapter outputAdapter = new FileOutputAdapter(@"c:\Result.html");
Highlighter highlighter = new HtmlHighlighter(outputAdapter);
index.Highlight(restoredDocument, highlighter);
```

