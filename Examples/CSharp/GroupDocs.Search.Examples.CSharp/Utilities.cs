using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupDocs.Search;
using GroupDocs.Search.Events;

namespace GroupDocs.Search_for_.NET
{
    //ExStart:commonutilitiesclass
    public class Utilities
    {
        public const string indexPath = "../../../../Data/Documents Indexes/";
        public const string indexPath2 = "../../../../Data/Documents Indexes2/";
        public const string documentsPath = "../../../../Data/Documents/";
        public const string synonymFilePath = "../../../../Data/synonyms.txt";
        public const string licensePath = "../../../../Data/Documents/GroupDocs.Search.lic";
      
        /// <summary>
        /// Apply license 
        /// </summary>
        public static void ApplyLicense()
        {
            //initialize License
            License lic = new License();
            //Set license
            lic.SetLicense(licensePath);
        }

        /// <summary>
        /// Index operation finished
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">OperationFinishedArg</param>
        public static void index_OperationFinished(object sender, OperationFinishedArg e)
        {
            DateTime time = e.Time; // Time when documents added
            Guid indexId = e.IndexId; // Index Id
            string indexFolder = e.IndexFolder; // Index Folder
            IndexStatus status = e.Status; // Index Status
            OperationType operationType = e.OperationType; // Operation Type.
        }

        /// <summary>
        /// Index operation finished
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">BaseIndexArg</param>
        internal static void index_OperationFinished(object sender, BaseIndexArg e)
        {
            throw new NotImplementedException();
        }
    }
    //ExEnd:commonutilitiesclass
}
