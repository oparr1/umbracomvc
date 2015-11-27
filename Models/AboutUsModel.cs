using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace MvcUmbraco.Models
{
    public class AboutUsModel : RenderModel
    {
        public AboutUsModel(IPublishedContent content, CultureInfo culture) : base (content, culture )
        {
        }

        public AboutUsModel(IPublishedContent content) : base(content)
        {
        }

        public string BodyText { get; set; }
        public string QuoteOne { get; set; }
        public string QuoteTwo { get; set; }
    }
}