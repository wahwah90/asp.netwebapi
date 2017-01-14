using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspnetsportwebapi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult IndexTest()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}