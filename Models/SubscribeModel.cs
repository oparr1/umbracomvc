using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace MvcUmbraco.Models
{
    public class SubscribeModel
    {
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%-]+@[a-zA-Z0-9._%-]+\.[a-zA-Z]{2,4}\s*$", ErrorMessage = "Must be a valid email e.g - email@net.net")]
        [Display(Name = "Email:")]
        public string Email { get; set; } // Has to be Email to work with campaign monitor different name to Email
    }

    public class SubscribeThanksModel : RenderModel
    {
        public SubscribeThanksModel(IPublishedContent content, CultureInfo culture)
            : base(content, culture)
        {
        }

        public SubscribeThanksModel(IPublishedContent content)
            : base(content)
        {
        }
        public string BodyText { get; set; }
    }
}