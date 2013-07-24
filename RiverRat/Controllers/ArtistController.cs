using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace RiverRat.Controllers
{
    public class ArtistController : Controller
    {
        //
        // GET: /Artist/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Gallery(string id) //string artistName)
        {
            List<Models.Photo> photos = new List<Models.Photo>();
            string artistName = id;
            ViewBag.ArtistName = artistName;

            var files= from f in System.IO.Directory.GetFiles(Server.MapPath(Url.Content("~/Content/Artists/" + artistName)))
                           where System.IO.Path.GetFileName(f).ToUpper().StartsWith("TAT")
                           select f;
            foreach (string fileName in files)
            {
                photos.Add(new Models.Photo { FileName = artistName + "/" + System.IO.Path.GetFileName(fileName), Title = GetTitle(fileName), SortKey = GetSortKey(fileName)  });
            }

            photos.Sort((p1, p2) => { return p1.SortKey.CompareTo(p2.SortKey); });

            Models.Artist artist = new Models.Artist { Name = artistName, Photos = photos };

            return View(artist);
        }

        /// <summary>
        /// Parses file name for the sort key
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>If no sort key is found then we return the max value for an integer</returns>
        private decimal GetSortKey(string fileName)
        {
            string[] words = System.IO.Path.GetFileNameWithoutExtension(fileName).Split('_');
            decimal sortKey = decimal.MaxValue;

            if (words.Length > 1)
            {
                decimal.TryParse(words[1], out sortKey);
            }
            return sortKey;
        }

        /// <summary>
        /// Parses the file name and returns a formatted title from the filename
        /// </summary>
        /// <param name="fileName">Example: TAT_2030_This_is_Andrews_favorite</param>
        /// <returns>Formatted title</returns>
        private string GetTitle(string fileName)
        {
            StringBuilder title = new StringBuilder();
            string[] words = System.IO.Path.GetFileNameWithoutExtension(fileName).Split('_');
            int index = 1;

            foreach (string word in words)
            {
                if (index > 2)
                {
                    //Puts spaces in the title that replaces the underscores
                    if (index > 3)
                    {
                        title.Append(" ");
                    }
                    title.Append(word);
                }
                index++;
            }
            return title.ToString();
        }

    }
}
