---
id: spelling-corrector
url: search/net/spelling-corrector
title: Spelling corrector
weight: 6
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
The [SpellingCorrector](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/spellingcorrector) class is designed to correct spelling errors in search queries, as well as to store words with correct spelling. You can learn about spelling correction in search queries on the [Spell checking]({{< ref "search/net/developer-guide/advanced-usage/searching/spell-checking.md" >}}) page.

To get the number of words in the spelling corrector dictionary, use the [Count](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/spellingcorrector/properties/count) property.

To get an array of words containing in the spelling corrector dictionary, the [GetWords](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/spellingcorrector/methods/getwords) method is used.

To add words to the spelling corrector dictionary, use the [AddRange](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/spellingcorrector/methods/addrange/index) method.

The [Clear](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/spellingcorrector/methods/clear) method is used to remove all words from the spelling corrector dictionary.

To export words to a file, use the [ExportDictionary](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/dictionarybase/methods/exportdictionary) method.

To import words from a file, use the [ImportDictionary](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/dictionarybase/methods/importdictionary) method.

The following example demonstrates the use of methods of the spelling corrector.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
 
// Creating an index from in specified folder
Index index = new Index(indexFolder);
 
if (index.Dictionaries.SpellingCorrector.Count > 0)
{
    // Removing all words from the dictionary
    index.Dictionaries.SpellingCorrector.Clear();
}
 
// Adding words to the dictionary
string[] words = new string[] { "achieve", "accomplish", "attain", "reach" };
index.Dictionaries.SpellingCorrector.AddRange(words);
 
// Export words to a file
index.Dictionaries.SpellingCorrector.ExportDictionary(@"C:\Words.txt");
 
// Import words from a file
index.Dictionaries.SpellingCorrector.ImportDictionary(@"C:\Words.txt");
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
