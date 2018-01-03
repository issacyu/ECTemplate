using System.Web.Mvc;

namespace ECTemplate.WebUI.Controllers
{
    /// <summary>
    /// A controller that handles the requests for the main page.
    /// </summary>
    public class MainController : Controller
    {
        /// <summary>
        /// Request for the main page.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Request for the slider.
        /// </summary>
        /// <returns></returns>
        public PartialViewResult Slider()
        {
            return PartialView();
        }
    }
}