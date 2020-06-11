---
id: groupdocs-search-for-net-17-06-release-notes
url: search/net/groupdocs-search-for-net-17-06-release-notes
title: GroupDocs.Search for .NET 17.06 Release Notes
weight: 7
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 17.6{{< /alert >}}

## Major Features

There are 4 features and enhancements in this regular monthly release. The most notable are:

*   SEARCHNET-1045 Implement optimization of the spelling corrector
*   SEARCHNET-1047 Implement optimization of searching
*   SEARCHNET-968 Integrate Dynabic.Metered to GroupDocs.Search
*   SEARCHNET-1019 Implement dictionary of letters

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-1045 | Implement optimization of the spelling corrector | Enhancement |
| SEARCHNET-1047 | Implement optimization of searching | Enhancement |
| SEARCHNET-968 | Integrate Dynabic.Metered to GroupDocs.Search | New Feature |
| SEARCHNET-1019 | Implement dictionary of letters | New Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Search for .NET 17.6. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Search which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Implement optimization of the spelling corrector

This enhancement implements optimization of the spelling corrector. Performance of the spelling corrector is improved by 10% when correcting 1 mistake, improved by 5 times when correcting 2 mistakes and improved by 30 times when correcting 3 mistakes.

The maximum number of mistakes for correction is increased up to 10.

**Public API Changes**  
None.

#### Implement optimization of searching

This enhancement implements optimization of searching. Simple search performance has been improved by 29%. Fuzzy search performance has been improved by 15-20%.

**Public API Changes**  
None.

#### Integrate Dynabic.Metered to GroupDocs.Search

This enhancement allows using Dynabic.Metered account to run library in licensed mode. It works only with the enabled internet connection.

**Public API Changes**  
Class **Metered** has been added to **GroupDocs.Search** namespace.

This example demonstrates how to use the library in the licensed mode using Dynabic.Metered account:

**C#**

```csharp
const string publicKey = "[Your Dynabic.Metered public key]";
const string privateKey = "[Your Dynabic.Metered private key]";

// initialize Metered API and set-up credentials
new Metered().SetMeteredKey(publicKey, privateKey);

// do indexing and searching in licensed mode 

```

#### Implement dictionary of letters

This feature allows managing list of searchable letters. Letters that are not in the dictionary considered as separators.

Users can change the list of searchable letters before indexing.

Dictionary of letters contains default collection of characters: digits, Latin and Cyrillic.

**Public API Changes**  
Class **Alphabet** has been added to **GroupDocs.Search** namespace.  
Property **GroupDocs.Search.****Alphabet** **Alphabet** has been added to **GroupDocs.Search.DictionaryCollection** class.

This example shows how to manage dictionary of letters:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";
string alphabetFileName = @"c:\MyAlphabet.txt";

Index index = new Index(indexFolder);

// Clearing dictionary of letters
index.Dictionaries.Alphabet.Clear();

// Adding letters
char[] letters = new char[] { '\u0141', '\u0142', '\u0143', '\u0144' };
index.Dictionaries.Alphabet.AddRange(letters);

// Import alphabet from file. Existing letters are staying.
index.Dictionaries.Alphabet.Import(alphabetFileName);
// Export alphabet to file
index.Dictionaries.Alphabet.Export(@"c:\MyExportedAlphabet.txt");

// Indexing
index.AddToIndex(documentsFolder);

```
