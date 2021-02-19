---
id: document-renaming
url: search/net/document-renaming
title: Document renaming
weight: 8
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
Sometimes a situation arises when an indexed document is renamed, but its contents have not changed. In this case, to save computing resources, you can notify the index about the renaming of the document, and then the document will not be reindexed during the update operation.

To notify an index about renaming a document, the [Notify](https://apireference.groupdocs.com/search/net/groupdocs.search/index/methods/notify) method is used with the corresponding notification object as a parameter.

You should keep in mind that if an index is notified of the renaming of a document, it will not be reindexed the next time you call the [Update](https://apireference.groupdocs.com/search/net/groupdocs.search/index/methods/update) method, even if its contents have changed. The following example demonstrates how to notify an index of a renamed document.

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

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
