using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Addict
{
    public sealed class Singleton
    {
        private Singleton()
        {
        }
        private static Singleton instance = null;
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
        public User User { get; set; }
    }
}