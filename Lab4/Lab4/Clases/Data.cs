using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab4.Models;

namespace Lab4.Clases
{
    public class Data
    {
        private static Data instance;
        public static Data Instance
        {
            get
            {
                if (instance == null) instance = new Data();
                return instance;
            }
        }

        public List<Estampitas1> Album;

        public Data()
        {
            Album = new List<Estampitas1>();
        }
    }
}