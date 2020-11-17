---
id: homophone-dictionary
url: search/net/homophone-dictionary
title: Homophone dictionary
weight: 5
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
The [HomophoneDictionary](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/homophonedictionary) class is designed to store homophones in an index. For information on searching using homophones, see the [Homophone search]({{< ref "search/net/developer-guide/advanced-usage/searching/homophone-search.md" >}}) page.

To get the number of homophones in the dictionary, use the [Count](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/homophonedictionary/properties/count) property.

To add groups of homophones to the dictionary, use the [AddRange](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/homophonedictionary/methods/addrange/index) method.

The [Clear](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/homophonedictionary/methods/clear) method is used to remove all homophones from the dictionary.

The [GetHomophones](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/homophonedictionary/methods/gethomophones) method is used to get a list of synonyms for a given word.

The [GetHomophoneGroups](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/homophonedictionary/methods/gethomophonegroups) method is used to get all synonym groups to which a given word belongs.

To get all synonym groups from the dictionary, use the [GetAllHomophoneGroups](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/homophonedictionary/methods/getallhomophonegroups) method.

To export homophones to a file, use the [ExportDictionary](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/dictionarybase/methods/exportdictionary) method.

To import homophones from a file, use the [ImportDictionary](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/dictionarybase/methods/importdictionary) method.

The following example demonstrates the use of methods of the homophone dictionary.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";

// Creating an index from in specified folder
Index index = new Index(indexFolder);

// Getting homophones for word 'braid'
string[] homophones = index.Dictionaries.HomophoneDictionary.GetHomophones("braid");
Console.WriteLine("Homophones for 'braid':");
for (int i = 0; i < homophones.Length; i++)
{
    Console.WriteLine(homophones[i]);
}

// Getting groups of homophones to which word 'braid' belongs to
string[][] groups = index.Dictionaries.HomophoneDictionary.GetHomophoneGroups("braid");
Console.WriteLine("Homophone groups for 'braid':");
for (int i = 0; i < groups.Length; i++)
{
    string[] group = groups[i];
    for (int j = 0; j < group.Length; j++)
    {
        Console.Write(group[j] + " ");
    }
    Console.WriteLine();
}

if (index.Dictionaries.HomophoneDictionary.Count > 0)
{
    // Removing all homophones from the dictionary
    index.Dictionaries.HomophoneDictionary.Clear();
}

// Adding homophones to the dictionary
string[][] homophoneGroups = new string[][]
{
    new string[] { "awe", "oar", "or", "ore" },
    new string[] { "aye", "eye", "i" },
};
index.Dictionaries.HomophoneDictionary.AddRange(homophoneGroups);

// Export homophones to a file
index.Dictionaries.HomophoneDictionary.ExportDictionary(@"C:\Homophones.dat");

// Import homophones from a file
index.Dictionaries.HomophoneDictionary.ImportDictionary(@"C:\Homophones.dat");
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
