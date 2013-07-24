using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiverRat.Models
{
    public class Artist
    {
        public string Name { get; set; }
        public List<Photo> Photos { get; set; }
    }
}