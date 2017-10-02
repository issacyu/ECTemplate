using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ECTemplate.Domain.Abstract;
using ECTemplate.WebUI.Models;
using ECTemplate.Domain.Entities;

namespace ECTemplate.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductsRepository repository;

        public NavController(IProductsRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return PartialView("SideBar", categories);
        }

        public PartialViewResult Navigation(CurrentUserViewModel user, Cart cart)
        {
            IEnumerable<string> categories = repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return PartialView("Navigation", new NavBarViewModel
            {
                User = user,
                Cart = cart,
                Categories = categories
            });
        }
    }
}