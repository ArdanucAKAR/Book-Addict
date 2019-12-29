using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Addict
{
    public class Book
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverPicturePath { get; set; }
        public int NumberOfPages { get; set; }
        public int Star { get; set; }
        public _Language Language { get; set; }
        public List<Author> Authors { get; set; }
        public List<Category> Categories { get; set; }
        public List<_Comment> Comments { get; set; }
        public List<PublicationInformation> PublicationInformation { get; set; }
        public int NumberOfReadings { get; set; }
        public int NumberOfReaders { get; set; }
    }
}