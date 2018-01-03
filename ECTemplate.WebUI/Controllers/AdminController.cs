using System.Web.Mvc;
using System.Web;
using System.Linq;
using ECTemplate.Domain.Abstract;
using ECTemplate.Domain.Entities;

namespace ECTemplate.WebUI.Controllers
{
    /// <summary>
    /// A controller that handles the admin requests.
    /// </summary>
    [Authorize]
    public class AdminController : Controller
    {
        /// <summary>
        /// The IProductRepository instance.
        /// </summary>
        private IProductsRepository repository;

        /// <summary>
        /// An argument constructor that declares a dependency on the interfaces,
        /// which will lead Ninject to inject the dependency.
        /// </summary>
        /// <param name="repo">The IProductsRepository dependency.</param>
        public AdminController(IProductsRepository repo)
        {
            repository = repo;
        }

        /// <summary>
        /// Request a list of products to the view.
        /// </summary>
        /// <returns>The product collection.</returns>
        public ActionResult Index()
        {
            return View(repository.Products);
        }

        /// <summary>
        /// Return a specific product to the view.
        /// </summary>
        /// <param name="productId">The product ID of the product that will return.</param>
        /// <returns></returns>
        public ViewResult Edit(int productId)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            return View(product);
        }

        /// <summary>
        /// Save the product into the database.
        /// </summary>
        /// <param name="product">The product needs to save.</param>
        /// <param name="image">The product image that needs to save.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete the product in the database.
        /// </summary>
        /// <param name="productId">The product ID of the product that needs to delete.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Return the edit product page for creating the product.
        /// </summary>
        /// <returns></returns>
        public ViewResult Create()
        {
            return View("Edit", new Product());
        }
    }
}