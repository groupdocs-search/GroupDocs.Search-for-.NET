---
id: nesting-search-queries-in-object-form
url: search/net/nesting-search-queries-in-object-form
title: Nesting search queries in object form
weight: 11
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
The table below shows all combinations of nesting search queries in object form with an indication of their possibility (+) or impossibility (–).

| Nested query type | Parent query type |
| --- | --- |
| Field | PhraseSearch | Not | Or | And |
| Word | + | + | + | + | + |
| WordPattern | + | + | + | + | + |
| NumericRange | + | + | + | + | + |
| Regex | + | + | + | + | + |
| Field | + | – | + | + | + |
| DateRange | + | + | + | + | + |
| PhraseSearch | + | + | + | + | + |
| Not | + | – | + | + | + |
| Or | + | – | + | + | + |
| And | + | – | + | + | + |
| Wildcard | – | + | – | – | – |

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
