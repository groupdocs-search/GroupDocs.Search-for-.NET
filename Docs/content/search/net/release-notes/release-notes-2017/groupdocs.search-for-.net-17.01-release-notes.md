---
id: groupdocs-search-for-net-17-01-release-notes
url: search/net/groupdocs-search-for-net-17-01-release-notes
title: GroupDocs.Search for .NET 17.01 Release Notes
weight: 12
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 17.1{{< /alert >}}

## Major Features

There are 4 features in this regular monthly release. The most notable are:

1.  Implement correcting words in search query before searching
2.  Implement Alias Dictionary functionality
3.  Implement Homophone Dictionary functionality
4.  Implement Merge Indexes functionality

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-445 | Implement correcting words in search query before searching | New Feature |
| SEARCHNET-703 | Implement Alias Dictionary functionality | New Feature |
| SEARCHNET-704 | Implement Homophone Dictionary functionality | New Feature |
| SEARCHNET-177 | Implement Merge Indexes functionality | New Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Search for .NET 17.1. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Search which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Implement correcting words in search query before searching

This feature allows correcting misspelled words in a query before performing the search.  
Spelling corrector supports 4 types of mistakes:

insertion of a single character  
deletion of a single character  
substitution of a single character  
transposition of two adjacent characters  
Spelling corrector supports up to 3 mistakes for each word in a query. The increase of error count increases the time of the search.  
Spelling corrector has default collection of English words but the user can modify the collection.

**Public API Changes**  
Class **SpellingCorrectorParameters** class has been added to **GroupDocs.Search** namespace.  
Property **GroupDocs.Search.SpellingCorrectorParameters SpellingCorrector** has been added to **GroupDocs.Search.SearchParameters** class.  
Class **SpellingCorrector** has been added to **GroupDocs.Search** namespace.  
Property **GroupDocs.Search.SpellingCorrector SpellingCorrector** has been added to **GroupDocs.Search.DictionaryCollection** class.

This example shows how to use Spelling Corrector:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

Index index = new Index(indexFolder);
index.AddToIndex(documentsFolder);

SearchParameters parameters = new SearchParameters();
parameters.SpellingCorrector.Enabled = true; // Enabling spelling corrector
parameters.SpellingCorrector.MaxMistakeCount = 1; // The default value for maximum mistake count is 2

SearchResults results = index.Search("strukture", parameters); // Search for misspelled term 'structure'


```

This example shows how to manage dictionary of Spelling Corrector:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

Index index = new Index(indexFolder);
index.AddToIndex(documentsFolder);

index.Dictionaries.SpellingCorrector.Clear(); // Remove all words from spelling corrector dictionary
index.Dictionaries.SpellingCorrector.Import(@"c:\MySpellingDictionary.txt"); // Import spelling dictionary from file. Existing words are staying.
string[] words = new string[] { "structure", "building", "rail", "house" };
index.Dictionaries.SpellingCorrector.AddRange(words); // Add word array to the dictionary. Words are case insensitive.
index.Dictionaries.SpellingCorrector.Export(@"c:\MyExportedSpellingDictionary.txt"); // Export spelling dictionary to file.

SearchParameters parameters = new SearchParameters();
parameters.SpellingCorrector.Enabled = true; // Enabling spelling corrector
parameters.SpellingCorrector.MaxMistakeCount = 1; // The default value for maximum mistake count is 2

SearchResults results = index.Search("strukture", parameters); // Search for misspelled term 'structure'

```

The imported dictionary must contain in each line one word. This example shows the content of "c:\\MySpellingDictionary.txt" file:

**C#**

```csharp
newspaper
opera
sensibility

```

#### Implement Alias Dictionary functionality

This feature allows using abbreviations for frequent long queries.  
Abbreviation (alias) must start with @ character in a query.  
Nested abbreviations are not supported, so abbreviations inside of other abbreviation will not be recognized.

**Public API Changes**  
Class **AliasDictionary** has been added to **GroupDocs.Search** namespace.  
Property **GroupDocs.Search.AliasDictionary AliasDictionary** has been added to **GroupDocs.Search.DictionaryCollection** class.

This example shows how to add one alias to the dictionary before search:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

Index index = new Index(indexFolder);
index.AddToIndex(documentsFolder);

index.Dictionaries.AliasDictionary.Add("s", "structure"); // Add alias 's' to the dictionary

SearchResults results = index.Search("@s"); // Search for term 'structure'

```

This example shows how to use Alias Dictionary:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";
string searchQuery = "@s";
string aliasesFileName = @"c:\MyAliases.txt";

Index index = new Index(indexFolder);
index.AddToIndex(documentsFolder);

index.Dictionaries.AliasDictionary.Clear(); // Clear dictionary of aliases
index.Dictionaries.AliasDictionary.Add("s", "structure"); // Add alias 's' to the dictionary. Alias and aliased text are case insensitive.
index.Dictionaries.AliasDictionary.Remove("x"); // Remove alias 'x' from the dictionary. Words which are absent will be ignored.
index.Dictionaries.AliasDictionary.Import(aliasesFileName); // Import aliases from file. Existing aliases are staying.
index.Dictionaries.AliasDictionary.Export(@"c:\MyExportedAliases.txt"); // Export aliases to file

SearchResults results = index.Search(searchQuery); // Search for term 'structure'

```

This example shows the content of "MyAliases.txt" file:

**C#**

```csharp
@y
example

@z
example AND usage

```

#### Implement Homophone Dictionary functionality

This feature allows to manage the list of heterographic homophones and use it to improve search results.  
Users can change the list of homophones before searching.  
Homophone dictionary has default collection of English homophones but the user can modify the collection.

**Public API Changes**  
Class **HomophoneDictionary** has been added to **GroupDocs.Search** namespace.  
Property **GroupDocs.Search.HomophoneDictionary HomophoneDictionary** has been added to **GroupDocs.Search.DictionaryCollection** class.  
Property **bool UseHomophoneSearch** has been added to **GroupDocs.Search.SearchParameters** class.

This example shows how to use Homophone Search:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";
string searchQuery = "pause";

Index index = new Index(indexFolder);
index.AddToIndex(documentsFolder);

SearchParameters parameters = new SearchParameters();
parameters.UseHomophoneSearch = true; // Enable homophone search in parameters

SearchResults results = index.Search(searchQuery , parameters); // Search for "pause", "paws", "pores", "pours"

```

This example shows how to manage Homophone dictionary:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";
string searchQuery = "pause";
string homophonesFileName = @"c:\MyHomophones.txt";

Index index = new Index(indexFolder);
index.AddToIndex(documentsFolder);

// Clearing homophone dictionary
index.Dictionaries.HomophoneDictionary.Clear();

// Adding homophones
string[] homophoneGroup1 = new string[] {"braise", "brays", "braze" };
string[] homophoneGroup2 = new string[] {"pause", "paws", "pores", "pours" };
List<string[]> homophoneGroups = new List<string[]>();
homophoneGroups.Add(homophoneGroup1);
homophoneGroups.Add(homophoneGroup2);
index.Dictionaries.HomophoneDictionary.AddRange(homophoneGroups);

index.Dictionaries.HomophoneDictionary.Import(homophonesFileName); // Import homophones from file. Existing homophones are staying.
index.Dictionaries.HomophoneDictionary.Export(@"c:\MyExportedHomophones.txt"); // Export homophones to file

SearchParameters parameters = new SearchParameters();
parameters.UseHomophoneSearch = true; // Enable homophone search in parameters

SearchResults results = index.Search(searchQuery , parameters); // Search for "pause", "paws", "pores", "pours"

```

This example shows the content of the "MyHomophones.txt" file:

**C#**

```csharp
alms
arms

altar
alter

bight
bite
byte

```

#### Implement Merge Indexes functionality

This feature allows merging two or more indexes to one.  
If the index is updated frequently, it has several delta indexes and Merging functionality can be used to merge all delta indexes in one for search performance improvement.  
After performing Merge, the main index will contain all the information from the merged indexes, but the indexes are merged remain unchanged.  
Merging works for indexes v17.1 and later.

**Public API changes**  
Method **Merge** has been added to **GroupDocs.Index** class.  
Method **MergeAsync** has been added to **GroupDocs.Index** class.  
Value **MergingFinished** has been added to **GroupDocs.Search.Events.OperationType** enum.

This example shows how to merge index with delta indexes to improve search performance:

**C#**

```csharp
string indexName = "MyIndex";
string myDocumentsFolder1 = @"c:\My Documents1\";
string myDocumentsFolder2 = @"c:\My Documents2\";

// Creating index
Index index = new Index(indexName, true);

// Adding documents to index
index.AddToIndex(myDocumentsFolder1);

// Adding one more folder to index. Delta index will be created.
index.AddToIndex(myDocumentsFolder2);

// Run merging
index.Merge();

```

This example shows how to merge several indexes:

**C#**

```csharp
// Creating/loading first index
Index index1 = new Index(@"c:\MyIndex1");
index1.AddToIndex(@"c:\MyDocuments1");

// Creating/loading second index
Index index2 = new Index(@"c:\MyIndex2");
index2.AddToIndex(@"c:\MyDocuments2");

index1.Merge(index2); // Merging data from index2 to index1. The index2 remains unchanged.

```

The following is an example of Merging current index with index repository:

**C#**

```csharp
IndexRepository indexRepository = new IndexRepository();
Index index1 = indexRepository.Create("IndexForMerging1");
index1.AddToIndex(@"c:\MyDocuments1");

Index index2 = indexRepository.Create("IndexForMerging2");
index2.AddToIndex(@"c:\MyDocuments2");

Index mainIndex = new Index("MainIndexName");
mainIndex.AddToIndex(@"c:\MyDocuments3");

// Merge data from indexes in repository to main index. After merge index repository stays unmodified.
mainIndex.Merge(indexRepository);

```

This example shows how to merge index with delta indexes asynchronously to improve search performance:

**C#**

```csharp
string indexName = "MyIndex";
string myDocumentsFolder1 = @"c:\My Documents1\";
string myDocumentsFolder2 = @"c:\My Documents2\";

// Creating index
Index index = new Index(indexName, true);

// Adding documents to index
index.AddToIndex(myDocumentsFolder1);

// Adding one more folder to index. Delta index will be created.
index.AddToIndex(myDocumentsFolder2);

// Run merging asynchonously
index.MergeAsync();

```

This example shows how to merge several indexes asynchronously:

**C#**

```csharp
// Creating/loading first index
Index index1 = new Index(@"c:\MyIndex1");
index1.AddToIndex(@"c:\MyDocuments1");

// Creating/loading second index
Index index2 = new Index(@"c:\MyIndex2");
index2.AddToIndex(@"c:\MyDocuments2");

index1.MergeAsync(index2); // Merging data from index2 to index1. The index2 remains unchanged.

```

The following is an example of Merging current index with index repository asynchronously:

**C#**

```csharp
IndexRepository indexRepository = new IndexRepository();
Index index1 = indexRepository.Create("IndexForMerging1");
index1.AddToIndex(@"c:\MyDocuments1");

Index index2 = indexRepository.Create("IndexForMerging2");
index2.AddToIndex(@"c:\MyDocuments2");

Index mainIndex = new Index("MainIndexName");
mainIndex.AddToIndex(@"c:\MyDocuments3");

// Merge data from indexes in repository to main index. After merge index repository stays unmodified.
mainIndex.MergeAsync(indexRepository);

```
