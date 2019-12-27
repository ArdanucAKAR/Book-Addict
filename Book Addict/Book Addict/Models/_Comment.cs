using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Addict
{
    public class _Comment
    {
        public string ID { get; set; }
        public string Comment { get; set; }
        public List<User> UserInformation { get; set; }
    }
}