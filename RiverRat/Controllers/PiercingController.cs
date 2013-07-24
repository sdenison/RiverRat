using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RiverRat.Controllers
{
    public class PiercingController : Controller
    {
        //
        // GET: /Piercing/

        public void Index() 
        {
            Response.Redirect("~/Artist/Gallery/Piercings/");
        }

    }
}
