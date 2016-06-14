using System;
using System.Collections.Generic;
using GroupDocs.Search;

namespace UserInterfaceExample.Helpers
{
    public static class IndexHelper
    {
        public static List<Index> Indexes;

        static IndexHelper()
        {
            LicenseHelper.SetGroupDocsSearchLicense();
            Indexes = new List<Index>();
        }

        public static void DeleteIndex(Guid indexId)
        {
            Indexes.Remove(Indexes.Find(i => i.IndexId == indexId));
        }

        public static void AddIndex(string indexFolder)
        {
            Index index = string.IsNullOrEmpty(indexFolder) ? new Index() : new Index(indexFolder, true);
            Indexes.Add(index);
        }

        public static void AddToIndex(Guid indexId, string folderName)
        {
            Index index = Indexes.Find(i => i.IndexId == indexId);
            index.AddToIndex(folderName);
        }

        public static SearchResults Search(Guid indexId, string searchQuery)
        {
            if (string.IsNullOrEmpty(searchQuery))
            {
                searchQuery = "";
            }
            return Indexes.Find(i => i.IndexId == indexId).Search(searchQuery);
        }
    }
}