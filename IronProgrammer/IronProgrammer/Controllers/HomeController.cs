using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Mvc;
using IronProgrammer.Common;
using IronProgrammer.Services.Interfaces;
using IronProgrammer.Services.Compile;
using IronProgrammer.Services.Compile.Roslyn;

namespace IronProgrammer.Controllers
{
    public class HomeController : Controller
    {
        private ICompiler _compiler = new RoslynCompiler();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CodeWrite()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CodeWrite(string code)
        {
            var error = _compiler.Compile(code, "Josef.exe", new List<string>() { "mscorlib", "System", "System.Core" });
            if (!error.Success)
            {
                TempData["errors"] = error.Errors;
                return RedirectToAction("Error");
            }
            Process.Start("D:\\Compilers\\Josef.exe");
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Error()
        {
            var errors = TempData["errors"] as List<Error>;
            return View(errors);
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}