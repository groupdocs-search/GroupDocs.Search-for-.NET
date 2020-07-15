---
id: using-aliases
url: search/net/using-aliases
title: Using aliases
weight: 28
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
The use of aliases allows you to reduce the length of search queries in text form. To use an alias in a search query, you must enter the @ symbol with the name of the alias after it without spaces.

Aliases are stored in the alias dictionary. By default the alias dictionary is empty. Detailed information on managing the alias dictionary can be found on the [Alias dictionary]({{< ref "search/net/developer-guide/advanced-usage/managing-dictionaries/alias-dictionary.md" >}}) page of the [Managing dictionaries]({{< ref "search/net/developer-guide/advanced-usage/managing-dictionaries/_index.md" >}}) section.

An example of using aliases for searching is presented below.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";
 
// Creating an index in the specified folder
Index index = new Index(indexFolder);
 
// Indexing documents from the specified folder
index.Add(documentsFolder);
 
// Adding aliases to the alias dictionary
index.Dictionaries.AliasDictionary.Add("t", "(theory OR relativity)");
index.Dictionaries.AliasDictionary.Add("e", "(Einstein OR Albert)");
 
// Search in the index
SearchResult result = index.Search("@t OR @e");
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
