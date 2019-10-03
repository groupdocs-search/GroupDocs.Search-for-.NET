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

            string path = Path.Combine(Utils.PasswordProtectedDocumentsPath, "English.docx");
            index.Dictionaries.DocumentPasswords.Add(path, "123456");

            if (index.Dictionaries.DocumentPasswords.Contains(path))
            {
                // Getting a password for a document
                string password = index.Dictionaries.DocumentPasswords.GetPassword(path);
                Console.WriteLine(path);
                Console.WriteLine("\tPassword: " + password);

                // Deleting the password from the dictionary
                index.Dictionaries.DocumentPasswords.Remove(path);
            }

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
    }
}
