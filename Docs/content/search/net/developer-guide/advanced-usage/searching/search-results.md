---
id: search-results
url: search/net/search-results
title: Search results
weight: 24
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
Search results are represented by the [SearchResult](https://apireference.groupdocs.com/net/search/groupdocs.search.results/searchresult) class, an instance of which is returned by the [Search](https://apireference.groupdocs.com/net/search/groupdocs.search/index/methods/search/index) method of the [Index](https://apireference.groupdocs.com/net/search/groupdocs.search/index) class. The [Search](https://apireference.groupdocs.com/net/search/groupdocs.search/indexrepository/methods/search/index) method of the [IndexRepository](https://apireference.groupdocs.com/net/search/groupdocs.search/indexrepository) class also returns an instance of the [SearchResult](https://apireference.groupdocs.com/net/search/groupdocs.search.results/searchresult) class.

The [SearchResult](https://apireference.groupdocs.com/net/search/groupdocs.search.results/searchresult) class contains the following members:

*   The [DocumentCount](https://apireference.groupdocs.com/net/search/groupdocs.search.results/searchresult/properties/documentcount) property returns the number of documents found.
*   The [OccurrenceCount](https://apireference.groupdocs.com/net/search/groupdocs.search.results/searchresult/properties/occurrencecount) property returns the total number of occurrences found.
*   The [Truncated](https://apireference.groupdocs.com/net/search/groupdocs.search.results/searchresult/properties/truncated) property returns a value indicating that the result is truncated due to limits specified in the search options.
*   The [Warnings](https://apireference.groupdocs.com/net/search/groupdocs.search.results/searchresult/properties/warnings) property returns a warnings describing the result, for example, a warning about the presence of stop word in a search query.
*   The [NextChunkSearchToken](https://apireference.groupdocs.com/net/search/groupdocs.search.results/searchresult/properties/nextchunksearchtoken) property returns a chunk search token to search for the next chunk. For details on search by chunks, see the [Search by chunks]({{< ref "search/net/developer-guide/advanced-usage/searching/search-by-chunks.md" >}}) page.
*   The [StartTime](https://apireference.groupdocs.com/net/search/groupdocs.search.results/searchresult/properties/starttime) property returns the start time of the search.
*   The [EndTime](https://apireference.groupdocs.com/net/search/groupdocs.search.results/searchresult/properties/endtime) property returns the end time of the search.
*   The [SearchDuration](https://apireference.groupdocs.com/net/search/groupdocs.search.results/searchresult/properties/searchduration) property returns the search duration.
*   The [GetFoundDocument](https://apireference.groupdocs.com/net/search/groupdocs.search.results/searchresult/methods/getfounddocument) method returns the found document by index.
*   The [GetEnumerator](https://apireference.groupdocs.com/net/search/groupdocs.search.results/searchresult/methods/getenumerator) method returns an enumerator that iterates through the collection of the documents found.

The found document is represented by an instance of a [FoundDocument](https://apireference.groupdocs.com/net/search/groupdocs.search.results/founddocument) class. The [FoundDocument](https://apireference.groupdocs.com/net/search/groupdocs.search.results/founddocument) class contains the following members:

*   The [DocumentInfo](https://apireference.groupdocs.com/net/search/groupdocs.search.results/founddocument/properties/documentinfo) property returns the document info object containing the file path, the file type, the format family, and the inner document path for items of container documents.
*   The [Relevance](https://apireference.groupdocs.com/net/search/groupdocs.search.results/founddocument/properties/relevance) property returns the relevance of the document in the search result.
*   The [OccurrenceCount](https://apireference.groupdocs.com/net/search/groupdocs.search.results/founddocument/properties/occurrencecount) property returns the number of occurrences found in the document.
*   The [FoundFields](https://apireference.groupdocs.com/net/search/groupdocs.search.results/founddocument/properties/foundfields) property returns the found document fields.
*   The [Terms](https://apireference.groupdocs.com/net/search/groupdocs.search.results/founddocument/properties/terms) property returns the found terms. The value is evaluated each time the property is accessed based on the data for each document field found.
*   The [TermSequences](https://apireference.groupdocs.com/net/search/groupdocs.search.results/founddocument/properties/termsequences) property returns the found term sequences.
*   The [Serialize](https://apireference.groupdocs.com/search/net/groupdocs.search.results/founddocument/methods/serialize) method serializes the current found document instance to a byte array.
*   The [Deserialize](https://apireference.groupdocs.com/search/net/groupdocs.search.results/founddocument/methods/deserialize) method deserializes an instance of found document from a byte array.

The found document field is represented by an instance of a [FoundDocumentField](https://apireference.groupdocs.com/net/search/groupdocs.search.results/founddocumentfield) class. The [FoundDocumentField](https://apireference.groupdocs.com/net/search/groupdocs.search.results/founddocumentfield) class contains the following members:

*   The [FieldName](https://apireference.groupdocs.com/net/search/groupdocs.search.results/founddocumentfield/properties/fieldname) property returns the field name.
*   The [OccurrenceCount](https://apireference.groupdocs.com/net/search/groupdocs.search.results/founddocumentfield/properties/occurrencecount) property returns the number of occurrences found.
*   The [Terms](https://apireference.groupdocs.com/net/search/groupdocs.search.results/founddocumentfield/properties/terms) property returns the terms found.
*   The [TermsOccurrences](https://apireference.groupdocs.com/net/search/groupdocs.search.results/founddocumentfield/properties/termsoccurrences) property returns the occurrences of the found terms.
*   The [TermSequences](https://apireference.groupdocs.com/net/search/groupdocs.search.results/founddocumentfield/properties/termsequences) property returns the term sequences found.
*   The [TermSequencesOccurrences](https://apireference.groupdocs.com/net/search/groupdocs.search.results/founddocumentfield/properties/termsequencesoccurrences) property returns the occurrences of the found term sequences.
*   The [Serialize](https://apireference.groupdocs.com/search/net/groupdocs.search.results/founddocumentfield/methods/serialize) method serializes the current found document field instance to a byte array.
*   The [Deserialize](https://apireference.groupdocs.com/search/net/groupdocs.search.results/founddocumentfield/methods/deserialize) method deserializes an instance of found document field from a byte array.

The following example shows how to print information on the documents found in the console.

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

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
