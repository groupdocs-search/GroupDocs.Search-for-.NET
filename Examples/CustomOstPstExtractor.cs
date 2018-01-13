using GroupDocs.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Search_for_.NET
{
    public class CustomOstPstExtractor : IContainerItemExtractor
    {
        public string[] Extensions
        {
            get { return new[] { ".ost", ".pst" }; }
        }

        public FieldInfo[] GetFields(string fileName)
        {
            FieldInfo[] result = new FieldInfo[3];
            result[1] = new FieldInfo("Author", "Hardcoded author");
            result[2] = new FieldInfo("CreationDate", "21.05.2004");
            return result;
        }

        public ExtractedItemInfo[] GetContaianerItems(string fileName)
        {
            ExtractedItemInfo[] result = new ExtractedItemInfo[1];
            FieldInfo[] fields;

            fields = new FieldInfo[9];
            fields[0] = new FieldInfo("MailMessageBody", "Text of email message");
            fields[1] = new FieldInfo("MailSenderName", "sender@email.com");
            fields[2] = new FieldInfo("MailDisplayName", "John Smith");
            fields[3] = new FieldInfo("MailDisplayToS", "All");
            fields[4] = new FieldInfo("MailSubject", "Email subject");
            fields[5] = new FieldInfo("MailDeliveryTime", "11:30");
            fields[6] = new FieldInfo("Author", "Email Author");
            fields[7] = new FieldInfo("MailArrivalTime", "11:30");
            fields[8] = new FieldInfo("MailMessageFlags", "Message flags");

            result[0] = new ExtractedItemInfo(DocumentType.OutlookEmailMessage, "EntryIdString", fileName ,fields);

            return result;
        }

        public DocumentType DocumentType { get { return DocumentType.OutlookStorage; } }
    }
}
