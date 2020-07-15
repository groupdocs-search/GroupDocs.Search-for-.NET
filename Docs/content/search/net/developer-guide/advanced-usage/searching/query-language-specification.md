---
id: query-language-specification
url: search/net/query-language-specification
title: Query language specification
weight: 16
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
The text below represents the complete specification of the search query DSL (Domain Specific Language) used in text queries. See also [Search operation table]({{< ref "search/net/developer-guide/advanced-usage/searching/search-operation-table.md" >}}), [Search flow]({{< ref "search/net/developer-guide/advanced-usage/searching/search-flow.md" >}}).

*query*:

*   *regex-query*
*   *non-regex-query*

*regex-query*:

*   ^*pattern*

*non-regex-query*:

*   *unary-query*
*   *binary-query*

*unary-query*:

*   *word*
*   *word-pattern* (since v.18.12)
*   *phrase-query*
*   *field-name-query*
*   *numeric-range-query*
*   *date-range-query*
*   *parenthesized-query*
*   *not-query*

*phrase-query*:

*   *phrase-item-list*

*phrase-item-list*:

*   *phrase-item phrase-item*
*   *phrase-item-list phrase-item*

*phrase-item*:

*   *word*
*   *word-pattern* (since v.18.12)
*   *wildcard* (since v.18.1)

*word*:

*   any word without special characters

*word-pattern* (since v.18.12)

*   any non-special characters
*   ? (question marks)
*   ?(n~m) (Wildcard groups, where n is *byte-number*, m is *byte-number*, and n <= m. For example: ?(1~2) )

*wildcard*: (since v.18.1)

*   \* *byte-number*
*   \* *byte-number* ~~ *byte-number*

*byte-number*: (since v.18.1)

*   Any integer number in the range from 0 to 255

*field-name-query*:

*   *field-name*: *unary-query*

*numeric-range-query*:

*   *number* ~~ *number*

*number*:

*   Any non-negative integer number

*date-range-query*:

*   daterange( *date* ~~ *date* )

*date*:

*   A date in the format 'yyyy-MM-dd'. For example: 2019-09-16

*parenthesized-query*:

*   ( *non-regex-query* )

*not-query*:

*   ! *unary-query*
*   NOT *unary-query*

*binary-query*:

*   *and-query*
*   *or-query*

*and-query*:

*   *non-regex-query* & *unary-query*
*   *non-regex-query* AND *unary-query*

*or-query*:

*   *non-regex-query* | *unary-query*
*   *non-regex-query* || *unary-query*
*   *non-regex-query* OR *unary-query*

*escape-sequence:* (since v.19.2)

*   \\*N  
    *where *N* is one of  
    *( ) : " & | ! ^ ~ \* ? \\*  
    or  
    *s* (for space character)
*   \\u*hhhh*  
    where *h* is hexadecimal digit (for any Unicode character)

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
