---
id: alphabet
url: search/net/alphabet
title: Alphabet
weight: 2
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
An instance of the [Alphabet](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/alphabet) class contains types of characters used for indexing. For detailed information on the types of characters, see the [Character types]({{< ref "search/net/developer-guide/advanced-usage/indexing/character-types.md" >}}) page.

The [GetCharacterType](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/alphabet/methods/getcharactertype) method is used to get the type of a specific character.

The [Count](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/alphabet/properties/count) property returns the number of characters of a type other than [CharacterType](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/charactertype).Separator.

To set the type of characters in the alphabet, use the [SetRange](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/alphabet/methods/setrange) method.

To set the [CharacterType](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/charactertype).Separator type for all characters in the alphabet, use the [Clear](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/alphabet/methods/clear) method.

To export types of all characters to a file, use the [ExportDictionary](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/dictionarybase/methods/exportdictionary) method.

To import types of all characters from a file, use the [ImportDictionary](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/dictionarybase/methods/importdictionary) method.

The following example demonstrates the use of methods of the alphabet.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
 
// Creating or opening an index from the specified folder
Index index = new Index(indexFolder);
 
if (index.Dictionaries.Alphabet.Count > 0)
{
    // Setting a type of all characters to Separator
    index.Dictionaries.Alphabet.Clear();
}
 
if (index.Dictionaries.Alphabet.GetCharacterType('-') != CharacterType.Blended)
{
    // Setting a type of hyphen character to Blended
    index.Dictionaries.Alphabet.SetRange(new char[] { '-' }, CharacterType.Blended);
}
 
// Export the alphabet to a file
index.Dictionaries.Alphabet.ExportDictionary(@"C:\Alphabet.dat");
 
// Import the alphabet from a file
index.Dictionaries.Alphabet.ImportDictionary(@"C:\Alphabet.dat");
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
