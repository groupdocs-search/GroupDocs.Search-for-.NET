---
id: index-lifecycle
url: search/net/index-lifecycle
title: Index lifecycle
weight: 4
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
The life cycle of an index begins at the moment of creating an instance of the Index class and first saving the index files to disk. The index life cycle ends when a folder containing index files is deleted. Below is a diagram of the recommended sequence of index life cycle states.

Please note that the index life cycle does not consider the events of loading and unloading the index from RAM. At each stage of existence, the index can be loaded and unloaded from memory several times.

![](search/net/images/index-lifecycle.png)

After creation a new index, it is in the Empty state.

When adding documents (method [Add](https://apireference.groupdocs.com/net/search/groupdocs.search/index/methods/add/index)) to the index and completing the indexing operation, the index is in the Actual state, the index is ready to process search queries.

To accelerate the processing of search queries, the index can be optimized by calling the [Optimize](https://apireference.groupdocs.com/net/search/groupdocs.search/index/methods/optimize/index) method. Upon completion of the optimization operation, the index goes into the Optimized state. In this state, the index contains the minimum required number of segments on the disk and therefore works faster.

Changing, adding, deleting documents from indexed folders puts the index in the Outdated state. In this state, search results may not be relevant.

Calling the [Update](https://apireference.groupdocs.com/net/search/groupdocs.search/index/methods/update/index) method starts reindexing of changed, new and deleted documents. Upon completion of the update operation, the index reverts to the Actual state.

Here we can give a recommendation to update the index at times of minimal search activity, for example, at night, to give more processor time to search queries handling. But this is not necessary, because the search can be performed simultaneously with the indexing or updating operation. Moreover, updating can work without pauses and start immediately after the previous one is completed.

Regarding the addition of documents to an index, it is important to know that at any stage of the existence of an index, new documents can be added (method [Add](https://apireference.groupdocs.com/net/search/groupdocs.search/index/methods/add/index)) to it to expand the search base.

## More resources

### Advanced usage topics

To learn more about search features and get familiar how to enhance your search solution, please refer to the [advanced usage section]({{< ref "search/net/developer-guide/advanced-usage/_index.md" >}}).

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
