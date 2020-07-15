---
id: wildcard-search
url: search/net/wildcard-search
title: Wildcard search
weight: 29
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
Wildcard search allows you to search for words with unknown letters or ranges of letters.

In text form of a search query, there are 2 forms of wildcard characters:

*   ? for a single character;
*   ?(*n*~*m*) for a group of characters, where *n* and *m* are numbers from 0 to 255, and *n* <= *m*.

Wildcard search is similar to [regular expression search]({{< ref "search/net/developer-guide/advanced-usage/searching/regular-expression-search.md" >}}), but it works significantly faster when groups of wildcard characters are less and closer to the end of a search query.

It is important to know that wildcard search is flexible enough to use for prefix queries, since prefix query is a special case of a wildcard query.

Examples of wildcard search with queries in text form are presented below.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";
 
// Creating an index in the specified folder
Index index = new Index(indexFolder);
 
// Indexing documents from the specified folder
index.Add(documentsFolder);
 
// Search in the index
SearchResult result1 = index.Search("m?rry"); // Search for 'merry', 'marry', etc.
SearchResult result2 = index.Search("card?(1~6)"); // Search for 'cardiff', 'cardinal', 'cardio', 'cards', etc.
```

To build a query for the wildcard search in object form, use the [WordPattern](https://apireference.groupdocs.com/net/search/groupdocs.search.common/wordpattern) class. This class contains methods for adding known parts of a word and wildcards to a template. An example of constructing a query in object form is presented below.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";
 
// Creating an index in the specified folder
Index index = new Index(indexFolder);
 
// Indexing documents from the specified folder
index.Add(documentsFolder);
 
// Search with pattern "m?rry"
// Search for 'merry', 'marry', etc.
WordPattern pattern1 = new WordPattern();
pattern1.AppendString("m");
pattern1.AppendOneCharacterWildcard();
pattern1.AppendString("rry");
SearchQuery query1 = SearchQuery.CreateWordPatternQuery(pattern1);
SearchResult result1 = index.Search(query1);
 
// Search with pattern "card?(1~6)"
// Search for 'cardiff', 'cardinal', 'cardio', 'cards', etc.
WordPattern pattern2 = new WordPattern();
pattern2.AppendString("card");
pattern2.AppendWildcard(1, 6);
SearchQuery query2 = SearchQuery.CreateWordPatternQuery(pattern2);
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
