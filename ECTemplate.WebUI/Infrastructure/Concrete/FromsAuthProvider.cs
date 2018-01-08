using System.Web.Security;
using System.Linq;
using ECTemplate.WebUI.Infrastructure.Abstract;
using ECTemplate.WebUI.Models;
using ECTemplate.Domain.Entities;
using ECTemplate.Domain.Abstract;

namespace ECTemplate.WebUI.Infrastructure.Concrete
{
    /// <summary>
    /// The concret class that peform the user login authentication.
    /// </summary>
    public class FromsAuthProvider : IAuthProvider
    {
        /// <summary>
        /// Gets or sets the account repository.
        /// </summary>
        IAccountRepository Repository { get; set; }

        /// <summary>
        /// An argument constructor that declares a dependency on the interfaces,
        /// which will lead Ninject to inject the dependency. 
        /// </summary>
        /// <param name="accountRepository">The IAccountRepository dependency.</param>
        public FromsAuthProvider(IAccountRepository accountRepository)
        {
            Repository = accountRepository;
        }

        /// <summary>
        /// Authenticate the users' login informations.
        /// </summary>
        /// <param name="model">The login information that enter by user.</param>
        /// <param name="userViewModel">The information of the current user.</param>
        /// <returns>True if the informations are correct.</returns>
        public bool Authenticate(LoginViewModel model, CurrentUserViewModel userViewModel)
        {
            Accounts account = Repository.Accounts
                .FirstOrDefault(m => model.EmailAddress == m.UserEmail && model.Password == m.UserPassword);

            if (account != null)
            {
                FormsAuthentication.SetAuthCookie(account.UserEmail, false);
                userViewModel.UserId = account.UserId;
                userViewModel.UserEmail = account.UserEmail;
                userViewModel.UserType = account.UserType;
                return true;
            }
            return false;
        }
    }
}