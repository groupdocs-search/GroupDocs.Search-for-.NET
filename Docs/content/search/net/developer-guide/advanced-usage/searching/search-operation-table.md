---
id: search-operation-table
url: search/net/search-operation-table
title: Search operation table
weight: 21
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
The table below provides syntax of all elements allowed in text search queries. See also [Query language specification]({{< ref "search/net/developer-guide/advanced-usage/searching/query-language-specification.md" >}}), [Search flow]({{< ref "search/net/developer-guide/advanced-usage/searching/search-flow.md" >}}).

| Element | Syntax | Description | Examples |
| --- | --- | --- | --- |
| Parentheses | ( *inner-query* ) | Parentheses are used to specify order of operations. | 
*   term1 I (term2 & term3)
*   ("total expenses" | "total costs") & (82000 ~~ 83000 | 92000 ~~ 93000)

 |
| Field specifier | *field-name* : *inner-query* | Field specifier is used to specify field name. | 

*   content : term
*   creationdate : (2010 ~~ 2013)
*   filename : report & creationdate : 2009

 |
| Exact phrase query specifier | " *exact-phrase-query* " | Exact phrase query specifier is used to specify phrase for phrase search. | 

*   "term1 term2 term3"
*   "computational complexity theory"
*   "formal language" AND harrison

 |
| And operation | *left-query* & *right-query*  
*left-query* AND *right-query* | And operation is used to find documents which contain both left query and right query. | 

*   term1 & term2
*   term1 AND term2
*   computational & complexity

 |
| Or operation | *left-query* | *right-query*  
*left-query* || *right-query*  
*left-query* OR *right-query* | Or operation is used to find documents which contain left query, or right query, or both. | 

*   term1 | term2
*   term1 || term2
*   term1 OR term2
*   "cumulative distribution function" OR "cumulative density function"

 |
| Not operation | ! *inner-query*  
NOT *inner-query* | Not operation is used to find all documents which do not contain inner query. | 

*   ! term
*   NOT term
*   author : (Cardano AND NOT Gerolamo)

 |
| Macro name specifier | @*macro-name* | Macro name specifier is used to specify name of macro within search query that will be replaced with the body of the macro before parsing the query. | 

*   @query\_macro
*   @macro1 & @macro2

 |
| Regular expression specifier | ^*regular-expression* | Regular expression specifier is used to specify query that is regular expression. | 

*   ^^\[0-9\]{1,5}$

 |
| Numeric range specifier | *start-number* ~~ *end-number* | Numeric range specifier is used to specify range for numeric range search. | 

*   13 ~~ 42
*   10000000000 ~~ 100000000000

 |
| Date range specifier | daterange( *start-date* ~~ *end-date*)  
where *start-date* and *end-date* are dates in the format 'yyyy-MM-dd'. | Date range specifier is used to specify range for date range search. | 

*   daterange(2017-09-28 ~~ 2017-11-11)

 |
| Wildcard (since v.18.12) | ? - wildcard character,  
?(*N*~*M*) - wildcard character range,  
\**N* - wildcard word,  
\**N*~~*M* - wildcard word range,  
where *N* and *M* are in the range from 0 to 255. | Wildcard characters and wildcard words allow to perform wildcard search. | 

*   ?ffect - for 'affect', 'effect'
*   princip?(2~4) - for 'principal', 'principle', 'principles', 'principally'
*   ?(0~2)sure - for 'assure', 'ensure', 'sure'
*   "\\"First law \*1 thermodynamics\\"" - for 'First law of thermodynamics'
*   "\\"Frodo \*1~~5 Pippin\\"" - for 'Frodo spoke to Pippin', 'Frodo stripped the blankets from Pippin'

 |
| Escape sequence (since v.19.2) | \\*N*  
where *N* can be one of  
( ) : " & | ! ^ ~ \* ? \\  
\- or -  
s (for space character)  
\- or -  
u*hhhh*where *h* is hexadecimal digit (for any Unicode character) | Escape sequence allows to use special character in a query as it is. Note that escaped character must be added to Alphabet to be indexed as a valid character (not as a separator). | 

*   \\& - escaping & character
*   \\~ - escaping ~ character
*   \\s - escaping space character
*   \\u0026 - escaping & character (Unicode code)
*   R\\&B - searching for 'R&B' as a whole word (& character must be added to Alphabet before indexing)

 |

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
