using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Addict.Models
{
    public class _Comment
    {
        public string CommentID { get; set; }
        public string Comment { get; set; }
        public string UserID{ get; set; }
        public string UserFullName { get; set; }

    }
}