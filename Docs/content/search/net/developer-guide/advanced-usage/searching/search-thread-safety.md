---
id: search-thread-safety
url: search/net/search-thread-safety
title: Search thread safety
weight: 25
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
## Multiple simultaneous searches

Search in an index is a thread safe operation. This means that calls to the [Search](https://apireference.groupdocs.com/net/search/groupdocs.search/index/methods/search/index) and [SearchNext](https://apireference.groupdocs.com/net/search/groupdocs.search/index/methods/searchnext/index) methods can be made from different threads to the same instance of the [Index](https://apireference.groupdocs.com/net/search/groupdocs.search/index) class without any cross-threading problems.

## Search during indexing, updating, optimizing, or merging operation

Simultaneous search from different threads is a thread safe operation and can be performed even during indexing, updating, optimizing, and merging operations.

However, indexing, updating, optimizing, and merging operations themselves cannot be performed at the same time. A new start of one of these operations before the completion of the previous operation will result in an error.

Details on performing these operations can be found in the [Indexing]({{< ref "search/net/developer-guide/advanced-usage/indexing/_index.md" >}}) section and on the [Merge indexes]({{< ref "search/net/developer-guide/advanced-usage/indexing/merge-indexes.md" >}}), [Optimize index]({{< ref "search/net/developer-guide/advanced-usage/indexing/optimize-index.md" >}}), and [Update index]({{< ref "search/net/developer-guide/advanced-usage/indexing/update-index.md" >}}) pages.

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
