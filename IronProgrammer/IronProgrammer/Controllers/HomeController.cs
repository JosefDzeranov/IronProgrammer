using IronProgrammer.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IronProgrammer.Controllers
{
    public class HomeController : Controller
    {
        ProblemContext context = new ProblemContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var res = context.TypeProblems.ToList();
            var a = res[0];
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}