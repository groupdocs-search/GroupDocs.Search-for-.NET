---
id: groupdocs-search-for-net-18-7-release-notes
url: search/net/groupdocs-search-for-net-18-7-release-notes
title: GroupDocs.Search for .NET 18.7 Release Notes
weight: 4
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 18.7.{{< /alert >}}

## Major Features

There are 4 enhancements in this regular monthly release. The most notable are:

*   Implement using morphological word forms dictionary in search
*   Implement possibility to break updating operation manually
*   Implement possibility to break merging operation manually
*   Implement possibility to break indexing with Cancelation object

## All Changes

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-236 | Implement using morphological word forms dictionary in search | Enhancement |
| SEARCHNET-1301 | Implement possibility to break updating operation manually | Enhancement |
| SEARCHNET-1302 | Implement possibility to break merging operation manually | Enhancement |
| SEARCHNET-1616 | Implement possibility to break indexing with Cancelation object | Enhancement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Search for .NET 18.7. It includes not only new and obsoleted public methods, but also a description of any changes in the behaviour behind the scenes in GroupDocs.Search which may affect existing code. Any behaviour introduced that could be seen as a regression and modifies existing behaviour is especially important and is documented here.{{< /alert >}}

### Implement using morphological word forms dictionary in search

##### Description

This enhancement allows a user to search for different word forms.  
For example, a user can search for singular and plural forms of a noun at the same time.  
Or the user can search for all existing forms of a verb at the same time: root, third-person singular, present participle, simple past, and past participle.  
In addition, the user can implement custom word forms provider to use in a language other than English.  
To do so the user needs to write the class that implements **IWordFormsProvider** interface and assign property **DictionaryCollection.WordFormsProvider** with an instance of that class.  
Note that the default value of **DictionaryCollection.WordFormsProvider** property is an instance of class **EnglishWordFormsProvider**.  
The **EnglishWordFormsProvider** class provides word forms search functionality for the English language.

##### Public API changes

Property **bool UseWordFormsSearch** has been added to **GroupDocs.Search.SearchParameters** class.

Interface **IWordFormsProvider** has been added to **GroupDocs.Search** namespace.  
Method **GetWordForms(String)** nas been added to **GroupDocs.Search.IWordFormsProvider** interface.

Class **EnglishWordFormsProvider** has been added to **GroupDocs.Search** namespace.  
Constructor **EnglishWordFormsProvider()** nas been added to **GroupDocs.Search.EnglishWordFormsProvider** class.  
Method **GetWordForms(String)** nas been added to **GroupDocs.Search.EnglishWordFormsProvider** class.

Property **IWordFormsProvider WordFormsProvider** has been added to **GroupDocs.Search.DictionaryCollection** class.

##### Usecases

The following code snippet shows how to perform the search for different word forms.

**C#**

```csharp
string folderForIndex = "c:\\MyIndex\\";
string folderWithDocuments = "c:\\MyDocuments\\";

Index index = new Index(folderForIndex); // Creating index in c:\MyIndex\ folder
index.AddToIndex(folderWithDocuments); // Indexing folder with documents

SearchParameters parameters = new SearchParameters();
parameters.UseWordFormsSearch = true; // Enabling word forms search

SearchResults results1 = index.Search("simplest", parameters); // Searching for words "simplest", "simple", and "simpler"
SearchResults results2 = index.Search("swimming", parameters); // Searching for words "swim", "swims", "swimming", "swam", "swum"
```

  

### Implement possibility to break updating operation manually

##### Description

This enhancement is implemented for the possibility of cancelling the updating operation by request and for time limitation of indexing. The break is not instantaneous and in cases of indexing large documents during updating, the breaking can take about a second.

##### Public API changes

Method **void Update(Cancellation)** has been added to **GroupDocs.Search.Index** class.  
Method **void UpdateAsync(Cancellation)** has been added to **GroupDocs.Search.Index** class.

##### Usecases

The following code snippet shows how to break the updating operation.

**C#**

```csharp
string indexFolder = @"c:\MyIndex";

// Load index
Index index = new Index(indexFolder);

// Updating index
index.UpdateAsync();

// Breaking updating
index.Break();
```

This example shows how to break updating with Cancellation object.

**C#**

```csharp
string indexFolder = @"c:\MyIndex";

// Creating cancellation object
Cancellation cancellation = new Cancellation();

// Load index
Index index = new Index(indexFolder);

// Updating
index.UpdateAsync(cancellation);


// Cancelling
cancellation.Cancel();
```

### Implement possibility to break merging operation manually

##### Description

This enhancement is implemented for the possibility of cancelling the merging operation by request. The break is not instantaneous and in cases of merging several indexes, the breaking can take about a second.

##### Public API changes

Method **void Merge(Cancellation)** has been added to **GroupDocs.Search.Index** class.  
Method **void Merge(bool, Cancellation)** has been added to **GroupDocs.Search.Index** class.  
Method **void Merge(Index, bool, Cancellation)** has been added to **GroupDocs.Search.Index** class.  
Method **void Merge(IndexRepository, bool, Cancellation)** has been added to **GroupDocs.Search.Index** class.  
Method **void MergeAsync(bool, Cancellation)** has been added to **GroupDocs.Search.Index** class.  
Method **void MergeAsync(Index, bool, Cancellation)** has been added to **GroupDocs.Search.Index** class.  
Method **void MergeAsync(IndexRepository, bool, Cancellation)** has been added to **GroupDocs.Search.Index** class.

##### Usecases

The following code snippet shows how to break the merging process.

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// Creating cancellation object 
Cancellation cancellation = new Cancellation();
// cancelation after 5 seconds
cancellation.CancelAfter(5000);

// Load index
Index index = new Index(indexFolder);
index.Merge(cancellation);
```

### Implement possibility to break indexing with Cancelation object

##### Description

This enhancement is implemented for the possibility of cancelling the indexing operation by request and for time limitation of indexing. The break is not instantaneous and in cases of indexing large documents, the breaking can take about a second.

##### Public API changes

Method **void AddToIndex(string, Cancellation)** has been added to **GroupDocs.Search.Index** class.  
Method **void AddToIndex(string, int, bool, Cancellation)** has been added to **GroupDocs.Search.Index** class.  
Method **void AddToIndex(string\[\], Cancellation)** has been added to **GroupDocs.Search.Index** class.  
Method **void AddToIndex(string\[\], int, Cancellation)** has been added to **GroupDocs.Search.Index** class.  
Method **void AddToIndex(string\[\], bool, Cancellation)** has been added to **GroupDocs.Search.Index** class.  
Method **void AddToIndex(string\[\], int, bool, Cancellation)** has been added to **GroupDocs.Search.Index** class.  
Method **void AddToIndexAsync(string, Cancellation)** has been added to **GroupDocs.Search.Index** class.  
Method **void AddToIndexAsync(string, int, Cancellation)** has been added to **GroupDocs.Search.Index** class.  
Method **void AddToIndexAsync(string, bool, Cancellation)** has been added to **GroupDocs.Search.Index** class.  
Method **void AddToIndexAsync(string, int, bool, Cancellation)** has been added to **GroupDocs.Search.Index** class.  
Method **void AddToIndexAsync(string\[\], Cancellation)** has been added to **GroupDocs.Search.Index** class.  
Method **void AddToIndexAsync(string\[\], int, Cancellation)** has been added to **GroupDocs.Search.Index** class.  
Method **void AddToIndexAsync(string\[\], bool, Cancellation)** has been added to **GroupDocs.Search.Index** class.  
Method **void AddToIndexAsync(string\[\], int, bool, Cancellation)** has been added to **GroupDocs.Search.Index** class.

##### Usecases

The following code snippet shows how to cancel the async indexing operation by request.

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// Creating cancellation object
Cancellation cancellation = new Cancellation();

// Creating index
Index index = new Index(indexFolder);

// Indexing
index.AddToIndexAsync(documentsFolder, cancellation);

// Cancelling after 1 second of indexing
Thread.Sleep(1000);
cancellation.Cancel();
```

This example shows how to search with time limitation.

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentsFolder = @"c:\MyDocuments";

// Creating cancellation object
Cancellation cancellation = new Cancellation();
// Cancelling after 1 second of searching
cancellation.CancelAfter(1000);

// Creating index
Index index = new Index(indexFolder);

// Indexing
index.AddToIndex(documentsFolder, cancellation);
```
