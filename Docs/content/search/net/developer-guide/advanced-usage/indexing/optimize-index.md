---
id: optimize-index
url: search/net/optimize-index
title: Optimize index
weight: 18
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
An index optimization operation allows you to reduce the number of segments in an index, thereby increasing search performance in the index.

To perform this operation, there is an overload that takes the [MergeOptions](https://apireference.groupdocs.com/net/search/groupdocs.search.options/mergeoptions) instance as a parameter. In the [MergeOptions](https://apireference.groupdocs.com/net/search/groupdocs.search.options/mergeoptions) class, there is a property for specifying a cancellation object and a property for specifying whether to perform the operation asynchronously. By default, the operation is performed synchronously.

The following example demonstrates how to perform the index optimization.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder1 = @"c:\MyDocuments1\";
string documentsFolder2 = @"c:\MyDocuments2\";
string documentsFolder3 = @"c:\MyDocuments3\";
 
// Creating an index in the specified folder
Index index = new Index(indexFolder);
 
index.Add(documentsFolder1); // Indexing documents from the specified folder
index.Add(documentsFolder2); // Each call to Add creates at least one new segment in the index
index.Add(documentsFolder3);
 
MergeOptions options = new MergeOptions();
options.Cancellation = new Cancellation(); // Creating cancellation object to be able to cancel the operation
options.Cancellation.CancelAfter(100000); // Setting maximum duration of the operation to 100 seconds
 
// Merging segments of the index
index.Optimize(options);
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
