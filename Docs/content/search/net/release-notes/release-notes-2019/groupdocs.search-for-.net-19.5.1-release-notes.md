---
id: groupdocs-search-for-net-19-5-1-release-notes
url: search/net/groupdocs-search-for-net-19-5-1-release-notes
title: GroupDocs.Search for .NET 19.5.1 Release Notes
weight: 3
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 19.5.1{{< /alert >}}

## Major Features

There are the following breaking changes and bug fixes:

*   Remove obsolete methods from Alphabet class
*   Error of updating an index containing password protected documents

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-2019 | Remove obsolete methods from Alphabet class | Breaking Change |
| SEARCHJAVA-82 | Error of updating an index containing password protected documents | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Search for .NET 19.5.1. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Search which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Remove obsolete methods from Alphabet class

Removed obsolete methods AddRange, RemoveRange from Alphabet class.  
Method **SetRange(char\[\] characters, CharacterType type)** should be used instead.

##### Public API changes

Method **AddRange(IEnumerable\<char>)** has been removed from **GroupDocs.Search.Alphabet** class.  
Method **RemoveRange(IEnumerable\<char>)** has been removed from **GroupDocs.Search.Alphabet** class.

##### Usecases

This example shows how to change character type for indexing:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Marking hyphen as valid letter
index.Dictionaries.Alphabet.SetRange(new char[] { '-' }, CharacterType.Letter);

// Marking underscore as separator
index.Dictionaries.Alphabet.SetRange(new char[] { '_' }, CharacterType.Separator);

// Indexing
index.AddToIndex(documentFolder);

// Searching
SearchResults results = index.Search("e-mail");
```

### Error of updating an index containing password protected documents

Fixed error of updating an index containing password protected documents.

##### Public API changes

None.
