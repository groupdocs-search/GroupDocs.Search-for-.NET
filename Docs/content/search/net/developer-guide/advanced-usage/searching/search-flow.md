---
id: search-flow
url: search/net/search-flow
title: Search flow
weight: 19
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
The table below shows the internal stages of each search operation. See also [Query language specification]({{< ref "search/net/developer-guide/advanced-usage/searching/query-language-specification.md" >}}), [Search operation table]({{< ref "search/net/developer-guide/advanced-usage/searching/search-operation-table.md" >}}).

| Operation | Search flow |
| --- | --- |
| Simple term search (case insensitive) | Keyboard layout correction  
Spelling correction  
Homophone search  
Synonym search  
Word forms search (since v.18.7)  
Fuzzy search  
Retrieving results |
| Simple term search (case sensitive) | Retrieving results |
| Wildcard search (since v.18.12) | Wildcard search  
Retrieving results |
| Date range search | Retrieving results |
| Numeric range search | Retrieving results |
| Phrase search | Retrieving results for each term of a phrase  
Joining sets of results |
| Regex search | Regex search  
Fuzzy search  
Retrieving results |
| And, Or | Retrieving results for each operand  
Combining sets of results |
| Not | Retrieving results for operand  
Inverting set of results |

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
