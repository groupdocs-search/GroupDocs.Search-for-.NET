---
id: synonym-dictionary
url: search/net/synonym-dictionary
title: Synonym dictionary
weight: 8
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
The [SynonymDictionary](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/synonymdictionary) class is designed to store synonyms in an index. For information on searching using synonyms, see the [Synonym dictionary]({{< ref "search/net/developer-guide/advanced-usage/managing-dictionaries/synonym-dictionary.md" >}}) page.

To get the number of synonyms in the dictionary, use the [Count](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/synonymdictionary/properties/count) property.

To add groups of synonyms to the dictionary, use the [AddRange](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/synonymdictionary/methods/addrange/index) method.

The [Clear](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/synonymdictionary/methods/clear) method is used to remove all synonyms from the dictionary.

To export synonyms to a file, use the [ExportDictionary](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/dictionarybase/methods/exportdictionary) method.

To import synonyms from a file, use the [ImportDictionary](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/dictionarybase/methods/importdictionary) method.

The following example demonstrates the use of methods of the synonym dictionary.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
 
// Creating an index from in specified folder
Index index = new Index(indexFolder);
 
if (index.Dictionaries.SynonymDictionary.Count > 0)
{
    // Removing all synonyms from the dictionary
    index.Dictionaries.SynonymDictionary.Clear();
}
 
// Adding synonyms to the dictionary
string[][] synonymGroups = new string[][]
{
    new string[] { "achieve", "accomplish", "attain", "reach" },
    new string[] { "accept", "take", "have" },
};
index.Dictionaries.SynonymDictionary.AddRange(synonymGroups);
 
// Export synonyms to a file
index.Dictionaries.SynonymDictionary.ExportDictionary(@"C:\Synonyms.dat");
 
// Import synonyms from a file
index.Dictionaries.SynonymDictionary.ImportDictionary(@"C:\Synonyms.dat");
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
