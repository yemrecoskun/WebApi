using System.Collections.Generic;

namespace WebApi.Model
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfBookOfInterests
        {
            get { return bookOfInterests.Count; }
        }
        public List<BookOfInterests> bookOfInterests { get; set; } = new List<BookOfInterests>();
    }
}
