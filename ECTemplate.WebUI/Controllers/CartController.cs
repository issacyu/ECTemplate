using System.Linq;
using System.Web.Mvc;
using ECTemplate.Domain.Abstract;
using ECTemplate.Domain.Entities;
using ECTemplate.WebUI.Models;
using ECTemplate.Domain.Concrete;

namespace ECTemplate.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductsRepository ProductRepository;
        private IOrderRepository OrderRepository;
        private IOrderDetailRepository OrderDetailRepository;

        public CartController(IProductsRepository repo, IOrderRepository proc, IOrderDetailRepository orderDetailRepo)
        {
            ProductRepository = repo;
            OrderRepository = proc;
            OrderDetailRepository = orderDetailRepo;
        }

        public PartialViewResult Index(Cart cart, string returnUrl)
        {
            return PartialView(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl, int quantity = 1)
        {
            Product product = ProductRepository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if(product != null)
            {
                cart.AddItem(product, quantity);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = ProductRepository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if(product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Checkout()
        {
            return View(new Addresses());
        }
        
        [HttpPost]
        public ViewResult Checkout(Cart cart, CurrentUserViewModel user, Addresses shippingDetails)
        {
            if (cart.Lines.Count() == 0)
                ModelState.AddModelError("", "Sorry, your cart is empty!");

            if (ModelState.IsValid)
            {
                Orders order = OrderRepository.AddOrder(user.UserId, cart, shippingDetails);
                OrderDetailRepository.AddOrderDetail(order.OrderId, cart);
                EmailSettings setting = new EmailSettings() { MailToAddress = user.UserEmail };
                EmailProcessor processor = new EmailProcessor(setting);
                processor.ProcessOrder(cart, shippingDetails);
                cart.Clear();

                return View("Completed");
            }
            else
                return View(shippingDetails);
        }
    }
}