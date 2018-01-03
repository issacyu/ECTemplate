using System.Web.Mvc;
using ECTemplate.WebUI.Models;
using ECTemplate.Domain.Entities;

namespace ECTemplate.WebUI.Controllers
{
    /// <summary>
    /// A controller that handles the summary requests.
    /// </summary>
    public class SummaryController : Controller
    {
        /// <summary>
        /// Request the summary page.
        /// </summary>
        /// <param name="user">The information of the current user.</param>
        /// <param name="cart">The shopping cart.</param>
        /// <returns></returns>
        public ActionResult Summary(CurrentUserViewModel user, Cart cart)
        {
            return PartialView("Summary", new SummaryViewModel
            {
                User = user,
                Cart = cart
            });
        }
    }
}