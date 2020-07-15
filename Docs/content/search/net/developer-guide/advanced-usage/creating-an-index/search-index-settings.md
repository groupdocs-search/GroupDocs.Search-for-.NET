---
id: search-index-settings
url: search/net/search-index-settings
title: Search index settings
weight: 3
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
This page contains a description of all index settings that can be specified in an instance of the [IndexSettings](https://apireference.groupdocs.com/net/search/groupdocs.search/indexsettings) class.

## AutoDetectEncoding property

The [AutoDetectEncoding](https://apireference.groupdocs.com/net/search/groupdocs.search/indexsettings/properties/autodetectencoding) property is a flag that allows you to automatically detect the following encodings of text files during indexing: UTF-32 LE, UTF-32 BE, UTF-16 LE, UTF-16 BE, UTF-8, UTF-7, ANSI. By default, the encoding auto detection of text files is disabled. But in any case, the encoding of a text file can be set during indexing when the [FileIndexing](https://apireference.groupdocs.com/net/search/groupdocs.search.events/eventhub/events/fileindexing)event is raised. Detailed information on detecting and setting the encoding of text files is presented on the page [Text file encoding detection]({{< ref "search/net/developer-guide/advanced-usage/indexing/text-file-encoding-detection.md" >}}).

## CustomExtractors property

The [CustomExtractors](https://apireference.groupdocs.com/net/search/groupdocs.search/indexsettings/properties/customextractors) property returns a collection of custom text extractors that allows adding new extractors for supported or not supported formats. A complete example of implementing a custom text extractor and using it to extract text is presented on the page [Custom text extractors]({{< ref "search/net/developer-guide/advanced-usage/indexing/custom-text-extractors.md" >}}).

## DocumentFilter property

The [DocumentFilter](https://apireference.groupdocs.com/net/search/groupdocs.search/indexsettings/properties/documentfilter) property allows you to set a filter used to determine whether files adding to the index should be indexed. If a document adding separately or located in the adding folder does not match the filter, then it will not be added and indexed. The default value is null, which means that all added files will be indexed if their format is supported. Detailed information on creating and setting the document indexing filter can be found on the page [Document filtering during indexing]({{< ref "search/net/developer-guide/advanced-usage/indexing/document-filtering-during-indexing.md" >}}).

## IndexType property

The [IndexType](https://apireference.groupdocs.com/net/search/groupdocs.search/indexsettings/properties/indextype) property is used to specify the type of an index. The [IndexType](https://apireference.groupdocs.com/net/search/groupdocs.search.options/indextype) enumeration contains 3 values:

*   **NormalIndex** - the type of an index containing the content and metadata of the added documents. It supports all search features.
*   **MetadataIndex** - the type of an index containing only metadata of added documents. It supports all search features. An example of creating an index of this type is presented on the [Indexing metadata of documents]({{< ref "search/net/developer-guide/advanced-usage/indexing/indexing-metadata-of-documents.md" >}}) page.
*   **CompactIndex** - the type of an index containing the content and metadata of the added documents. It takes much less disk space, but does not support the [phrase search]({{< ref "search/net/developer-guide/advanced-usage/searching/phrase-search.md" >}}) and the [date range search]({{< ref "search/net/developer-guide/advanced-usage/searching/date-range-search.md" >}}) features.

The default value of this property is **NormalIndex**.

## InMemoryIndex property

The read-only property [InMemoryIndex](https://apireference.groupdocs.com/net/search/groupdocs.search/indexsettings/properties/inmemoryindex) returns a value indicating whether an index is located in RAM or on disk. The value of this property is set indirectly when creating or loading an index. An index is created on disk, when specifying the path to the index folder, otherwise an index is created in memory.

## Logger property

The [Logger](https://apireference.groupdocs.com/net/search/groupdocs.search/indexsettings/properties/logger) property allows you to specify in the index settings the logger used for logging index events and errors during its operation. The default value is null meaning that logging is not used. Detailed information on creating and assigning an index logger and the implementation of a custom logger is presented on the page [Logging]({{< ref "search/net/developer-guide/advanced-usage/indexing/logging.md" >}}).

## MaxIndexingReportCount property

The [MaxIndexingReportCount](https://apireference.groupdocs.com/net/search/groupdocs.search/indexsettings/properties/maxindexingreportcount) property allows you to specify the maximum number of indexing reports stored in RAM for an index since it was created or loaded. The default value is 5. Detailed information on indexing reports is provided on the page [Indexing reports]({{< ref "search/net/developer-guide/advanced-usage/indexing/indexing-reports.md" >}}).

## MaxSearchReportCount property

The [MaxSearchReportCount](https://apireference.groupdocs.com/net/search/groupdocs.search/indexsettings/properties/maxsearchreportcount) property allows you to specify the maximum number of search reports stored in RAM for an index since it was created or loaded. The default value is 10. Detailed information on search reports is provided on the page [Indexing reports]({{< ref "search/net/developer-guide/advanced-usage/indexing/indexing-reports.md" >}}).

## SearchThreads property

The [SearchThreads](https://apireference.groupdocs.com/net/search/groupdocs.search/indexsettings/properties/searchthreads) property allows you to set the number of threads used to search in an index. By default, this value is [NumberOfThreads](https://apireference.groupdocs.com/net/search/groupdocs.search.options/numberofthreads).Default, which means that the search will be performed using the number of threads equal to the number of processor cores. This number of threads ensures the optimal rate of each individual search in an index. If you plan a large number of parallel search queries and you need to ensure maximum total search performance, you should set the [NumberOfThreads](https://apireference.groupdocs.com/net/search/groupdocs.search.options/numberofthreads).One value for this parameter.

## TextStorageSettings property

The [TextStorageSettings](https://apireference.groupdocs.com/net/search/groupdocs.search/indexsettings/properties/textstoragesettings) property allows you to specify the settings for saving the text of indexed documents in an index. The default value is null, which means that document texts are not stored. Detailed information on saving the text of indexed documents in an index is presented on the page [Storing text of indexed documents]({{< ref "search/net/developer-guide/advanced-usage/indexing/storing-text-of-indexed-documents.md" >}})).

## UseCharacterReplacements property

The [UseCharacterReplacements](https://apireference.groupdocs.com/net/search/groupdocs.search/indexsettings/properties/usecharacterreplacements) property allows you to set the value indicating whether to perform character replacements during the indexing process or not. The default value is false. Details on replacing characters during indexing are provided on the page [Character replacement during Indexing]({{< ref "search/net/developer-guide/advanced-usage/indexing/character-replacement-during-indexing.md" >}}).

## UseStopWords property

The [UseStopWords](https://apireference.groupdocs.com/net/search/groupdocs.search/indexsettings/properties/usestopwords) property allows you to specify a value indicating whether to use stop words during indexing or not. Stop words are frequently used words that do not carry a semantic load, which are removed from an index to reduce its size. The default value for this parameter is true. Detailed information on stop words and their use is presented on the page [Indexing with stop words]({{< ref "search/net/developer-guide/advanced-usage/indexing/indexing-with-stop-words.md" >}}).

## UseRawTextExtraction property

Property [UseRawTextExtraction](https://apireference.groupdocs.com/search/net/groupdocs.search/indexsettings/properties/userawtextextraction) allows you to specify a value indicating whether to use raw text  extraction mode whenever possible during indexing. The raw text  extraction mode can significantly speed up the indexing process at the  cost of losing the formatting quality of the extracted text. The default value for this property is true.



## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
