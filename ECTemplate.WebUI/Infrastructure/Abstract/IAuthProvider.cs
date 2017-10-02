using ECTemplate.WebUI.Models;


namespace ECTemplate.WebUI.Infrastructure.Abstract
{
    public interface IAuthProvider
    {
        bool Authenticate(LoginViewModel model, CurrentUserViewModel userViewModel);
    }
}
