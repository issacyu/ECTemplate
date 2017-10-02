using System.Web.Mvc;
using System.Web;
using System.Linq;
using ECTemplate.Domain.Abstract;
using ECTemplate.Domain.Entities;

namespace ECTemplate.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductsRepository repository;

        public AdminController(IProductsRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Edit(int productId)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase image = null)
        {
            if(ModelState.IsValid)
            {
                if(image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                //there is something wrong with the data values
                return View(product);
            }
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deleteProduct = repository.DeleteProduct(productId);
            if(deleteProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deleteProduct.Name);
            }
            return RedirectToAction("Index");
        }

        public ViewResult Create()
        {
            return View("Edit", new Product());
        }
    }
}