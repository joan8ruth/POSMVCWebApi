using POSMVCWebAPIClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POSMVCWebAPIClient.Controllers
{
    public class HomeController : Controller
    {

        public static List<Item> ItemList = new List<Item>();
        public static int i = 0;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ScanItem()
        {
            return PartialView();
        }



    }
}