---
id: work-with-search-results
url: search/net/work-with-search-results
title: Work with search results
weight: 3
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
Working with search results consists in obtaining information from objects of search results and highlighting occurrences in the text of documents.

## Obtain search result information

When a search is complete, the [Search](https://apireference.groupdocs.com/net/search/groupdocs.search/index/methods/search/index) method returns an object of type [SearchResult](https://apireference.groupdocs.com/net/search/groupdocs.search.results/searchresult). This page describes the information available in an object of type [SearchResult](https://apireference.groupdocs.com/net/search/groupdocs.search.results/searchresult).

From the root object of the search result, information is available on the number of documents found, the number of occurrences of the words and phrases found, as well as detailed information on each individual document. Information about an individual document found is represented by an object of the class [FoundDocument](https://apireference.groupdocs.com/net/search/groupdocs.search.results/founddocument).

From the object of the class [FoundDocument](https://apireference.groupdocs.com/net/search/groupdocs.search.results/founddocument), information is available on the full path to the document, the number of occurrences, the words and phrases found, as well as detailed information on each field of the document. Information about the document field is represented by an object of the class [FoundDocumentField](https://apireference.groupdocs.com/net/search/groupdocs.search.results/founddocumentfield).

From the object of the class [FoundDocumentField](https://apireference.groupdocs.com/net/search/groupdocs.search.results/founddocumentfield), information is available on the name of the document field, the number of occurrences, the words and phrases found, and the number of occurrences of each word and phrase.

Below is a code example that writes to the console the detailed information contained in an object of the class [SearchResult](https://apireference.groupdocs.com/net/search/groupdocs.search.results/searchresult) about each document, document field, word, phrase and the number of their occurrences in the document fields.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentFolder = @"c:\MyDocuments\";
 
// Creating an index
Index index = new Index(indexFolder);
 
// Indexing documents from the specified folder
index.Add(documentFolder);
 
// Creating search options
SearchOptions options = new SearchOptions();
options.FuzzySearch.Enabled = true; // Enabling the fuzzy search
options.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(3); // Setting the maximum number of differences to 3
 
// Search for documents containing the word 'Einstein' or the phrase 'Theory of Relativity'
SearchResult result = index.Search("Einstein OR \"Theory of Relativity\"", options);
 
// Printing the result
Console.WriteLine("Documents: " + result.DocumentCount);
Console.WriteLine("Total occurrences: " + result.OccurrenceCount);
for (int i = 0; i < result.DocumentCount; i++)
{
    FoundDocument document = result.GetFoundDocument(i);
    Console.WriteLine("\tDocument: " + document.DocumentInfo.FilePath);
    Console.WriteLine("\tOccurrences: " + document.OccurrenceCount);
    for (int j = 0; j < document.FoundFields.Length; j++)
    {
        FoundDocumentField field = document.FoundFields[j];
        Console.WriteLine("\t\tField: " + field.FieldName);
        Console.WriteLine("\t\tOccurrences: " + document.OccurrenceCount);
        // Printing found terms
        if (field.Terms != null)
        {
            for (int k = 0; k < field.Terms.Length; k++)
            {
                Console.WriteLine("\t\t\t" + field.Terms[k].PadRight(20) + field.TermsOccurrences[k]);
            }
        }
        // Printing found phrases
        if (field.TermSequences != null)
        {
            for (int k = 0; k < field.TermSequences.Length; k++)
            {
                string sequence = string.Join(" ", field.TermSequences[k]);
                Console.WriteLine("\t\t\t" + sequence.PadRight(30) + field.TermSequencesOccurrences[k]);
            }
        }
    }
}
```

## Highlight search results

At the end of a search, it is usually necessary to visualize the results by highlighting the words found in the text. You can highlight search results either in the text of an entire document, or in separate segments. Detailed information about highlighting search results can be found on the page [Highlighting search results]({{< ref "search/net/developer-guide/advanced-usage/searching/highlighting-search-results.md" >}}). Below is an example of highlighting search results in the text of an entire document.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentFolder = @"c:\MyDocuments\";
 
// Creating an index
Index index = new Index(indexFolder);
 
// Indexing documents from the specified folder
index.Add(documentFolder);
 
// Search for the word 'eternity'
SearchResult result = index.Search("eternity");
 
// Highlighting occurrences in text
if (result.DocumentCount > 0)
{
    FoundDocument document = result.GetFoundDocument(0); // Getting the first found document
    OutputAdapter outputAdapter = new FileOutputAdapter(@"c:\Highlighted.html"); // Creating an output adapter to the file
    Highlighter highlighter = new HtmlHighlighter(outputAdapter); // Creating the highlighter object
    index.Highlight(document, highlighter); // Generating HTML formatted text with highlighted occurrences
}
```

## More resources

### Advanced usage topics

To learn more about search features and get familiar how to enhance your search solution, please refer to the [advanced usage section]({{< ref "search/net/developer-guide/advanced-usage/_index.md" >}}).

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
