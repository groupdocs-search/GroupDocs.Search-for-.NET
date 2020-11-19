---
id: groupdocs-search-for-net-20-11-release-notes
url: search/net/groupdocs-search-for-net-20-11-release-notes
title: GroupDocs.Search for .NET 20.11 Release Notes
weight: 5
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 20.11{{< /alert >}}

## Major Features

There are the following improvementes in this release:

- Implement methods to get synonym groups
- Implement methods to get homophone groups

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-2435 | Implement methods to get synonym groups   | Improvement |
| SEARCHNET-2445 | Implement methods to get homophone groups | Improvement |

## Public API and Backward Incompatible Changes

### Implement methods to get synonym groups

This improvement adds a method to get synonyms for a specific word from the synonym dictionary. Also, this improvement adds methods for getting the groups of synonyms to which a certain word belongs in the dictionary, and for getting all groups of synonyms contained in the dictionary.

##### Public API changes

Method **string[] GetSynonyms(string)** has been added to **GroupDocs.Search.Dictionaries.SynonymDictionary** class.  
Method **string[]\[] GetSynonymGroups(string)** has been added to **GroupDocs.Search.Dictionaries.SynonymDictionary** class.  
Method **string[]\[] GetAllSynonymGroups()** has been added to **GroupDocs.Search.Dictionaries.SynonymDictionary** class.

##### Use cases

The following example demonstrates how to get synonyms for a word and how to get synonym groups to which a word belongs to.

**C#**

```csharp
// Creating an index in memory with default synonym dictionary
Index index = new Index();

// Getting synonyms for word 'make'
string[] synonyms = index.Dictionaries.SynonymDictionary.GetSynonyms("make");
Console.WriteLine("Synonyms for 'make':");
for (int i = 0; i < synonyms.Length; i++)
{
    Console.WriteLine(synonyms[i]);
}

// Getting groups of synonyms to which word 'make' belongs to
string[][] groups = index.Dictionaries.SynonymDictionary.GetSynonymGroups("make");
Console.WriteLine("Synonym groups for 'make':");
for (int i = 0; i < groups.Length; i++)
{
    string[] group = groups[i];
    for (int j = 0; j < group.Length; j++)
    {
        Console.Write(group[j] + " ");
    }
    Console.WriteLine();
}
```

### Implement methods to get homophone groups

This improvement adds a method to get homophones for a specific word from the homophone dictionary. Also, this improvement adds methods for getting the groups of homophones to which a certain word belongs in the dictionary, and for getting all groups of homophones contained in the dictionary.

##### Public API changes

Method **string[] GetHomophones(string)** has been added to **GroupDocs.Search.Dictionaries.HomophoneDictionary** class.  
Method **string[]\[] GetHomophoneGroups(string)** has been added to **GroupDocs.Search.Dictionaries.HomophoneDictionary** class.  
Method **string[]\[] GetAllHomophoneGroups()** has been added to **GroupDocs.Search.Dictionaries.HomophoneDictionary** class.

##### Use cases

The following example demonstrates how to get homophones for a word and how to get homophone groups to which a word belongs to.

**C#**

```csharp
// Creating an index in memory with default homophone dictionary
Index index = new Index();

// Getting homophones for word 'braid'
string[] homophones = index.Dictionaries.HomophoneDictionary.GetHomophones("make");
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
```
