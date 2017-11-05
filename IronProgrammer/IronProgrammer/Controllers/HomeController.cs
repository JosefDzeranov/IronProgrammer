using System.Diagnostics;
using System.Web.Mvc;
using IronProgrammer.Services.Interfaces;
using IronProgrammer.Services.Compile;

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
            var a = _compiler.Compile(code, "Josef.exe", "mscorlib.dll","System.Core.dll");
            Process.Start("D:\\Compilers\\Josef.exe");
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