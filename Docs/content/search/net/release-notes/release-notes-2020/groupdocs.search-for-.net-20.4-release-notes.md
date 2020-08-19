---
id: groupdocs-search-for-net-20-4-release-notes
url: search/net/groupdocs-search-for-net-20-4-release-notes
title: GroupDocs.Search for .NET 20.4 Release Notes
weight: 2
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 20.4{{< /alert >}}

## Major Features

There are the following new features in this release:

*   Implement changing path without reindexing for renamed documents
*   Implement ability to change attributes of indexed documents without reindexing

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-215 | Implement changing path without reindexing for renamed documents | New Feature |
| SEARCHNET-2134 | Implement ability to change attributes of indexed documents without reindexing | New Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Search for .NET 20.4. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Search which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Implement changing path without reindexing for renamed documents

This feature allows you to notify an index about renaming or moving to another location an indexed document. After notification, when calling the Update method, the document will not be reindexed even if its contents have changed.

##### Public API changes

Value **Renaming** has been added to **GroupDocs.Search.Common.IndexStatus** enum.

Class **Notification** has been added to **GroupDocs.Search.Common** namespace.  
Method **Notification CreateRenameNotification(string, string)** has been added to **GroupDocs.Search.Common.Notification** class.

Method **bool Notify(Notification)** has been added to **GroupDocs.Search.Index** class.

##### Use cases

This example demonstrates how to notify an index about renaming an indexed document:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";
  
// Creating an index
Index index = new Index(indexFolder);
  
// Indexing documents in a document folder
index.Add(documentFolder);
  
// Renaming a document
string oldDocumentPath = @"c:\MyDocuments\OldDocumentName.txt";
string newDocumentPath = @"c:\MyDocuments\NewDocumentName.txt";
File.Move(oldDocumentPath, newDocumentPath);
  
// Notifying the index about renaming
Notification notification = Notification.CreateRenameNotification(oldDocumentPath, newDocumentPath);
bool result = index.Notify(notification);
  
// Updating the index
// The renamed document will not be reindexed
index.Update();
```

### Implement ability to change attributes of indexed documents without reindexing

This feature allows you to add text attributes to indexed documents without the need to reindex documents. Added text attributes can be further used to filter search results.

##### Public API changes

Value **ChangingAttributes** has been added to **GroupDocs.Search.Common.IndexStatus** enum.

Class **AttributeChangeBatch** has been added to **GroupDocs.Search.Common** namespace.  
Constructor **AttributeChangeBatch()** has been added to **GroupDocs.Search.Common.AttributeChangeBatch** class.  
Method **void Add(string path, params string\[\] attributes)** has been added to **GroupDocs.Search.Common.AttributeChangeBatch** class.  
Method **void Add(string\[\] paths, params string\[\] attributes)** has been added to **GroupDocs.Search.Common.AttributeChangeBatch** class.  
Method **void AddToAll(params string\[\] attributes)** has been added to **GroupDocs.Search.Common.AttributeChangeBatch** class.  
Method **void Remove(string path, params string\[\] attributes)** has been added to **GroupDocs.Search.Common.AttributeChangeBatch** class.  
Method **void Remove(string\[\] paths, params string\[\] attributes)** has been added to **GroupDocs.Search.Common.AttributeChangeBatch** class.  
Method **void RemoveAll(string path)** has been added to **GroupDocs.Search.Common.AttributeChangeBatch** class.  
Method **void RemoveAll(string\[\] paths)** has been added to **GroupDocs.Search.Common.AttributeChangeBatch** class.  
Method **void RemoveFromAll(params string\[\] attributes)** has been added to **GroupDocs.Search.Common.AttributeChangeBatch** class.  
Method **void Clear()** has been added to **GroupDocs.Search.Common.AttributeChangeBatch** class.

Method **void ChangeAttributes(AttributeChangeBatch batch)** has been added to **GroupDocs.Search.Index** class.  
Method **string\[\] GetAttributes(string path)** has been added to **GroupDocs.Search.Index** class.

Property **string\[\] Attributes** has been added to **GroupDocs.Search.Events.FileIndexingEventArgs** class.

Method **ISearchDocumentFilter CreateAttribute(params string\[\] attributes)** has been added to **GroupDocs.Search.Options.SearchDocumentFilter** class.

##### Use cases

This example demonstrates how to add attributes to and remove attributes from indexed documents:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";
 
// Creating an index
Index index = new Index(indexFolder);
 
// Indexing documents in a document folder
index.Add(documentFolder);
 
// Creating an attribute change container object
AttributeChangeBatch batch = new AttributeChangeBatch();
// Adding one attribute to all indexed documents
batch.AddToAll("public");
// Removing one attribute from one indexed document
batch.Remove(@"c:\MyDocuments\KeyPoints.doc", "public");
// Adding two attributes to one indexed document
batch.Add(@"c:\MyDocuments\KeyPoints.doc", "main", "key");
 
// Applying attribute changes in the index
index.ChangeAttributes(batch);
```

The next example demonstrates how to add attributes to documents during indexing and how to search with filter by attribute:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";
 
// Creating an index
Index index = new Index(indexFolder);
 
// Subscribing to the FileIndexing event for adding attributes
index.Events.FileIndexing += (sender, args) =>
{
    if (args.DocumentFullPath.EndsWith("KeyPoints.doc"))
    {
        // Adding two attributes
        args.Attributes = new string[] { "main", "key" };
    }
};
 
// Indexing documents in a document folder
index.Add(documentFolder);
 
// Searching in the index
SearchOptions options = new SearchOptions();
// Creating a document filter by attribute
options.SearchDocumentFilter = SearchDocumentFilter.CreateAttribute("main");
SearchResult result = index.Search("Einstein", options);
```
