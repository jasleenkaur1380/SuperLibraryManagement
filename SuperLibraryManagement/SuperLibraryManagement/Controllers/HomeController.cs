using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperLibraryManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TempData["Success"] = "Welcome to the dashboard!";
            TempData["Error"] = "Something went wrong!";
            TempData["Warning"] = "This is a warning message!";
            TempData["Info"] = "Here is some information!";
            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            try
            {

            }
            catch (Exception)
            {

            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}