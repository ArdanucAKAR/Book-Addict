using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Addict
{
    public class HomePage
    {
        public User User { get; set; }
        public List<Book> PopularBooks { get; set; }
        public List<Author> PopularAuthors { get; set; }
    }
}