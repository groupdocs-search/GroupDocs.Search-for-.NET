---
id: groupdocs-search-for-net-18-6-release-notes
url: search/net/groupdocs-search-for-net-18-6-release-notes
title: GroupDocs.Search for .NET 18.6 Release Notes
weight: 5
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 18.6.{{< /alert >}}

## Major Features

There are 3 enhancements in this regular monthly release. The most notable are:

*   Remove obsolete Relevance property from DetailedResultInfo
*   Implement possibility to break indexing operation manually

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-1564 | Remove obsolete Relevance property from DetailedResultInfo | Breaking Changes |
| SEARCHNET-957 | Implement possibility to break indexing operation manually | Enhancement |
| SEARCHNET-1551 | Add ImportDictionary and ExportDictionary methods to index dictionaries | Enhancement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Search for .NET 18.6. It includes not only new and obsoleted public methods, but also a description of any changes in the behaviour behind the scenes in GroupDocs.Search which may affect existing code. Any behaviour introduced that could be seen as a regression and modifies existing behaviour is especially important and is documented here.{{< /alert >}}

### Remove obsolete Relevance property from DetailedResultInfo

##### Description

Removed obsolete property **GroupDocs.Search.DetailedResultInfo.Relevance**

##### Public API changes

Property **Relevance** has been removed from **GroupDocs.Search.DetailedResultInfo** class.

##### Usecases

None.

### Implement possibility to break indexing operation manually

##### Description

This enhancement allows you breaking indexing operation. The break is not instantaneous and in cases of indexing large documents, the breaking can take about a second.

##### Public API changes

Method **void Break** has been added to **GroupDocs.Search.Index** class.

##### Usecases

Following code snippet shows how to break indexing operation:

**C#**

```csharp
string folderForIndex = "c:\\MyIndex\\";
string folderWithDocuments = "c:\\MyDocuments\\";
Index index = new Index(folderForIndex);  // Creating index in c:\MyIndex\ folder
index.OperationFinished += index_OperationFinished; // Subscribing on Operation Finished event
index.AddToIndexAsync(folderWithDocuments); // indexing selected folder asynchronously

index.Break(); // Breaking indexing
```

### Add ImportDictionary and ExportDictionary methods to index dictionaries

##### Description

Updated methods to match names for both Java and .NET platforms.

##### Public API changes

Method **ImportDictionary** has been added to **GroupDocs.Search.AliasDictionary** class.  
Method **ExportDictionary** has been added to **GroupDocs.Search.AliasDictionary** class.  
Method **Import** has been marked as obsolete in **GroupDocs.Search.AliasDictionary** class.  
Method **Export** has been marked as obsolete in **GroupDocs.Search.AliasDictionary** class.

Method **ImportDictionary** has been added to **GroupDocs.Search.CharacterReplacementDictionary** class.  
Method **ExportDictionary** has been added to **GroupDocs.Search.CharacterReplacementDictionary** class.  
Method **Import** has been marked as obsolete in **GroupDocs.Search.CharacterReplacementDictionary** class.  
Method **Export** has been marked as obsolete in **GroupDocs.Search.CharacterReplacementDictionary** class.

Method **ImportDictionary** has been added to **GroupDocs.Search.Alphabet** class.  
Method **ExportDictionary** has been added to **GroupDocs.Search.Alphabet** class.  
Method **Import** has been marked as obsolete in **GroupDocs.Search.Alphabet** class.  
Method **Export** has been marked as obsolete in **GroupDocs.Search.Alphabet** class.

Method **ImportDictionary** has been added to **GroupDocs.Search.SpellingCorrector** class.  
Method **ExportDictionary** has been added to **GroupDocs.Search.SpellingCorrector** class.  
Method **Import** has been marked as obsolete in **GroupDocs.Search.SpellingCorrector** class.  

Method **ImportDictionary** has been added to **GroupDocs.Search.HomophoneDictionary** class.  
Method **ExportDictionary** has been added to **GroupDocs.Search.HomophoneDictionary** class.  
Method **Import** has been marked as obsolete in **GroupDocs.Search.HomophoneDictionary** class.  
Method **Export** has been marked as obsolete in **GroupDocs.Search.HomophoneDictionary** class.

Method **ImportDictionary** has been added to **GroupDocs.Search.StopWordDictionary** class.  
Method **ExportDictionary** has been added to **GroupDocs.Search.StopWordDictionary** class.  
Method **Import** has been marked as obsolete in **GroupDocs.Search.StopWordDictionary** class.  
Method **Export** has been marked as obsolete in **GroupDocs.Search.StopWordDictionary** class.

Method **ImportDictionary** has been added to **GroupDocs.Search.SynonymDictionary** class.  
Method **ExportDictionary** has been added to **GroupDocs.Search.SynonymDictionary** class.  
Method **Import** has been marked as obsolete in **GroupDocs.Search.SynonymDictionary** class.  
Method **Export** has been marked as obsolete in **GroupDocs.Search.SynonymDictionary** class.

##### Changing Details

| Old method name | New method name |
| --- | --- |
| GroupDocs.Search.AliasDictionary.Import | GroupDocs.Search.AliasDictionary.ImportDictionary |
| GroupDocs.Search.AliasDictionary.Export | GroupDocs.Search.AliasDictionary.ExportDictionary |
| GroupDocs.Search.CharacterReplacementDictionary.Import | GroupDocs.Search.CharacterReplacementDictionary.ImportDictionary |
| GroupDocs.Search.CharacterReplacementDictionary.Export | GroupDocs.Search.CharacterReplacementDictionary.ExportDictionary |
| GroupDocs.Search.Alphabet.Import | GroupDocs.Search.Alphabet.ImportDictionary |
| GroupDocs.Search.Alphabet.Export | GroupDocs.Search.Alphabet.ExportDictionary |
| GroupDocs.Search.SpellingCorrector.Import | GroupDocs.Search.SpellingCorrector.ImportDictionary |
| GroupDocs.Search.SpellingCorrector.Export | GroupDocs.Search.SpellingCorrector.ExportDictionary |
| GroupDocs.Search.HomophoneDictionary.Import | GroupDocs.Search.HomophoneDictionary.ImportDictionary |
| GroupDocs.Search.HomophoneDictionary.Export | GroupDocs.Search.HomophoneDictionary.ExportDictionary |
| GroupDocs.Search.StopWordDictionary.Import | GroupDocs.Search.StopWordDictionary.ImportDictionary |
| GroupDocs.Search.StopWordDictionary.Export | GroupDocs.Search.StopWordDictionary.ExportDictionary |
| GroupDocs.Search.SynonymDictionary.Import | GroupDocs.Search.SynonymDictionary.ImportDictionary |
| GroupDocs.Search.SynonymDictionary.Export | GroupDocs.Search.SynonymDictionary.ExportDictionary |
