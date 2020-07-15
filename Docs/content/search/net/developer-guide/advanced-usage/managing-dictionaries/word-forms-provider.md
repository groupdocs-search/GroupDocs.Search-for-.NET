---
id: word-forms-provider
url: search/net/word-forms-provider
title: Word forms provider
weight: 9
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
The [IWordFormsProvider](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/iwordformsprovider) interface is designed to implement a word forms provider for searching by word forms. For information on searching by word forms, see [Search for different word forms]({{< ref "search/net/developer-guide/advanced-usage/searching/search-for-different-word-forms.md" >}}) page.

The [IWordFormsProvider](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/iwordformsprovider) interface contains only one [GetWordForms](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/iwordformsprovider/methods/getwordforms) method, which returns various forms for the word passed as an argument. An example implementation of a simple provider of word forms is presented below.

**C#**

```csharp
public class SimpleWordFormsProvider : IWordFormsProvider
{
    public string[] GetWordForms(string word)
    {
        List<string> result = new List<string>();
 
        // We assume that the input word is in the plural, then we add the singular
        if (word.Length > 2 &&
            word.EndsWith("es", StringComparison.InvariantCultureIgnoreCase))
        {
            result.Add(word.Substring(0, word.Length - 2));
        }
        if (word.Length > 1 &&
            word.EndsWith("s", StringComparison.InvariantCultureIgnoreCase))
        {
            result.Add(word.Substring(0, word.Length - 1));
        }
 
        // Then we assume that the input word is in the singular, we add the plural
        if (word.Length > 1 &&
            word.EndsWith("e", StringComparison.InvariantCultureIgnoreCase))
        {
            result.Add(word + "s");
        }
        if (word.Length > 1 &&
            word.EndsWith("y", StringComparison.InvariantCultureIgnoreCase))
        {
            result.Add(word.Substring(0, word.Length - 1) + "is");
        }
        result.Add(word + "es");
        // All rules are implemented in the EnglishWordFormsProvider class
 
        return result.ToArray();
    }
}
```

By default, the **[EnglishWordFormsProvider](https://apireference.groupdocs.com/net/search/groupdocs.search.dictionaries/englishwordformsprovider)** class is used, which for English generates various forms of nouns, adjectives, pronouns, verbs, etc. An example of setting a custom provider of word forms is presented below.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";
 
// Creating an index in the specified folder
Index index = new Index(indexFolder);
 
// Indexing documents from the specified folder
index.Add(documentsFolder);
 
// Setting the custom word forms provider instance
index.Dictionaries.WordFormsProvider = new SimpleWordFormsProvider();
 
// Creating a search options instance
SearchOptions options = new SearchOptions();
options.UseWordFormsSearch = true; // Enabling search for word forms
 
// Searching in the index
SearchResult result = index.Search("relative", options);
 
// The following words can be found:
// relative
// relatives
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
