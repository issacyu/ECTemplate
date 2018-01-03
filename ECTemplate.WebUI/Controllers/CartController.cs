using System.Linq;
using System.Web.Mvc;
using ECTemplate.Domain.Abstract;
using ECTemplate.Domain.Entities;
using ECTemplate.WebUI.Models;
using ECTemplate.Domain.Concrete;
using System;

namespace ECTemplate.WebUI.Controllers
{
    /// <summary>
    /// A controller that handles the cart requests.
    /// </summary>
    public class CartController : Controller
    {
        /// <summary>
        /// An argument constructor that declares a dependency on the interfaces,
        /// which will lead Ninject to inject the dependency. 
        /// </summary>
        /// <param name="repo">The IProductsRepository dependency.</param>
        /// <param name="proc">The IOrderRepository dependency.</param>
        /// <param name="orderDetailRepo">The IOrderDetailRepository dependency.</param>
        /// <param name="addressRepository">The IAddressRepository dependency.</param>
        /// <param name="accountRepository">The IAccountRepository dependency.</param>
        public CartController(IProductsRepository repo, IOrderRepository proc, IOrderDetailRepository orderDetailRepo, IAddressRepository addressRepository, IAccountRepository accountRepository)
        {
            ProductRepository = repo;
            OrderRepository = proc;
            OrderDetailRepository = orderDetailRepo;
            AddressRepository = addressRepository;
            AccountRepository = accountRepository;
        }

        /// <summary>
        /// The IProductsRepository instance.
        /// </summary>
        private IProductsRepository ProductRepository;

        /// <summary>
        /// The IOrderRepository instance.
        /// </summary>
        private IOrderRepository OrderRepository;

        /// <summary>
        /// The IOrderDetailRepository instance.
        /// </summary>
        private IOrderDetailRepository OrderDetailRepository;

        /// <summary>
        /// The IAddressRepository instance.
        /// </summary>
        private IAddressRepository AddressRepository;

        /// <summary>
        /// The IAccountRepository instance.
        /// </summary>
        private IAccountRepository AccountRepository;

        /// <summary>
        /// Request the shopping cart page.
        /// </summary>
        /// <param name="cart">The shopping cart.</param>
        /// <param name="returnUrl">Thr url of the previous page.</param>
        /// <returns>The shopping cart page.</returns>
        public PartialViewResult Index(Cart cart, string returnUrl)
        {
            return PartialView(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        /// <summary>
        /// Add the product into the shopping cart and return the shopping cart page.
        /// </summary>
        /// <param name="cart">The shopping cart.</param>
        /// <param name="productId">The product ID.</param>
        /// <param name="returnUrl">The url of the previous page.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns>The shopping cart page.</returns>
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

        /// <summary>
        /// Remove the product from the shopping cart.
        /// </summary>
        /// <param name="cart">The shopping cart.</param>
        /// <param name="productId">The product ID.</param>
        /// <param name="returnUrl">The url of the previous page.</param>
        /// <returns>The shopping cart page.</returns>
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

        /// <summary>
        /// Redirect to the shipping address page.
        /// </summary>
        /// <param name="currentUser">The infotmation of the current user.</param>
        /// <returns>The default shipping address.</returns>
        public ViewResult Checkout(CurrentUserViewModel currentUser)
        {
            Addresses address = AddressRepository.FindAddress(currentUser.UserId);

            if (address != null)
                return View(address);

            return View(new Addresses());
        }

        /// <summary>
        /// Check out the product in the shopping cart.
        /// </summary>
        /// <param name="cart">The shopping cart.</param>
        /// <param name="user">The infotmation of the current user.</param>
        /// <param name="shippingDetails">The shipping detail.</param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult Checkout(Cart cart, CurrentUserViewModel user, Addresses shippingDetails)
        {
            if (cart.Lines.Count() == 0)
                ModelState.AddModelError("", "Sorry, your cart is empty!");

            if (ModelState.IsValid)
            {
                Guid orderDetailId = Guid.NewGuid();
                Accounts account = AccountRepository.FindAccount(user.UserId);
                OrderRepository.AddOrder(user.UserId, cart, shippingDetails);
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