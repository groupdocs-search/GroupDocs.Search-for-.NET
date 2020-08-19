---
id: groupdocs-search-for-net-19-2-release-notes
url: search/net/groupdocs-search-for-net-19-2-release-notes
title: GroupDocs.Search for .NET 19.2 Release Notes
weight: 6
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 19.2{{< /alert >}}

## Major Features

There are the following improvements in this release:

*   Implement escaping special characters in search queries
*   Implement indexing ZIP archives inside other ZIP archives

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-1842 | Delete obsolete methods Import and Export | Breaking Change |
| SEARCHNET-1800 | Implement escaping special characters in search queries | Improvement |
| SEARCHNET-1837 | Implement indexing ZIP archives inside other ZIP archives | Improvement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Search for .NET 19.2. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Search which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Delete obsolete methods Import and Export

Removed obsolete methods **Import** and **Export** from dictionary classes. Please, use **ImportDictionary** and **ExportDictionary** methods instead.

**Public API changes**

Method **Import(string)** has been removed from **GroupDocs.Search.AliasDictionary** class.  
Method **Export(string)** has been removed from **GroupDocs.Search.AliasDictionary** class.  
Method **Import(string)** has been removed from **GroupDocs.Search.CharacterReplacementDictionary** class.  
Method **Export(string)** has been removed from **GroupDocs.Search.CharacterReplacementDictionary** class.

Method **Import(string)** has been removed from **GroupDocs.Search.Alphabet** class.  
Method **Export(string)** has been removed from **GroupDocs.Search.Alphabet** class.

Method **Import(string)** has been removed from **GroupDocs.Search.SpellingCorrector** class.  
Method **Export(string)** has been removed from **GroupDocs.Search.SpellingCorrector** class.

Method **Import(string)** has been removed from **GroupDocs.Search.HomophoneDictionary** class.  
Method **Export(string)** has been removed from **GroupDocs.Search.HomophoneDictionary** class.

Method **Import(string)** has been removed from **GroupDocs.Search.StopWordDictionary** class.  
Method **Export(string)** has been removed from **GroupDocs.Search.StopWordDictionary** class.

Method **Import(string)** has been removed from **GroupDocs.Search.SynonymDictionary** class.  
Method **Export(string)** has been removed from **GroupDocs.Search.SynonymDictionary** class.

### Implement escaping special characters in search queries

This improvement provides ability to escape special characters and use them in text queries.

The following characters are special and can be escaped: (, ), :, ", &, |, !, ^, ~, \*, ?, \\.

The space character can be escaped with sequence '\\s'.

Also it is possible to use any Unicode character by writing escape sequence in the form '\\uhhhh'. Where h is a hexadecimal digit.

The example to perform search with special character escaping is given below.

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Marking character '&' as a valid letter, not a separator
index.Dictionaries.Alphabet.SetRange(new char[] { '&' }, CharacterType.Letter);

// Adding documents to index
index.AddToIndex(documentFolder);

// Searching for word 'R&B'
SearchResults results0 = index.Search(@"R\&B");

// Searching for word 'R&B'
SearchResults results1 = index.Search(@"R\u0026B");
```

### Implement indexing ZIP archives inside other ZIP archives

This improvement provides ability of indexing ZIP archives inside other ZIP archives of any nesting level. This functionality works automatically when adding files to an index.

The example to perform indexing is given below.

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Adding documents to index
// ZIP archives and ZIP archives inside those archives will be automatically added to index
index.AddToIndex(documentFolder);

// Searching
SearchResults results = index.Search("zip");

```
