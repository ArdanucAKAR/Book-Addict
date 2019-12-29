using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Addict
{
    public class Singleton
    {
        private static Singleton instance = null;
        public User User { get; set; }

        private Singleton() { }

        public static Singleton GetInstance()
        {
            if (instance == null)
            {
                instance = new Singleton();
                instance.Initialize();
            }
            return instance;
        }

        public static void Destroy()
        {
            instance = null;
        }
        
        private void Initialize()
        {
            User = new User();
        }
    }
}