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
    public class ProductController : Controller
    {
        private IProductsRepository repository;
        public int PageSize = 4;

        public ProductController(IProductsRepository productRepository)
        {
            repository = productRepository;
        }

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

        public ActionResult Category(string category, int page = 1)
        {
            CategoryViewModel viewModel = new CategoryViewModel
            {
                Category = category,
                Page = page
            };
            return View(viewModel);
        }

        public FileContentResult GetImage(int productId)
        {
            Product prod = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (prod != null)
                return File(prod.ImageData, prod.ImageMimeType);
            else
                return null;
        }

        public ActionResult ProductDetail(int productId)
        {
            Product prod = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            return View(prod);
        }

        public ActionResult QuickView(int productId)
        {
            Product prod = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            return PartialView(prod);
        }
    }
}