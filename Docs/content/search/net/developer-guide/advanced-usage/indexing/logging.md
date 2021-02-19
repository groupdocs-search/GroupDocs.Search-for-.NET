---
id: logging
url: search/net/logging
title: Logging
weight: 16
description: ""
keywords: 
productName: GroupDocs.Search for .NET
hideChildren: False
---
This page contains information on creating and assigning a logger of an index, as well as on the implementation of a custom logger.

## Use of standard file logger

In order to save information about events and errors in an index into a file, you should use the standard file logger or your own custom logger. It is important to remember that each time you open an existing index, you must create and assign an instance of the logger again, because the logger is not saved. The good news is that the same code can be used to create a new index and open an existing one. In this case, when opening an existing index, a logger will be used from the index settings passed to the constructor, the remaining index settings will be loaded from disk.

The following example demonstrates the use of the standard file logger. The constructor parameters of this logger are the path to the log file and its maximum size in MB.

**C#**

```csharp
string indexFolder = @"c:\MyIndex\";
string documentsFolder = @"c:\MyDocuments\";
string query = "Einstein";
string logPath = @"c:\Log.txt";
 
IndexSettings settings = new IndexSettings();
settings.Logger = new FileLogger(logPath, 4.0); // Specifying the path to the log file and a maximum length of 4 MB
 
Index index = new Index(indexFolder, settings); // Creating or loading an index from the specified folder
 
index.Add(documentsFolder); // Indexing documents from the specified folder
 
SearchResult result = index.Search(query); // Search in index
```

## Implementing custom logger

Sometimes you may need to implement your own logger, for example, to display the log in the console. An example implementation of such a logger is presented below.

**C#**

```csharp
public class ConsoleLogger : ILogger
{
    public ConsoleLogger()
    {
    }
 
    public void Error(string message)
    {
        Console.WriteLine("Error: " + message);
    }
 
    public void Trace(string message)
    {
        Console.WriteLine(message);
    }
}
```

## More resources

### GitHub examples

You may easily run the code from documentation articles and see the features in action in our GitHub examples:

*   [GroupDocs.Search for .NET examples](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET)
    
*   [GroupDocs.Search for Java examples](https://github.com/groupdocs-search/GroupDocs.Search-for-Java)
    

### Free online document search App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to search over your PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX and more with our free online [Free Online Document Search App](https://products.groupdocs.app/search).
