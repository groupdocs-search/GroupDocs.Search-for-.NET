using GroupDocs.Search.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.Indexing
{
    class IndexingPasswordProtectedDocuments
    {
        public static void IndexingUsingThePasswordDictionary()
        {
            string indexFolder = @".\AdvancedUsage\Indexing\IndexingPasswordProtectedDocuments\IndexingUsingThePasswordDictionary";
            string documentsFolder = Utils.PasswordProtectedDocumentsPath;

            // Creating an index
            Index index = new Index(indexFolder);

            // Adding document passwords to the dictionary
            index.Dictionaries.DocumentPasswords.Add(Path.Combine(Utils.PasswordProtectedDocumentsPath, "English.docx"), "123456");
            index.Dictionaries.DocumentPasswords.Add(Path.Combine(Utils.PasswordProtectedDocumentsPath, "Lorem ipsum.docx"), "123456");

            // Indexing documents from the specified folder
            // Passwords will be automatically retrieved from the dictionary when necessary
            index.Add(documentsFolder);

            // Searching in the index
            string query = "ipsum OR increasing";
            SearchResult result = index.Search(query);

            Utils.TraceResult(query, result);
        }

        public static void IndexingUsingThePasswordRequiredEvent()
        {
            string indexFolder = @".\AdvancedUsage\Indexing\IndexingPasswordProtectedDocuments\IndexingUsingThePasswordRequiredEvent";
            string documentsFolder = Utils.PasswordProtectedDocumentsPath;

            // Creating an index
            Index index = new Index(indexFolder);

            // Subscribing to the event
            index.Events.PasswordRequired += (sender, args) =>
            {
                if (args.DocumentFullPath.EndsWith(".docx", StringComparison.InvariantCultureIgnoreCase))
                {
                    args.Password = "123456"; // Providing password for DOCX files
                }
            };

            // Indexing documents from the specified folder
            index.Add(documentsFolder);

            // Searching in the index
            string query = "ipsum OR increasing";
            SearchResult result = index.Search(query);

            Utils.TraceResult(query, result);
        }
    }
}
