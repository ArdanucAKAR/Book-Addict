using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Addict.Models
{
    public class user
    {
        public int id { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public string birthdate { get; set; }
        public Location location = new Location();
        public string username { get; set; }
        public string password { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string title { get; set; }
        public string picture { get; set; }
    }
}