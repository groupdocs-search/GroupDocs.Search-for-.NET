---
id: groupdocs-search-for-net-19-10-release-notes
url: search/net/groupdocs-search-for-net-19-10-release-notes
title: GroupDocs.Search for .NET 19.10 Release Notes
weight: 2
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 19.10{{< /alert >}}

## Major Features

{{< alert style="danger" >}}In this version, we are introducing a new public API that has been designed to be intuitive and easy to use. For more information on the new API, please check the Public Docs section. The deprecated API was moved to the Legacy namespace, so after upgrading to this version, you need to replace the use of the namespace across the entire project from GroupDocs.Search.* to GroupDocs.Search.Legacy.* to resolve build issues.{{< /alert >}}

Other notable features and improvements:

*   Implement highlighting search results in short fragments
*   Enhance document metadata indexing with new formats
*   Implement indexing each letter as a separate word
*   Implement ability to remove paths from index

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-1967 | Implement highlighting search results in short fragments | Improvement |
| SEARCHNET-1970 | Enhance document metadata indexing with new formats | Improvement |
| SEARCHNET-2110 | Implement new public API | Improvement |
| SEARCHNET-2035 | Implement indexing each letter as a separate word | New Feature |
| SEARCHNET-2108 | Implement ability to remove paths from index | New Feature |

## Public API and Backward Incompatible Changes

### Implement highlighting search results in short fragments

This improvement allows highlighting the search results in separate short fragments of the text, and not in the whole document. A detailed description of the feature is presented in the documentation on the [Highlighting search results]({{< ref "search/net/developer-guide/advanced-usage/searching/highlighting-search-results.md" >}}) page.

##### Usecases

This example shows how to generate short HTML snippets with highlighted found terms:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";
 
// Creating index
Index index = new Index(indexFolder);
 
// Adding documents to index
index.Add(documentFolder);
 
// Searching
SearchResult result = index.Search("hobbit");
 
// Highlighting found terms in short HTML snippets
if (result.DocumentCount > 0)
{
    FoundDocument document = result.GetFoundDocument(0);
    HtmlFragmentHighlighter highlighter = new HtmlFragmentHighlighter();
    index.Highlight(document, highlighter);
 
    // Getting the result
    FragmentContainer[] fragmentContainers = highlighter.GetResult();
    for (int i = 0; i < fragmentContainers.Length; i++)
    {
        FragmentContainer container = fragmentContainers[i];
        string[] fragments = container.GetFragments();
        if (fragments.Length > 0)
        {
            Console.WriteLine(container.FieldName);
            Console.WriteLine();
            for (int j = 0; j < fragments.Length; j++)
            {
                // Printing HTML markup to console
                Console.WriteLine(fragments[j]);
                Console.WriteLine();
            }
        }
    }
} 
```

### Enhance document metadata indexing with new formats

This improvement adds support for new document formats. These are mostly documents, the main content of which is not textual, therefore only the metadata of these documents is indexed:

*   MP3 – MPEG-2 Audio Layer III;
*   WAV – Waveform Audio File Format;
*   BMP – Bitmap Picture;
*   GIF – Graphical Interchange Format File;
*   JP2 – JPEG 2000 Core Image File;
*   PNG – Portable Network Graphics;
*   WEBP – WebP Image Format File;
*   TIFF – Tagged Image File Format;
*   EMF – Enhanced Windows Metafile;
*   WMF – Windows Metafile;
*   JPG – JPEG Image;
*   PSD – Adobe Photoshop Document;
*   DJVU – DjVu Image;
*   MPP – Microsoft Project File;
*   TORRENT – BitTorrent File;
*   VSD – Visio Drawing File;
*   VSS – Visio Stencil File;
*   DCM – DICOM Image;
*   AVI – Audio Video Interleave File;
*   MOV – Apple QuickTime Movie;
*   QT – Apple QuickTime Movie;
*   FLV – Animate Video File;
*   ASF – Advanced Systems Format File.

A complete list of supported formats is provided on the [Supported Document Formats]({{< ref "search/net/getting-started/supported-document-formats.md" >}}) page.

### Implement new public API

Implemented a new convenient intuitive public API. Full documentation for the new API is presented [here]({{< ref "search/net/_index.md" >}}).

All public types from the legacy GroupDocs.Search namespace have been moved to the GroupDocs.Search.Legacy namespace and marked obsolete with the message: "This interface / class / enumeration is deprecated and will be available until January 2020 (version 20.1)."

### Implement indexing each letter as a separate word

This feature is designed to work with hieroglyphic languages and allows you to index each character in the text as a separate word, regardless of the presence of separators.

##### Usecases

The example shows how to perform indexing and search for Chinese characters:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";
 
// Creating index
Index index = new Index(indexFolder);
 
// Setting blended character type for Chinese characters
HashSet<char> hashSet = new HashSet<char>();
for (char character = (char)0x4E00; character <= 0x9FFF; character++) // Common
{
    hashSet.Add(character);
}
for (char character = (char)0x3400; character <= 0x4DBF; character++) // Rare
{
    hashSet.Add(character);
}
char[] characters = new char[hashSet.Count];
hashSet.CopyTo(characters);
index.Dictionaries.Alphabet.SetRange(characters, CharacterType.SeparateWord); // Setting character type
 
// Adding documents to index
index.Add(documentFolder);
 
// Searching for the Unicode character U+4E50
SearchResult result = index.Search("\u4E50");
```

### Implement ability to remove paths from index

This feature allows you to remove from an index paths added for indexing. When indexed paths are removed from an index, the index is updated and all removed documents and folders become inaccessible for search. Detailed information about this feature is presented on the [Delete indexed paths]({{< ref "search/net/developer-guide/advanced-usage/indexing/delete-indexed-paths.md" >}}) page.

##### Usecases

The example shows how to remove indexed paths from an index:

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder1 = @"c:\MyDocuments\";
string documentsFolder2 = @"c:\MyDocuments2\";
 
// Creating an index in the specified folder
Index index = new Index(indexFolder);
 
// Indexing documents from the specified folders
index.Add(documentsFolder1);
index.Add(documentsFolder2);
 
// Getting indexed paths from the index
string[] indexedPaths1 = index.GetIndexedPaths();
 
// Writing indexed paths to the console
Console.WriteLine("Indexed paths:");
foreach (string path in indexedPaths1)
{
    Console.WriteLine("\t" + path);
}
 
// Deleting index path from the index
DeleteResult deleteResult = index.Delete(new string[] { documentsFolder1 }, new UpdateOptions());
 
// Getting indexed paths after deletion
string[] indexedPaths2 = index.GetIndexedPaths();
Console.WriteLine("\nDeleted paths: " + deleteResult.SuccessCount);
 
Console.WriteLine("\nIndexed paths:");
foreach (string path in indexedPaths2)
{
    Console.WriteLine("\t" + path);
}
```
