---
id: groupdocs-search-for-net-19-3-release-notes
url: search/net/groupdocs-search-for-net-19-3-release-notes
title: GroupDocs.Search for .NET 19.3 Release Notes
weight: 5
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 19.3{{< /alert >}}

## Major Features

There are the following improvements in this release:

*   Implement event that notifies about search phase finished
*   Implement logging of indexing operations
*   Searching for a complete phrase with stop words
*   Implement Dictionary API enhancements

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-659 | Implement event that notifies about search phase finished | Improvement |
| SEARCHNET-1833 | Implement logging of indexing operations | Improvement |
| SEARCHNET-1845 | Searching for a complete phrase with stop words | Improvement |
| SEARCHNET-1878 | Implement Dictionary API enhancements | Improvement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Search for .NET 19.3. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Search which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Implement event that notifies about search phase finished

This improvement adds event that notifies about search phase is finished and provides intermediate results.

**Public API changes**

Enum **SearchPhase** has been added to **GroupDocs.Search.Events** namespace.  
Value **AliasSubstitution** has been added to **GroupDocs.Search.Events.SearchPhase** enum.  
Value **KeyboardLayoutCorrection** has been added to **GroupDocs.Search.Events.SearchPhase** enum.  
Value **SpellingCorrection** has been added to **GroupDocs.Search.Events.SearchPhase** enum.  
Value **HomophoneSearch** has been added to **GroupDocs.Search.Events.SearchPhase** enum.  
Value **SynonymSearch** has been added to **GroupDocs.Search.Events.SearchPhase** enum.  
Value **WordFormsSearch** has been added to **GroupDocs.Search.Events.SearchPhase** enum.  
Value **FuzzySearch** has been added to **GroupDocs.Search.Events.SearchPhase** enum.  
Value **WildcardMatching** has been added to **GroupDocs.Search.Events.SearchPhase** enum.  
Value **RegexMatching** has been added to **GroupDocs.Search.Events.SearchPhase** enum.

Class **SearchPhaseEventArgs** has been added to **GroupDocs.Search.Events** namespace.  
Property **SearchPhase SearchPhase** has been added to **GroupDocs.Search.Events.SearchPhaseEventArgs** class.  
Property **string Query** has been added to **GroupDocs.Search.Events.SearchPhaseEventArgs** class.  
Property **string\[\] Words** has been added to **GroupDocs.Search.Events.SearchPhaseEventArgs** class.

Event **EventHandler\<SearchPhaseEventArgs> SearchPhaseCompleted** has been added to **GroupDocs.Search.Index** class

The example to perform that how to use **SearchPhaseCompleted** event.

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Adding synonyms
index.Dictionaries.SynonymDictionary.AddRange(new string[][] { new string[] { "big", "large" } });

// Adding documents to index
index.AddToIndex(documentFolder);

// Subscribing to the event
index.SearchPhaseCompleted += (sender, args) =>
{
    Console.WriteLine(args.SearchPhase + ": " + args.Words.Length);
};

// Creating search parameters
SearchParameters parameters = new SearchParameters();
parameters.UseCaseSensitiveSearch = false;
parameters.KeyboardLayoutCorrector.Enabled = true;
parameters.SpellingCorrector.Enabled = true;
parameters.SpellingCorrector.MaxMistakeCount = 1;
parameters.UseHomophoneSearch = true;
parameters.UseSynonymSearch = true;
parameters.UseWordFormsSearch = true;
parameters.FuzzySearch.Enabled = true;
parameters.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(1);

// Searching for word 'big'.
// Note that enabling many of search options at a time may give many results and take a long time.
SearchResults results = index.Search("big", parameters);
```

### Implement logging of indexing operations

This improvement implements logging of main index operations to file **'log.txt'** inside index folder.

### Searching for a complete phrase with stop words

This improvement provides ability of searching phrases containing stop words. Stop words are words that are not included in an index to reduce index size.

The following example shows how to search with stop words.

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Adding stop words to dictionary
// Note that words 'in' and 'these' are stop words by default. This line of code is here for demonstration purposes only.
index.Dictionaries.StopWordDictionary.AddRange(new string[] { "in", "these" });

// Adding documents to index
index.AddToIndex(documentFolder);

// Searching for phrase without stop words
SearchResults results1 = index.Search("\"information contained *1 *1 materials\"");

// Searching for phrase containing stop words
// This search gives the same results as the previous one
SearchResults results2 = index.Search("\"information contained in these materials\"");
```

### Implement Dictionary API enhamcements

This improvement adds overloads of **AddRange()** methods to dictionary classes.

**Public API changes**

Class **AliasReplacementPair** has been added to **GroupDocs.Search** namespace.  
Constructor **AliasReplacementPair(string, string)** has been added to **GroupDocs.Search.AliasReplacementPair** class.  
Property **string Alias** has been added to **GroupDocs.Search.AliasReplacementPair** class.  
Property **string Replacement** has been added to **GroupDocs.Search.AliasReplacementPair** class.

Class **CharacterReplacementPair** has been added to **GroupDocs.Search** namespace.  
Constructor **CharacterReplacementPair(char, char)** has been added to **GroupDocs.Search.CharacterReplacementPair** class.  
Property **char Character** has been added to **GroupDocs.Search.CharacterReplacementPair** class.  
Property **char Replacement** has been added to **GroupDocs.Search.CharacterReplacementPair** class.

Method **AddRange(IEnumerable\<AliasReplacementPair>)** has been added to **GroupDocs.Search.AliasDictionary** class.  
Method **AddRange(AliasReplacementPair\[\])** has been added to **GroupDocs.Search.AliasDictionary** class.

Method **AddRange(IEnumerable\<CharacterReplacementPair>)** has been added to **GroupDocs.Search.CharacterReplacementDictionary** class.  
Method **AddRange(CharacterReplacementPair\[\])** has been added to **GroupDocs.Search.CharacterReplacementDictionary** class.

Method **AddRange(string\[\])** has been added to **GroupDocs.Search.SpellingCorrector** class. 

Method **AddRange(string\[\]\[\])** has been added to **GroupDocs.Search.HomophoneDictionary** class.

Method **AddRange(string\[\])** has been added to **GroupDocs.Search.StopWordDictionary** class.

Method **RemoveRange(string\[\])** has been added to **GroupDocs.Search.StopWordDictionary** class.

Method **AddRange(string\[\]\[\])** has been added to **GroupDocs.Search.SynonymDictionary** class.

The example to perform indexing is given below.

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";
 
// Creating index
Index index = new Index(indexFolder);
 
// Adding alias for a query
index.Dictionaries.AliasDictionary.AddRange(new AliasReplacementPair[] { new AliasReplacementPair("query1", "\"Celestial mechanics\"") });
 
// Adding stop words
index.Dictionaries.StopWordDictionary.AddRange(new string[] { "i", "we", "you", "he", "she", "it" });
 
// Adding words to spelling corrector
index.Dictionaries.SpellingCorrector.AddRange(new string[] { "Newton", "Leibniz" });
 
// Indexing
index.AddToIndex(documentFolder);
 
// Searching
SearchResults results = index.Search("query1");
```
