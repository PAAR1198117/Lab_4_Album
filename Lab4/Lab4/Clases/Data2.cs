using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Clases
{
    public class Data2
    {
        private static Data2 instance;
        public static Data2 Instance
        {
            get
            {
                if (instance == null) instance = new Data2();
                return instance;
            }
        }

        public List<Estampitas2> Album;

        public Data2()
        {
            Album = new List<Estampitas2>();
        }
    }
}