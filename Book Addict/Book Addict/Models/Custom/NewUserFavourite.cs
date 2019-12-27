using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Addict
{
    public class NewUserFavourite
    {
        public List<Book> Books { get; set; }
        public List<Author> Authors { get; set; }
        public List<Category> Categories { get; set; }
    }
}