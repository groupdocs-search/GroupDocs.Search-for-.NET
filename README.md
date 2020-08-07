# Document Indexing & Search API

[GroupDocs.Search for .NET](https://products.groupdocs.com/search/net) helps build reliable, smart and feature-rich search application for your end-users, supporting all popular document formats. It extracts text and metadata from different files and performs search over all documents. In order to make search process fast and accurate, index is created and documents are added to it. Hence all the search queries or advanced searches are performed over the index.

<p align="center">

  <a title="Download complete GroupDocs.Search for .NET source code" href="https://codeload.github.com/groupdocs-search/GroupDocs.Search-for-.NET/zip/master">
	<img src="https://raw.github.com/AsposeExamples/java-examples-dashboard/master/images/downloadZip-Button-Large.png" />
  </a>
</p>

Directory | Description
--------- | -----------
[Docs](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET/tree/master/Docs)  | Product documentation containing Developer's Guide, Release Notes and more.
[Examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET/tree/master/Examples)  | C# based examples and sample files for quick start. 
[Showcases](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET/tree/master/Showcases/GroupDocs.Search-UI)  | ASP.NET MVC based application demonstrating the core features.

## Document Indexing Features

- [70+ supported file formats](https://docs.groupdocs.com/search/net/supported-document-formats/).
- Create index in memory or on disk.
- Update index to take into account changed, deleted and added documents.
- Merge several indexes into one.
- Optimize index to improve search performance.
- Index password protected documents.
- Index with stop words.
- Option for compact and metadata index.
- Ability to save extracted text in index with different level of compression.
- Document filtering during indexing.
- Deleting indexed paths from index.

## Document Search Features
- Simple word search.
- Boolean search.
- Search based on regular expression.
- Faceted search.
- Case sensitive search.
- Flexible fuzzy search.
- Synonym search.
- Homophone search.
- Wildcard search.
- Phrase search with wildcards.
- Search for different word forms.
- Date range search.
- Numeric range search.
- Search by chunks (pages).

## Develop & Deploy GroupDocs.Search Anywhere

**Microsoft Windows:** Windows Desktop & Server (x86, x64), Windows Azure\
**macOS:** Mac OS X\
**Linux:** Ubuntu, OpenSUSE, CentOS, and others\
**Development Environments:** Microsoft Visual Studio, Xamarin.Android, Xamarin.IOS, Xamarin.Mac, MonoDevelop\
**Supported Frameworks:** .NET Framework 2.0 or higher, .NET Standard 2.0, .NET Core 2.1 & 2.0, Mono Framework 1.2 or higher

## Getting Started with GroupDocs.Search for .NET

Are you ready to give GroupDocs.Search for .NET a try? Simply execute `Install-Package GroupDocs.Search` from Package Manager Console in Visual Studio to fetch & reference GroupDocs.Search assembly in your project. If you already have GroupDocs.Search for .NET and want to upgrade it, please execute `Update-Package GroupDocs.Search` to get the latest version.

## Perform Regular Expression Search

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";

// creating an index in the specified folder
Index index = new Index(indexFolder);

// indexing documents from the specified folder
index.Add(documentsFolder);

// search for the phrase in text form
// the first caret character at the beginning indicates that this is a regular expression search query
string query1 = "^^(.)\\1{1,}";
// search for two or more identical characters at the beginning of a word
SearchResult result1 = index.Search(query1); 

// search for the phrase in object form
// search for two or more identical characters at the beginning of a word
SearchQuery query2 = SearchQuery.CreateRegexQuery("^(.)\\1{1,}");
SearchResult result2 = index.Search(query2);
```

## Spell Check with Smart Search

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";

// creating an index in the specified folder
Index index = new Index(indexFolder);

// indexing documents from the specified folder
index.Add(documentsFolder);

// creating a search options instance
SearchOptions options = new SearchOptions();
// enabling the spelling correction
options.SpellingCorrector.Enabled = true;
// setting the maximum number of mistakes
options.SpellingCorrector.MaxMistakeCount = 1;
// enabling the option for only the best results of the spelling correction
options.SpellingCorrector.OnlyBestResults = true;

// search for the word "Rleativity" containing a spelling error
// the word "Relativity" will be found that differs from the search query in two transposed letters
SearchResult result = index.Search("Rleativity", options);
```

[Home](https://www.groupdocs.com/) | [Product Page](https://products.groupdocs.com/search/net) | [Documentation](https://docs.groupdocs.com/search/net/) | [Demo](https://products.groupdocs.app/search/family) | [API Reference](https://apireference.groupdocs.com/search/net) | [Examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET) | [Blog](https://blog.groupdocs.com/category/search/) | [Free Support](https://forum.groupdocs.com/c/search) | [Temporary License](https://purchase.groupdocs.com/temporary-license)
