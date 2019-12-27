using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Addict
{
    public class PublicationInformation
    {
        public string ISBN { get; set; }
        public string PublishYear { get; set; }
        public List<Publisher> Publisher { get; set; }
    }
}