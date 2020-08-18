using GroupDocs.Search.Results;
using System;
using System.IO;

namespace GroupDocs.Search.Examples.CSharp.AdvancedUsage.ManagingDictionaries
{
    class DocumentPasswords
    {
        public static void Run()
        {
            string indexFolder = @".\AdvancedUsage\ManagingDictionaries\DocumentPasswords\Index";
            string documentsFolder = Utils.DocumentsPath;

            // Creating an index from in specified folder
            Index index = new Index(indexFolder);

            if (index.Dictionaries.DocumentPasswords.Count > 0)
            {
                // Removing all passwords from the dictionary
                index.Dictionaries.DocumentPasswords.Clear();
            }

            string key1 = Path.GetFullPath(Path.Combine(Utils.PasswordProtectedDocumentsPath, "English.docx"));
            index.Dictionaries.DocumentPasswords.Add(key1, "123456");

            if (index.Dictionaries.DocumentPasswords.Contains(key1))
            {
                // Getting a password for a document
                string password = index.Dictionaries.DocumentPasswords.GetPassword(key1);
                Console.WriteLine(key1);
                Console.WriteLine("\tPassword: " + password);

                // Deleting the password from the dictionary
                index.Dictionaries.DocumentPasswords.Remove(key1);
            }

            // Adding document passwords to the dictionary
            string key2 = Path.GetFullPath(Path.Combine(Utils.PasswordProtectedDocumentsPath, "English.docx"));
            index.Dictionaries.DocumentPasswords.Add(key2, "123456");
            string key3 = Path.GetFullPath(Path.Combine(Utils.PasswordProtectedDocumentsPath, "Lorem ipsum.docx"));
            index.Dictionaries.DocumentPasswords.Add(key3, "123456");

            // Indexing documents from the specified folder
            // Passwords will be automatically retrieved from the dictionary when necessary
            index.Add(documentsFolder);

            // Searching in the index
            string query = "ipsum OR increasing";
            SearchResult result = index.Search(query);

            Utils.TraceResult(query, result);
        }
    }
}
