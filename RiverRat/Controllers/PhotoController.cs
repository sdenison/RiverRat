using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Globalization;

namespace RiverRat.Controllers
{
    public class PhotoController : Controller
    {
        //
        // GET: /Photo/

        public ActionResult Index(string artistName)
        {
            List<Models.Photo> photos = new List<Models.Photo>();
            var fileList = from f in System.IO.Directory.GetFiles(@"~\Content\Artists\" + artistName)
                           where f.ToUpper().StartsWith("TAT")
                           select f;
            foreach (string fileName in fileList)
            {
                photos.Add(new Models.Photo { FileName = fileName, Title = GetTitle(fileName) });
            }

            return View(photos);
        }



        public ActionResult Gallery(string id) //string artistName)
        {
            List<Models.Photo> photos = new List<Models.Photo>();
            string artistName = id;
            ViewBag.ArtistName = artistName;
            var fileList = System.IO.Directory.GetFiles(Server.MapPath(Url.Content("~/Content/Artists/" + artistName )));
            
            //var fileList = from f in System.IO.Directory.GetFiles("images\Artists\Jess") // + artistName)
            //               where f.ToUpper().StartsWith("TAT")
            //               select f;
            foreach (string fileName in fileList)
            {
                photos.Add(new Models.Photo { FileName = artistName + "/" + System.IO.Path.GetFileName(fileName), Title = GetTitle(fileName) });
            }

            return View(photos);
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
