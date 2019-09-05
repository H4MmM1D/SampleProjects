using System;

namespace Model
{
    public class Link
    {
        public int Id { get; set; }

        public string OriginalUrl { get; set; }

        public Guid Token { get; set; }

        public int NOVisit { get; set; }
    }
}
