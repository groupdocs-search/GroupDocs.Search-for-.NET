---
id: fuzzy-search
url: search/net/fuzzy-search
title: Fuzzy search
weight: 6
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
This page provides a fuzzy search definition, a description of its capabilities in GroupDocs.Search, and fuzzy search C# examples with use of GroupDocs.Search.

## Fuzzy search definition

Fuzzy search is a text search technique based on fuzzy logic that matches even where search queries or the text of documents to search for are written with errors.

## Fuzzy search features

Fuzzy search allows you to search for words that do not exactly match the search query. This type of search can be used, for example, to search for words containing spelling errors in documents. During fuzzy search, the number of possible differences with the search word is determined by the fuzzy search algorithm used. Differences or errors mean insertions, deletions, substitutions and, optionally, transpositions of adjacent characters.

GroupDocs.Search does not use special fuzzy queries. Instead, you can enable fuzzy search in search options for any search query, whether it is a single word, phrase or logical search query. And it becomes a fuzzy query.

The fuzzy search algorithm used is defined in the [SearchOptions](https://apireference.groupdocs.com/net/search/groupdocs.search.options/searchoptions) class. By default, the algorithm provided by the [SimilarityLevel](https://apireference.groupdocs.com/net/search/groupdocs.search.options/similaritylevel) class is used with the similarity level value of 0.5. This algorithm uses a linear dependence of the number of possible differences from the search word. To calculate the maximum number of possible differences, the following expression is used:

int maxMistakeCount = (int)((1 - similarityLevel) \* termLength);

where similarityLevel is a parameter of the fuzzy search algorithm; termLength is the length of the searched word.

An example of setting a fuzzy search algorithm of this type is presented below.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";
string query = "Einstein";
 
// Creating an index in the specified folder
Index index = new Index(indexFolder);
 
// Indexing documents from the specified folder
index.Add(documentsFolder);
 
SearchOptions options = new SearchOptions();
options.FuzzySearch.Enabled = true; // Enabling the fuzzy search
options.FuzzySearch.FuzzyAlgorithm = new SimilarityLevel(0.8); // Creating the fuzzy search algorithm
// This function specifies 0 as the maximum number of mistakes for words from 1 to 4 characters.
// It specifies 1 as the maximum number of mistakes for words from 5 to 9 characters.
// It specifies 2 as the maximum number of mistakes for words from 10 to 14 characters. And so on.
 
// Search in index
SearchResult result = index.Search(query, options);
```

The fuzzy search algorithm can also be specified by a table of correspondences between the length of the searched word and the maximum number of possible differences. For this, the algorithm presented by the **[TableDiscreteFunction](https://apireference.groupdocs.com/net/search/groupdocs.search.options/tablediscretefunction)** class is used. In this case, the correspondence table can be calculated based on the parameters of a step function. An example of setting a fuzzy search algorithm in the form of a step function is presented below.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";
string query = "Einstein";
 
// Creating an index in the specified folder
Index index = new Index(indexFolder);
 
// Indexing documents from the specified folder
index.Add(documentsFolder);
 
SearchOptions options = new SearchOptions();
options.FuzzySearch.Enabled = true; // Enabling the fuzzy search
options.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(1, new Step(5, 2), new Step(8, 3)); // Creating the fuzzy search algorithm
// This function specifies 1 as the maximum number of mistakes for words from 1 to 4 characters.
// It specifies 2 as the maximum number of mistakes for words from 5 to 7 characters.
// It specifies 3 as the maximum number of mistakes for words from 8 and more characters.
 
// Search in index
SearchResult result = index.Search(query, options);
```

The fuzzy search options object allows you to specify the following options:

*   The [FuzzyAlgorithm](https://apireference.groupdocs.com/net/search/groupdocs.search.options/fuzzysearchoptions/properties/fuzzyalgorithm) property defines the fuzzy search algorithm. The currently available fuzzy search algorithms are [SimilarityLevel](https://apireference.groupdocs.com/net/search/groupdocs.search.options/similaritylevel) and [TableDiscreteFunction](https://apireference.groupdocs.com/net/search/groupdocs.search.options/tablediscretefunction). The default value is an instance of [SimilarityLevel](https://apireference.groupdocs.com/net/search/groupdocs.search.options/similaritylevel) class with a similarity level value of 0.5.
*   The [OnlyBestResults](https://apireference.groupdocs.com/net/search/groupdocs.search.options/fuzzysearchoptions/properties/onlybestresults) property determines whether to return only the best results. The default value is false, which means that all results will be returned.
*   The [OnlyBestResultsRange](https://apireference.groupdocs.com/net/search/groupdocs.search.options/fuzzysearchoptions/properties/onlybestresultsrange) property determines a value of exceeding the number of differences from the best result. The default value is 0.
*   The [ConsiderTranspositions](https://apireference.groupdocs.com/net/search/groupdocs.search.options/fuzzysearchoptions/properties/considertranspositions) property determines whether to consider the transposition of adjacent characters as one mistake. The default value is true.
*   The [Enabled](https://apireference.groupdocs.com/net/search/groupdocs.search.options/fuzzysearchoptions/properties/enabled) property enables or disables the fuzzy search. The default value is false.

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
