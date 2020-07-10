---
id: migration-notes
url: search/net/migration-notes
title: Migration Notes
weight: 3
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
### Why To Migrate?

Here are the main reasons for using the new updated API provided by GroupDocs.Search for .NET from version 19.9:

*   Unified work with some similar entities to increase the intuitiveness of using API.
*   The architecture of the product has been revised and optimized, so that some functions will work faster.
*   Some entities have been renamed to improve code readability.
*   The changes made to the API are not too significant, so the migration will not be too difficult.
*   New functionality will not be added to the old API version, only to the new version.

### How To Migrate?

The following code examples demonstrate changes in the use of the API.

Old coding style:

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";
 
// Creating an index in the specified folder
Index index = new Index(indexFolder);
 
// Indexing documents from the specified folder
index.AddToIndex(documentsFolder);
 
// Creating a search parameters object
SearchParameters parameters = new SearchParameters();
parameters.FuzzySearch.Enabled = true; // Enabling the fuzzy search
parameters.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(2); // Setting the number of possible differences for each word
 
// Searching in the index
SearchResults results = index.Search("Happiness", parameters);
 
if (results.Count > 0)
{
    // Generating HTML-formatted text of a document with highlighted search results
    index.HighlightInText(@"c:\Highlighted.html", results[0]);
}
```

New coding style:

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";
 
// Creating an index in the specified folder
Index index = new Index(indexFolder);
 
// Indexing documents from the specified folder
index.Add(documentsFolder);
 
// Creating a search options object
SearchOptions options = new SearchOptions();
options.FuzzySearch.Enabled = true; // Enabling the fuzzy search
options.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(2); // Setting the number of possible differences for each word
 
// Searching in the index
SearchResult result = index.Search("Happiness", options);
 
if (result.DocumentCount > 0)
{
    // Generating HTML-formatted text of a document with highlighted search results
    index.Highlight(result.GetFoundDocument(0), new HtmlHighlighter(new FileOutputAdapter(@"c:\Highlighted.html")));
}
```
