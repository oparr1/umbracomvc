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
    public class ContactModel
    {
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(20, ErrorMessage = "Must be between 2 and 50 characters", MinimumLength = 2)]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(20, ErrorMessage = "Must be between 2 and 20 characters", MinimumLength = 2)]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        [Display(Name = "Email:")]
        public string CEmail { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [StringLength(500, ErrorMessage = "Must be between 10 and 500 characters", MinimumLength = 10)]
        [Display(Name = "Message:")]
        public string Message { get; set; }
    }

    public class ContactInfoModel : RenderModel
    {
        public ContactInfoModel(IPublishedContent content, CultureInfo culture) : base (content, culture )
        {
        }

        public ContactInfoModel(IPublishedContent content) : base(content)
        {
        }

        public string Address { get; set; }
        public string BodyText { get; set; }
    }
}