using System;
using System.Web.Mvc;
using System.Web.Security;
using ECTemplate.WebUI.Infrastructure.Abstract;
using ECTemplate.WebUI.Models;
using ECTemplate.Domain.Concrete;
using ECTemplate.Domain.Entities;
using System.Collections.Generic;

namespace ECTemplate.WebUI.Controllers
{
    /// <summary>
    /// A controller that handle the requests for the account.
    /// </summary>
    public class AccountController : Controller
    {
        private IAuthProvider AuthProvider { get; set; }

        private EFAccountRepository AccountRepository { get; set; }

        private EFAddressRepository AddressRepository { get; set; }

        private EFOrderRepository OrderRepository { get; set; }

        private EFOrderDetailRepository OrderDetailRepository { get; set; }

        private EFProductRepository ProductRepository { get; set; }

        public AccountController(IAuthProvider auth)
        {
            AuthProvider = auth;
            AccountRepository = new EFAccountRepository();
            AddressRepository = new EFAddressRepository();
            OrderRepository = new EFOrderRepository();
            OrderDetailRepository = new EFOrderDetailRepository();
            ProductRepository = new EFProductRepository();
        }

        /// <summary>
        /// Request the register page.
        /// </summary>
        /// <returns></returns>
        public PartialViewResult Register()
        {
            return PartialView();
        }

        /// <summary>
        /// Create a new account and save the information into the database.
        /// </summary>
        /// <param name="model">The information of the new account.</param>
        /// <returns>A page with successful registered message.</returns>
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Register", "~/Views/Shared/_AdminLayout.cshtml");

            Guid addressId = Guid.NewGuid();
            Addresses newAddress = new Addresses()
            {
                AddressId = addressId,
                ShippingFirstName = model.UserFirstName,
                ShippingLastName = model.UserLastName,
                ShippingAddress = model.ShippingAddress,
                ShippingAddress2 = model.ShippingAddress2,
                ShippingCity = model.ShippingCity,
                ShippingState = model.ShippingState,
                ShippingZip = model.ShippingZip,
                ShippingCountry = model.ShippingCountry,
                ShippingPhone = model.ShippingPhone,
            };

            Accounts newAccount = new Accounts
            {
                UserFirstName = model.UserFirstName,
                UserLastName = model.UserLastName,
                UserEmail = model.UserEmail,
                UserPassword = model.UserPassword,
                AddressId = addressId,
                UserType = "User",
                Address = newAddress
            };

            AccountRepository.AddAccount(newAccount);
            return View("Registered");
        }

        /// <summary>
        /// Request the login page.
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Validate the user name and password.
        /// </summary>
        /// <param name="model">The login information.</param>
        /// <param name="userViewModel">The current user information.</param>
        /// <param name="returnUrl">The url of the previous page.</param>
        /// <returns>The main page.</returns>
        [HttpPost]
        public ActionResult Login(LoginViewModel model, CurrentUserViewModel userViewModel, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                if(AuthProvider.Authenticate(model, userViewModel))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Main"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// Log out the current user.
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Main");
        }

        /// <summary>
        /// Request the user setting page.
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit()
        {
            return View();
        }

        /// <summary>
        /// Request the change password page.
        /// </summary>
        /// <returns></returns>
        public PartialViewResult ChangePassword()
        {
            return PartialView();
        }

        /// <summary>
        /// Update the password and save into the database.
        /// </summary>
        /// <param name="currentUser">The information of the current user.</param>
        /// <param name="changePassword">The current and the new passwords.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangePassword(CurrentUserViewModel currentUser, ChangePasswordViewModel changePassword)
        {
            Accounts account = AccountRepository.FindAccount(currentUser.UserId);

            if(!string.Equals(account.UserPassword, changePassword.CurrentPassword))
                ModelState.AddModelError("", "The password that you enter doesn't match the current password.");

            if (!string.Equals(changePassword.NewPassword, changePassword.ConfirmPassword))
                ModelState.AddModelError("", "The new password doesn't match the confirm password.");

            if (!ModelState.IsValid)
                return View();

            account.UserPassword = changePassword.NewPassword;
            AccountRepository.UpdateAccount(account);

            return RedirectToAction("Edit");
        }

        /// <summary>
        /// Request the shipping address page.
        /// </summary>
        /// <param name="currentUser">The information of the current user.</param>
        /// <returns>The shipping address page with current shipping address.</returns>
        public PartialViewResult UpdateShippingAddress(CurrentUserViewModel currentUser)
        {
            Addresses address = AddressRepository.FindAddress(currentUser.UserId);

            if (address != null)
            {
                AddressViewModel model = new AddressViewModel()
                {
                    FirstName = address.ShippingFirstName,
                    LastName = address.ShippingLastName,
                    Address = address.ShippingAddress,
                    Address2 = address.ShippingAddress2,
                    City = address.ShippingCity,
                    State = address.ShippingState,
                    Zip = address.ShippingZip,
                    Country = address.ShippingCountry,
                    Phone = address.ShippingPhone
                };
                return PartialView(model);
            }

            return PartialView(new AddressViewModel());
        }

        /// <summary>
        /// Update the shipping address and save it into the database.
        /// </summary>
        /// <param name="currentUser">The information of the current user.</param>
        /// <param name="shippingAddress">The new shipping address.</param>
        /// <returns>The shipping address page.</returns>
        [HttpPost]
        public ActionResult UpdateShippingAddress(CurrentUserViewModel currentUser, AddressViewModel shippingAddress)
        {
            if (!ModelState.IsValid)
                return View();

            Addresses address = new Addresses
            {
                ShippingFirstName = shippingAddress.FirstName,
                ShippingLastName = shippingAddress.LastName,
                ShippingAddress = shippingAddress.Address,
                ShippingAddress2 = shippingAddress.Address2,
                ShippingCity = shippingAddress.City,
                ShippingState = shippingAddress.State,
                ShippingZip = shippingAddress.Zip,
                ShippingCountry = shippingAddress.Country,
                ShippingPhone = shippingAddress.Phone
            };

            AddressRepository.UpdateShippingAddress(currentUser.UserId, address);
            return View();
        }

        /// <summary>
        /// Request the order history page with a list of order history.
        /// </summary>
        /// <param name="currentUser">The information of the current user.</param>
        /// <returns>The order history page.</returns>
        public PartialViewResult OrderHistory(CurrentUserViewModel currentUser)
        {
            return PartialView(OrderRepository.FindOrder(currentUser.UserId));
        }

        /// <summary>
        /// Display the order history view.
        /// </summary>
        /// <returns>The view a list of order histories.</returns>
        [HttpPost]
        public ActionResult OrderHistory()
        {
            return View();
        }

        /// <summary>
        /// Request the order detail page.
        /// </summary>
        /// <param name="order">The order that needs to view the detail.</param>
        /// <returns>The order detail page with detail of an order.</returns>
        public PartialViewResult OrderDetail(Orders order)
        {
            OrderDetailViewModel OrderDetail = new OrderDetailViewModel();
            OrderDetail.OrderDetails = OrderDetailRepository.FindOrderDetails(order.OrderId) as List<OrderDetails>;
            OrderDetail.Order = order; 
            foreach(OrderDetails od in OrderDetail.OrderDetails)
            {
                OrderDetail.ProductDetails.Add(od.DetailProductId, ProductRepository.FindProduct(od.DetailProductId).Name);
            }

            return PartialView(OrderDetail);
        }

        /// <summary>
        /// Display the order detail view.
        /// </summary>
        /// <param name="currentUser">The current user.</param>
        /// <returns>The view with the order detail of an order.</returns>
        [HttpPost]
        public ActionResult OrderDetail(CurrentUserViewModel currentUser)
        {
            return View();
        }
    }
}