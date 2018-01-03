using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ECTemplate.Domain.Abstract;
using ECTemplate.WebUI.Models;
using ECTemplate.Domain.Entities;

namespace ECTemplate.WebUI.Controllers
{
    /// <summary>
    /// A controller that handles the navigation requests.
    /// </summary>
    public class NavController : Controller
    {
        /// <summary>
        /// An argument constructor that declares a dependency on the interfaces,
        /// which will lead Ninject to inject the dependency.  
        /// </summary>
        /// <param name="repo">The IProductsRepository instance.</param>
        public NavController(IProductsRepository repo)
        {
            repository = repo;
        }

        /// <summary>
        /// The IProductsRepository instance.
        /// </summary>
        private IProductsRepository repository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return PartialView("SideBar", categories);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cart"></param>
        /// <returns></returns>
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