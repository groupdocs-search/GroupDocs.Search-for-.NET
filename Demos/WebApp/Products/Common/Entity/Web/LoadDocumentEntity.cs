using System.Collections.Generic;

namespace GroupDocs.Search.WebForms.Products.Common.Entity.Web
{
    public class LoadDocumentEntity
    {
        public string guid { get; set; }

        public List<PageDescriptionEntity> pages { get; set; }
    }
}
