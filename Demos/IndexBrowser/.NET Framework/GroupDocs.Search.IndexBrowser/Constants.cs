using System;
using System.IO;

namespace GroupDocs.Search.IndexBrowser
{
    static class Constants
    {
        public static string LocalAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public const string CompanyName = "GroupDocs";
        public const string ProductName = "Search";
        public const string AppName = "IndexBrowser";
        public static string StorageBasePath = Path.Combine(LocalAppDataPath, CompanyName, ProductName, AppName);
        public static string SettingsFilePath = Path.Combine(StorageBasePath, "Settings.xml");
    }
}
