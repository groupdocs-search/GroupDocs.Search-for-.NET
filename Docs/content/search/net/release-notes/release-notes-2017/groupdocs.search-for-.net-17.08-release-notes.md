---
id: groupdocs-search-for-net-17-08-release-notes
url: search/net/groupdocs-search-for-net-17-08-release-notes
title: GroupDocs.Search for .NET 17.08 Release Notes
weight: 5
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 17.8{{< /alert >}}

## Major Features

There are 11 features and enhancements in this regular monthly release. The most notable are:

*   SEARCHNET-1146 Fix all arguments classes according to best practices
*   SEARCHNET-1091 Remove obsolete SimilarityLevel property from SearchParameters
*   SEARCHNET-474 Implement accent-insensitive indexing
*   SEARCHNET-576 Add FileIndexing event for selecting custom indexing strategy for separate document
*   SEARCHNET-1092 Implement option for the spelling corrector 'Only best results'
*   SEARCHNET-1096 Implement option for the fuzzy search 'Only best results'
*   SEARCHNET-1098 Implement Limit for Searching Report
*   SEARCHNET-1099 Implement Limit for Indexing Report
*   SEARCHNET-1129 Implement method that generates text with highlighted search results
*   SEARCHNET-1135 Implement indexing ZIP archives
*   SEARCHNET-1148 Add StatusChanged event to Index class

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-1146 | Fix all arguments classes according to best practices | Breaking Change |
| SEARCHNET-1091 | Remove obsolete SimilarityLevel property from SearchParameters | Enhancement |
| SEARCHNET-474 | Implement accent-insensitive indexing | New Feature |
| SEARCHNET-576 | Add FileIndexing event for selecting custom indexing strategy for separate document | New Feature |
| SEARCHNET-1092 | Implement option for the spelling corrector 'Only best results' | New Feature |
| SEARCHNET-1096 | Implement option for the fuzzy search 'Only best results' | New Feature |
| SEARCHNET-1098 | Implement Limit for Searching Report | New Feature |
| SEARCHNET-1099 | Implement Limit for Indexing Report | New Feature |
| SEARCHNET-1129 | Implement method that generates text with highlighted search results | New Feature |
| SEARCHNET-1135 | Implement indexing ZIP archives | New Feature |
| SEARCHNET-1148 | Add StatusChanged event to Index class | New Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Search for .NET 17.8. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Search which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Fix all arguments classes according to best practices

In this enhancement all argument classes have been renamed according to best practices.

**Public API Changes**  
Class **GroupDocs.Search.Events.BaseIndexArg** renamed to **GroupDocs.Search.Events.BaseIndexEventArgs**.  
Class **GroupDocs.Search.Events.PasswordRequiredArg** renamed to **GroupDocs.Search.Events.PasswordRequiredEventArgs**.  
Class **GroupDocs.Search.Events.OperationFinishedArg** renamed to **GroupDocs.Search.Events.OperationFinishedEventArgs**.  
Class **GroupDocs.Search.Events.OperationProgressArg** renamed to **GroupDocs.Search.Events.OperationProgressEventArgs**.

#### Remove obsolete SimilarityLevel property from SearchParameters

In this enhancement obsolete SimilarityLevel property has been removed from Public API.

**Public API Changes  
**Property **SimilarityLevel** has been removed from **GroupDocs.Search.FuzzySearchParameters** class.

Use this code to set similarity level for fuzzy search:

**C#**

```csharp
SearchParameters searchParameters = new SearchParameters();
searchParameters.FuzzySearch.Enabled = true;

// Removed obsolete property
// searchParameters.FuzzySearch.SimilarityLevel = 0.5;

// Current way to set similarity level
searchParameters.FuzzySearch.FuzzyAlgorithm = new SimilarityLevel(0.5);

```

#### Implement accent-insensitive indexing

This feature allows to perform replacements of characters during indexing.

Users can manage list of characters for replacements. It makes sense to do this only before indexing.

**Public API Changes**  
Class **CharacterReplacementDictionary** has been added to **GroupDocs.Search** namespace.  
Property **GroupDocs.Search.****CharacterReplacementDictionary** **CharacterReplacements** has been added to **GroupDocs.Search.DictionaryCollection** class.  
Property **bool UseCharacterReplacements** has been added to **GroupDocs.Search.IndexingSettings** class.

This example shows how to use and manage character replacement dictionary:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";
string replacementsFileName = @"c:\MyReplacements.txt";

// Enabling replacements during indexing
var settings = new IndexingSettings();
settings.UseCharacterReplacements = true;

// Creating index
Index index = new Index(indexFolder, settings);

// Clearing dictionary of replacements
index.Dictionaries.CharacterReplacements.Clear();

// Adding replacements
KeyValuePair<char, char>[] replacements = new KeyValuePair<char, char>[]
{
    new KeyValuePair<char, char>('Ṝ', 'R'),
    new KeyValuePair<char, char>('ṝ', 'r'),
};
index.Dictionaries.CharacterReplacements.AddRange(replacements);

// Import replacements from file. Existing replacements are staying.
index.Dictionaries.CharacterReplacements.Import(replacementsFileName);
// Export replacements to file
index.Dictionaries.CharacterReplacements.Export(@"c:\MyExportedReplacements.txt");

// Indexing
index.AddToIndex(documentsFolder);

```

#### Add FileIndexing event for selecting custom indexing strategy for separate document

Feature allows to set custom strategy for each document.

User can select skipping indexing, change text extractor, change encoding for text files or do something else before indexing.

**Public API Changes**  
Class **Encodings** has been added to **GroupDocs.Search** namespace.  
Class **FileIndexingEventArgs** has been added to **GroupDocs.Search.Events** namespace.  
Event **FileIndexing** has been added to **GroupDocs.Search.Index** class.  
Event **FileIndexing** has been added to **GroupDocs.Search.IndexRepository** class.  
Fields of **Encodings** class are listed below.

![](images/icons/grey_arrow_down.png)Click here to view the list of fields added to Encodings class

Property **string IBM037** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM437** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM500** has been added to **GroupDocs.Search.Encodings** class.  
Property **string ASMO\_708** has been added to **GroupDocs.Search.Encodings** class.  
Property **string DOS\_720** has been added to **GroupDocs.Search.Encodings** class.  
Property **string ibm737** has been added to **GroupDocs.Search.Encodings** class.  
Property **string ibm775** has been added to **GroupDocs.Search.Encodings** class.  
Property **string ibm850** has been added to **GroupDocs.Search.Encodings** class.  
Property **string ibm852** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM855** has been added to **GroupDocs.Search.Encodings** class.  
Property **string ibm857** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM00858** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM860** has been added to **GroupDocs.Search.Encodings** class.  
Property **string ibm861** has been added to **GroupDocs.Search.Encodings** class.  
Property **string DOS\_862** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM863** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM864** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM865** has been added to **GroupDocs.Search.Encodings** class.  
Property **string cp866** has been added to **GroupDocs.Search.Encodings** class.  
Property **string ibm869** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM870** has been added to **GroupDocs.Search.Encodings** class.  
Property **string windows\_874** has been added to **GroupDocs.Search.Encodings** class.  
Property **string cp875** has been added to **GroupDocs.Search.Encodings** class.  
Property **string shift\_jis** has been added to **GroupDocs.Search.Encodings** class.  
Property **string gb2312** has been added to **GroupDocs.Search.Encodings** class.  
Property **string ks\_c\_5601\_1987** has been added to **GroupDocs.Search.Encodings** class.  
Property **string big5** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM1026** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM01047** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM01140** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM01141** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM01142** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM01143** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM01144** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM01145** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM01146** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM01147** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM01148** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM01149** has been added to **GroupDocs.Search.Encodings** class.  
Property **string utf\_16** has been added to **GroupDocs.Search.Encodings** class.  
Property **string utf\_16BE** has been added to **GroupDocs.Search.Encodings** class.  
Property **string windows\_1250** has been added to **GroupDocs.Search.Encodings** class.  
Property **string windows\_1251** has been added to **GroupDocs.Search.Encodings** class.  
Property **string Windows\_1252** has been added to **GroupDocs.Search.Encodings** class.  
Property **string windows\_1253** has been added to **GroupDocs.Search.Encodings** class.  
Property **string windows\_1254** has been added to **GroupDocs.Search.Encodings** class.  
Property **string windows\_1255** has been added to **GroupDocs.Search.Encodings** class.  
Property **string windows\_1256** has been added to **GroupDocs.Search.Encodings** class.  
Property **string windows\_1257** has been added to **GroupDocs.Search.Encodings** class.  
Property **string windows\_1258** has been added to **GroupDocs.Search.Encodings** class.  
Property **string Johab** has been added to **GroupDocs.Search.Encodings** class.  
Property **string macintosh** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_mac\_japanese** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_mac\_chinesetrad** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_mac\_korean** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_mac\_arabic** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_mac\_hebrew** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_mac\_greek** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_mac\_cyrillic** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_mac\_chinesesimp** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_mac\_romanian** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_mac\_ukrainian** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_mac\_thai** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_mac\_ce** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_mac\_icelandic** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_mac\_turkish** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_mac\_croatian** has been added to **GroupDocs.Search.Encodings** class.  
Property **string utf\_32** has been added to **GroupDocs.Search.Encodings** class.  
Property **string utf\_32BE** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_Chinese\_CNS** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_cp20001** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_Chinese\_Eten** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_cp20003** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_cp20004** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_cp20005** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_IA5** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_IA5\_German** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_IA5\_Swedish** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_IA5\_Norwegian** has been added to **GroupDocs.Search.Encodings** class.  
Property **string us\_ascii** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_cp20261** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_cp20269** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM273** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM277** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM278** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM280** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM284** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM285** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM290** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM297** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM420** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM423** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM424** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_EBCDIC\_KoreanExtended** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM\_Thai** has been added to **GroupDocs.Search.Encodings** class.  
Property **string koi8\_r** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM871** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM880** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM905** has been added to **GroupDocs.Search.Encodings** class.  
Property **string IBM00924** has been added to **GroupDocs.Search.Encodings** class.  
Property **string EUC\_JP** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_cp20936** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_cp20949** has been added to **GroupDocs.Search.Encodings** class.  
Property **string cp1025** has been added to **GroupDocs.Search.Encodings** class.  
Property **string koi8\_u** has been added to **GroupDocs.Search.Encodings** class.  
Property **string iso\_8859\_1** has been added to **GroupDocs.Search.Encodings** class.  
Property **string iso\_8859\_2** has been added to **GroupDocs.Search.Encodings** class.  
Property **string iso\_8859\_3** has been added to **GroupDocs.Search.Encodings** class.  
Property **string iso\_8859\_4** has been added to **GroupDocs.Search.Encodings** class.  
Property **string iso\_8859\_5** has been added to **GroupDocs.Search.Encodings** class.  
Property **string iso\_8859\_6** has been added to **GroupDocs.Search.Encodings** class.  
Property **string iso\_8859\_7** has been added to **GroupDocs.Search.Encodings** class.  
Property **string iso\_8859\_8** has been added to **GroupDocs.Search.Encodings** class.  
Property **string iso\_8859\_9** has been added to **GroupDocs.Search.Encodings** class.  
Property **string iso\_8859\_13** has been added to **GroupDocs.Search.Encodings** class.  
Property **string iso\_8859\_15** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_Europa** has been added to **GroupDocs.Search.Encodings** class.  
Property **string iso\_8859\_8\_i** has been added to **GroupDocs.Search.Encodings** class.  
Property **string iso\_2022\_jp** has been added to **GroupDocs.Search.Encodings** class.  
Property **string csISO2022JP** has been added to **GroupDocs.Search.Encodings** class.  
Property **string iso\_2022\_kr** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_cp50227** has been added to **GroupDocs.Search.Encodings** class.  
Property **string euc\_jp** has been added to **GroupDocs.Search.Encodings** class.  
Property **string EUC\_CN** has been added to **GroupDocs.Search.Encodings** class.  
Property **string euc\_kr** has been added to **GroupDocs.Search.Encodings** class.  
Property **string hz\_gb\_2312** has been added to **GroupDocs.Search.Encodings** class.  
Property **string GB18030** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_iscii\_de** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_iscii\_be** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_iscii\_ta** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_iscii\_te** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_iscii\_as** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_iscii\_or** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_iscii\_ka** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_iscii\_ma** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_iscii\_gu** has been added to **GroupDocs.Search.Encodings** class.  
Property **string x\_iscii\_pa** has been added to **GroupDocs.Search.Encodings** class.  
Property **string utf\_7** has been added to **GroupDocs.Search.Encodings** class.  
Property **string utf\_8** has been added to **GroupDocs.Search.Encodings** class.

This example shows how to skip indexing by file name:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

Index index = new Index(indexFolder);

// Subscrubing to event FileIndexing where we skip all files which contain 'secret' in file name
index.FileIndexing += (sender, arg) =>
{
    if (arg.DocumentFullName.Contains("secret"))
    {
        arg.SkipIndexing = true;
    }
};

index.AddToIndex(documentsFolder);

```

This example shows how set encoding for some files:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

Index index = new Index(indexFolder);

// Subscrubing to event FileIndexing where we set encoding for some files
index.FileIndexing += (sender, arg) =>
{
    if (arg.DocumentFullName.Contains("not_english"))
    {
        // Use GroupDocs.Search.Encodings constants to select encoding
        arg.Encoding = GroupDocs.Search.Encodings.windows_1251;
    }
};

index.AddToIndex(documentsFolder);

```

This example shows how set custom text extractor for some files:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

Index index = new Index(indexFolder);

// Subscrubing to event FileIndexing where we set custom text extractor for some files
index.FileIndexing += (sender, arg) =>
{
    if (arg.DocumentFullName.Contains(".txt"))
    {
        arg.CustomExtractor = new CustomExtractor();
    }
};

index.AddToIndex(documentsFolder);

...

class CustomExtractor : IFieldExtractor
{
    public string[] Extensions { get { return new[] { ".txt" }; } }

    public GroupDocs.Search.FieldInfo[] GetFields(string fileName)
    {
        System.Collections.Generic.List<GroupDocs.Search.FieldInfo> fields =
            new System.Collections.Generic.List<GroupDocs.Search.FieldInfo>();
        fields.Add(new Search.FieldInfo("content", "extracted text"));
        return fields.ToArray();
    }
}

```

#### Implement accent-insensitive indexing

This feature allows to perform replacements of characters during indexing.

Users can manage list of characters for replacements. It makes sense to do this only before indexing.

**Public API Changes**  
Class **CharacterReplacementDictionary** has been added to **GroupDocs.Search** namespace.  
Property **GroupDocs.Search.****CharacterReplacementDictionary** **CharacterReplacements** has been added to **GroupDocs.Search.DictionaryCollection** class.  
Property **bool UseCharacterReplacements** has been added to **GroupDocs.Search.IndexingSettings** class.

This example shows how to use and manage character replacement dictionary:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";
string replacementsFileName = @"c:\MyReplacements.txt";

// Enabling replacements during indexing
var settings = new IndexingSettings();
settings.UseCharacterReplacements = true;

// Creating index
Index index = new Index(indexFolder, settings);

// Clearing dictionary of replacements
index.Dictionaries.CharacterReplacements.Clear();

// Adding replacements
KeyValuePair<char, char>[] replacements = new KeyValuePair<char, char>[]
{
    new KeyValuePair<char, char>('Ṝ', 'R'),
    new KeyValuePair<char, char>('ṝ', 'r'),
};
index.Dictionaries.CharacterReplacements.AddRange(replacements);

// Import replacements from file. Existing replacements are staying.
index.Dictionaries.CharacterReplacements.Import(replacementsFileName);
// Export replacements to file
index.Dictionaries.CharacterReplacements.Export(@"c:\MyExportedReplacements.txt");

// Indexing
index.AddToIndex(documentsFolder);

```

#### Implement option for the spelling corrector 'Only best results'

This feature allows to perform spelling correction by collecting suggestions with only minimum mistake count and discarding worse suggestions.

Enabling this option can greatly improve the performance of spelling corrector.

**Public API Changes**  
Property **bool ****OnlyBestResults** has been added to **GroupDocs.Search.****SpellingCorrectorParameters** class.

This example shows how to use **OnlyBestResults** option:

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
// Setting maximum mistake count to 5
searchParameters.SpellingCorrector.MaxMistakeCount = 5;
// Enabling OnlyBestResults option
searchParameters.SpellingCorrector.OnlyBestResults = true;

// Searching
SearchResults searchResults = index.Search("some", searchParameters);

```

#### Implement option for the fuzzy search 'Only best results'

This feature allows to perform fuzzy search by collecting results with only minimum mistake count and discarding worse results.

Enabling this option can greatly improve the performance of fuzzy search.

**Public API Changes**  
Property **bool ****OnlyBestResults** has been added to **GroupDocs.Search.FuzzySearchParameters** class.

This example shows how to use **OnlyBestResults** option:

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
// Setting maximum mistake count to 5
searchParameters.FuzzySearch.FuzzyAlgorithm = new TableDiscreteFunction(5);
// Enabling OnlyBestResults option
searchParameters.FuzzySearch.OnlyBestResults = true;

// Searching
SearchResults searchResults = index.Search("some", searchParameters);

```

#### Implement Limit for Searching Report

Feature allows to set the maximum count of search reports.

This value means how many last reports are stored.

Default value of the maximum search report count is 10.

**Public API Changes**  
Property **int MaxSearchingReportCount** has been added to **GroupDocs.Search.IndexingSettings** class.

This example shows how to limit the search report:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

Index index = new Index(indexFolder);

// Setting the maximum count of search reports
index.IndexingSettings.MaxSearchingReportCount = 3;

// Indexing
index.AddToIndex(documentsFolder);

// Running 100 of searches
for (int i = 0; i < 100; i++)
{
    index.Search("Query");
}

// Getting search report. Array contains only 3 last records.
SearchingReport[] report = index.GetSearchingReport();

// This code writes to console information about 3 last searches only
foreach (SearchingReport record in report)
{
    Console.WriteLine("Searching takes {0}, {1} results was found.", record.SearchingTime, record.ResultCount);
}

```

#### Implement Limit for Indexing Report

Feature allows to set the maximum count of indexing report.

This value means how many last reports are stored.

Default value of the maximum indexing report count is 5.

**Public API Changes**  
Property **int MaxIndexingReportCount** has been added to **GroupDocs.Search.IndexingSettings** class.

This example shows how to limit the index report:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";

Index index = new Index(indexFolder);

// Setting the maximum count of indexing reports
index.IndexingSettings.MaxIndexingReportCount = 3;

index.AddToIndex(@"c:\MyDocuments\folder1\");
index.AddToIndex(@"c:\MyDocuments\folder2\");
index.AddToIndex(@"c:\MyDocuments\folder3\");
index.AddToIndex(@"c:\MyDocuments\folder4\");
index.AddToIndex(@"c:\MyDocuments\folder5\");

// Getting indexing report. Array contains only 3 last records about indexing.
IndexingReport[] report = index.GetIndexingReport();

// Five indexing operations were performed, but only 3 last operations will be printed on the console in this example
foreach (IndexingReport record in report)
{
    Console.WriteLine("Indexing takes {0}, index size: {1}.", record.IndexingTime, record.TotalIndexSize);
}

```

#### Implement method that generates text with highlighted search results

This feature allows to generate text formatted with minimum number of HTML tags.

HTML tags are used to insert line breaks, highlight found terms in text, and navigate on found terms in web browser.

**Public API Changes**  
Method **string ****HighlightInText(DocumentResultInfo info, IFieldExtractor customExtractor, string encoding)** has been added to **GroupDocs.Search.Index** class.  
Method **void HighlightInText(string fileName, DocumentResultInfo** **info****, IFieldExtractor** **customExtractor****, string** **encoding****)** has been added to **GroupDocs.Search.Index** class.

This example shows how to generate text with highlighted search results:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Indexing
index.AddToIndex(documentsFolder);

// Searching
SearchResults results = index.Search("some");

// Generating HTML-formatted text for the first document in search results
string text = index.HighlightInText(results[0]);

```

This example shows how to generate text with highlighted results directly to file:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// Creating index
Index index = new Index(indexFolder);

// Indexing
index.AddToIndex(documentsFolder);

// Searching
SearchResults results = index.Search("some");

// Generating HTML-formatted text for the first document directly to the file 'HighlightedResults.html'
index.HighlightInText("HighlightedResults.html", results[0]);

```

This example shows how to create URL string for generated HTML file to navigate on search results in web browser:

**C#**

```csharp
file:///C:/HighlightedResults.html#hit0

```

#### Implement indexing ZIP archives

Implemented indexing of zip-archives with all supported documents.

**Public API Changes**  
Enum value **ZipArchive** has been added to **GroupDocs.Search.DocumentType** enum.  
Class **ZipArchiveResultInfo** has been added to **GroupDocs.Search** namespace.  
Property **string InnerPath** has been added to **GroupDocs.Search.OutlookEmailMessageResultInfo** class.

#### Add StatusChanged event to Index class

This feature allows to track index status in a simple way.

**Public API Changes**  
Event **EventHandler<GroupDocs.Search.Events.BaseIndexEventArgs> StatusChanged** added to **GroupDocs.Search.Index** class.

This example shows how to use StatusChanged event:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";

// Creating index
Index index = new Index(indexFolder);

IndexStatus status;
// Subscribing to StatusChanged event
index.StatusChanged += (sender, args) =>
{
    status = args.Status;
};

```
