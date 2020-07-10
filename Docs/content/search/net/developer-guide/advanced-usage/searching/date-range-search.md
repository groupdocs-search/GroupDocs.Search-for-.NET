---
id: date-range-search
url: search/net/date-range-search
title: Date range search
weight: 3
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
This page describes how you can search by date with date range search. As well it describes the creation of date wise search queries, and also describes the management of formats for date range search.

## Creating date range search queries

Date range search allows you to search in documents dates from a given range in given date formats.

Queries for date range search in text form are specified in the following format:

*   daterange( date ~~ date )

where date is the date in yyyy-MM-dd format, for example, 2019-09-13. Please note that in a search query, dates are always set in the same format.

The following example demonstrates how to search by date using queries in text and object form.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";
 
// Creating an index in the specified folder
Index index = new Index(indexFolder);
 
// Indexing documents from the specified folder
index.Add(documentsFolder);
 
// Search for dates using query in text form
string query1 = "daterange(2017-01-01 ~~ 2019-12-31)";
SearchResult result1 = index.Search(query1);
 
// Search for dates using query in text form
SearchQuery query2 = SearchQuery.CreateDateRangeQuery(new DateTime(2017, 1, 1), new DateTime(2019, 12, 31));
SearchResult result2 = index.Search(query2);
```

## Specifying date range search formats

To perform the date range search, the date templates specified in the search options are used. The following formats are used by default:

*   dd.MM.yyyy
*   MM/dd/yyyy
*   yyyy-MM-dd

Formats for date range search are set in the [DateFormats](https://apireference.groupdocs.com/net/search/groupdocs.search.options/searchoptions/properties/dateformats) property of the [SearchOptions](https://apireference.groupdocs.com/net/search/groupdocs.search.options/searchoptions) class. To add a format, use the [Add](https://apireference.groupdocs.com/net/search/groupdocs.search.options/dateformatcollection/methods/add) method, to remove it, use the [Remove](https://apireference.groupdocs.com/net/search/groupdocs.search.options/dateformatcollection/methods/remove) method, to clear a collection of existing formats, use the [Clear](https://apireference.groupdocs.com/net/search/groupdocs.search.options/dateformatcollection/methods/clear) method. Each format in the collection is defined by an instance of the [DateFormat](https://apireference.groupdocs.com/net/search/groupdocs.search.options/dateformat) class. To create a new format, you must specify a sequence of format elements and a separator character. All available format elements are represented in the [DateFormatElement](https://apireference.groupdocs.com/net/search/groupdocs.search.options/dateformatelement) class:

*   [DayOfMonth](https://apireference.groupdocs.com/net/search/groupdocs.search.options/dateformatelement/properties/dayofmonth) specifies the day of month element, represented by one or two digits;
*   [DayOfMonthTwoDigits](https://apireference.groupdocs.com/net/search/groupdocs.search.options/dateformatelement/properties/dayofmonthtwodigits) specifies the day of month element, represented by two digits;
*   [Month](https://apireference.groupdocs.com/net/search/groupdocs.search.options/dateformatelement/properties/month) specifies the month element, represented by one or two digits;
*   [MonthTwoDigits](https://apireference.groupdocs.com/net/search/groupdocs.search.options/dateformatelement/properties/monthtwodigits) specifies the month element, represented by two digits;
*   [MonthAbbreviatedName](https://apireference.groupdocs.com/net/search/groupdocs.search.options/dateformatelement/properties/monthabbreviatedname) specifies the month element, represented by abbreviated name;
*   [MonthFullName](https://apireference.groupdocs.com/net/search/groupdocs.search.options/dateformatelement/properties/monthfullname) specifies the month element, represented by full name;
*   [Year](https://apireference.groupdocs.com/net/search/groupdocs.search.options/dateformatelement/properties/year) specifies the year element, represented by one, two, three, or four digits;
*   [YearTwoDigits](https://apireference.groupdocs.com/net/search/groupdocs.search.options/dateformatelement/properties/yeartwodigits) specifies the year element, represented by two digits;
*   [YearFourDigits](https://apireference.groupdocs.com/net/search/groupdocs.search.options/dateformatelement/properties/yearfourdigits) specifies the year element, represented by four digits;
*   [DateSeparator](https://apireference.groupdocs.com/net/search/groupdocs.search.options/dateformatelement/properties/dateseparator) specifies the date separator element.

An example of setting the date format for the search is presented below.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";
 
// Creating an index in the specified folder
Index index = new Index(indexFolder);
 
// Indexing documents from the specified folder
index.Add(documentsFolder);
 
// Setting date formats
SearchOptions options = new SearchOptions();
options.DateFormats.Clear(); // Removing default date formats
DateFormatElement[] elements = new DateFormatElement[]
{
    DateFormatElement.MonthTwoDigits,
    DateFormatElement.DateSeparator,
    DateFormatElement.DayOfMonthTwoDigits,
    DateFormatElement.DateSeparator,
    DateFormatElement.YearFourDigits,
};
// Creating a date format pattern 'MM/dd/yyyy'
DateFormat dateFormat = new DateFormat(elements, "/");
options.DateFormats.Add(dateFormat);
 
// Searching in the index.
// For the given query, for example, the date 09/27/2019 will be found,
// but the date 2019-09-27 will not be found, because it is presented in a format that is not specified in the search options.
SearchResult result = index.Search("daterange(2017-01-01 ~~ 2019-12-31)", options);
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
