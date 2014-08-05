using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaughtItHere.Models;

namespace CaughtItHere.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<FishType> theTypes = new List<FishType>();
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}