---
id: numeric-range-search
url: search/net/numeric-range-search
title: Numeric range search
weight: 12
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
Numeric range search or numerical search allows you to search in documents any integer numbers in the range from 0 to 9223372036854775807 (Int64.MaxValue). Please note that the number in the text must not be separated by spaces, otherwise it will already be several numbers. A search query of this type is specified as follows:

number ~~ number

The example below demonstrates the numeric range search in text and object forms.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";
 
// Creating an index in the specified folder
Index index = new Index(indexFolder);
 
// Indexing documents from the specified folder
index.Add(documentsFolder);
 
// Search with text query
SearchResult result1 = index.Search("500 ~~ 600");
 
// Search with object query
SearchQuery query2 = SearchQuery.CreateNumericRangeQuery(500, 600);
SearchResult result2 = index.Search(query2);
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
