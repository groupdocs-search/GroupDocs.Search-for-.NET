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
        public const string indexPath = "../../Data/Documents Indexes/";
        public const string indexPath2 = "../../Data/Documents Indexes2/";
        public const string mergeIndexPath1 = "../../Data/Index Merging/Index1/";
        public const string mergeIndexPath2 = "../../Data/Index Merging/Index2/";
        public const string mainMergedIndexesPath = "../../Data/Index Merging/Main Merged Indexes/";
        public const string documentsPath = "../../Data/Documents/";
        public const string documentsPath2 = "../../Data/Documents2/";
        public const string documentsPath3 = "../../Data/Documents3/";
        public const string synonymFilePath = "../../Data/Dictionaries/synonyms.txt";
        public const string stopWordsFilePath = "../../Data/Dictionaries/MyStopWords.txt";
        public const string exportedStopWordsFilePath = "../../Data/Dictionaries/MyExportedStopWords.txt";
        public const string mySynonymFilePath = "../../Data/Dictionaries/mySynonyms.txt";
        public const string licensePath = "D:/GroupDocs.Total.lic";
        public const string pathToPstFile = "D:/MyOutlookDataFile.pst";
        public const string pathToPasswordProtectedFile =  "../../Data/Documents/Password Protected Document.docx";
        public const string pathToPasswordProtectedFile2 = "../../Data/Documents/Password Protected Document2.docx";
        public const string pathToPasswordProtectedFile3 = "../../Data/Documents/Password Protected Document3.docx";
        public const string exportedHomophonesFilePath = "../../Data/Dictionaries/MyExportedHomophones.txt";
        public const string homophonesFilePath = "../../Data/Dictionaries/MyHomophones.txt";
        public const string aliasFilePath = "../../Data/Dictionaries/MyAliases.txt";
        public const string exportedAliasFilePath = "../../Data/Dictionaries/MyExportedAliases.txt";
        public const string spellingDictionaryFilePath = "../../Data/Dictionaries/MySpellingDictionary.txt";
        public const string exportedSpellingDictionaryFilePath = "../../Data/Dictionaries/MyExportedSpellingDictionary.txt";
        public const string oldIndexFolderPath = "../../Data/Old index";
        public const string alphabetFilePath = "../../Data/Dictionaries/MyAlphabet.txt";
        public const string exportedAlphabetFilePath = "../../Data/Dictionaries/MyExportedAlphabet.txt";
        public const string publicKey = "[Your Dynabic.Metered public key]";
        public const string privateKey = "[Your Dynabic.Metered private key]";
        public const string replacementsFileName = "../../Data/Dictionaries/Replacements.txt";
        public const string exportedReplacementsFileName  = "../../Data/Dictionaries/MyExportedReplacements.txt";
        public const string highlightedTextFilePath = "../../Data/Output/HighlightedResults.html";
		public const string documentTextPath = "../../Data/Output/DocumentText.html";

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
        /// Allows using Dynabic.Metered account to run library in licensed mode
        /// Feature is supported for version 17.06 or greater
        /// </summary>
        public static void UseDynabicMeteredAccount() {
            //ExStart:UseDynabicMeteredAccount
            // initialize Metered API and set-up credentials
            new Metered().SetMeteredKey(publicKey, privateKey);
            // do indexing and searching in licensed mode 
            //ExEnd:UseDynabicMeteredAccount
        }

        /// <summary>
        /// Index operation finished
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">OperationFinishedArg</param>
        public static void index_OperationFinished(object sender, OperationFinishedEventArgs e)
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
        internal static void index_OperationFinished(object sender, BaseIndexEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
    //ExEnd:commonutilitiesclass
}
