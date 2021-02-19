---
id: delete-indexed-paths
url: search/net/delete-indexed-paths
title: Delete indexed paths
weight: 5
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
GroupDocs.Search supports the ability to remove indexed files and folders from an index. Only files or folders that were explicitly added to the index can be deleted. It is not possible to remove a file or folder from the index that is a child of the indexed folder. To delete files and folders inside indexed paths, use the document filter (see [Document filtering during indexing]({{< ref "search/net/developer-guide/advanced-usage/indexing/document-filtering-during-indexing.md" >}})). To get a list of indexed paths, use the [GetIndexedPaths](https://apireference.groupdocs.com/net/search/groupdocs.search/index/methods/getindexedpaths) method of the [Index](https://apireference.groupdocs.com/net/search/groupdocs.search/index) class.

The following example shows how to remove indexed paths from an index.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder1 = @"c:\MyDocuments\";
string documentsFolder2 = @"c:\MyDocuments2\";

// Creating an index in the specified folder
Index index = new Index(indexFolder);

// Indexing documents from the specified folders
index.Add(documentsFolder1);
index.Add(documentsFolder2);

// Getting indexed paths from the index
string[] indexedPaths1 = index.GetIndexedPaths();

// Writing indexed paths to the console
Console.WriteLine("Indexed paths:");
foreach (string path in indexedPaths1)
{
    Console.WriteLine("\t" + path);
}
 
// Deleting indexed path from the index
DeleteResult deleteResult = index.Delete(new string[] { documentsFolder1 }, new UpdateOptions());
 
// Getting indexed paths after deletion
string[] indexedPaths2 = index.GetIndexedPaths();
Console.WriteLine("\nDeleted paths: " + deleteResult.SuccessCount);

Console.WriteLine("\nIndexed paths:");
foreach (string path in indexedPaths2)
{
    Console.WriteLine("\t" + path);
}
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
