using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiverRat.Models
{
    public class PhotoList : List<Photo>
    {
        public PhotoList(List<Photo> photos)
        {
            foreach (var photo in photos)
            {
                this.Add(photo);
            }
        }
        public PhotoList()
        {
        }
    }
}