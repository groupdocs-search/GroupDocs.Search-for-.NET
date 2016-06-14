namespace UserInterfaceExample.Helpers
{
    public class LicenseHelper
    {
        //License path
        private const string licensePath = @"D:\GroupDocs.Search.lic";

        public static void SetGroupDocsSearchLicense()
        {
            GroupDocs.Search.License lic = new GroupDocs.Search.License();
            lic.SetLicense(licensePath);
        }

        public static void SetGroupDocsViewerLicense()
        {
            GroupDocs.Viewer.License lic = new GroupDocs.Viewer.License();
            lic.SetLicense(licensePath);
        }
    }
}