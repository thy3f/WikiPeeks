using System;

namespace WikiPeeks.Helpers
{
    public class WikiEntry
    {
        public int ID { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime DateAdded { get; set; }
    }
}