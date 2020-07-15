---
id: stop-word-dictionary
url: search/net/stop-word-dictionary
title: Stop word dictionary
weight: 7
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
The [StopWordDictionary](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/stopworddictionary) class is designed to store stop words in an index. Information on using stop words during indexing is provided on the [Indexing with stop words]({{< ref "search/net/developer-guide/advanced-usage/indexing/indexing-with-stop-words.md" >}}) page.

To get the number of stop words in the dictionary, use the [Count](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/stopworddictionary/properties/count) property.

To add stop words to the dictionary, use the [AddRange](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/stopworddictionary/methods/addrange/index) method.

To remove words from the dictionary, use the [RemoveRange](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/stopworddictionary/methods/removerange/index) method.

To check for a word in a dictionary, use the [Contains](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/stopworddictionary/methods/contains) method.

To remove all words from the dictionary, use the [Clear](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/stopworddictionary/methods/clear) method.

To export words to a file, use the [ExportDictionary](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/dictionarybase/methods/exportdictionary) method.

To import words from a file, use the [ImportDictionary](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/dictionarybase/methods/importdictionary) method.

The following example demonstrates the use of methods of the stop word dictionary.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
 
// Creating an index from in specified folder
Index index = new Index(indexFolder);
 
if (index.Dictionaries.StopWordDictionary.Count > 0)
{
    // Removing all words from the dictionary
    index.Dictionaries.StopWordDictionary.Clear();
}
 
// Adding stop words to the dictionary
string[] words = new string[] { "a", "an", "the", "but", "by" };
index.Dictionaries.StopWordDictionary.AddRange(words);
 
if (index.Dictionaries.StopWordDictionary.Contains("but") &&
    index.Dictionaries.StopWordDictionary.Contains("by"))
{
    // Removing words from the dictionary
    index.Dictionaries.StopWordDictionary.RemoveRange(new string[] { "but", "by" });
}
 
// Export words to a file
index.Dictionaries.StopWordDictionary.ExportDictionary(@"C:\Words.txt");
 
// Import words from a file
index.Dictionaries.StopWordDictionary.ImportDictionary(@"C:\Words.txt");
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
