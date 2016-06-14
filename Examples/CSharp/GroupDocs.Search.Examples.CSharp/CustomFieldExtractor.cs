using GroupDocs.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Search_for_.NET
{
    //ExStart:Customfieldextractor
    class CustomFieldExtractor : IFieldExtractor
    {
        public string[] Extensions
        {
            //redefine internal field extractor
            get { return new[] {".doc", ".doc"}; }
            //extractor for supporting new document format
            //get { return new[] { ".ext1", ".ext2" }; }
        }

        public FieldInfo[] GetFields(string fileName)
        {
            FieldInfo[] result = new FieldInfo[4];
            result[0] = new FieldInfo("Content", "Hardcoded document content");
            result[1] = new FieldInfo("DocumentType", "MyDocumentType");
            result[2] = new FieldInfo("Author", "Hardcoded author");
            result[3] = new FieldInfo("CreationDate", "21.05.2004");
            return result;
        }
    }
    //ExEnd:Customfieldextractor
}
