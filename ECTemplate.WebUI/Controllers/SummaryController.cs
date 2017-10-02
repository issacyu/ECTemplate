using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECTemplate.WebUI.Models;
using ECTemplate.Domain.Entities;

namespace ECTemplate.WebUI.Controllers
{
    public class SummaryController : Controller
    {

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