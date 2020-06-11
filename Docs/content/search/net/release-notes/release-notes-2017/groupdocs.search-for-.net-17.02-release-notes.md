---
id: groupdocs-search-for-net-17-02-release-notes
url: search/net/groupdocs-search-for-net-17-02-release-notes
title: GroupDocs.Search for .NET 17.02 Release Notes
weight: 11
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 17.2{{< /alert >}}

## Major Features

There are 3 features and enhancements in this regular monthly release. The most notable are:

1.  Inherit Password dictionary from IEnumerable to make it like other dictionaries
2.  Support different search features in one search query
3.  Implement recognizing the queries written in a different keyboard layout

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-802 | Inherit Password dictionary from IEnumerable to make it like other dictionaries | Enhancement |
| SEARCHNET-841 | Support different search features in one search query | Enhancement |
| SEARCHNET-384 | Implement recognizing the queries written in a different keyboard layout | New Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Search for .NET 17.2. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Search which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Inherit Password dictionary from IEnumerable to make it like other dictionaries

This enhancement allows using privileges of IEnumerable for Password dictionary.

**Public API Changes**  
Method **GetEnumerator** has been added to **GroupDocs.Search.PasswordDictionary** class.

This example shows how to use GetEnumerator method:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";

Index index = new Index(indexFolder);
index.Dictionaries.DocumentPasswords.Add(@"c:\document1.pdf", "password1");
index.Dictionaries.DocumentPasswords.Add(@"c:\document2.pdf", "password2");
index.Dictionaries.DocumentPasswords.Add(@"c:\document3.pdf", "password3");

foreach (string documentName in index.Dictionaries.DocumentPasswords)
{
    string password = index.Dictionaries.DocumentPasswords[documentName];
}


```

#### Support different search features in one search query

This enhancement allows using all search features in one search query.  
Please note that turning on all search features can extremely reduce the search speed.

This example shows how to use all search features:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";
string query = "@alias term ^reg.ex зфгыу"; // Query with alias, ordinary term, regex and term for spelling corrector

Index index = new Index(indexFolder);
index.AddToIndex(documentsFolder);

index.Dictionaries.AliasDictionary.Add("alias", "alias subquery"); // Adding alias to dictionary
index.Dictionaries.HomophoneDictionary.AddRange(new List<string[]> { new string[] { "cell", "sell" } }); // Adding homophones to dictionary
index.Dictionaries.SynonymDictionary.AddRange(new List<string[]> { new string[] { "little", "small" } }); // Adding synonyms to dictionary

SearchParameters searchParams = new SearchParameters();
searchParams.KeyboardLayoutCorrector.Enabled = true; // Turning on layout corrector
searchParams.SpellingCorrector.Enabled = true; // Turning on spelling corrector
searchParams.SpellingCorrector.MaxMistakeCount = 1;
searchParams.UseSynonymSearch = true; // Turning on synonym search feature
searchParams.UseHomophoneSearch = true; // Turning on homophone search feature
searchParams.FuzzySearch.Enabled = true; // Turning on fuzzy search feature
searchParams.FuzzySearch.SimilarityLevel = 0.9; // Turning on fuzzy search feature

SearchResults results = index.Search(query, searchParams); // Run searching with all search features

```

#### Implement recognizing the queries written in a different keyboard layout

This feature allows recognizing queries written in a language that is not matched to the keyboard layout.  
Keyboard Layout Corrector supports 88 languages and 164 different keyboard layouts.

**Public API Changes**  
Class **KeyboardLayoutCorrectorParameters** has been added to **GroupDocs.Search** namespace.  
Property **GroupDocs.Search.KeyboardLayoutCorrectorParameters KeyboardLayoutCorrector** has been added to **GroupDocs.Search.SearchParameters** class.

This example shows how to use Keyboard Layout Corrector:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";
string searchQuery = "зфгыу"; // Word "pause" in Russian keyboard layout

Index index = new Index(indexFolder);
index.AddToIndex(documentsFolder);

SearchParameters parameters = new SearchParameters();
parameters.KeyboardLayoutCorrector.Enabled = true; // Enable keyboard layout correction in parameters

SearchResults results = index.Search(searchQuery, parameters); // Search for "pause"

```
