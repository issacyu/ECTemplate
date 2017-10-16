using System;
using System.Web.Mvc;
using System.Web.Security;
using ECTemplate.WebUI.Infrastructure.Abstract;
using ECTemplate.WebUI.Models;
using ECTemplate.Domain.Concrete;
using ECTemplate.Domain.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ECTemplate.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private IAuthProvider AuthProvider { get; set; }

        private EFAccountRepository AccountRepository { get; set; }

        private EFAddressRepository AddressRepository { get; set; }

        private EFLookUpRepository LookUpRepository { get; set; }

        private EFOrderRepository OrderRepository { get; set; }

        private EFOrderDetailRepository OrderDetailRepository { get; set; }

        private EFProductRepository ProductRepository { get; set; }

        public AccountController(IAuthProvider auth)
        {
            AuthProvider = auth;
            AccountRepository = new EFAccountRepository();
            AddressRepository = new EFAddressRepository();
            LookUpRepository = new EFLookUpRepository();
            OrderRepository = new EFOrderRepository();
            OrderDetailRepository = new EFOrderDetailRepository();
            ProductRepository = new EFProductRepository();
        }

        public PartialViewResult Register()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Register", "~/Views/Shared/_AdminLayout.cshtml");

            string addressId = Guid.NewGuid().ToString();
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
                UserFirstName = "a",
                UserLastName = "a",
                UserEmail = model.UserEmail,
                UserPassword = model.UserPassword,
                AddressId = addressId,
                UserType = "User",
                Address = newAddress
            };
            AccountRepository.AddAccount(newAccount);
            return View("Registered");
        }

        public ActionResult Login()
        {
            return View();
        }

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

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Main");
        }

        public ActionResult Edit()
        {
            return View();
        }

        public PartialViewResult ChangePassword()
        {
            return PartialView();
        }

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

        [HttpPost]
        public ActionResult UpdateShippingAddress(CurrentUserViewModel currentUser, AddressViewModel shippingAddress)
        {
            if (!ModelState.IsValid)
                return View();

            Addresses address = AddressRepository.FindAddress(currentUser.UserId);
            if (address == null)
            {
                Accounts account = AccountRepository.FindAccount(currentUser.UserId);
                address = new Addresses()
                {
                    AddressId = account.AddressId,
                    //UserId = account.UserId
                };
            }
            address.ShippingFirstName = shippingAddress.FirstName;
            address.ShippingLastName = shippingAddress.LastName;
            address.ShippingAddress = shippingAddress.Address;
            address.ShippingAddress2 = shippingAddress.Address2;
            address.ShippingCity = shippingAddress.City;
            address.ShippingState = shippingAddress.State;
            address.ShippingZip = shippingAddress.Zip;
            address.ShippingCountry = shippingAddress.Country;
            address.ShippingPhone = shippingAddress.Phone;

            AddressRepository.UpdateShippingAddress(address);
            return View();
        }

        public PartialViewResult OrderHistory(CurrentUserViewModel currentUser)
        {
            return PartialView(OrderRepository.GetOrder(currentUser.UserId));
        }

        [HttpPost]
        public ActionResult OrderHistory()
        {
            return View();
        }

        public PartialViewResult OrderDetail(Orders order)
        {
            OrderDetailViewModel OrderDetail = new OrderDetailViewModel();
            OrderDetail.OrderDetails = OrderDetailRepository.GetOrderDetails(order.OrderId) as List<OrderDetails>;
            OrderDetail.Order = order; 
            foreach(OrderDetails od in OrderDetail.OrderDetails)
            {
                OrderDetail.ProductDetails.Add(od.DetailProductId, ProductRepository.GetProduct(od.DetailProductId).Name);
            }

            return PartialView(OrderDetail);
        }

        [HttpPost]
        public ActionResult OrderDetail(CurrentUserViewModel currentUser)
        {
            return View();
        }
    }
}