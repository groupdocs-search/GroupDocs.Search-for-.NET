using GroupDocs.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Search_for_.NET
{
    //ExStart:ComparerClass
    // Implementing comparer
    public class Comparer : IComparer<DocumentResultInfo>
    {
        public int Compare(DocumentResultInfo x, DocumentResultInfo y)
        {
            // Compare y and x in reverse order
            return y.Relevance.CompareTo(x.Relevance);
        }
    }
    //ExEnd:ComparerClass
}
