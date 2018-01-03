using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECTemplate.Domain.Abstract;
using ECTemplate.Domain.Entities;
using ECTemplate.WebUI.Models;

namespace ECTemplate.WebUI.Controllers
{
    /// <summary>
    /// A controller that handles the product requests.
    /// </summary>
    public class ProductController : Controller
    {
        /// <summary>
        /// The IProductsRepository instance.
        /// </summary>
        private IProductsRepository repository;

        /// <summary>
        /// The default size of the products that display on the page.
        /// </summary>
        public int PageSize = 4;

        /// <summary>
        /// An argument constructor that declares a dependency on the interfaces,
        /// which will lead Ninject to inject the dependency.
        /// </summary>
        /// <param name="productRepository">The IProductsRepository dependency.</param>

        public ProductController(IProductsRepository productRepository)
        {
            repository = productRepository;
        }

        /// <summary>
        /// Return the product in the specific category and page.
        /// </summary>
        /// <param name="category">The requested category.</param>
        /// <param name="page">The requested page.</param>
        /// <returns>The products.</returns>
        public PartialViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                    repository.Products.Count() :
                    repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };
            return PartialView(model);
        }

        /// <summary>
        /// Return the product in the specific category and page.
        /// </summary>
        /// <param name="category">The requested category.</param>
        /// <param name="page">The requested page.</param>
        /// <returns>The products.</returns>
        public ActionResult Category(string category, int page = 1)
        {
            CategoryViewModel viewModel = new CategoryViewModel
            {
                Category = category,
                Page = page
            };
            return View(viewModel);
        }

        /// <summary>
        /// Return the product image.
        /// </summary>
        /// <param name="productId">The product ID of the image.</param>
        /// <returns>The image.</returns>
        public FileContentResult GetImage(int productId)
        {
            Product prod = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (prod != null)
                return File(prod.ImageData, prod.ImageMimeType);
            else
                return null;
        }

        /// <summary>
        /// Return the product detail page.
        /// </summary>
        /// <param name="productId">The product ID of the product detail.</param>
        /// <returns>The product detail.</returns>
        public ActionResult ProductDetail(int productId)
        {
            Product prod = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            return View(prod);
        }

        /// <summary>
        /// Return the quick view of the product.
        /// </summary>
        /// <param name="productId">The product ID of the quick view.</param>
        /// <returns>The quick view.</returns>
        public ActionResult QuickView(int productId)
        {
            Product prod = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            return PartialView(prod);
        }
    }
}