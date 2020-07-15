---
id: alias-dictionary
url: search/net/alias-dictionary
title: Alias dictionary
weight: 1
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
An instance of the [AliasDictionary](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/aliasdictionary) class contains all the aliases defined in an index. Information on using aliases to search is provided on the [Using aliases]({{< ref "search/net/developer-guide/advanced-usage/searching/using-aliases.md" >}}) page.

To get the number of existing aliases, use the [Count](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/aliasdictionary/properties/count) property.

Use the [Add](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/aliasdictionary/methods/add) method to add new alias-replacement pair.

Use the [AddRange](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/aliasdictionary/methods/addrange/index) method to add a collection of new alias-replacement pairs.

To remove an alias from the dictionary, use the [Remove](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/aliasdictionary/methods/remove) method.

The [Contains](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/aliasdictionary/methods/contains) method is used to check for the presence of a particular alias in the dictionary.

To get a replacement for a particular alias, use the [GetText](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/aliasdictionary/methods/gettext) method.

The [Clear](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/aliasdictionary/methods/clear) method is used to remove all existing aliases from the dictionary.

To export the list of aliases with replacements to a file, use the [ExportDictionary](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/dictionarybase/methods/exportdictionary) method.

To import the list of aliases from a file, use the [ImportDictionary](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/dictionarybase/methods/importdictionary) method.

The following example demonstrates the use of methods of the alias dictionary.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
 
// Creating or opening an index from the specified folder
Index index = new Index(indexFolder);
 
if (index.Dictionaries.AliasDictionary.Count > 0)
{
    // Deleting all existing aliases
    index.Dictionaries.AliasDictionary.Clear();
}
 
// Adding aliases to the alias dictionary
index.Dictionaries.AliasDictionary.Add("t", "(theory OR relativity)");
index.Dictionaries.AliasDictionary.Add("e", "(Einstein OR Albert)");
AliasReplacementPair[] pairs = new AliasReplacementPair[]
{
    new AliasReplacementPair("d", "daterange(2017-01-01 ~~ 2019-12-31)"),
    new AliasReplacementPair("n", "(100 ~~ 900)"),
};
index.Dictionaries.AliasDictionary.AddRange(pairs);
 
if (index.Dictionaries.AliasDictionary.Contains("e"))
{
    // Getting an alias replacement
    string replacement = index.Dictionaries.AliasDictionary.GetText("e");
    Console.WriteLine("e - " + replacement);
}
 
// Export aliases to a file
index.Dictionaries.AliasDictionary.ExportDictionary(@"C:\Aliases.dat");
 
// Import aliases from a file
index.Dictionaries.AliasDictionary.ImportDictionary(@"C:\Aliases.dat");
 
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
