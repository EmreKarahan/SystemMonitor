using System.Web.Mvc;
using OpenShift.Models;


namespace OpenShift.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.CpuCount = AppConfig.CoreCount;
            return View();
        }

    }
}