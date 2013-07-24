using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using RiverRat.Models;

namespace RiverRat.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    ViewBag.Message = "Modify this template to kick-start your ASP.NET MVC application.";

        //    //return View();
        //    PhotoList photos = new PhotoList();
        //    photos.Add(new Photo { FileName = "/Content/Artists/Jess/TAT_1.1_Starbuck.jpg", Title = "autogen", SortKey = 1 });
        //    photos.Add(new Photo { FileName = "/Content/Artists/Jess/TAT_6_Knife.jpg", Title = "autogen", SortKey = 2 });
        //    return View(photos);
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Location()
        {
            ViewBag.Message = "Location page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Index() //string artistName)
        {
            PhotoList photos = new PhotoList();
            List<string> fileList = new List<string>();
            var dirList = System.IO.Directory.GetDirectories(Server.MapPath(Url.Content("~/Content/Artists/")));
            Random rand = new Random();

            //Selects a random sample of 10 pictures and returns them to the view to use in the slider.
            foreach (string directory in dirList)
            {
                var artist = GetArtistName(directory);
                var files = from f in System.IO.Directory.GetFiles(directory)
                            where System.IO.Path.GetFileName(f).ToUpper().StartsWith("TAT")
                            select f;
                fileList.AddRange(files);
                foreach (string fileName in files)
                {
                    decimal sortKey = rand.Next();
                    photos.Add( new Models.Photo { FileName = artist + "/" + System.IO.Path.GetFileName(fileName), 
                        Title = GetTitle(fileName), 
                        SortKey = sortKey});
                }
            }

            photos.Sort((p1, p2) => (p1.SortKey.CompareTo(p2.SortKey)));

            return View(new PhotoList(photos.GetRange(0, 10)));
        }

        private string GetArtistName(string directory)
        {
            return System.Text.RegularExpressions.Regex.Split(directory, "\\\\Artists\\\\")[1];
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
