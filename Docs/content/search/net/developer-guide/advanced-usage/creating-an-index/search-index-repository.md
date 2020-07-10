---
id: search-index-repository
url: search/net/search-index-repository
title: Search index repository
weight: 2
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
The [IndexRepository](https://apireference.groupdocs.com/net/search/groupdocs.search/indexrepository) class can be used to combine several indexes into a group for searching all indexes at once. In addition, a single call to the [Update](https://apireference.groupdocs.com/net/search/groupdocs.search/indexrepository/methods/update/index) method can update all indexes in the repository. And also the index repository serves as an event hub for all indexes in it. That is, you can subscribe to any events available for the index also through the index repository. However, note that indexing documents is performed separately for each index.

To start using the index repository, indexes must be created or loaded and added to an instance of the index repository. Examples of creating and adding indexes to the repository are presented below.

**C#**

```csharp
string indexFolder1 = @"c:\MyIndex1\";
string indexFolder2 = @"c:\MyIndex2\";
string documentsFolder1 = @"c:\MyDocuments1\";
string documentsFolder2 = @"c:\MyDocuments2\";
 
// Creating an index repository instance
IndexRepository indexRepository = new IndexRepository();
 
// Creating or loading an index and adding to the index repository
Index index1 = new Index(indexFolder1);
indexRepository.AddToRepository(index1);
 
// Creating an index via the index repository by calling a single method
Index index2 = indexRepository.Create(indexFolder2);
 
// Adding documents to the index 1
index1.Add(documentsFolder1);
 
// Adding documents to the index 2
index2.Add(documentsFolder2);
```

The following example shows how to subscribe to the repository events, update indexes in the repository, and search in the repository.

**C#**

```csharp
string indexFolder1 = @"c:\MyIndex1\";
string indexFolder2 = @"c:\MyIndex2\";
string documentFolder1 = @"c:\MyDocuments1\";
string documentFolder2 = @"c:\MyDocuments2\";
 
// Creating an index repository instance
IndexRepository indexRepository = new IndexRepository();
 
// Subscribing to an event
indexRepository.Events.ErrorOccurred += (sender, args) =>
{
    Console.WriteLine("Index: " + args.IndexFolder);
    Console.WriteLine("Error: " + args.Message);
};
 
// Creating or loading an index and adding to the index repository
Index index1 = new Index(indexFolder1);
indexRepository.AddToRepository(index1);
 
// Creating or loading an index and adding to the index repository
Index index2 = new Index(indexFolder2);
indexRepository.AddToRepository(index2);
 
// Adding documents to the index 1
index1.Add(documentFolder1);
 
// Adding documents to the index 2
index2.Add(documentFolder2);
 
// Changing, deleting, adding documents to document folders
// ...
 
// Updating all indexes in the repository
indexRepository.Update();
 
// Searching in the repository
SearchResult result = indexRepository.Search("Einstein");
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
