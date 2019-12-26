using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Addict.Models
{
    public class PublicationInformation
    {
        public string BookISBN { get; set; }
        public string PublishYear { get; set; }

        public string PublisherID { get; set; }

        public string PublisherName { get; set; }
    }
}