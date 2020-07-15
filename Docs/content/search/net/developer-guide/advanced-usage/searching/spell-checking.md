---
id: spell-checking
url: search/net/spell-checking
title: Spell checking
weight: 26
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
During the search, a search query can be checked for spelling errors in words. To enable spelling correction in search queries, the [Enabled](https://apireference.groupdocs.com/net/search/groupdocs.search.options/spellingcorrectoroptions/properties/enabled) property of the spelling corrector options is set to true. By default, the spelling correction is disabled.

The spelling corrector considers the following types of misprints: adding a character, deleting a character, replacing a character, and, optionally, transposing two adjacent characters.

By default, the spelling corrector dictionary contains only English words. To manage the spelling corrector dictionary, see the [Spelling corrector]({{< ref "search/net/developer-guide/advanced-usage/managing-dictionaries/spelling-corrector.md" >}}) page of the [Managing dictionaries]({{< ref "search/net/developer-guide/advanced-usage/managing-dictionaries/_index.md" >}}) section.

The [SpellingCorrectorOptions](https://apireference.groupdocs.com/net/search/groupdocs.search.options/spellingcorrectoroptions) class contains the following properties:

*   [MaxMistakeCount](https://apireference.groupdocs.com/net/search/groupdocs.search.options/spellingcorrectoroptions/properties/maxmistakecount) is the maximum number of mistakes possible in each word of a search query. The default value is 2.
*   [OnlyBestResults](https://apireference.groupdocs.com/net/search/groupdocs.search.options/spellingcorrectoroptions/properties/onlybestresults) is a value indicating whether only the best results will be returned by the spelling corrector. The default value is false.
*   [OnlyBestResultsRange](https://apireference.groupdocs.com/net/search/groupdocs.search.options/spellingcorrectoroptions/properties/onlybestresultsrange) is the maximum exceeding of the minimum number of mistakes that are found by the spelling corrector. The default value is 0.
*   [ConsiderTranspositions](https://apireference.groupdocs.com/net/search/groupdocs.search.options/spellingcorrectoroptions/properties/considertranspositions) is a value indicating whether the spelling corrector must consider transposition of two adjacent characters as a single mistake (true) or two mistakes (false). The default value is true.

The following example shows how to perform a search using the spelling correction.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";
 
// Creating an index in the specified folder
Index index = new Index(indexFolder);
 
// Indexing documents from the specified folder
index.Add(documentsFolder);
 
// Creating a search options instance
SearchOptions options = new SearchOptions();
options.SpellingCorrector.Enabled = true; // Enabling the spelling correction
options.SpellingCorrector.MaxMistakeCount = 1; // Setting the maximum number of mistakes
options.SpellingCorrector.OnlyBestResults = true; // Enabling the option for only the best results of the spelling correction
 
// Search for the word "Rleativity" containing a spelling error
// The word "Relativity" will be found that differs from the search query in two transposed letters
SearchResult result = index.Search("Rleativity", options);
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
