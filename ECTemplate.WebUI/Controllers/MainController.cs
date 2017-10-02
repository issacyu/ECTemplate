using System.Web.Mvc;

namespace ECTemplate.WebUI.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Slider()
        {
            return PartialView();
        }
    }
}