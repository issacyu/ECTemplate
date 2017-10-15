using System.Web.Security;
using System.Linq;
using ECTemplate.WebUI.Infrastructure.Abstract;
using ECTemplate.WebUI.Models;
using ECTemplate.Domain.Entities;
using ECTemplate.Domain.Abstract;

namespace ECTemplate.WebUI.Infrastructure.Concrete
{
    public class FromsAuthProvider : IAuthProvider
    {
        IAccountRepository repository;

        public FromsAuthProvider(IAccountRepository accountRepository)
        {
            repository = accountRepository;
        }

        public bool Authenticate(LoginViewModel model, CurrentUserViewModel userViewModel)
        {
            Accounts account = repository.Accounts
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