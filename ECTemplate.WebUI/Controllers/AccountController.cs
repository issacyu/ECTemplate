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
            int userId = LookUpRepository.FindLookUp().UserId;
            int addressId = LookUpRepository.FindLookUp().AddressId;

            Accounts account = new Accounts()
            {
                UserId = userId,
                UserFirstName = model.UserFirstName,
                UserLastName = model.UserLastName,
                UserEmail = model.UserEmail,
                UserPassword = model.UserPassword,
                UserAddressId = addressId
            };

            Addresses address = new Addresses()
            {
                AddressId = addressId,
                UserId = userId,
                ShippingFirstName = model.UserFirstName,
                ShippingLastName = model.UserLastName,
                ShippingAddress = model.ShippingAddress,
                ShippingAddress2 = model.ShippingAddress2,
                ShippingCity = model.ShippingCity,
                ShippingState = model.ShippingState,
                ShippingZip = model.ShippingZip,
                ShippingCountry = model.ShippingCountry,
                ShippingPhone = model.ShippingPhone
            };

            AddressRepository.AddShippingAddress(address);
            AccountRepository.AddAccount(account);
            LookUpRepository.UpdateLookUp();

            return Redirect(Url.Action("List", "Product"));
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

        //[HttpPost]
        //public ActionResult Edit(RegisterViewModel model)
        //{
        //    Accounts account = new Accounts()
        //    {
        //        UserId = model.UserId,
        //        UserFirstName = model.UserFirstName,
        //        UserLastName = model.UserLastName,
        //        UserEmail = model.UserEmail,
        //        UserPassword = model.UserPassword
        //    };

        //    AccountRepository.UpdateAccount(account);
        //    return RedirectToAction("Index", "Main");
        //}

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

            //return View();

            return RedirectToAction("Edit");
        }

        public PartialViewResult UpdateShippingAddress()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult UpdateShippingAddress(CurrentUserViewModel currentUser, AddressViewModel shippingAddress)
        {
            if (!ModelState.IsValid)
                return View();

            Addresses address = AddressRepository.FindAddress(currentUser.UserId);
            Accounts account = AccountRepository.FindAccount(currentUser.UserId);
            if (address == null)
            {
                address = new Addresses()
                {
                    AddressId = account.UserAddressId,
                    UserId = account.UserId
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