using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECTemplate.Domain.Entities;

namespace ECTemplate.WebUI.Models
{
    public class SummaryViewModel
    {
        public Cart Cart { get; set; }
        public CurrentUserViewModel User { get; set; }
    }
}