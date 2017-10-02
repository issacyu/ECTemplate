using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECTemplate.WebUI.Models;
using ECTemplate.Domain.Entities;

namespace ECTemplate.WebUI.Models
{
    public class NavBarViewModel
    {
        public Cart Cart { get; set; }
        public CurrentUserViewModel User { get; set; }
        public IEnumerable<string> Categories { get; set; }
    }
}