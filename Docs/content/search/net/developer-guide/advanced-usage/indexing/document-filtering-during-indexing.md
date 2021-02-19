---
id: document-filtering-during-indexing
url: search/net/document-filtering-during-indexing
title: Document filtering during indexing
weight: 7
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
This page contains a description of the use of document filters for indexing, as well as descriptions of all types of filters with examples of their creation.

## Setting a filter

To indicate which documents from adding folders should be indexed and which not, the [DocumentFilter](https://apireference.groupdocs.com/net/search/groupdocs.search/indexsettings/properties/documentfilter) property of the [IndexSettings](https://apireference.groupdocs.com/net/search/groupdocs.search/indexsettings) class can be used to specify a filter based on various properties of these documents. If a document adding separately or located in an adding folder does not match the filter, then it will not be added and indexed. The default value is null, which means that all added files will be indexed if their format is supported. The following example demonstrates how to set a document filter for indexing.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";
 
// Creating a filter that skips documents with extensions '.doc', '.docx', '.rtf'
IndexSettings settings = new IndexSettings();
DocumentFilter fileExtensionFilter = DocumentFilter.CreateFileExtension(".doc", ".docx", ".rtf"); // Creating file extension filter that allows only specified extensions
DocumentFilter invertedFilter = DocumentFilter.CreateNot(fileExtensionFilter); // Inverting file extension filter to allow all extensions except specified ones
settings.DocumentFilter = invertedFilter;
 
// Creating an index in the specified folder
Index index = new Index(indexFolder, settings);
 
// Indexing documents
index.Add(documentsFolder);
```

## Creation time filters

The first type of filters is based on the time the document file was created. Such filters can skip files created earlier than a certain date, later than a certain date, or outside a certain range of dates. Examples of these filters are given below.

**C#**

```csharp
// The first filter skips files created earlier than January 1, 2017, 00:00:00 a.m.
DocumentFilter filter1 = DocumentFilter.CreateCreationTimeLowerBound(new DateTime(2017, 1, 1));
 
// The second filter skips files created later than June 15, 2018, 00:00:00 a.m.
DocumentFilter filter2 = DocumentFilter.CreateCreationTimeUpperBound(new DateTime(2018, 6, 15));
 
// The third filter skips files created outside the range from January 1, 2017, 00:00:00 a.m. to June 15, 2018, 00:00:00 a.m.
DocumentFilter filter3 = DocumentFilter.CreateCreationTimeRange(new DateTime(2017, 1, 1), new DateTime(2018, 6, 15));
```

## Modification time filters

The next type of filters works similarly, but based on the document file modification date. Examples are presented below.

**C#**

```csharp
// The first filter skips files modified earlier than January 1, 2017, 00:00:00 a.m.
DocumentFilter filter1 = DocumentFilter.CreateModificationTimeLowerBound(new DateTime(2017, 1, 1));
 
// The second filter skips files modified later than June 15, 2018, 00:00:00 a.m.
DocumentFilter filter2 = DocumentFilter.CreateModificationTimeUpperBound(new DateTime(2018, 6, 15));
 
// The third filter skips files modified outside the range from January 1, 2017, 00:00:00 a.m. to June 15, 2018, 00:00:00 a.m.
DocumentFilter filter3 = DocumentFilter.CreateModificationTimeRange(new DateTime(2017, 1, 1), new DateTime(2018, 6, 15));
```

## File path filters

The next type of filters allows you to set a regular expression for skipping those documents whose full paths do not match the specified pattern. This type of filters uses the **System.Text.RegularExpressions.Regex** class to compare with a pattern.

**C#**

```csharp
// The filter skips files that do not contain the word 'Einstein' in their paths
DocumentFilter filter = DocumentFilter.CreateFilePathRegularExpression("Einstein", RegexOptions.IgnoreCase);
```

## File length filters

The following group of filters uses the file length in bytes for filtering. It is possible to specify a lower bound, an upper bound or the range of acceptable file length. Examples are below.

**C#**

```csharp
 // The first filter skips documents less than 50 KB in length
DocumentFilter filter1 = DocumentFilter.CreateFileLengthLowerBound(50 * 1024);
 
// The second filter skips documents more than 10 MB in length
DocumentFilter filter2 = DocumentFilter.CreateFileLengthUpperBound(10 * 1024 * 1024);
 
// The third filter skips documents less than 100 KB and more than 5 MB in length
DocumentFilter filter3 = DocumentFilter.CreateFileLengthRange(100 * 1024, 5 * 1024 * 1024);
```

## File extension filter

The following type of filters allows you to specify a list of valid file extensions for indexing.

**C#**

```csharp
// This filter allows indexing only FB2, EPUB, and TXT files
DocumentFilter filter = DocumentFilter.CreateFileExtension(".fb2", ".epub", ".txt");
```

## Logical NOT filter

The next type of filter allows you to invert the logic of an internal filter.

**C#**

```csharp
IndexSettings settings = new IndexSettings();
DocumentFilter filter = DocumentFilter.CreateFileExtension(".htm", ".html");
DocumentFilter invertedFilter = DocumentFilter.CreateNot(filter); // Inverting file extension filter to allow all extensions except of HTM and HTML
settings.DocumentFilter = invertedFilter;
```

## Logical AND filter

The filter of the following type allows you to compose a complex filter from several other filters, using the logic "AND". This composite filter requires the simultaneous fulfillment of the conditions of all internal filters for each file to be added. The example below shows how to make a filter that allows indexing only documents created in the date range from 01/01/2015 to 01/01/2016, with the extension '.txt' and a size of no more than 8 MB.

**C#**

```csharp
IndexSettings settings = new IndexSettings();
DocumentFilter filter1 = DocumentFilter.CreateCreationTimeRange(new DateTime(2015, 1, 1), new DateTime(2016, 1, 1));
DocumentFilter filter2 = DocumentFilter.CreateFileExtension(".txt");
DocumentFilter filter3 = DocumentFilter.CreateFileLengthUpperBound(8 * 1024 * 1024);
DocumentFilter finalFilter = DocumentFilter.CreateAnd(filter1, filter2, filter3);
settings.DocumentFilter = finalFilter;
```

## Logical OR filter

The filter of the following type allows you to compose a complex filter from several other filters, using the logic "OR". This composite filter requires fulfillment of the condition of at least one internal filter for each added file. The example below shows how to create a filter that limits the size of text files to 5 mb and other files to 10 mb.

**C#**

```csharp
IndexSettings settings = new IndexSettings();
DocumentFilter txtFilter = DocumentFilter.CreateFileExtension(".txt");
DocumentFilter notTxtFilter = DocumentFilter.CreateNot(txtFilter);
DocumentFilter bound5Filter = DocumentFilter.CreateFileLengthUpperBound(5 * 1024 * 1024);
DocumentFilter bound10Filter = DocumentFilter.CreateFileLengthUpperBound(10 * 1024 * 1024);
DocumentFilter txtSizeFilter = DocumentFilter.CreateAnd(txtFilter, bound5Filter);
DocumentFilter notTxtSizeFilter = DocumentFilter.CreateAnd(notTxtFilter, bound10Filter);
DocumentFilter finalFilter = DocumentFilter.CreateOr(txtSizeFilter, notTxtSizeFilter);
settings.DocumentFilter = finalFilter;
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
