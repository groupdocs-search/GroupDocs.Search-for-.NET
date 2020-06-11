---
id: groupdocs-search-for-net-16-12-release-notes
url: search/net/groupdocs-search-for-net-16-12-release-notes
title: GroupDocs.Search for .NET 16.12 Release Notes
weight: 1
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 16.12{{< /alert >}}

## Major Features

There are 3 features in this regular monthly release. The most notable are:

1.  Implement support of password protected documents
2.  Implement Managing Stop Words functionality
3.  Implement Managing Synonyms functionality

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-423 | Implement support of password protected documents | New Feature |
| SEARCHNET-443 | Implement Managing Stop Words functionality | New Feature |
| SEARCHNET-589 | Implement Managing Synonyms functionality | New Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Search for .NET 16.12.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Search which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Implement Support of Password Protected Documents

This feature allows the user to add password protected documents to index.

Class PasswordRequiredArg has been added to GroupDocs.Search.Events namespace.  
Class PasswordDictionary has been added to GroupDocs.Search namespace.  
Event PasswordRequired has been added to GroupDocs.Search.Index class.  
Event PasswordRequired has been added to GroupDocs.Search.IndexRepository class.  
Property PasswordDictionary DocumentPasswords has been added to GroupDocs.Search.DictionaryCollection class.

This example shows how to use event to set password for protected document using event argument:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";
string searchQuery = "Search Query";

Index index = new Index(indexFolder);
index.PasswordRequired += index_PasswordRequired;
 // User can subscribe to PasswordRequired event to be able to specify a password
index.AddToIndex(documentsFolder);

...
        // This event will appear for every password protected document
        void index_PasswordRequired(object sender, PasswordRequiredArg e)
        {
            if (e.DocumentFullName == @"c:\MyDocuments\ProtectedDocument.doc")
            {
                e.Password = "Password";  // User can put password to Password field of event argument
            }
        }


```

This example shows how to use event to set password for protected document using event argument:

**C#**

```csharp
This example shows how to set password for protected document using Index.Dictionaries.DocumentPasswords property:

string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";
string searchQuery = "Search Query";

Index index = new Index(indexFolder);
index.Dictionaries.DocumentPasswords.Add(@"c:\MyDocuments\ProtectedDocument.doc", "Password"); // User can set passwords for some documents in this property
index.AddToIndex(documentsFolder);

```

This example shows how to set password for protected document using both methods, PasswordRequired event and Index.Dictionaries.DocumentPasswords property:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";
string searchQuery = "Search Query";

Index index = new Index(indexFolder);
index.PasswordRequired += index_PasswordRequired; // User can subscribe to PasswordRequired event to be able to specify a password
index.Dictionaries.DocumentPasswords.Add(@"c:\MyDocuments\ProtectedDocument1.doc", "Password1"); // User can set passwords for some documents in this property
index.Dictionaries.DocumentPasswords.Add(@"c:\MyDocuments\ProtectedDocument2.doc", "Password2"); // User can set passwords for some documents in this property
index.Dictionaries.DocumentPasswords.Add(@"c:\MyDocuments\ProtectedDocument3.doc", "Password3"); // User can set passwords for some documents in this property
index.AddToIndex(documentsFolder);

...
        // This event will appear for every password protected document
        void index_PasswordRequired(object sender, PasswordRequiredArg e)
        {
            if (e.DocumentFullName == @"c:\MyDocuments\ProtectedDocument4.doc")
            {
                e.Password = "Password4";  // User should put password to Password field of event argument
            }
            else if (e.DocumentFullName == @"c:\MyDocuments\ProtectedDocument5.doc")
            {
                e.Password = "Password5";  // User should put password to Password field of event argument
            }
            else if (e.DocumentFullName == @"c:\MyDocuments\ProtectedDocument6.doc")
            {
                e.Password = "Password6";  // User should put password to Password field of event argument
            }
        }

```

#### Implement Managing Stop Words functionality

This feature allows to manage the list of stop words.  
Stop words are words which are filtered and are not indexed. For example words: a, an, the, for, in, is, it, was, were and so on.  
Users can change list of stop words before indexing. Also user can disable using stop words, but this can increase time of indexing.  
All indexes contain default Stop Word dictionary with the most common stop words.  
Using Stop Words is enabled by default.

This example shows how to disable using Stop Words:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

Index index = new Index(indexFolder);

index.IndexingSettings.UseStopWords = false; // This line disables using stop words and all of the words in documents will be indexed

index.AddToIndex(documentsFolder);

```

This example shows how to manage Stop Word dictionary:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

Index index = new Index(indexFolder);

int stopWordsCount = index.Dictionaries.StopWordDictionary.Count; //  Get count of stop words
index.Dictionaries.StopWordDictionary.Clear(); // Clear dictionary of stop words
index.Dictionaries.StopWordDictionary.AddRange(new List<string>() { "one", "Two", "three" }); // Add several stop words to dictionary. Words are case insensitive.
index.Dictionaries.StopWordDictionary.RemoveRange(new List<string>() { "one", "three" }); //  Remove stop words from dictionary. Words which are absent will be ignored.

index.AddToIndex(documentsFolder);

bool isTwoPresent = index.Dictionaries.StopWordDictionary.Contains("two");

index.Dictionaries.StopWordDictionary.Import(@"c:\MyStopWords.txt"); // Import stop words from file. Existing stop words are staying.
index.Dictionaries.StopWordDictionary.Export(@"c:\MyExportedStopWords.txt"); // Export stop words to file


```

#### Implement Managing Synonyms functionality

This feature allows to manage list of synonyms.  
Users can change list of synonyms before searching.

This example shows how to manage Synonym dictionary:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";
string searchQuery = "Search Query";
string synonymsFileName = @"c:\MySynonyms.txt";

Index index = new Index(indexFolder);
index.AddToIndex(documentsFolder);

// Clearing synonym dictionary
index.Dictionaries.SynonymDictionary.Clear();

// Adding synonyms
string[] synonymGroup1 = new string[]{"big", "huge", "colossal", "massive" };
string[] synonymGroup2 = new string[]{"fast", "agile", "quick", "rapid", "swift" };
List<string[]> synonymGroups = new List<string[]>();
synonymGroups.Add(synonymGroup1);
synonymGroups.Add(synonymGroup2);
index.Dictionaries.SynonymDictionary.AddRange(synonymGroups);

index.Dictionaries.SynonymDictionary.Import(synonymsFileName); // Import synonyms from file. Existing synonyms are staying.
index.Dictionaries.SynonymDictionary.Export(@"c:\MyExportedSynonyms.txt"); // Export synonyms to file

SearchParameters parameters = new SearchParameters();
parameters.UseSynonymSearch = true; // Turning on synonym search

SearchResults results = index.Search(searchQuery , parameters); // Enable synonym search in parameters

```
