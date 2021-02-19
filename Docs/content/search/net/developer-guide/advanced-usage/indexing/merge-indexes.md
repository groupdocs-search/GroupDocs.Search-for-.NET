---
id: merge-indexes
url: search/net/merge-indexes
title: Merge indexes
weight: 17
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
The merge operation is designed to combine two or more indexes into one index to accelerate the search and to simplify the work with indexes. When merging, only the index at which the [Merge](https://apireference.groupdocs.com/net/search/groupdocs.search/index/methods/merge/index) method was called is changed. This index as a result of the operation contains all the documents that were contained in all indexes together. The second index or index repository after the merge can be deleted to free up disk space.

The [MergeOptions](https://apireference.groupdocs.com/net/search/groupdocs.search.options/mergeoptions) class contains a property for specifying a cancellation object, as well as a property for specifying whether the operation will be performed asynchronously. By default, index merging operation is performed synchronously.

The [Index](https://apireference.groupdocs.com/net/search/groupdocs.search/index) class has method overloads for merging a single index and a whole index repository. Before performing a merge, checks are made to ensure that the indexes are of the same type. Merging is performed only on those indexes that have the same [IndexType](https://apireference.groupdocs.com/net/search/groupdocs.search/indexsettings/properties/indextype) value as the index on which the [Merge](https://apireference.groupdocs.com/net/search/groupdocs.search/index/methods/merge/index) method is called.

The following example demonstrates the merging of two indexes.

**C#**

```csharp
string indexFolder1 = @"c:\MyIndex1\";
string indexFolder2 = @"c:\MyIndex2\";
string documentsFolder1 = @"c:\MyDocuments1\";
string documentsFolder2 = @"c:\MyDocuments2\";
 
Index index1 = new Index(indexFolder1); // Creating index1
index1.Add(documentsFolder1); // Indexing documents
 
Index index2 = new Index(indexFolder2); // Creating index2
index2.Add(documentsFolder2); // Indexing documents
 
MergeOptions options = new MergeOptions();
options.Cancellation = new Cancellation(); // Creating cancellation object to be able to cancel the oparation
 
// Merging index2 into index1
// Files of index2 will not be changed
index1.Merge(index2, options);
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
