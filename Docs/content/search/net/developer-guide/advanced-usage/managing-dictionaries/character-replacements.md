---
id: character-replacements
url: search/net/character-replacements
title: Character replacements
weight: 3
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
An instance of the [CharacterReplacementDictionary](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/characterreplacementdictionary) class contains all the character replacements defined in an index. For detailed information on character replacement, see the [Character replacement during Indexing]({{< ref "search/net/developer-guide/advanced-usage/indexing/character-replacement-during-indexing.md" >}}) page.

The [Count](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/characterreplacementdictionary/properties/count) property allows you to get the number of character replacements defined in the dictionary.

To add character replacements to the dictionary, use the [AddRange](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/characterreplacementdictionary/methods/addrange/index) method.

To remove character replacements from the dictionary, the [RemoveRange](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/characterreplacementdictionary/methods/removerange/index) method is used.

The [Contains](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/characterreplacementdictionary/methods/contains) method is used to determine if the dictionary contains a replacement for the specified character.

To get a replacement for the specified character, use the [GetReplacement](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/characterreplacementdictionary/methods/getreplacement) method.

To remove all replacements from the dictionary, use the [Clear](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/characterreplacementdictionary/methods/clear) method.

To export all replacements to a file, use the [ExportDictionary](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/dictionarybase/methods/exportdictionary) method.

To import character replacements from a file, use the [ImportDictionary](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/dictionarybase/methods/importdictionary) method.

The following example demonstrates the use of the character replacement dictionary methods.

**C#**

```csharp
 string indexFolder = @"c:\MyIndex\";
 
// Creating an index from in specified folder
Index index = new Index(indexFolder);
 
if (index.Dictionaries.CharacterReplacements.Count > 0)
{
    // Deleting all character replacements from the dictionary
    index.Dictionaries.CharacterReplacements.Clear();
}
 
if (index.Dictionaries.CharacterReplacements.Contains('-'))
{
    char replacement = index.Dictionaries.CharacterReplacements.GetReplacement('-');
    Console.WriteLine("The replacement for hyphen is " + replacement);
 
    // Deleting the hyphen character replacement from the dictionary
    index.Dictionaries.CharacterReplacements.RemoveRange(new char[] { '-' });
}
 
// Export character replacements to a file
index.Dictionaries.CharacterReplacements.ExportDictionary(@"C:\CharacterReplacements.dat");
 
// Import character replacements from a file
index.Dictionaries.CharacterReplacements.ImportDictionary(@"C:\CharacterReplacements.dat");
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
