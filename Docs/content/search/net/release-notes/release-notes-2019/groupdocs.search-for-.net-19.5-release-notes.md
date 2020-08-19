---
id: groupdocs-search-for-net-19-5-release-notes
url: search/net/groupdocs-search-for-net-19-5-release-notes
title: GroupDocs.Search for .NET 19.5 Release Notes
weight: 4
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 19.5{{< /alert >}}

## Major Features

There are the following improvements and new features in this release:

*   Implement document filtering in search results
*   Implement settings for logging functionality
*   Add English synonyms to default synonym dictionary
*   Implement providing number of hits for each found word separately
*   Implement optimization of index storage format
*   Add support for new file formats
*   Implement method to retrieve credit consumption info
*   Implement ability to attach to a document arbitrary additional fields

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-371 | Implement document filtering in search results | Improvement |
| SEARCHNET-1883 | Implement settings for logging functionality | Improvement |
| SEARCHNET-1896 | Add English synonyms to default synonym dictionary | Improvement |
| SEARCHNET-1945 | Implement providing number of hits for each found word separately | Improvement |
| SEARCHNET-1951 | Implement optimization of index storage format | Improvement |
| SEARCHNET-1966 | Add support for new file formats | Improvement |
| SEARCHNET-1980 | Implement method to retrieve credit consumption info | Improvement |
| SEARCHNET-1941 | Implement ability to attach to a document arbitrary additional fields | New Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Search for .NET 19.5. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Search which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

###  Implement document filtering in search results

This improvement allows to filter found documents.

##### Public API changes

Inverface **ISearchDocumentFilter** has been added to **GroupDocs.Search** namespace.

Static class **SearchDocumentFilter** has been added to **GroupDocs.Search** namespace.  
Static method **ISearchDocumentFilter CreateFileNameRegularExpression(string)** has been added to **GroupDocs.Search.SearchDocumentFilter** class.  
Static method **ISearchDocumentFilter CreateFileNameRegularExpression(string, RegexOptions)** has been added to **GroupDocs.Search.SearchDocumentFilter** class.  
Static method **ISearchDocumentFilter CreateFileExtension(string\[\])** has been added to **GroupDocs.Search.SearchDocumentFilter** class.  
Static method **ISearchDocumentFilter CreateInverted(ISearchDocumentFilter)** has been added to **GroupDocs.Search.SearchDocumentFilter** class.  
Static method **ISearchDocumentFilter CreateConjunction(ISearchDocumentFilter\[\])** has been added to **GroupDocs.Search.SearchDocumentFilter** class.  
Static method **ISearchDocumentFilter CreateDisjunction(ISearchDocumentFilter\[\])** has been added to **GroupDocs.Search.SearchDocumentFilter** class.

Property **ISearchDocumentFilter SearchDocumentFilter** has been added to **GroupDocs.Search.SearchParameters** class.

##### Usecases

This example shows how to set up document filtering for searching:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Adding documents to index
index.AddToIndex(documentFolder);

// Configuring document filter
// Filter filter3 will only accept TXT and DOC documents with text 'Tolkien' in file names
SearchParameters parameters = new SearchParameters();
ISearchDocumentFilter filter1 = SearchDocumentFilter.CreateFileExtension(".txt", ".doc");
ISearchDocumentFilter filter2 = SearchDocumentFilter.CreateFileNameRegularExpression("Tolkien");
ISearchDocumentFilter filter3 = SearchDocumentFilter.CreateConjunction(filter1, filter2);
parameters.SearchDocumentFilter = filter3;

// Searching
SearchResults results = index.Search("hobbit", parameters);
```

### Implement settings for logging functionality

This improvement allows to set up log file name and maximum log file size.

##### Public API changes

Class **LogSettings** has been added to **GroupDocs.Search** namespace.  
Property **string FileName** has been added to **GroupDocs.Search.LogSettings** class.  
Property **double MaxSize** has been added to **GroupDocs.Search.LogSettings** class.

Property **LogSettings LogSettings** has been added to **GroupDocs.Search.Index** class.

##### Usecases

This example shows how to configure logging settings:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Setting the log file name. The log file name can be relative or absolute.
index.LogSettings.FileName = @"Log\Log.txt";

// Setting the maximum size of the log file in megabytes. This value must be in the range from 0.1 to 1000.
index.LogSettings.MaxSize = 2.0;

// Adding documents to index
index.AddToIndex(documentFolder);

// Searching
SearchResults results = index.Search("big");
```

### Add English synonyms to default synonym dictionary

This improvement adds English synonyms to default synonym dictionary.

##### Public API changes

None.

##### Usecases

This example shows how to perform synonym search:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";

// Creating index
// Default synonyms will be added automatically to the index
Index index = new Index(indexFolder);

// Adding documents to index
index.AddToIndex(documentFolder);

// Enabling synonym search in search parameters
SearchParameters parameters = new SearchParameters();
parameters.UseSynonymSearch = true;

// Searching for word 'big'
// The word 'large' will also be found
SearchResults results = index.Search("big", parameters);
```

### Implement providing number of hits for each found word separately

This improvement adds exact number of occurrences for each found word. This can be used to implement 'Did you mean' feature.

##### Public API changes

Property **int\[\] TermsOccurrences** has been added to **GroupDocs.Search.DetailedResultInfo** class.  
Property **int\[\] TermSequencesOccurrences** has been added to **GroupDocs.Search.DetailedResultInfo** class.

##### Usecases

This example shows how to get number of occurrences for each found word:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Adding documents to index
index.AddToIndex(documentFolder);

// Configuring search parameters
SearchParameters parameters = new SearchParameters();

// Enabling maximum 2 misprints per word
parameters.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(2);
parameters.FuzzySearch.Enabled = true;

// Searching
SearchResults results = index.Search("hobbot", parameters);

// Getting number of occurrences for each found word
foreach (DocumentResultInfo doc in results)
{
    foreach (DetailedResultInfo field in doc.DetailedResults)
    {
        for (int i = 0; i < field.Terms.Length; i++)
        {
            string word = field.Terms[i];
            int hits = field.TermsOccurrences[i];
            Console.WriteLine(word + " - " + hits);
        }
    }
}
```

### Implement optimization of index storage format

This improvement reduces index storage size more than by 30%.

##### Public API changes

Enum **VersionUpdateResult** has been added to **GroupDocs.Search** namespace.  
Value **Updated** has been added to **GroupDocs.Search.VersionUpdateResult** enum.  
Value **AlreadyUpToDate** has been added to **GroupDocs.Search.VersionUpdateResult** enum.  
Value **Unsupported** has been added to **GroupDocs.Search.VersionUpdateResult** enum.

Class **IndexVersionUpdater** has been added to **GroupDocs.Search** namespace.  
Constructor **IndexVersionUpdater()** has been added to **GroupDocs.Search.IndexVersionUpdater** class.  
Method **bool IsLatestVersion(string)** has been added to **GroupDocs.Search.IndexVersionUpdater** class.  
Method **bool CanUpdate(string)** has been added to **GroupDocs.Search.IndexVersionUpdater** class.  
Method **VersionUpdateResult Update(string, string)** has been added to **GroupDocs.Search.IndexVersionUpdater** class.

##### Usecases

This example shows how to update index of previous version:

**C#**

```csharp
string oldIndexFolder = @"c:\MyIndex";
string newIndexFolder = @"c:\MyIndexUpdated";

// Creating updater instance
IndexVersionUpdater updater = new IndexVersionUpdater();

// Updating index version
if (updater.CanUpdate(oldIndexFolder))
{
    VersionUpdateResult updateResult = updater.Update(oldIndexFolder, newIndexFolder);
    Console.WriteLine(updateResult);
}

// Loading updated index
Index index = new Index(newIndexFolder);

// Searching
SearchResults results = index.Search("hobbit");
```

### Add support for new file formats

This improvement adds support for new file formats: MD, POTM, CSV, TSV, XML, HTM, HTML, XHTML, MHT, MHTML.

##### Public API changes

Value **Xml** has been added to **GroupDocs.Search.DocumentType** enum.

Constant **string Xml** has been added to **GroupDocs.Search.DocumentTypes** class.

##### Usecases

This example shows how to add documents to an index:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Adding documents to index
index.AddToIndex(documentFolder);

// Searching
SearchResults results = index.Search("hobbit");
```

### Implement method to retrieve credit consumption info

This improvement implements method to retrieve credit consumption info.

##### Public API changes

Method **decimal GetConsumptionCredit()** has been added to **GroupDocs.Search.Metered** class.

##### Usecases

This example shows how to check how many credits are spent:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";

// Set Metered keys
new Metered().SetMeteredKey(publicKey, privateKey);

// Creating index
Index index = new Index(indexFolder);

// Adding documents to index
index.AddToIndex(documentFolder);

// Searching
SearchResults results = index.Search("arbitrary");

// Getting consumption credit
decimal used = Metered.GetConsumptionCredit();
```

### Implement ability to attach to a document arbitrary additional fields

This feature allows adding arbitrary additional fields to each document during indexing. Field names can be non-unique.

##### Public API changes

Property **FieldInfo\[\] AdditionalFields** has been added to **GroupDocs.Search.Events.FileIndexingEventArgs** class.  
Method **string HighlightInText(DocumentResultInfo, IFieldExtractor, FieldInfo\[\])** has been added to **GroupDocs.Search.Index** class.  
Method **void HighlightInText(string, DocumentResultInfo, IFieldExtractor, FieldInfo\[\])** has been added to **GroupDocs.Search.Index** class.  
Method **string ExtractDocumentText(DocumentInfo, IFieldExtractor, FieldInfo\[\])** has been added to **GroupDocs.Search.Index** class.  
Method **void ExtractDocumentText(string, DocumentInfo, IFieldExtractor, FieldInfo\[\])** has been added to **GroupDocs.Search.Index** class.  

##### Usecases

This example shows how to add additional fields to a document during indexing:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Subscribing to event
index.FileIndexing += (sender, args) =>
{
    FieldInfo[] additionalFields = new FieldInfo[]
    {
        new FieldInfo("Tags", "arbitrary additional fields"),
    };
    args.AdditionalFields = additionalFields;
};

// Adding documents to index
index.AddToIndex(documentFolder);

// Searching
SearchResults results = index.Search("arbitrary");
```
