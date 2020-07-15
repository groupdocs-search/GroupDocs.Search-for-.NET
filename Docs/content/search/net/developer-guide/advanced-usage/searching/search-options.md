---
id: search-options
url: search/net/search-options
title: Search options
weight: 22
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
This page contains a description of all search options that can be specified in an instance of the [SearchOptions](https://apireference.groupdocs.com/net/search/groupdocs.search.options/searchoptions) class.

## Cancellation property

The [Cancellation](https://apireference.groupdocs.com/net/search/groupdocs.search.options/searchoptions/properties/cancellation) property allows you to specify the object to cancel the search operation. The search can be canceled without delay by calling the [Cancel](https://apireference.groupdocs.com/net/search/groupdocs.search.common/cancellation/methods/cancel) method or by calling the [CancelAfter](https://apireference.groupdocs.com/net/search/groupdocs.search.common/cancellation/methods/cancelafter) method with the delay in milliseconds as an argument.

## DateFormats property

The [DateFormats](https://apireference.groupdocs.com/net/search/groupdocs.search.options/searchoptions/properties/dateformats) property allows you to specify formats for the date range search feature. For details, see the [Date range search]({{< ref "search/net/developer-guide/advanced-usage/searching/date-range-search.md" >}}) page.

## FuzzySearch property

The [FuzzySearch](https://apireference.groupdocs.com/net/search/groupdocs.search.options/searchoptions/properties/fuzzysearch) property returns a fuzzy search options object that allows you to enable fuzzy search and set its options. By default, the fuzzy search feature is disabled. For details, see the [Fuzzy search]({{< ref "search/net/developer-guide/advanced-usage/searching/fuzzy-search.md" >}}) page.

## IsChunkSearch property

The [IsChunkSearch](https://apireference.groupdocs.com/net/search/groupdocs.search.options/searchoptions/properties/ischunksearch) property allows you to enable search by chunks. By default, the search by chunks feature is disabled. For details, see the [Search by chunks]({{< ref "search/net/developer-guide/advanced-usage/searching/search-by-chunks.md" >}}) page.

## KeyboardLayoutCorrector property

The [KeyboardLayoutCorrector](https://apireference.groupdocs.com/net/search/groupdocs.search.options/searchoptions/properties/keyboardlayoutcorrector) property returns a keyboard layout corrector options object, which allows you to enable keyboard layout correction in search queries. By default, the keyboard layout correction feature is disabled. See the [Keyboard layout correction]({{< ref "search/net/developer-guide/advanced-usage/searching/keyboard-layout-correction.md" >}}) page for details.

## MaxOccurrenceCountPerTerm property

The [MaxOccurrenceCountPerTerm](https://apireference.groupdocs.com/net/search/groupdocs.search.options/searchoptions/properties/maxoccurrencecountperterm) property allows you to specify the maximum number of occurrences of each word found that will be returned as a search result. The default value is 100000.

## MaxTotalOccurrenceCount property

The [MaxTotalOccurrenceCount](https://apireference.groupdocs.com/net/search/groupdocs.search.options/searchoptions/properties/maxtotaloccurrencecount) property allows you to specify the maximum number of occurrences in total for all found words, which will be returned as a search result. The default value is 500000.

## SearchDocumentFilter property

The [SearchDocumentFilter](https://apireference.groupdocs.com/net/search/groupdocs.search.options/searchoptions/properties/searchdocumentfilter) property allows you to specify the filter of documents returned as a search result. By default, all documents found will be returned as a search result. For details, see the [Document filtering in search result]({{< ref "search/net/developer-guide/advanced-usage/searching/document-filtering-in-search-result.md" >}}) page.

## SpellingCorrector property

The [SpellingCorrector](https://apireference.groupdocs.com/net/search/groupdocs.search.options/searchoptions/properties/spellingcorrector) property returns the spelling corrector options object, which allows you to enable spelling correction in search queries and specify spelling correction options. By default, spelling correction is disabled. See the [Spell checking]({{< ref "search/net/developer-guide/advanced-usage/searching/spell-checking.md" >}}) page for details.

## UseCaseSensitiveSearch property

The [UseCaseSensitiveSearch](https://apireference.groupdocs.com/net/search/groupdocs.search.options/searchoptions/properties/usecasesensitivesearch) property allows you to perform case-sensitive search. Please note that case-sensitive search is not compatible with other types of searches. By default, case-insensitive search is performed. For details, see the [Case sensitive search]({{< ref "search/net/developer-guide/advanced-usage/searching/case-sensitive-search.md" >}}) page.

## UseHomophoneSearch property

The [UseHomophoneSearch](https://apireference.groupdocs.com/net/search/groupdocs.search.options/searchoptions/properties/usehomophonesearch) property allows you to enable homophone search feature. By default, the homophone search feature is disabled. For details, see the [Homophone search]({{< ref "search/net/developer-guide/advanced-usage/searching/homophone-search.md" >}}) page.

## UseSynonymSearch property

The [UseSynonymSearch](https://apireference.groupdocs.com/net/search/groupdocs.search.options/searchoptions/properties/usesynonymsearch) property allows you to enable synonym search feature. By default, the synonym search feature is disabled. For details, see the [Synonym search]({{< ref "search/net/developer-guide/advanced-usage/searching/synonym-search.md" >}}) page.

## UseWordFormsSearch property

The [UseWordFormsSearch](https://apireference.groupdocs.com/net/search/groupdocs.search.options/searchoptions/properties/usewordformssearch) property allows you to enable the word forms search feature. By default, the word forms search feature is disabled. For details, see the [Search for different word forms]({{< ref "search/net/developer-guide/advanced-usage/searching/search-for-different-word-forms.md" >}}) page.

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
