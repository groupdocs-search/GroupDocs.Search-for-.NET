---
id: groupdocs-search-for-net-18-8-release-notes
url: search/net/groupdocs-search-for-net-18-8-release-notes
title: GroupDocs.Search for .NET 18.8 Release Notes
weight: 3
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 18.8.{{< /alert >}}

## Major Features

There is 1 enhancement in this regular monthly release.

*   Implement breaking functionality for IndexRepository class

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-1622 | Implement breaking functionality for IndexRepository class | Enhancement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Search for .NET 18.8. It includes not only new and obsoleted public methods, but also a description of any changes in the behaviour behind the scenes in GroupDocs.Search which may affect existing code. Any behaviour introduced that could be seen as a regression and modifies existing behaviour is especially important and is documented here.{{< /alert >}}

### Implement breaking functionality for IndexRepository class

##### Description

This enhancement is implemented for the possibility of cancelling the operations in all indexes in the index repository. The canceling is not instantaneous and in cases of operations with large documents, the breaking can takes about a second.

##### Public API changes

Method **void Update(Cancellation)** has been added to **GroupDocs.Search.IndexRepository** class.  
Method **void UpdateAsync(Cancellation)** has been added to **GroupDocs.Search.IndexRepository** class.  
Method **void Break()** has been added to **GroupDocs.Search.IndexRepository** class.

##### Usecases

The following code snippet shows how to break the updating operation.

**C#**

```csharp
string indexFolder = "c:\\MyIndex\\";
string documentsFolder = "c:\\MyDocuments\\";
 
IndexRepository repository = new IndexRepository();
Index index = repository.Create(indexFolder );
index.AddToIndexAsync(indexFolder);
 
// Breaking all processes in all indexes in repository
repository.Break();
```

This example shows how to break updating with Cancellation object.

**C#**

```csharp
string documentsFolder = "c:\\MyDocuments\\";
IndexRepository repository = new IndexRepository();
Index index = repository.Create();
index.AddToIndex(documentsFolder);
  
Cancellation cnc = new Cancellation();
  
// Updating all indexes in repository
repository.UpdateAsync(cnc);
  
// Canceling all operations in index repository
cnc.Cancel();
```
