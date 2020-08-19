---
id: how-to-run-examples
url: search/net/how-to-run-examples
title: How to Run Examples
weight: 7
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
## Build project from scratch

*   Open Visual Studio and go to **File** -> **New** -> **Project**.
*   Select appropriate project type - Console App, ASP.NET Web Application etc.
*   Install **GroupDocs.Search for .NET** from Nuget or official GroupDocs website following this [guide]({{< ref "search/net/getting-started/installation.md" >}}).
*   Code your first application with **GroupDocs.Search for .NET** like this:
    

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\"; // NOTE: Put here actual path for your documents
string query = "Einstein";

Index index = new Index(indexFolder); // Creating index in the specified folder
index.Add(documentsFolder); // Indexing documents from the specified folder

SearchResult result = index.Search(query); // Searching in index
foreach (FoundDocument document in result)
{
    Console.WriteLine(document.DocumentInfo.FilePath);
}
```

*   Build and Run your project.
*   List of found documents will appear in the console.

## Download examples from GitHub

The complete examples package of **GroupDocs.Search** is hosted on [GitHub](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET). You can either download the ZIP file from [here](https://codeload.github.com/groupdocs-search/GroupDocs.Search-for-.NET/zip/master) or clone the repository of GitHub using your favourite GitHub client.

In case you download the ZIP file, extract the folders on your local disk. The extracted files and folders will look like following image:

![](search/net/images/how-to-run-examples.jpg)

In extracted files and folders, you can find the following solution file:

*   CSharp solution file

The project is created in **Microsoft Visual Studio 2012**. The **Data** folder contains all the sample document files used in the examples.

To run the examples, open the solution file in Visual Studio and build the project. To add missing references for **GroupDocs.Search** see [Installation]({{< ref "search/net/getting-started/installation.md" >}}). All the functions are called from **Program.cs**. Un-comment the function you want to run and comment the rest.

![](search/net/images/how-to-run-examples_1.jpg)

## Contribute

If you like to add or improve an example, we encourage you to contribute to the project. All examples in this repository are open source and can be freely used in your own applications.

To contribute, you can fork the repository, edit the code and create a pull request. We will review the changes and include it in the repository if found helpful.
