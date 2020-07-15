---
id: character-types
url: search/net/character-types
title: Character types
weight: 2
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
This page contains descriptions of all character types. Character types differ in how characters of these types are indexed. For more information on managing the Alphabet, see the [Alphabet]({{< ref "search/net/developer-guide/advanced-usage/managing-dictionaries/alphabet.md" >}}) page in the [Managing dictionaries]({{< ref "search/net/developer-guide/advanced-usage/managing-dictionaries/_index.md" >}}) section.

## Regular characters

Regular characters are separators and letters. During indexing, separators are used to separate words from each other, and words are formed from continuous sequences of letters.

The type of each particular character, can be specified in the Alphabet. By default, the following characters are defined as letters (Unicode numbers are given):

*   Digits: 0030-0039;
*   Latin capital letters: 0041-005A;
*   Low line: 005F;
*   Latin small letters: 0061-007A;
*   Latin letters: 00C0-00D6, 00D8-00F6, 00F8-00FF, 0100-017F, 0180-024F, 0250-02AF;
*   Greek and Coptic letters: 0370-0373, 0376-0377, 037F, 0386, 0388-038A, 038C, 038E-03A1, 03A3-03FC;
*   Cyrillic letters: 0400-0481, 048A-04FF, 0500-052F;
*   Armenian letters: 0531-0556, 0561-0587.

The other characters are defined as separators in the Alphabet.

The following example demonstrates how to specify only numbers, low line character, and English characters as letters in the Alphabet.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentFolder = @"c:\MyDocuments\";
 
// Creating an index in the specified folder
Index index = new Index(indexFolder);
 
// Configuring the alphabet
// Setting the separator type for all characters in the alphabet
index.Dictionaries.Alphabet.Clear();
// Creating a list of letter characters
List<char> list = new List<char>();
for (char i = (char)0x0030; i <= 0x0039; i++)
{
    list.Add(i); // Digits
}
for (char i = (char)0x0041; i <= 0x005A; i++)
{
    list.Add(i); // Latin capital letters
}
list.Add((char)0x005F); // Low line
for (char i = (char)0x0061; i <= 0x007A; i++)
{
    list.Add(i); // Latin small letters
}
// Setting the type of characters in the alphabet
char[] characters = list.ToArray();
index.Dictionaries.Alphabet.SetRange(characters, CharacterType.Letter);
 
// Indexing documents from the specified folder
index.Add(documentFolder);
 
// Searching in the index
SearchResult result = index.Search("Einstein");
```

## Blended characters

Blended characters are special characters that are indexed both as separators and as letters. This type of character can be useful, for example, for indexing hyphens. In this case, parts of a compound word containing a hyphen will be indexed both as a single word with a hyphen and individually without a hyphen. An example of using blended characters is presented below.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentFolder = @"c:\MyDocuments\";
 
// Creating an index in the specified folder
Index index = new Index(indexFolder);
 
// Setting hyphen character type to blended
index.Dictionaries.Alphabet.SetRange(new char[] { '-' }, CharacterType.Blended);
 
// Indexing documents from the specified folder
index.Add(documentFolder);
 
// Searching in the index
SearchResult result1 = index.Search("Elliot-Murray-Kynynmound");
SearchResult result2 = index.Search("Elliot");
SearchResult result3 = index.Search("Murray");
SearchResult result4 = index.Search("Kynynmound");
```

## Indexing each character as a whole word

Another special type of character is character indexed as a separate word. This type of character is designed to work with hieroglyphic languages and allows you to index each character in the text as a separate word, regardless of the presence of separators.

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
