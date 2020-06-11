---
id: groupdocs-search-for-net-17-09-release-notes
url: search/net/groupdocs-search-for-net-17-09-release-notes
title: GroupDocs.Search for .NET 17.09 Release Notes
weight: 4
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 17.9{{< /alert >}}

## Major Features

There are 10 features and enhancements in this regular monthly release. The most notable are:

SEARCHNET-1087 Add public constants with field names  
SEARCHNET-1191 Remove obsolete properties from IndexingSettings  
SEARCHNET-563 Implement functionality for storing document text in index  
SEARCHNET-575 Add DocumentFilter property to IndexingSetting for filtering files  
SEARCHNET-1150 Implement automatic encoding detection for text documents  
SEARCHNET-1159 Implement support of CHM files  
SEARCHNET-1161 Implement feature 'Only best results range' for fuzzy search  
SEARCHNET-1162 Implement feature 'Only best results range' for spelling corrector  
SEARCHNET-1196 Implement option for fuzzy search to consider transposition as a single mistake or not  
SEARCHNET-1197 Implement option for spelling corrector to consider transposition as a single mistake or not

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-1087 | Add public constants with field names | Enhancement |
| SEARCHNET-1191 | Remove obsolete properties from IndexingSettings | Enhancement |
| SEARCHNET-563 | Implement functionality for storing document text in index | New Feature |
| SEARCHNET-575 | Add DocumentFilter property to IndexingSetting for filtering files | New Feature |
| SEARCHNET-1150 | Implement automatic encoding detection for text documents | New Feature |
| SEARCHNET-1159 | Implement support of CHM files | New Feature |
| SEARCHNET-1161 | Implement feature 'Only best results range' for fuzzy search | New Feature |
| SEARCHNET-1162 | Implement feature 'Only best results range' for spelling corrector | New Feature |
| SEARCHNET-1196 | Implement option for fuzzy search to consider transposition as a single mistake or not | New Feature |
| SEARCHNET-1197 | Implement option for spelling corrector to consider transposition as a single mistake or not | New Feature |

##   
Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Search for .NET 17.9.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Search which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Add public constants to field names

In this enhancement, field names have been added to public constants.

**Public API Changes**  
Class **DocumentTypes** has been added to **GroupDocs.Search** namespace.  
Class **EpubFieldNames** has been added to **GroupDocs.Search** namespace.  
Class **ExcelFieldNames** has been added to **GroupDocs.Search** namespace.  
Class **FieldNames** has been added to **GroupDocs.Search** namespace.  
Class **PresentationFieldNames** has been added to **GroupDocs.Search** namespace.  
Class **WordFieldNames** has been added to **GroupDocs.Search** namespace.

##### List of fields added to classes

Field **Excel** has been added to **GroupDocs.Search.DocumentTypes** class.  
Field **Pdf** has been added to **GroupDocs.Search.DocumentTypes** class.  
Field **Presentation** has been added to **GroupDocs.Search.DocumentTypes** class.  
Field **Word** has been added to **GroupDocs.Search.DocumentTypes** class.  
Field **Txt** has been added to **GroupDocs.Search.DocumentTypes** class.  
Field **OutlookStorage** has been added to **GroupDocs.Search.DocumentTypes** class.  
Field **EmailMessage** has been added to **GroupDocs.Search.DocumentTypes** class.  
Field **OneNote** has been added to **GroupDocs.Search.DocumentTypes** class.  
Field **Epub** has been added to **GroupDocs.Search.DocumentTypes** class.  
Field **FictionBook** has been added to **GroupDocs.Search.DocumentTypes** class.  
Field **Zip** has been added to **GroupDocs.Search.DocumentTypes** class.  
Field **Chm** has been added to **GroupDocs.Search.DocumentTypes** class.

Field **Title** has been added to **GroupDocs.Search.EpubFieldNames** class.  
Field **Subject** has been added to **GroupDocs.Search.EpubFieldNames** class.  
Field **Author** has been added to **GroupDocs.Search.EpubFieldNames** class.  
Field **Description** has been added to **GroupDocs.Search.EpubFieldNames** class.  
Field **Language** has been added to **GroupDocs.Search.EpubFieldNames** class.  
Field **Copyrights** has been added to **GroupDocs.Search.EpubFieldNames** class.  
Field **Publisher** has been added to **GroupDocs.Search.EpubFieldNames** class.  
Field **PublishedDate** has been added to **GroupDocs.Search.EpubFieldNames** class.

Field **Application** has been added to **GroupDocs.Search.ExcelFieldNames** class.  
Field **ApplicationVersion** has been added to **GroupDocs.Search.ExcelFieldNames** class.  
Field **Title** has been added to **GroupDocs.Search.ExcelFieldNames** class.  
Field **Subject** has been added to **GroupDocs.Search.ExcelFieldNames** class.  
Field **Comments** has been added to **GroupDocs.Search.ExcelFieldNames** class.  
Field **Keywords** has been added to **GroupDocs.Search.ExcelFieldNames** class.  
Field **ContentStatus** has been added to **GroupDocs.Search.ExcelFieldNames** class.  
Field **Category** has been added to **GroupDocs.Search.ExcelFieldNames** class.  
Field **Manager** has been added to **GroupDocs.Search.ExcelFieldNames** class.  
Field **Author** has been added to **GroupDocs.Search.ExcelFieldNames** class.  
Field **LastAuthor** has been added to **GroupDocs.Search.ExcelFieldNames** class.  
Field **Company** has been added to **GroupDocs.Search.ExcelFieldNames** class.  
Field **HyperlinkBase** has been added to **GroupDocs.Search.ExcelFieldNames** class.  
Field **CreatedTime** has been added to **GroupDocs.Search.ExcelFieldNames** class.  
Field **LastSavedTime** has been added to **GroupDocs.Search.ExcelFieldNames** class.  
Field **LastPrintedTime** has been added to **GroupDocs.Search.ExcelFieldNames** class.

Field **Title** has been added to **GroupDocs.Search.FictionBookFieldNames** class.  
Field **Subject** has been added to **GroupDocs.Search.FictionBookFieldNames** class.  
Field **Keywords** has been added to **GroupDocs.Search.FictionBookFieldNames** class.  
Field **Author** has been added to **GroupDocs.Search.FictionBookFieldNames** class.  
Field **Description** has been added to **GroupDocs.Search.FictionBookFieldNames** class.  
Field **Language** has been added to **GroupDocs.Search.FictionBookFieldNames** class.  
Field **Publisher** has been added to **GroupDocs.Search.FictionBookFieldNames** class.  
Field **PublishedDate** has been added to **GroupDocs.Search.FictionBookFieldNames** class.

Field **Content** has been added to **GroupDocs.Search.FieldNames** class.  
Field **FileName** has been added to **GroupDocs.Search.FieldNames** class.  
Field **DocumentType** has been added to **GroupDocs.Search.FieldNames** class.  
Field **CreationDate** has been added to **GroupDocs.Search.FieldNames** class.  
Field **ModificationDate** has been added to **GroupDocs.Search.FieldNames** class.

Field **Application** has been added to **GroupDocs.Search.PresentationFieldNames** class.  
Field **ApplicationVersion** has been added to **GroupDocs.Search.PresentationFieldNames** class.  
Field **Title** has been added to **GroupDocs.Search.PresentationFieldNames** class.  
Field **Subject** has been added to **GroupDocs.Search.PresentationFieldNames** class.  
Field **Comments** has been added to **GroupDocs.Search.PresentationFieldNames** class.  
Field **Keywords** has been added to **GroupDocs.Search.PresentationFieldNames** class.  
Field **ContentStatus** has been added to **GroupDocs.Search.PresentationFieldNames** class.  
Field **Category** has been added to **GroupDocs.Search.PresentationFieldNames** class.  
Field **Manager** has been added to **GroupDocs.Search.PresentationFieldNames** class.  
Field **Author** has been added to **GroupDocs.Search.PresentationFieldNames** class.  
Field **LastAuthor** has been added to **GroupDocs.Search.PresentationFieldNames** class.  
Field **Company** has been added to **GroupDocs.Search.PresentationFieldNames** class.  
Field **HyperlinkBase** has been added to **GroupDocs.Search.PresentationFieldNames** class.  
Field **CreatedTime** has been added to **GroupDocs.Search.PresentationFieldNames** class.  
Field **LastSavedTime** has been added to **GroupDocs.Search.PresentationFieldNames** class.  
Field **LastPrintedTime** has been added to **GroupDocs.Search.PresentationFieldNames** class.  
Field **RevisionNumber** has been added to **GroupDocs.Search.PresentationFieldNames** class.  
Field **TotalEditingTime** has been added to **GroupDocs.Search.PresentationFieldNames** class.

Field **Application** has been added to **GroupDocs.Search.WordFieldNames** class.  
Field **ApplicationVersion** has been added to **GroupDocs.Search.WordFieldNames** class.  
Field **Template** has been added to **GroupDocs.Search.WordFieldNames** class.  
Field **Title** has been added to **GroupDocs.Search.WordFieldNames** class.  
Field **Subject** has been added to **GroupDocs.Search.WordFieldNames** class.  
Field **Comments** has been added to **GroupDocs.Search.WordFieldNames** class.  
Field **Keywords** has been added to **GroupDocs.Search.WordFieldNames** class.  
Field **ContentStatus** has been added to **GroupDocs.Search.WordFieldNames** class.  
Field **Category** has been added to **GroupDocs.Search.WordFieldNames** class.  
Field **Manager** has been added to **GroupDocs.Search.WordFieldNames** class.  
Field **Author** has been added to **GroupDocs.Search.WordFieldNames** class.  
Field **LastAuthor** has been added to **GroupDocs.Search.WordFieldNames** class.  
Field **Company** has been added to **GroupDocs.Search.WordFieldNames** class.  
Field **HyperlinkBase** has been added to **GroupDocs.Search.WordFieldNames** class.  
Field **CreatedTime** has been added to **GroupDocs.Search.WordFieldNames** class.  
Field **LastSavedTime** has been added to **GroupDocs.Search.WordFieldNames** class.  
Field **LastPrintedTime** has been added to **GroupDocs.Search.WordFieldNames** class.  
Field **RevisionNumber** has been added to **GroupDocs.Search.WordFieldNames** class.  
Field **TotalEditingTime** has been added to **GroupDocs.Search.WordFieldNames** class.

Usage:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// creating index.
Index index = new Index(indexFolder);
index.AddToIndex(documentsFolder);

// searching using public constants as field names.
SearchResults results1 = index.Search(string.Format("{0}:{1}", FieldNames.Content, "query1"));
SearchResults results2 = index.Search(string.Format("{0}:{1}", ExcelFieldNames.Subject, "query2"));
```

#### Remove obsolete properties from IndexingSettings

Removed obsolete properties and constructors from indexing settings.

**Public API Changes  
**Constructor **IndexingSettings(bool quickIndexing)** has been removed from **GroupDocs.Search.IndexingSettings** class.  
Constructor **IndexingSettings(bool quickIndexing, bool caseSensitive)** has been removed from **GroupDocs.Search.IndexingSettings** class.  
Property **bool QuickIndexing** has been removed from **GroupDocs.Search.IndexingSettings** class.  
Property **bool CaseSensitive** has been removed from **GroupDocs.Search.IndexingSettings** class.

#### Implement functionality for storing document text in index

This feature allows for cache text of indexed documents in the index. The cached text is used to generate HTML markup by highlighting of search results.  
Generating HTML markup from the cached text is faster than extracting text from source documents again, and can be performed even if source documents are no longer available.  
The default value for **TextStorageSettings** property is null. This means that document texts will not be cached in the index.  
**TextStorageSettings** class has a **Compression** parameter.  
**Compression.Normal** value is used to cache text with a good balance of compression ratio and indexing speed.  
**Compression.None** value is used to cache text at a maximum speed, but index size will be large.

**Public API Changes**  
Class **GroupDocs.Search.TextStorageSettings** has been added to **GroupDocs.Search** namespace.  
Property **GroupDocs.Search.TextStorageSettings TextStorageSettings** has been added to **GroupDocs.Search.IndexingSettings** class.  
Enumeration **Compression** has been added to **GroupDocs.Search** namespace.  
Value **None** has been added to **GroupDocs.Search.Compression** enumeration.  
Value **Normal** has been added to **GroupDocs.Search.Compression** enumeration.

This example shows how to cache text of indexed documents in the index:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// Creating indexing settings object
IndexingSettings settings = new IndexingSettings();
// Enabling source document text caching with normal compression level
settings.TextStorageSettings = new TextStorageSettings(Compression.Normal);

// Creating index
Index index = new Index(indexFolder, settings);

// Indexing
index.AddToIndex(documentsFolder);

```

#### Add DocumentFilter property to IndexingSetting for filtering files

This feature allows filtering files during indexing.  
Filtering can be performed by the following parameters:

*   file length;
*   creation date;
*   modification date;
*   extension;
*   file name using the regular expression.  
      
    

**Public API Changes**  
Abstract class **GroupDocs.Search.DocumentFilter** has been added.  
Method **DocumentFilter CreateCreationTimeLowerBound(System.DateTime)** has been added to **GroupDocs.Search.DocumentFilter** class.  
Method **DocumentFilter CreateCreationTimeUpperBound(System.DateTime)** has been added to **GroupDocs.Search.DocumentFilter** class.  
Method **DocumentFilter CreateCreationTimeRange(System.DateTime,System.DateTime)** has been added to **GroupDocs.Search.DocumentFilter** class.  
Method **DocumentFilter CreateModificationTimeLowerBound(System.DateTime)** has been added to **GroupDocs.Search.DocumentFilter** class.  
Method **DocumentFilter CreateModificationTimeUpperBound(System.DateTime)** has been added to **GroupDocs.Search.DocumentFilter** class.  
Method **DocumentFilter CreateModificationTimeRange(System.DateTime,System.DateTime)** has been added to **GroupDocs.Search.DocumentFilter** class.  
Method **DocumentFilter CreateFileNameRegularExpression(System.String,System.Text.RegularExpressions.RegexOptions)** has been added to **GroupDocs.Search.DocumentFilter** class.  
Method **DocumentFilter CreateFileLengthLowerBound(System.Int64)** has been added to **GroupDocs.Search.DocumentFilter** class.  
Method **DocumentFilter CreateFileLengthUpperBound(System.Int64)** has been added to **GroupDocs.Search.DocumentFilter** class.  
Method **DocumentFilter CreateFileLengthRange(System.Int64,System.Int64)** has been added to **GroupDocs.Search.DocumentFilter** class.  
Method **DocumentFilter CreateFileExtension(System.String\[\])** has been added to **GroupDocs.Search.DocumentFilter** class.  
Method **DocumentFilter CreateInverted(DocumentFilter)** has been added to **GroupDocs.Search.DocumentFilter** class.  
Method **DocumentFilter CreateConjunction(DocumentFilter\[\])** has been added to **GroupDocs.Search.DocumentFilter** class.  
Method **DocumentFilter CreateDisjunction(DocumentFilter\[\])** has been added to **GroupDocs.Search.DocumentFilter** class.  
Property **GroupDocs.Search.DocumentFilter DocumentFilter** has been added to **GroupDocs.Search.IndexingSettings** class.

This example shows how to use document filters:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// Creating indexing settings object
IndexingSettings settings = new IndexingSettings();

// Creating filter that only passes files from 600 KB to 1 MB in length
DocumentFilter byLength = DocumentFilter.CreateFileLengthRange(614400, 1048576);

// Creating filter that only passes text files
DocumentFilter byExtension = DocumentFilter.CreateFileExtension(".txt");

// Creating composite filter that only passes text files from 600 KB to 1 MB in length
DocumentFilter compositeFilter = DocumentFilter.CreateConjunction(byLength, byExtension);

// Setting filter
settings.DocumentFilter = compositeFilter;

// Creating index
Index index = new Index(indexFolder, settings);

// Indexing
index.AddToIndex(documentsFolder);

```

#### Implement automatic encoding detection for text documents

This feature allows detecting automatically the encoding of each text file that is indexed.  
By default, AutoDetectEncoding property is set to false.  
The following encodings can be detected:

*   UTF32 LE
*   UTF32 BE
*   UTF16 LE
*   UTF16 BE
*   UTF8
*   UTF7
*   ANSI

Encoding can be detected by BOM or by the content of the file (if BOM is not presented).  
If encoding is not detected than UTF8 is used by default.

**Public API Changes**  
Property **bool AutoDetectEncoding** has been added to **GroupDocs.Search.IndexingSettings** class.  
Method **string DetectEncoding(Encoding defaultEncoding, bool detectByContent)** has been added to **GroupDocs.Search.Events.FileIndexingEventArgs** class.

This example shows how to detect the encoding of each text file automatically:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// Creating indexing settings object
IndexingSettings settings = new IndexingSettings();
// Enabling automatic encoding detection
settings.AutoDetectEncoding = true;

// Creating index
Index index = new Index(indexFolder, settings);

// Indexing
index.AddToIndex(documentsFolder);

```

This example shows how to detect encoding selectively for some text files:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Creating default encoding that is used when encoding was not detected
Encoding defaultEncoding = Encoding.GetEncoding(Encodings.Windows_1252);

// Subscribing to FileIndexing event
index.FileIndexing += (sender, args) =>
{
    // Detecting encoding only for text files located in the 'DifferentEncodings' folder
    string fileName = args.DocumentFullName;
    if (fileName.EndsWith(".txt", true, CultureInfo.InvariantCulture) &&
        fileName.StartsWith(@"c:\MyDocuments\txt\DifferentEncodings\"))
    {
        args.DetectEncoding(defaultEncoding, true);
    }
};

// Indexing
index.AddToIndex(documentsFolder);

```

#### Implement support for CHM files

Implemented support for CHM format.

**Public API Changes**  
Enum value **Chm** has been added to **GroupDocs.Search.DocumentType** enum.

#### Implement feature 'Only best results range' for fuzzy search

This feature allows performing the fuzzy search by collecting the best results, as well as results with a larger number of mistakes in a given range.  
For example, suppose that the search is performed for a maximum of 10 mistakes with a range of 2. If words with a minimum of 5 mistakes are found, then also words with 6 and 7 mistakes will be included in the final result.  
The default value for the OnlyBestResultsRange property is 0. This means that by default there will only be words with a minimum number of mistakes in the results of the search.

**Public API Changes**  
Property **bool OnlyBestResultsRange** has been added to **GroupDocs.Search.FuzzySearchParameters** class.

This example shows how to use **OnlyBestResultsRange** property:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Indexing
index.AddToIndex(documentsFolder);

SearchParameters searchParameters = new SearchParameters();
// Enabling fuzzy search
searchParameters.FuzzySearch.Enabled = true;
// Setting maximum mistake count to 10
searchParameters.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(10);
// Enabling OnlyBestResults option
searchParameters.FuzzySearch.OnlyBestResults = true;
// Setting best results range to 2
searchParameters.FuzzySearch.OnlyBestResultsRange = 2;

// Searching
SearchResults searchResults = index.Search("aaaaa", searchParameters);
// If there is no 'aaaaa' word in the index then
// there will be found 'aaaax' - 1 mistake, 'aaaxx' - 2 mistakes, 'aaxxx' - 3 mistakes

```

#### Implement feature 'Only best results range' from spelling corrector

This feature allows performing spelling correction by collecting the best results, as well as results with a larger number of mistakes in a given range.  
For example, suppose that the correction is performed for a maximum of 10 mistakes with a range of 2. If words with a minimum of 5 mistakes are found, then also words with 6 and 7 mistakes will be included in the final result.  
The default value for the OnlyBestResultsRange property is 0. This means that by default there will only be words with a minimum number of mistakes in the results of the spelling correction.

**Public API Changes**  
Property **bool OnlyBestResultsRange** has been added to **GroupDocs.Search.SpellingCorrectorParameters** class.

This example shows how to use **OnlyBestResultsRange** property:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Indexing
index.AddToIndex(documentsFolder);

SearchParameters searchParameters = new SearchParameters();
// Enabling spelling correction
searchParameters.SpellingCorrector.Enabled = true;
// Setting maximum mistake count to 10
searchParameters.SpellingCorrector.MaxMistakeCount = 10;
// Enabling OnlyBestResults option
searchParameters.SpellingCorrector.OnlyBestResults = true;
// Setting best results range to 2
searchParameters.SpellingCorrector.OnlyBestResultsRange = 2;

// Searching
SearchResults searchResults = index.Search("aaaaa", searchParameters);
// If there is no 'aaaaa' word in the spelling corrector dictionary then
// there will be found 'aaaax' - 1 mistake, 'aaaxx' - 2 mistakes, 'aaxxx' - 3 mistakes
// if this last three words are presented both in the spelling corrector dictionary and in the index

```

#### Implement option for fuzzy search to consider transposition as a single mistake or not

This option for fuzzy search allows to consider transposition of two adjacent characters as a single mistake, when the option is enabled, or as two mistakes, when the option is disabled.  
The default value for the ConsiderTranspositions property is true.

**Public API Changes**  
Property **bool ConsiderTranspositions** has been added to **GroupDocs.Search.FuzzySearchParameters** class.

This example shows how to use **ConsiderTranspositions** option:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Indexing
index.AddToIndex(documentsFolder);

SearchParameters searchParameters = new SearchParameters();
// Enabling fuzzy search
searchParameters.FuzzySearch.Enabled = true;
// Setting maximum mistake count to 1
searchParameters.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(1);
// Setting not to consider transposition as a single mistake
searchParameters.FuzzySearch.ConsiderTranspositions = false;

// Searching for word 'Mail'
SearchResults searchResults = index.Search("Mail", searchParameters);
// There will be found word 'mails' - 1 mistake, but will not be found word 'Mali' - 2 mistakes

```

#### Implement option for spelling corrector to consider transposition as a single mistake or not

This option for spelling corrector allows to consider transposition of two adjacent characters as a single mistake, when the option is enabled, or as two mistakes, when the option is disabled.  
The default value for the ConsiderTranspositions property is true.

**Public API Changes**  
Property **bool ConsiderTranspositions** has been added to **GroupDocs.Search.SpellingCorrectorParameters** class.

This example shows how to use ConsiderTranspositions option:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Indexing
index.AddToIndex(documentsFolder);

SearchParameters searchParameters = new SearchParameters();
// Enabling spelling corrector
searchParameters.SpellingCorrector.Enabled = true;
// Setting maximum mistake count to 1
searchParameters.SpellingCorrector.MaxMistakeCount = 1;
// Setting not to consider transposition as a single mistake
searchParameters.SpellingCorrector.ConsiderTranspositions = false;

// Searching for word 'Mail'
SearchResults searchResults = index.Search("Mail", searchParameters);
// There will be found word 'mails' - 1 mistake, but will not be found word 'Mali' - 2 mistakes.
// Note that word 'mails' must be present both in the spelling corrector dictionary and in the index.

```
