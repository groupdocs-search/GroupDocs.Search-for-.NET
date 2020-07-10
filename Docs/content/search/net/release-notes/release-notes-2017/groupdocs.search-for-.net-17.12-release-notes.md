---
id: groupdocs-search-for-net-17-12-release-notes
url: search/net/groupdocs-search-for-net-17-12-release-notes
title: GroupDocs.Search for .NET 17.12 Release Notes
weight: 1
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 17.12.{{< /alert >}}

## Major Features

There are 4 enhancements in this regular monthly release. The most notable are:

*   Improved representation of results of exact phrase search
*   Improved calculation of relevance of search results
*   Improved search query syntax
*   Implementation of highlighted results for exact phrase search in text

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-1294 | Improve representation of results of exact phrase search | Enhancement |
| SEARCHNET-1295 | Improve calculation of relevance of search results | Enhancement |
| SEARCHNET-1296 | Improve search query syntax | Enhancement |
| SEARCHNET-1275 | Implement highlighting of results of exact phrase search in text | Enhancement  |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Search for .NET 17.12. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Search which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Improved representation of results of exact phrase search

##### Description

This enhancement is implemented to store the results of exact phrase search in a more structured and convenient form.

##### Public API changes

Property **System.String\[\]\[\] TermSequences** has been added to **GroupDocs.Search.DocumentResultInfo** class.  
Property **System.String\[\]\[\] TermSequences** has been added to **GroupDocs.Search.DetailedResultInfo** class.

##### Usecases

This example shows how to perform the exact phrase search and get results:

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Indexing
index.AddToIndex(documentsFolder);

// Creating search parameters object
SearchParameters searchParameters = new SearchParameters();
// Enabling fuzzy search
searchParameters.FuzzySearch.Enabled = true;
// Setting maximum mistake count to 1
searchParameters.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(1);

// Searching for phrase 'cumulative distribution function' or phrase 'cumulative density function'
SearchResults searchResults = index.Search("\"cumulative distribution function\" OR \"cumulative density function\"", searchParameters);

// Displaying results
foreach (DocumentResultInfo document in searchResults)
{
    Console.WriteLine(document.FileName);
    foreach (DetailedResultInfo field in document.DetailedResults)
    {
        Console.WriteLine(field.FieldName);
        foreach (string[] phrase in field.TermSequences)
        {
            Console.Write("\t");
            foreach (string word in phrase)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();
        }
    }
}

// The results may contain the following phrases:
// cumulative distribution function
// cumulative distribution functions
// cumulative density function
// cumulative density functions
```

### Improved calculation of relevance of search results

##### Description

In this enhancement, the way of calculating the relevance of search results has been changed. Now the following formula is used to calculate the relevance of each found document:  
**R = O / T**,  
where **R** is relevance; **O** is occurrence count in the document; **T** is total word count in document.

##### Public API changes

None.

##### Usecases

This example shows how to perform search and sort results by relevance:

```csharp
 // Implementing comparer
public class Comparer : IComparer<DocumentResultInfo>
{
    public int Compare(DocumentResultInfo x, DocumentResultInfo y)
    {
        // Compare y and x in reverse order
        return y.Relevance.CompareTo(x.Relevance);
    }
}

...

string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Indexing
index.AddToIndex(documentsFolder);

// Creating search parameters object
SearchParameters searchParameters = new SearchParameters();
// Enabling fuzzy search
searchParameters.FuzzySearch.Enabled = true;
// Setting maximum mistake count to 1
searchParameters.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(1);

// Searching for term 'database'
// Using fuzzy search allows to find the plural form of the term 'databases'
SearchResults searchResults = index.Search("database", searchParameters);

// Creating and filling array for sorting
DocumentResultInfo[] array = new DocumentResultInfo[searchResults.Count];
for (int i = 0; i < array.Length; i++)
{
    array[i] = searchResults[i];
}

// Sorting results in array by relevance in descending order
Array.Sort(array, new Comparer());
```

### Implementation of highlighted results for exact phrase search in text

##### Description

In this enhancement, generating of HTML-formatted text with highlighted found terms is implemented for the results of exact phrase search.

##### Public API changes

None.

##### Usecases

This example shows how to generate text with highlighted results of exact phrase search:

```csharp
 string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Indexing documents
index.AddToIndex(documentsFolder);

// Searching for phrase 'cumulative distribution function'
SearchResults results = index.Search("\"cumulative distribution function\"");

// Generating HTML-formatted text for the first document directly to the file 'HighlightedResults.html'
index.HighlightInText("HighlightedResults.html", results[0]);
```

### Improved search query syntax

In this enhancement, the syntax of the search query language has been redesigned to make it more understandable and conventional.

#### Search operations (since v.17.12)

| Operation | Syntax | Description | Examples |
| --- | --- | --- | --- |
| Parentheses | ( *inner-query* ) | Parentheses are used to specify order of operations. | 
*   term1 I (term2 & term3) 
*   ("total expenses" | "total costs") & (82000 ~~ 83000 | 92000 ~~ 93000)

 |
| Field specifier | *field-name* : *inner-query* | Field specifier is used to specify field name. | 

*   content : term 
*   creationdate : (2010 ~~ 2013) 
*   filename : report & creationdate: 2009

 |
| Exact phrase query specifier | " *exact-phrase-query* " | Exact phrase query specifier is used to specify phrase for phrase search. | 

*   "term1 term2 term3" 
*   "computational complexity theory" 
*   "formal language" AND harrison

 |
| And operation | *left-query* & *right-query*   
*left-query* AND *right-query* | And operation is used to find documents which contain both left query and right query. | 

*   term1 & term2 
*   term1 AND term2 
*   computational & complexity

 |
| Or operation | *left-query* | *right-query*   
*left-query* || *right-query*   
*left-query* OR *right-query* | Or operation is used to find documents which contain left query, or right query, or both. | 

*   term1 | term2 
*   term1 || term2 
*   term1 OR term2
*   "cumulative distribution function" OR "cumulative density function"

 |
| Not operation | ! *inner-query*   
NOT *inner-query* | Not operation is used to find all documents which do not contain inner query. | 

*   ! term 
*   NOT term 
*   author : (Cardano AND NOT Gerolamo)

 |
| Macro name specifier | @*macro-name* | Macro name specifier is used to specify name of macro within search query that will be replaces with the body of the macro before parsing the query. | 

*   @query\_macro 
*   @macro1 & @macro2

 |
| Regular expression specifier | ^*regular-expression* | Regular expression specifier is used to specify query that is regular expression. | 

*   ^^\[0-9\]{1,5}$

 |
| Numeric range specifier | *start-number* ~~ *end-number* | Numeric range specifier is used to specify range for numeric range search. | 

*   13 ~~ 42 
*   10000000000 ~~ 100000000000

 |
| Date range specifier | daterange( *start-date* ~~ *end-date *) | Date range specifier is used to specify range for date range search. | 

*   daterange(09.28.2017~~11.11.2017)

 |

#### Search flow (since v.17.12)

| Operation | Search flow |
| --- | --- |
| Simple term search (case insensitive) | Keyboard layout correction   
Spelling correction   
Homophone search   
Synonym search   
Fuzzy search   
Retrieving results |
| Simple term search (case sensitive) | Retrieving results |
| Date range search | Retrieving results |
| Numeric range search | Retrieving results |
| Exact phrase search | Retrieving results for each term of the phrase   
Joining sets of results |
| Regex search | Regex search   
Fuzzy search   
Retrieving results |
| And, Or | Retrieving results for each operand  
Combining sets of results |
| Not | Retrieving results for operand  
Inverting set of results |

#### Query language specification (since v.17.12)

*query*:

*   *regex-query*
*   *non-regex-query*

*regex-query*:

*   ^*pattern*

*non-regex-query*:

*   *unary-query*
*   *binary-query*

*unary-query*:

*   *word*
*   *exact-query*
*   *field-name-query*
*   *numeric-range-query*
*   *date-range-query*
*   *parenthesized-query*
*   *not-query*

*exact-query*:

*   " *word-list* "

*word-list*:

*   *word word*
*   *word-list word*

*field-name-query*:

*   *field-name*: *unary-query*

*numeric-range-query*:

*   *number* ~~ *number*

*date-range-query*:

*   daterange( *date* ~~ *date* )

*parenthesized-query*:

*   ( *non-regex-query* )

*not-query*:

*   ! *unary-query*
*   NOT *unary-query*

*binary-query*:

*   *and-query*
*   *or-query*

*and-query*:

*   *non-regex-query* & *unary-query*
*   *non-regex-query* AND *unary-query*

*or-query*:

*   *non-regex-query* | *unary-query*
*   *non-regex-query* || *unary-query*
*   *non-regex-query* OR *unary-query*
