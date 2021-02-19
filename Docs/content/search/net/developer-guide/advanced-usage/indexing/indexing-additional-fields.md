---
id: indexing-additional-fields
url: search/net/indexing-additional-fields
title: Indexing additional fields
weight: 9
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
Sometimes when indexing, it is necessary to associate each document with certain additional metadata, for example, a set of tags, a number in the library catalog, the subject of a document, etc. To accomplish this task, additional fields can be added to each indexed document in addition to those already in the document itself.

Additional fields are associated with the document through the arguments of the [FileIndexing](https://apireference.groupdocs.com/net/search/groupdocs.search.events/eventhub/events/fileindexing) event that occurs before indexing each added document. When adding each field, its name and contents are specified. The name of the added field can match the names of other added fields or fields of the document itself. During the search inside the fields with the same name, coincidences with the text of all fields with the specified name will be taken into account.

The example below demonstrates the associating of additional fields with documents during indexing.

**C#**

```csharp
// Defining somewhere a dictionary containing subjects of documents
Dictionary<string, string> subjects = new Dictionary<string, string>();
subjects.Add(@"C:\MyDocuments\BhagavadGitaAsItIs.pdf".ToLowerInvariant(), "Spiritual");
// ...
 
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";
 
// Creating an index
Index index = new Index(indexFolder);
 
// Subscribing to the event
index.Events.FileIndexing += (sender, args) =>
{
    string subject;
    if (subjects.TryGetValue(args.DocumentFullPath.ToLowerInvariant(), out subject)) // Getting a subject for the current document
    {
        args.AdditionalFields = new DocumentField[] // Setting additional fields for the current document
        {
            new DocumentField("Subject", subject)
        };
    }
};
 
// Indexing documents from the specified folder
index.Add(documentsFolder);
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
