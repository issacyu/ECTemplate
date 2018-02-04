/// <summary>
/// The view model that uses to bind to the view that cantains the current user info.
/// </summary>
namespace ECTemplate.WebUI.Models
{
    public class CurrentUserViewModel
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user email.
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// Gets or sets the user type.
        /// It can be admin or customer.
        /// </summary>
        public string UserType { get; set; }
    }
}