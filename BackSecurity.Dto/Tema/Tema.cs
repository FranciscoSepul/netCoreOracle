﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Tema
{
   
     public class Item
    {
        public int idcapacitacion { get; set; }
        public string capacitacion { get; set; }
        public List<Link> links { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class TemaRoot
    {
        public List<Item> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<Link> links { get; set; }
    }

    public class OneTemaRoot
    {
        public int idcapacitacion { get; set; }
        public string capacitacion { get; set; }
        public List<Link> links { get; set; }
    }
}
