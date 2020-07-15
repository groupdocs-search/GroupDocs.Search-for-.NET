---
id: character-replacement-during-indexing
url: search/net/character-replacement-during-indexing
title: Character replacement during Indexing
weight: 1
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
Character replacement during indexing can be used, for example, to convert all text to lowercase characters or to remove diacritics from text. Such replacements can reduce the size of an index on disk if the case of characters or diacritics are not significant. See also [Character replacements]({{< ref "search/net/developer-guide/advanced-usage/managing-dictionaries/character-replacements.md" >}}) page in the [Managing dictionaries]({{< ref "search/net/developer-guide/advanced-usage/managing-dictionaries/_index.md" >}}) section.

The example below demonstrates how to configure and use character replacements during indexing.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentFolder = @"c:\MyDocuments\";
 
// Enabling character replacements in the index settings
IndexSettings settings = new IndexSettings();
settings.UseCharacterReplacements = true;
 
// Creating an index in the specified folder
Index index = new Index(indexFolder, settings);
 
// Configuring character replacements
// Deleting all existing character replacements from the dictionary
index.Dictionaries.CharacterReplacements.Clear();
// Creating new character replacements
CharacterReplacementPair[] characterReplacements = new CharacterReplacementPair[Char.MaxValue + 1];
for (int i = 0; i < characterReplacements.Length; i++)
{
    char character = (char)i;
    char replacement = Char.ToLower(character);
    characterReplacements[i] = new CharacterReplacementPair(character, replacement);
}
// Adding character replacements to the dictionary
index.Dictionaries.CharacterReplacements.AddRange(characterReplacements);
 
// Indexing documents from the specified folder
index.Add(documentFolder);
 
// Searching in the index
// Case-sensitive search is no longer possible for this index, since all characters are lowercase
// By default, case-insensitive search is performed
SearchResult result = index.Search("Einstein");
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
