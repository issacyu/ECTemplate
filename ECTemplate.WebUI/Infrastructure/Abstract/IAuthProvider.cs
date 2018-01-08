using ECTemplate.WebUI.Models;

namespace ECTemplate.WebUI.Infrastructure.Abstract
{
    /// <summary>
    /// The class that inherit from the IAuthProvider can perform the authentication check
    /// when users try to login to their account.
    /// </summary>
    public interface IAuthProvider
    {
        /// <summary>
        /// Authenticate the users' login informations.
        /// </summary>
        /// <param name="model">The login information that enter by user.</param>
        /// <param name="userViewModel">The information of the current user.</param>
        /// <returns>True if the informations are correct.</returns>
        bool Authenticate(LoginViewModel model, CurrentUserViewModel userViewModel);
    }
}
