---
id: groupdocs-search-for-net-18-12-release-notes
url: search/net/groupdocs-search-for-net-18-12-release-notes
title: GroupDocs.Search for .NET 18.12 Release Notes
weight: 1
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 18.12.{{< /alert >}}

## Major Features

There are 2 new features in this regular monthly release:

*   Implement blended characters
*   Implement wildcard search

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-803 | Implement blended characters | New Feature |
| SEARCHNET-1781 | Implement wildcard search | New Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Search for .NET 18.12. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Search which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Implement blended characters

##### Description

This feature introduces a new class of characters - blended. When indexing, blended characters are interpreted simultaneously as valid letters and as separators.  
For example, if the hyphen is marked as a blended character then indexing of term 'silver-gray' will result in saving of 3 terms in the index: 'silver', 'gray', and 'silver-gray'.

##### Public API changes

Enum **CharacterType** has been added to **GroupDocs.Search** namespace.  
Value **Separator** has been added to **GroupDocs.Search.CharacterType** enum.  
Value **Letter** has been added to **GroupDocs.Search.CharacterType** enum.  
Value **Blended** has been added to **GroupDocs.Search.CharacterType** enum.

Indexer **CharacterType Item(char)** has been added to **GroupDocs.Search.Alphabet** class.  
Method **SetRange(char\[\], CharacterType)** nas been added to **GroupDocs.Search.Alphabet** class.

##### Usecases

This example shows how to perform indexing and search with blended characters:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";
  
// Creating index
Index index = new Index(indexFolder);
  
// Marking hyphen as blended character
index.Dictionaries.Alphabet.SetRange(new char[] { '-' }, CharacterType.Blended);
  
// Adding documents to index
index.AddToIndex(documentFolder);
  
// Searching for word 'silver-gray'
SearchResults results = index.Search("silver-gray");
```

### Implement wildcard search

##### Description

This feature allows to perform search of words containing wildcards.  
There are two possible forms of wildcard to use in wildcard search:

*   ? - quotation mark representing one arbitrary character
*   ?(N~M) -range of arbitrary characters in an amount from N to M, where N and M must be in the range from 0 to 255

As well implemented the ability to perform wildcard search using the more flexible object form of search query.

##### Public API changes

Class **WordPattern** has been added to **GroupDocs.Search** namespace.  
Constructor **WordPattern()** nas been added to **GroupDocs.Search.WordPattern** class.  
Method **AppendString(string)** nas been added to **GroupDocs.Search.WordPattern** class.  
Method **AppendCharacter(char)** nas been added to **GroupDocs.Search.WordPattern** class.  
Method **AppendOneCharacterWildcard()** nas been added to **GroupDocs.Search.WordPattern** class.  
Method **AppendZeroOrOneCharacterWildcard()** nas been added to **GroupDocs.Search.WordPattern** class.  
Method **AppendZeroOrMoreCharactersWildcard()** nas been added to **GroupDocs.Search.WordPattern** class.  
Method **AppendOneOrMoreCharactersWildcard()** nas been added to **GroupDocs.Search.WordPattern** class.  
Method **AppendWildcard(int, int)** nas been added to **GroupDocs.Search.WordPattern** class.

Method **SearchQuery CreateWordPatternQuery(WordPattern)** nas been added to **GroupDocs.Search.SearchQuery** class.

Method **SearchQuery GetChild(int)** nas been added to **GroupDocs.Search.SearchQuery** class.

##### Usecases

The first example shows how to perform wildcard search using the query in text form:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";
  
// Creating index
Index index = new Index(indexFolder);
  
// Adding documents to index
index.AddToIndex(documentFolder);
  
// Searching for words 'affect' or 'effect' in a one document with 'principal', 'principle', 'principles', or 'principally'
SearchResults results1 = index.Search("?ffect & princip?(2~4)");
  
// Searching with a single query for phrases 'assure equal opportunities', 'ensure equal opportunities', and 'sure equal opportunities'
SearchResults results2 = index.Search("\"?(0~2)sure equal opportunities\"");
```

The next example shows how to perform wildcard search using query in object form:

**C#**

```csharp
string documentFolder = @"c:\MyDocuments";
  
// Creating index
Index index = new Index(indexFolder);
  
// Adding documents to index
index.AddToIndex(documentFolder);
  
// Constructing query 1
// Word 1 in the query is a pattern '?ffect' for wildcard search
WordPattern pattert11 = new WordPattern();
pattert11.AppendOneCharacterWildcard();
pattert11.AppendString("ffect");
SearchQuery subquery11 = SearchQuery.CreateWordPatternQuery(pattert11);
  
// Word 2 in the query is a pattern 'princip?(2~4)' for wildcard search
WordPattern pattert12 = new WordPattern();
pattert12.AppendString("princip");
pattert12.AppendWildcard(2, 4);
SearchQuery subquery12 = SearchQuery.CreateWordPatternQuery(pattert12);
  
// Creating boolean search query
SearchQuery query1 = SearchQuery.CreateAndQuery(subquery11, subquery12);
  
// Searching with query 1
SearchResults results1 = index.Search(query1, new SearchParameters());
  
// Constructing query 2
// Word 1 in the phrase is a pattern '?(0~2)sure' for wildcard search
WordPattern pattert21 = new WordPattern();
pattert21.AppendWildcard(0, 2);
pattert21.AppendString("sure");
SearchQuery subquery21 = SearchQuery.CreateWordPatternQuery(pattert21);
  
// Word 2 in the phrase is searched with different word forms ('equal', 'equals', 'equally', etc.)
SearchQuery subquery22 = SearchQuery.CreateWordQuery("equal");
subquery22.SearchParameters = new SearchParameters() { UseWordFormsSearch = true };
  
// Word 3 in the phrase is searched with maximum 2 differences of fuzzy search
SearchQuery subquery23 = SearchQuery.CreateWordQuery("opportunities");
subquery23.SearchParameters = new SearchParameters();
subquery23.SearchParameters.FuzzySearch.Enabled = true;
subquery23.SearchParameters.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(2);
  
// Creating phrase search query
SearchQuery query2 = SearchQuery.CreatePhraseSearchQuery(subquery21, subquery22, subquery23);
  
// Searching with query 2
SearchResults results2 = index.Search(query2, new SearchParameters());
```
