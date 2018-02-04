using ECTemplate.Domain.Entities;

/// <summary>
/// The view model that uses to bind to the view that cantains the summary info.
/// </summary>
namespace ECTemplate.WebUI.Models
{
    public class SummaryViewModel
    {
        /// <summary>
        /// Gets or sets the shopping cart.
        /// </summary>
        public Cart Cart { get; set; }

        /// <summary>
        /// Gets or sets the current user.
        /// </summary>
        public CurrentUserViewModel User { get; set; }
    }
}