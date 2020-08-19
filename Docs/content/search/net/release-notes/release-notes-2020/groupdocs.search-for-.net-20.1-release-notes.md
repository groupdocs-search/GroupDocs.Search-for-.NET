---
id: groupdocs-search-for-net-20-1-release-notes
url: search/net/groupdocs-search-for-net-20-1-release-notes
title: GroupDocs.Search for .NET 20.1 Release Notes
weight: 1
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---


{{< alert style="info" >}}This page contains release notes for GroupDocs.Search for .NET 20.1{{< /alert >}}

## Major Features

**.NET Standard 2.0**

Starting from 20.1 release GroupDocs.Search for .NET includes .NET Standard 2.0 version. It has full functionality of regular .NET version of GroupDocs.Search.

There are also the following improvements:

*   Implement index statuses reflecting possible operations
*   Remove Legacy namespace
*   Implement options for metadata indexing

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| SEARCHNET-2182 | Add support for .Net Standard 2.0 | Improvement |
| SEARCHNET-2160 | Implement index statuses reflecting possible operations | Improvement |
| SEARCHNET-2185 | Remove Legacy namespace | Improvement |
| SEARCHNET-2186 | Implement options for metadata indexing | Improvement |

## Public API and Backward Incompatible Changes

### Implemented index statuses reflecting possible operations

This improvement brings order to the set of statuses of the index, and also clarifies the type of operation being performed.

##### Public API changes

Value **NotStarted** has been deleted from **GroupDocs.Search.Common.IndexStatus** enum.  
Value **InProgress** has been deleted from **GroupDocs.Search.Common.IndexStatus** enum.  
Value **LicenseRestrictionFinished** has been deleted from **GroupDocs.Search.Common.IndexStatus** enum.  
Value **Indexing** has been added to **GroupDocs.Search.Common.IndexStatus** enum.  
Value **Updating** has been added to **GroupDocs.Search.Common.IndexStatus** enum.  
Value **Merging** has been added to **GroupDocs.Search.Common.IndexStatus** enum.  
Value **Optimizing** has been added to **GroupDocs.Search.Common.IndexStatus** enum.  
Value **Deleting** has been added to **GroupDocs.Search.Common.IndexStatus** enum.

Value **Deleting** has been added to **GroupDocs.Search.Events.OperationType** enum.  
Value **Optimizing** has been added to **GroupDocs.Search.Events.OperationType** enum.

##### Usecases

This example shows how to get information about changing the status of an index and completing the index operation:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";
 
// Creating index
Index index = new Index(indexFolder);
 
// Subscribing to event
index.Events.StatusChanged += (sender, args) =>
{
    Console.WriteLine("Index status: " + args.Status);
};
 
// Subscribing to event
index.Events.OperationFinished += (sender, args) =>
{
    Console.WriteLine("Operation finished: " + args.OperationType);
};
 
// Starting indexing operation
index.Add(documentFolder);
```

### Added support for .Net Standard 2.0

Starting from 20.1 release GroupDocs.Search for .Net includes a .Net Standard 2.0 compatible assembly.

##### Public API changes

None.

### Removed Legacy namespace

All types from the **GroupDocs.Search.Legacy** namespace have been removed.

##### Public API changes

All types from the **GroupDocs.Search.Legacy** namespace have been removed.

### Implement options for metadata indexing

This improvement adds the **MetadataIndexingOptions** property to **IndexingOptions**, **UpdateOptions**, and **TextOptions** classes. The **MetadataIndexingOptions** class contains the following properties for setting metadata indexing options:

*   The **IndexingEmptyValues** property sets a value indicating whether to index empty field values or not. The default value is true.
*   The **IndexingEmptyNames** property sets a value indicating whether to index empty field names or not. The default value is true.
*   The **DefaultFieldName** property sets the default field name used to index empty field names. The default value is "unknown".
*   The **SeparatorInCompoundName** property sets the separator in the compound name of a field. The default value is "." (period character).
*   The **MaxBytesToIndexField** property sets the maximum number of values indexed from an array of **byte** values. The default value is **int.MaxValue**.
*   The **MaxIntsToIndexField** property sets the maximum number of values indexed from an array of **int** values. The default value is **int.MaxValue**.
*   The **MaxLongsToIndexField** property sets the maximum number of values indexed from an array of **long** values. The default value is **int.MaxValue**.
*   The **MaxDoublesToIndexField** property sets the maximum number of values indexed from an array of **double** values. The default value is **int.MaxValue**.
*   The **SeparatorBetweenValues** property sets the separator between values in a field of type array. The default value is " " (space character).

##### Public API changes

Class **MetadataIndexingOptions** has been added to **GroupDocs.Search.Options** namespace.  
Property **bool IndexingEmptyValues** has been added to **GroupDocs.Search.Options.MetadataIndexingOptions** class.  
Property **bool IndexingEmptyNames** has been added to **GroupDocs.Search.Options.MetadataIndexingOptions** class.  
Property **string DefaultFieldName** has been added to **GroupDocs.Search.Options.MetadataIndexingOptions** class.  
Property **string SeparatorInCompoundName** has been added to **GroupDocs.Search.Options.MetadataIndexingOptions** class.  
Property **int MaxBytesToIndexField** has been added to **GroupDocs.Search.Options.MetadataIndexingOptions** class.  
Property **int MaxIntsToIndexField** has been added to **GroupDocs.Search.Options.MetadataIndexingOptions** class.  
Property **int MaxLongsToIndexField** has been added to **GroupDocs.Search.Options.MetadataIndexingOptions** class.  
Property **int MaxDoublesToIndexField** has been added to **GroupDocs.Search.Options.MetadataIndexingOptions** class.  
Property **string SeparatorBetweenValues** has been added to **GroupDocs.Search.Options.MetadataIndexingOptions** class.

Property **MetadataIndexingOptions MetadataIndexingOptions** has been added to **GroupDocs.Search.Options.IndexingOptions** class.  
Property **MetadataIndexingOptions MetadataIndexingOptions** has been added to **GroupDocs.Search.Options.TextOptions** class.  
Property **MetadataIndexingOptions MetadataIndexingOptions** has been added to **GroupDocs.Search.Options.UpdateOptions** class.

##### Usecases

This example demonstrates how to set the metadata indexing options:

**C#**

```csharp
string indexFolder = @"c:\MyIndex";
string documentFolder = @"c:\MyDocuments";
 
// Creating an index
Index index = new Index(indexFolder);
 
// Setting the metadata indexing options
var options = new IndexingOptions();
options.MetadataIndexingOptions.DefaultFieldName = "default";
options.MetadataIndexingOptions.SeparatorInCompoundName = @"\";
options.MetadataIndexingOptions.MaxBytesToIndexField = 10;
options.MetadataIndexingOptions.MaxIntsToIndexField = 10;
options.MetadataIndexingOptions.MaxLongsToIndexField = 10;
options.MetadataIndexingOptions.MaxDoublesToIndexField = 10;
 
// Starting indexing operation
index.Add(documentFolder, options);
```

