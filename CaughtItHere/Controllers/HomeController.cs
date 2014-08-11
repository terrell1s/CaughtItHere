using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaughtItHere.Models;

namespace CaughtItHere.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private CaughtItHereEntities db = new CaughtItHereEntities();

        public ActionResult Index()
        {
            List<FishType> theTypes = new List<FishType>();
            
            
            var exisitingFish = db.Fish;
            
            
            
            return View(exisitingFish);
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

        public ActionResult DNR()
        {
            return Redirect("http://www.mdnr-elicense.com/Welcome/Default.aspx");
        }

        public ActionResult Regulations()
        {
            return Redirect("http://www.eregulations.com/wp-content/uploads/2014/01/14MIFW-FINAL-LR.pdf");
        }
    }
}