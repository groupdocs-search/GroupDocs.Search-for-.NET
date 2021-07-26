namespace GroupDocs.Search.WebForms.Products.Common.Entity.Web
{
    /// <summary>
    /// File description entity
    /// </summary>
    public class FilePropertyEntity
    {
        public string name { get; set; }
        public dynamic value { get; set; }
        public FilePropertyCategory category { get; set; }
        public bool original { get; set; }
    }

    public enum FilePropertyCategory
    {
        BuildIn,
        Default
    }
}