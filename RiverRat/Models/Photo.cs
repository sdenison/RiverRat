﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiverRat.Models
{
    public class Photo
    {
        public string Title { get; set; }
        public string FileName { get; set; }
        public decimal SortKey { get; set; }
    }
}