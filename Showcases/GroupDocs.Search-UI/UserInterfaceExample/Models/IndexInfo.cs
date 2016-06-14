using System;

namespace UserInterfaceExample.Models
{
    public class IndexInfo
    {
        public Guid IndexId { get; set; }
        public string IndexFullFolder { get; set; }
        public string IndexFolder { get; set; }
        public bool InMemory { get; set; }
        public int DocumentsCount { get; set; }
    }
}